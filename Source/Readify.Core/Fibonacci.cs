using System;

namespace KnockKnock.SampleRedPillService
{
    public static class Fibonacci
    {
		#region Constants
		
		public const int MaxIndex = 92;
		public const int MinIndex = -92; 

		#endregion


		/// <summary>
		/// An in-memory collection of all possible 64-bit calculations of the fibonacci sequence.
		/// </summary>
		/// <remarks>
		/// This collection uses 736 bytes (92 items * 8 bytes). An insignificant usage of memory for faster execution.
		/// </remarks>
	    public static readonly long[] Values =
	    {
		    0,
		    1,
		    1,
		    2,
		    3,
		    5,
		    8,
		    13,
		    21,
		    34,
		    55,
		    89,
		    144,
		    233,
		    377,
		    610,
		    987,
		    1597,
		    2584,
		    4181,
		    6765,
		    10946,
		    17711,
		    28657,
		    46368,
		    75025,
		    121393,
		    196418,
		    317811,
		    514229,
		    832040,
		    1346269,
		    2178309,
		    3524578,
		    5702887,
		    9227465,
		    14930352,
		    24157817,
		    39088169,
		    63245986,
		    102334155,
		    165580141,
		    267914296,
		    433494437,
		    701408733,
		    1134903170,
		    1836311903,
		    2971215073,
		    4807526976,
		    7778742049,
		    12586269025,
		    20365011074,
		    32951280099,
		    53316291173,
		    86267571272,
		    139583862445,
		    225851433717,
		    365435296162,
		    591286729879,
		    956722026041,
		    1548008755920,
		    2504730781961,
		    4052739537881,
		    6557470319842,
		    10610209857723,
		    17167680177565,
		    27777890035288,
		    44945570212853,
		    72723460248141,
		    117669030460994,
		    190392490709135,
		    308061521170129,
		    498454011879264,
		    806515533049393,
		    1304969544928657,
		    2111485077978050,
		    3416454622906707,
		    5527939700884757,
		    8944394323791464,
		    14472334024676221,
		    23416728348467685,
		    37889062373143906,
		    61305790721611591,
		    99194853094755497,
		    160500643816367088,
		    259695496911122585,
		    420196140727489673,
		    679891637638612258,
		    1100087778366101931,
		    1779979416004714189,
		    2880067194370816120,
		    4660046610375530309,
			7540113804746346429
	    };

		/// <summary>
		/// Gets the Fibonacci value at the given index.
		/// </summary>
	    public static long ValueAt(long n)
	    {
		    if (n < MinIndex)
		    {
				throw new ArgumentOutOfRangeException("n", "Fib(<92) will cause a 64-bit integer overflow.");
		    }

		    if (n > MaxIndex)
		    {
				throw new ArgumentOutOfRangeException("n", "Fib(>92) will cause a 64-bit integer overflow.");
		    }

		    var absIndex = Math.Abs(n);
		    var value = Values[absIndex];

		    return n < 0 && absIndex % 2 == 0 ? -value : value;
	    }

		/// <summary>
		/// Gets the Fibonacci value at the given index.
		/// </summary>
		[Obsolete("Use ValueAt(long n) instead. It is a faster implementation.")]
	    public static long FindValueAt(long n)
	    {
			if (n < MinIndex)
		    {
				throw new ArgumentOutOfRangeException("n", "Fib(<92) will cause a 64-bit integer overflow.");
		    }

		    if (n > MaxIndex)
		    {
				throw new ArgumentOutOfRangeException("n", "Fib(>92) will cause a 64-bit integer overflow.");
		    }

		    if (n == 0)
		    {
			    return 0;
		    }

			long v1 = 1;
			long v2 = 1;
			var absIndex = Math.Abs(n);

		    for (var i = 2; i < absIndex; i++)
		    {
			    var tmp = v1;
			    v1 = v2;
			    v2 = v1 + tmp;
		    }

		    return n < 0 && absIndex % 2 == 0 ? -v2 : v2;
	    }
    }
}
