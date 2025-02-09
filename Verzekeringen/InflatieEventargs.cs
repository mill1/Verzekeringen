using System;

namespace Verzekeringen
{
	/// <summary>
	/// Summary description for InflatieEventargs.
	/// </summary>
	public class InflatieEventargs: EventArgs
	{
		private int inflatie;
		public InflatieEventargs(int inflatie)
		{
			this.inflatie = inflatie;
		}

		public int Inflatie
		{
			get
			{
				return inflatie;
			}
		}
	}
}
