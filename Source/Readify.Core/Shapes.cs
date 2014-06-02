namespace KnockKnock.SampleRedPillService
{
	public static class Shapes
	{
		/// <summary>
		/// An enumeration of all possible types of a triangle.
		/// </summary>
		public enum TriangleType
		{
			Error = 0,
			Equilateral = 1,
			Isosceles = 2,
			Scalene = 3,
		}

		/// <summary>
		/// Determines the type of triangle based on the three provides sides.
		/// </summary>
		/// <param name="a">The length of side A.</param>
		/// <param name="b">The length of side B.</param>
		/// <param name="c">The length of side C.</param>
		/// <returns>A value of <see cref="TriangleType"/>.</returns>
		public static TriangleType WhatIsthis(int a, int b, int c)
		{
			// If any side is invalid, then return error.
			if (a <= 0 || b <= 0 || c <= 0)
			{
				return TriangleType.Error;
			}

			
			var ab = a == b;
			var ac = a == c;
			var bc = b == c;


			// If all sides are equal, then return equilateral.
			if (ab && ac && bc)
			{
				return TriangleType.Equilateral;
			}


			// Check isosceles where the two equal sides must be greater than the third side.
			if (ab)
			{
				return a + b <= c ? TriangleType.Error : TriangleType.Isosceles;
			}

			if (ac)
			{
				return a + c <= b ? TriangleType.Error : TriangleType.Isosceles;
			}

			if (bc)
			{
				return b + c <= a ? TriangleType.Error : TriangleType.Isosceles;
			}


			// Otherwise, check scalene where largest side must be less then the sum of the other two.
			if (a > b && a > c && b + c <= a)
			{
				return TriangleType.Error;
			}

			if (b > a && b > c && a + c <= b)
			{
				return TriangleType.Error;
			}

			return a + b <= c ? TriangleType.Error : TriangleType.Scalene;
		}
	}
}