using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;

namespace Verzekeringen
{
	delegate void CorrigeerVoorInflatie (object Sender, InflatieEventargs args);

	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	/// 

	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | 
		 AttributeTargets.Struct, AllowMultiple=true)]
	public class DeveloperInfo: System.Attribute
	{
		private string naam;
		public DeveloperInfo(string name)
		{
			naam = name;
		}

		public string Name
		{
			get
			{
				return naam;
			}
		}
	}

	public class VerzMaatschappij: IAfdrukbaar
	{

		public void Reflect()
		{
			MemberInfo typeInfo;
			
			typeInfo = typeof(Verzekering);
			
			object[] attrs = typeInfo.GetCustomAttributes(false); 			

			for(int i = 0 ; i <= attrs.GetUpperBound(0); i++)
			{
				DeveloperInfo d = attrs[i] as DeveloperInfo;
				if (d != null)
				{
					Console.WriteLine (((DeveloperInfo)attrs[i]).Name);
				}
				else
				{
					Console.WriteLine("da kannie {0} is een {1}", attrs[i].ToString(), attrs[i].GetType());
				}
			}
		}

		static VerzMaatschappij vm;
		event CorrigeerVoorInflatie erIsInflatie;

		private VerzMaatschappij()
		{
			//intNrOfVMs++;
			//if (intNrOfVMs > 1)
			//{
			//	throw new TeveelMaatschappijenException("Te veel maatschappijen!");
			//}
		}

		public static VerzMaatschappij GeefVM()
		{
			if (vm == null)
			{
				vm = new VerzMaatschappij();
			}
			return vm;
		}
		Hashtable hstVerz  = new Hashtable();

		public void GroeiMee(long polisnummer)
		{
			erIsInflatie += new CorrigeerVoorInflatie(GetVerz(polisnummer).InflatieCorrectie);
		}

		public void GroeiNietMee(long polisnummer)
		{
			erIsInflatie -= new CorrigeerVoorInflatie(GetVerz(polisnummer).InflatieCorrectie);
		}

		public void StartNieuwJaar (int inflatie)
		{
			InflatieEventargs i = new InflatieEventargs(inflatie);
			if (erIsInflatie != null)
			{
				erIsInflatie(this, i);
			}
		}

		public long  OpenVerz()
		{			
			Verzekering x  = new Verzekering();			

			//toekenning van een object value x aan een object key polisnummer
			hstVerz[x.PolisNummer] = x;

			return x.PolisNummer;
		}

		public long  OpenVerz(VerzType penuType, float pfltMaxBedrag)
		{			
			Verzekering x  = new Verzekering(penuType, pfltMaxBedrag);			

			//toekenning van een object value x aan een object key polisnummer
			hstVerz[x.PolisNummer] = x;

			return x.PolisNummer;
		}

		
		public void VerzOpheffen(long plngPolisNr)
		{
			// Verzekering q is private
			hstVerz.Remove(plngPolisNr);
		}
		
		public void SchadeMelden(long plngPolisNr,bool pblnVerwijtbaar, 
			float pfltKosten, string pstrOorzaak)
		{
			Verzekering x = GetVerz(plngPolisNr);
			
			if (pblnVerwijtbaar)
			{

				if (pstrOorzaak == "")
				{
					x.MeldVerwijtbareSchade(pfltKosten);
				}
				else
				{
					x.MeldVerwijtbareSchade(pfltKosten,pstrOorzaak);
				}
			}
			else
			{
				x.MeldNietVerwijtbareSchade(pfltKosten, pstrOorzaak);				
			}
		}

		[Conditional ("DEBUG_VERZEKERING")]
		public void DumpNaarScherm()
		{			
			DrukAf();
		}

		public void DrukAf()
		{
			foreach (Verzekering oVerz in hstVerz.Values)
			{
				IAfdrukbaar iFace = oVerz as IAfdrukbaar;
				if (iFace == null)
				{
					Console.WriteLine("niet afdrukbaar");
				}
				else
				{
					iFace.DrukAf();
				}
			}
		}

		public void DrukAfSchade(long PolisNummer, int SchadeGeval)
		{
			Verzekering oVerz;

			foreach (object oObj in hstVerz.Values)
			{				
				if (oObj is Verzekering)												
				{
					oVerz = (Verzekering)oObj;

					if (PolisNummer == oVerz.PolisNummer)
					{
						oVerz[SchadeGeval].DrukAf();
					}
				}
			}
		}

		public void WijzigMaxBedrag(long plngPolisNr, float MaxBedrag)
		{
			//ophalen van de object value
			GetVerz(plngPolisNr).MaximaalBedrag = MaxBedrag;
		}
		
		private Verzekering GetVerz(long plngPolisNr)
		{
			//ophalen van de object value
			return (Verzekering) hstVerz[plngPolisNr];
		}

	}
}
