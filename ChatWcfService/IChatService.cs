using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace ChatWcfService
{
	[ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IMessageCallback))]
	public interface IChatService
	{
		[OperationContract]
		bool Connect(string nickname);

		[OperationContract]
		bool Disconnect(string nickname);

		[OperationContract]
		IEnumerable<Message> GetChatHistory();

		[OperationContract]
		bool SendMessage(string sender, string messageText);
	}
}
