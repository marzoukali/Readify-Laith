using System.Collections.Generic;
using KnockKnock.SampleRedPillService;
using NUnit.Framework;
namespace Readify.Tests
{
	[TestFixture]
	public class ShapeTests
	{
		public struct ShapeCase
		{
			public int A;
			public int B;
			public int C;
			public Shapes.TriangleType Type;

			public ShapeCase(int a, int b, int c, Shapes.TriangleType type)
			{
				A = a;
				B = b;
				C = c;
				Type = type;
			}
		}

		public IEnumerable<ShapeCase> ShapeCases
		{
			get
			{
				// Zeros
				yield return new ShapeCase(0, 0, 0, Shapes.TriangleType.Error);
				yield return new ShapeCase(0, 0, 1, Shapes.TriangleType.Error);
				yield return new ShapeCase(0, 1, 0, Shapes.TriangleType.Error);
				yield return new ShapeCase(0, 1, 1, Shapes.TriangleType.Error);
				yield return new ShapeCase(1, 0, 0, Shapes.TriangleType.Error);
				yield return new ShapeCase(1, 0, 1, Shapes.TriangleType.Error);
				yield return new ShapeCase(1, 1, 0, Shapes.TriangleType.Error);

				// Negatives
				yield return new ShapeCase(1, 1, -1, Shapes.TriangleType.Error);
				yield return new ShapeCase(1, -1, 1, Shapes.TriangleType.Error);
				yield return new ShapeCase(1, -1, -1, Shapes.TriangleType.Error);
				yield return new ShapeCase(-1, 1, 1, Shapes.TriangleType.Error);
				yield return new ShapeCase(-1, 1, -1, Shapes.TriangleType.Error);
				yield return new ShapeCase(-1, -1, 1, Shapes.TriangleType.Error);
				yield return new ShapeCase(-1, -1, -1, Shapes.TriangleType.Error);

				// Equilaterals
				yield return new ShapeCase(1, 1, 1, Shapes.TriangleType.Equilateral);
				yield return new ShapeCase(10, 10, 10, Shapes.TriangleType.Equilateral);

				// Isosceles
				yield return new ShapeCase(1, 2, 2, Shapes.TriangleType.Isosceles);
				yield return new ShapeCase(2, 1, 2, Shapes.TriangleType.Isosceles);
				yield return new ShapeCase(2, 2, 1, Shapes.TriangleType.Isosceles);

				// Isosceles - Equal sides are less or equal to than 3rd side
				yield return new ShapeCase(4, 2, 2, Shapes.TriangleType.Error);
				yield return new ShapeCase(5, 2, 2, Shapes.TriangleType.Error);
				yield return new ShapeCase(2, 4, 2, Shapes.TriangleType.Error);
				yield return new ShapeCase(2, 5, 2, Shapes.TriangleType.Error);
				yield return new ShapeCase(2, 2, 4, Shapes.TriangleType.Error);
				yield return new ShapeCase(2, 2, 5, Shapes.TriangleType.Error);

				// Scalenes
				yield return new ShapeCase(3, 4, 6, Shapes.TriangleType.Scalene);
				yield return new ShapeCase(3, 6, 4, Shapes.TriangleType.Scalene);
				yield return new ShapeCase(4, 3, 6, Shapes.TriangleType.Scalene);
				yield return new ShapeCase(4, 6, 3, Shapes.TriangleType.Scalene);
				yield return new ShapeCase(6, 4, 3, Shapes.TriangleType.Scalene);
				yield return new ShapeCase(6, 3, 4, Shapes.TriangleType.Scalene);

				// Scalenes - Sides don't add up
				yield return new ShapeCase(1, 2, 3, Shapes.TriangleType.Error);
				yield return new ShapeCase(1, 3, 2, Shapes.TriangleType.Error);
				yield return new ShapeCase(2, 1, 3, Shapes.TriangleType.Error);
				yield return new ShapeCase(2, 3, 1, Shapes.TriangleType.Error);
				yield return new ShapeCase(3, 1, 2, Shapes.TriangleType.Error);
				yield return new ShapeCase(3, 2, 1, Shapes.TriangleType.Error);


				// Readify tests
				yield return new ShapeCase(-2147483648, -2147483648, -2147483648, Shapes.TriangleType.Error);
				yield return new ShapeCase(1, 1, 2, Shapes.TriangleType.Error);
				yield return new ShapeCase(1, 1, 2147483647, Shapes.TriangleType.Error);
				yield return new ShapeCase(2147483647, 2147483647, 2147483647, Shapes.TriangleType.Equilateral);
				yield return new ShapeCase(1,2,1, Shapes.TriangleType.Error);
				yield return new ShapeCase(1,2,3, Shapes.TriangleType.Error);
				yield return new ShapeCase(2,1,1, Shapes.TriangleType.Error);
				yield return new ShapeCase(2,2,2, Shapes.TriangleType.Equilateral);
				yield return new ShapeCase(2,2,3, Shapes.TriangleType.Isosceles);
				yield return new ShapeCase(2,3,2, Shapes.TriangleType.Isosceles);
				yield return new ShapeCase(2,3,4, Shapes.TriangleType.Scalene);
				yield return new ShapeCase(3,2,2, Shapes.TriangleType.Isosceles);
				yield return new ShapeCase(3,4,2, Shapes.TriangleType.Scalene);
				yield return new ShapeCase(4,2,3, Shapes.TriangleType.Scalene);
				yield return new ShapeCase(4,3,2, Shapes.TriangleType.Scalene);
			}
		}

		[Test]
		[TestCaseSource("ShapeCases")]
		public void WhatIsthis_UsingCase_ValueMatches(ShapeCase test)
		{
			// Arrange
			var expected = test.Type;


			// Act
			var actual = Shapes.WhatIsthis(test.A, test.B, test.C);


			// Assert
			Assert.AreEqual(
				expected, 
				actual,
				"A:{0} B:{1} C:{2} = {3}, but received {4}", 
				test.A, 
				test.B, 
				test.C, 
				expected, 
				actual
			);
		}
	}
}