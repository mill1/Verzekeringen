using System;
using System.Collections;

namespace Verzekeringen
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	abstract class Schade: IAfdrukbaar
	{					
		readonly DateTime datDatum;
		readonly float fltKosten;
		readonly string strOorzaak;
	
		public Schade(float pfltKosten) : this("onbekend", pfltKosten){}
		public Schade(string pstrOorzaak, float pfltKosten)
		{	
			strOorzaak = pstrOorzaak;
			fltKosten = pfltKosten;
			datDatum = DateTime.Now;
		}

		public string Oorzaak()
		{
			return strOorzaak;
		}
		public float Kosten()
		{
			return fltKosten;
		}
		public virtual float Vergoeding()
		{
			return fltKosten;
		}
		public DateTime Datum()
		{
			return datDatum;
		}
		public void DrukAf()
		{
			Console.WriteLine ("Schade {0}, {1}, verg.: {2}, datum: {3}", this.GetType(), this.Oorzaak(), this.Vergoeding(), this.Datum()); 
		}
	}
	
	class NietVerwSchade: Schade
	{
		public NietVerwSchade(string pstrOorzaak, float pfltKosten):base(pstrOorzaak,pfltKosten) {}
	}

	class VerwSchade: Schade
	{
		public VerwSchade(float pfltKosten):base(pfltKosten) {}
		public VerwSchade(string pstrOorzaak, float pfltKosten):base(pstrOorzaak,pfltKosten) {}

		public override float Vergoeding()
		{
			return base.Kosten()/ 2f;
		}
	}
}
