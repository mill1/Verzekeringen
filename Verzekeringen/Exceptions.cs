using System;

namespace Verzekeringen
{
	/// <summary>
	/// Summary description for SchadeTeHoogException.
	/// </summary>
	public class SchadeTeHoogException:Exception
	{
		private string message;

		public SchadeTeHoogException(string Message)
		{
			message = Message;
		}

		public string GetMessage()
		{
			return message;
		}
	}

	public class TeveelMaatschappijenException:Exception
	{
		private string message;

		public TeveelMaatschappijenException(string Message)
		{
			message = Message;
		}

		public string GetMessage()
		{
			return message;
		}
	}

	public class SchadeOutOfBound:Exception
	{
		private string strMessage;

		public SchadeOutOfBound(string Message)
		{
			strMessage = Message;
		}

		public override string Message
		{
			get {return strMessage;}
		}
	}
}
