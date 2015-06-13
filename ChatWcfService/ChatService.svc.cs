using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace ChatWcfService
{
	public class ChatService : IChatService
	{
		private readonly List<IMessageCallback> receiverCallbacks = new List<IMessageCallback>();

		public bool Connect()
		{
			try
			{
				var callback = OperationContext.Current.GetCallbackChannel<IMessageCallback>();
				if (!this.receiverCallbacks.Contains(callback))
				{
					this.receiverCallbacks.Add(callback);
				}

				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Disconnect()
		{
			try
			{
				var callback = OperationContext.Current.GetCallbackChannel<IMessageCallback>();
				if (this.receiverCallbacks.Contains(callback))
				{
					this.receiverCallbacks.Remove(callback);
				}

				return true;
			}
			catch
			{
				return false;
			}
		}

		public IEnumerable<Message> GetChatHistory()
		{
			// TODO: implement this method
			yield return new Message()
			{
				Sender = "bb",
				Timestamp = DateTime.Now,
				MessageText = "message1"
			};

			yield return new Message()
			{
				Sender = "aa",
				Timestamp = DateTime.Now,
				MessageText = "message2"
			};
		}

		public bool SendMessage(string sender, string messageText)
		{
			var message = new Message()
			{
				Sender = sender,
				MessageText = messageText,
				Timestamp = DateTime.Now
			};
			
			try
			{
				foreach (var callback in this.receiverCallbacks)
				{
					callback.OnMessageAdded(message);
				}

				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
