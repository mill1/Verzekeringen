using System;

namespace Verzekeringen
{
	/// <summary>
	/// 
	/// </summary>
	/// 
	public class Breuk
	{
		public Breuk() : this (0,1){}		
		public Breuk(int pTeller, int pNoemer)
		{
			Teller = pTeller;
			Noemer = pNoemer;
		}
		public int Teller, Noemer;


//		public static bool operator==(Breuk Eerste, Breuk Tweede)
//		{
//			return ((Eerste.Teller * Tweede.Noemer) == 
//					(Eerste.Noemer * Tweede.Teller))?true:false ;
//		}
//		public static bool operator!=(Breuk Eerste, Breuk Tweede)
//		{
//			return ((Eerste.Teller * Tweede.Noemer) != 
//					(Eerste.Noemer * Tweede.Teller))?true:false ;
//		}



		public static bool operator>(Breuk Eerste, Breuk Tweede)
		{
			return ((Eerste.Teller * Tweede.Noemer) > 
					(Eerste.Noemer * Tweede.Teller))?true:false ;
		}
		public static bool operator>=(Breuk Eerste, Breuk Tweede)
		{
			return ((Eerste.Teller * Tweede.Noemer) >= 
					(Eerste.Noemer * Tweede.Teller))?true:false ;
		}
		public static bool operator<(Breuk Eerste, Breuk Tweede)
		{
			return ((Eerste.Teller * Tweede.Noemer) < 
					(Eerste.Noemer * Tweede.Teller))?true:false ;
		}
		public static bool operator<=(Breuk Eerste, Breuk Tweede)
		{
			return ((Eerste.Teller * Tweede.Noemer) <= 
					(Eerste.Noemer * Tweede.Teller))?true:false ;
		}

		public static Breuk operator+(Breuk Eerste, Breuk Tweede)
		{
			int intTeller = 0;
			int intNoemer = 0;
			float f = 0;

			intNoemer = Eerste.Noemer * Tweede.Noemer;
			intTeller = ((intNoemer/Eerste.Noemer) * Eerste.Teller) + 
						((intNoemer/Tweede.Noemer) * Tweede.Teller);

			f = ((float)intNoemer)/intTeller;

			if (f == (intNoemer/intTeller))
			{
				intTeller = intTeller/(int)f;
				intNoemer = intNoemer/(int)f;
			}

			return new Breuk(intTeller,intNoemer);
		}

		public static Breuk operator-(Breuk Eerste, Breuk Tweede)
		{
			int intTeller = 0;
			int intNoemer = 0;
			float f = 0;

			intNoemer = Eerste.Noemer * Tweede.Noemer;
			intTeller = ((intNoemer/Eerste.Noemer) * Eerste.Teller) - 
				((intNoemer/Tweede.Noemer) * Tweede.Teller);

			f = ((float)intNoemer)/intTeller;

			if (f == (intNoemer/intTeller))
			{
				intTeller = intTeller/(int)f;
				intNoemer = intNoemer/(int)f;
			}

			return new Breuk(intTeller,intNoemer);
		}

		public static Breuk operator++(Breuk Eerste)
		{
			return (Eerste + new Breuk(1,1));
//			return new Breuk(Eerste.Noemer + Eerste.Teller,Eerste.Noemer);
		}
	}
}
