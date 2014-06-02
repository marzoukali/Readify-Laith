using System;
using System.ServiceModel;

namespace KnockKnock.SampleRedPillService
{
	public class RedPill : IRedPill
	{
		public long FibonacciNumber(long n)
		{
			long output;

			try
			{
				output = Fibonacci.ValueAt(n);
			}
			catch (ArgumentOutOfRangeException ex)
			{
				throw new FaultException<ArgumentOutOfRangeException>(ex, ex.Message);
			}

			return output;
		}

		public string ReverseWords(string s)
		{
			return Words.Reverse(s);
		}

		public Shapes.TriangleType WhatShapeIsThis(int a, int b, int c)
		{
			return Shapes.WhatIsthis(a, b, c);
		}

		public ContactDetails WhoAreYou()
		{
			var details = new ContactDetails
			{
				EmailAddress = "laith24@gmail.com",
				FamilyName = "Alasa'd",
				GivenName = "Laith",
				PhoneNumber = "+61 405 907 148"
			};

			return details;
		}
	}
}
