using System;
using System.Collections;


public enum VerzType{Auto, Boot}

namespace Verzekeringen
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	/// 

	public enum Stoplicht{Rood, Oranje, Groen}

	[DeveloperInfo("Emiel")]
	public class Verzekering:IAfdrukbaar
	{
		private VerzType enuType;
		private float fltMaxBedrag;
		private long lngPolisNr;
		private Queue q = new Queue();
		//Initialiseren van deze static gebeurt maar 1 keer!
		static long  mlngPolisNr = 90000000;

		//Constuctors:
		internal Verzekering(): this(VerzType.Auto, 1000)
		{
		}
		internal Verzekering(VerzType penuType, float pfltMaxBedrag)
		{
			enuType = penuType;
			fltMaxBedrag = pfltMaxBedrag;
			lngPolisNr = mlngPolisNr++;
		}

		public void MeldNietVerwijtbareSchade(float pfltKosten, string pstrOorzaak)
		{
			if (this.MaximaalBedrag < pfltKosten)
			{
				throw new SchadeTeHoogException("schade te hoog");
			}
			NietVerwSchade oNVS = new  NietVerwSchade(pstrOorzaak,pfltKosten);
			q.Enqueue(oNVS);
		}

		public void InflatieCorrectie (object Sender, InflatieEventargs args)
		{
			this.MaximaalBedrag = (((float)args.Inflatie/100) + 1)  * this.MaximaalBedrag;
		}

		public void MeldVerwijtbareSchade(float pfltKosten)
		{
			if (this.MaximaalBedrag < pfltKosten)
			{
				throw new SchadeTeHoogException("schade te hoog");
			}
			VerwSchade oNVS = new VerwSchade(pfltKosten);
			q.Enqueue(oNVS);
		}		
		
		public void MeldVerwijtbareSchade(float pfltKosten, string pstrOorzaak)
		{
			if (this.MaximaalBedrag < pfltKosten)
			{
				throw new SchadeTeHoogException("schade te hoog");
			}
			VerwSchade oVS = new  VerwSchade(pstrOorzaak, pfltKosten);
			q.Enqueue(oVS);
		}
		
		public long PolisNummer
		{
			get {return lngPolisNr;}
		}
		public VerzType VerzekeringType
		{
			get {return enuType;}
		}
		public float MaximaalBedrag
		{
			get{return fltMaxBedrag;}
			set{ fltMaxBedrag = value;}
		}

		internal Schade this[int index]
		{
			get {
				
				if (index > q.Count-1)
				{
					throw new SchadeOutOfBound("Slecht " + q.Count + 
						" schadegevallen bekend");
				}

				IEnumerator enu = q.GetEnumerator();

				for (int i = 0; i <= index ; i++)
				{
					enu.MoveNext();
				}
				return (Schade)enu.Current;
			}
		}

		public int SchadeGevallen
		{
			get {return q.Count;}
		}

		public float Premie()
		{
			return ((1f/100) + (q.Count/1000f)) * fltMaxBedrag;
		}

		public void DrukAf()
		{
			VerwSchade oVS = new VerwSchade(111f);
			
			Console.WriteLine ("");
			Console.WriteLine ("VerzekeringsType: {0}", enuType); 
			Console.WriteLine ("Maximaal bedrag: Eur {0}", fltMaxBedrag); 
			Console.WriteLine ("Polis Nr: {0}", lngPolisNr); 
			Console.WriteLine ("Premie: {0}", Premie());
 
			foreach(Schade s in q){
				s.DrukAf();
			}
		}
	}
}
