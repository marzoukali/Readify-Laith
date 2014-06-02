using System;
using System.Collections.Generic;
using KnockKnock.SampleRedPillService;
using NUnit.Framework;

namespace Readify.Tests
{
	[TestFixture]
	public class FibonacciTests
	{
		public struct FibonacciCase
		{
			public int Index;
			public long Value;

			public FibonacciCase(int index, long value)
			{
				Index = index;
				Value = value;
			}
		}

		public IEnumerable<FibonacciCase> FibonacciCases
		{
			get
			{
				var count = Fibonacci.Values.Length - 1;

				for (var i = -count; i <= count; i++)
				{
					yield return new FibonacciCase(i, Fibonacci.ValueAt(i));
				}
			}
		}

		public IEnumerable<long> FailedCases
		{
			get
			{
				yield return 93;
				yield return -93;
				yield return -2147483648;
				yield return -9223372036854775808;
				yield return 2147483647;
				yield return 9223372036854775807;
			}
		}


		[Test]
		[TestCaseSource("FibonacciCases")]
		public void FindValueAt_UsingCases_ValueMatches(FibonacciCase test)
		{
			// Arrange

			
			// Act
			var actual = Fibonacci.FindValueAt(test.Index);


			// Assert
			Assert.AreEqual(
				test.Value, 
				actual, 
				"Expected {0} at index {1}, but received {2}.",
				test.Value,
				test.Index,
				actual
			);
		}

		[Test]
		[TestCaseSource("FibonacciCases")]
		public void ValueAt_UsingCases_ValueMatches(FibonacciCase test)
		{
			// Arrange


			// Act
			var actual = Fibonacci.ValueAt(test.Index);


			// Assert
			Assert.AreEqual(
				test.Value,
				actual,
				"Expected {0} at index {1}, but received {2}.",
				test.Value,
				test.Index,
				actual
			);
		}

		[Test]
		[TestCaseSource("FailedCases")]
		public void FindValueAt_OutOfRangeCase_ThrowsException(long index)
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => Fibonacci.FindValueAt(index));
		}

		[Test]
		[TestCaseSource("FailedCases")]
		public void ValueAt_OutOfRangeCase_ThrowsException(long index)
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => Fibonacci.ValueAt(index));
		}
	}
}
