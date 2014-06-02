using System.Collections.Generic;
using KnockKnock.SampleRedPillService;
using NUnit.Framework;

namespace Readify.Tests
{
	[TestFixture]
	public class WordsTests
	{
		public struct ReverseWordsCase
		{
			public string Input;
			public string Output;

			public ReverseWordsCase(string input, string output)
			{
				Input = input;
				Output = output;
			}
		}

		public IEnumerable<ReverseWordsCase> ReverseWordsCases
		{
			get
			{
				yield return new ReverseWordsCase(
					"",
					""
				);

				yield return new ReverseWordsCase(
					"hello",
					"olleh"
				);

				yield return new ReverseWordsCase(
					"hello world",
					"olleh dlrow"
				);

				yield return new ReverseWordsCase(
					"Hello!", 
					"!olleH"
				);

				yield return new ReverseWordsCase(
					"This Is A Long Sentence To Be Reversed", 
					"sihT sI A gnoL ecnetneS oT eB desreveR"
				);
				
				yield return new ReverseWordsCase(
					"!This! is ?strange? combination 0f characters. It ?? will 100k 0dd.",
					"!sihT! si ?egnarts? noitanibmoc f0 .sretcarahc tI ?? lliw k001 .dd0"
				);

				yield return new ReverseWordsCase(
					"1234",
					"4321"
				);

				yield return new ReverseWordsCase(
					"-- Numbers -- Should -- Reverse -- As -- Well -- 1234 -- -4321 --",
					"-- srebmuN -- dluohS -- esreveR -- sA -- lleW -- 4321 -- 1234- --"
				);

				yield return new ReverseWordsCase(
					"Bacon ipsum dolor sit amet doner frankfurter chuck cow fatback corned beef. Turkey landjaeger ball tip pork belly boudin. T-bone sirloin shoulder boudin bresaola landjaeger fatback flank beef ribs pork pancetta jowl swine doner meatloaf. Jowl landjaeger fatback, jerky leberkas boudin brisket strip steak meatloaf ribeye. Jerky tri-tip meatball ground round, kielbasa doner bresaola ham shank biltong venison filet mignon jowl ham hock chicken.",
					"nocaB muspi rolod tis tema renod retrufknarf kcuhc woc kcabtaf denroc .feeb yekruT regeajdnal llab pit krop ylleb .niduob enob-T niolris redluohs niduob aloaserb regeajdnal kcabtaf knalf feeb sbir krop attecnap lwoj eniws renod .faoltaem lwoJ regeajdnal ,kcabtaf ykrej sakrebel niduob teksirb pirts kaets faoltaem .eyebir ykreJ pit-irt llabtaem dnuorg ,dnuor asableik renod aloaserb mah knahs gnotlib nosinev telif nongim lwoj mah kcoh .nekcihc"
				);

				yield return new ReverseWordsCase(
					"And then...",
					"dnA ...neht"
				);

				yield return new ReverseWordsCase(
					" ",
					" "
				);

				yield return new ReverseWordsCase(
					"                       ",
					"                       "
				);

				yield return new ReverseWordsCase(
					"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+}{[]|<,>.?/:;'",
					"';:/?.>,<|][{}+_)(*&^%$#@!9876543210ZYXWVUTSRQPONMLKJIHGFEDCBAzyxwvutsrqponmlkjihgfedcba"
				);

				yield return new ReverseWordsCase(
					"  S  P  A  C  E  Y  ",
					"  S  P  A  C  E  Y  "
				);

				yield return new ReverseWordsCase(
					" leading space",
					" gnidael ecaps"
				);

				yield return new ReverseWordsCase(
					"!B!A!N!G!S!",
					"!S!G!N!A!B!"
				);

				yield return new ReverseWordsCase(
					"Bang!",
					"!gnaB"
				);

				yield return new ReverseWordsCase(
					"Capital",
					"latipaC"
				);

				yield return new ReverseWordsCase(
					"This is a snark: ⸮",
					"sihT si a :krans ⸮"
				);

				yield return new ReverseWordsCase(
					"cat",
					"tac"
				);

				yield return new ReverseWordsCase(
					"cat and dog",
					"tac dna god"
				);

				yield return new ReverseWordsCase(
					"detartrated kayak detartrated",
					"detartrated kayak detartrated"
				);

				yield return new ReverseWordsCase(
					"trailing space ",
					"gniliart ecaps "
				);

				yield return new ReverseWordsCase(
					"two  spaces",
					"owt  secaps"
				);
			}
		}
		
		[Test]
		[TestCaseSource("ReverseWordsCases")]
		public void Reverse_UsingCase_ValueMatches(ReverseWordsCase test)
		{
			// Arrange
			

			// Act
			var actual = Words.Reverse(test.Input);


			// Assert
			Assert.AreEqual(test.Output, actual);
		}
	}
}