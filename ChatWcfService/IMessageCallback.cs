using System;
using System.Linq;
using System.ServiceModel;

namespace ChatWcfService
{
	public interface IMessageCallback
	{
		[OperationContract(IsOneWay = true)]
		void OnMessageAdded(Message message);
	}
}
