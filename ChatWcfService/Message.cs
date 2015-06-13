using System;
using System.Runtime.Serialization;

namespace ChatWcfService
{
	[DataContract]
	public class Message
	{
		[DataMember]
		public string Sender { get; set; }

		[DataMember]
		public DateTime Timestamp { get; set; }

		[DataMember]
		public string MessageText { get; set; }
	}
}