using System.Text;

namespace KnockKnock.SampleRedPillService
{
	public static class Words
	{
		private const char Separator = ' ';

		/// <summary>
		/// Reverses the words in a string.
		/// </summary>
		public static string Reverse(string s)
		{
			var reversedString = new StringBuilder();
			var length = s.Length;
			var cursor = 0;

			for (var i = 0; i < length; i++)
			{
				var c = s[i];

				if (c == Separator)
				{
					reversedString.Append(c);
					cursor = i + 1;
				}
				else
				{
					reversedString.Insert(cursor, c);
				}
			}

			return reversedString.ToString();
		}
	}
}