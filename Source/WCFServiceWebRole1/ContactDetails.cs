using System.Runtime.Serialization;

namespace KnockKnock.SampleRedPillService
{
	[DataContract(Namespace = "http://KnockKnock.readify.net")]
	public class ContactDetails
	{
		[DataMember]
		public string EmailAddress { get; set; }

		[DataMember]
		public string GivenName { get; set; }

		[DataMember]
		public string FamilyName { get; set; }

		[DataMember]
		public string PhoneNumber { get; set; }
	}
}