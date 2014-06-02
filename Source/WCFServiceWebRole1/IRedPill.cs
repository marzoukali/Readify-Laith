using System.ServiceModel;

namespace KnockKnock.SampleRedPillService
{
	[ServiceContract(Namespace = "http://KnockKnock.readify.net")]
	public interface IRedPill
	{
		[OperationContract]
		long FibonacciNumber(long n);

		[OperationContract]
		string ReverseWords(string s);

		[OperationContract]
		Shapes.TriangleType WhatShapeIsThis(int a, int b, int c);

		[OperationContract]
		ContactDetails WhoAreYou();
	}
}
