using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ChatWcfService
{
	public class ChatService : IChatService
	{
		private Dictionary<string, Data.Sessions> userToSessionMap; 

		private Data.ChatAppDB db;

		private readonly List<IMessageCallback> receiverCallbacks = new List<IMessageCallback>();

		public bool Connect(string nickname)
		{
			try
			{
				var callback = OperationContext.Current.GetCallbackChannel<IMessageCallback>();
				if (!this.receiverCallbacks.Contains(callback))
				{
					this.receiverCallbacks.Add(callback);

					this.InitSession(nickname);
				}

				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Disconnect(string nickname)
		{
			try
			{
				var callback = OperationContext.Current.GetCallbackChannel<IMessageCallback>();
				if (this.receiverCallbacks.Contains(callback))
				{
					this.receiverCallbacks.Remove(callback);
				}

				this.CloseSession(nickname);

				return true;
			}
			catch
			{
				return false;
			}
		}

		public IEnumerable<Message> GetChatHistory()
		{
			foreach (var dbMessage in this.db.Messages)
			{
				yield return this.ConvertMessage(dbMessage);
			}

			//return this.db.Messages.Select(x => this.ConvertMessage(x));
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

				this.LogMessage(message);

				return true;
			}
			catch
			{
				return false;
			}
		}

		private void InitSession(string nickname)
		{
			this.Init();

			try
			{
				var user = this.db.Users.FirstOrDefault(x => x.Nickname == nickname);
				if (user == null)
				{
					user = new Data.Users() { Nickname = nickname };
					user.Id = this.db.Users.Count() + 1;
					this.db.Users.Add(user);
				}

				var session = new Data.Sessions()
				{
					Id = this.db.Sessions.Count() + 1,
					Id_User = user.Id,
					Connect_Time = DateTime.Now
				};

				this.userToSessionMap.Add(nickname, session);

				this.db.Sessions.Add(session);
				this.db.SaveChanges();
			}
			catch {}
		}

		private void Init()
		{
			if (this.db == null)
			{
				this.db = new Data.ChatAppDB();
			}

			if (this.userToSessionMap == null)
			{
				this.userToSessionMap = new Dictionary<string, Data.Sessions>();
			}
		}

		private void CloseSession(string nickname)
		{
			try
			{
				var session = this.userToSessionMap[nickname];
				session.Disconnect_Time = DateTime.Now;

				this.db.SaveChanges();
			}
			catch {}
		}

		private async Task LogMessage(Message message)
		{
			try
			{
				var user = this.db.Users.First(x => x.Nickname == message.Sender); 

				var dbMessage = new Data.Messages()
				{
					Id = this.db.Messages.Count() + 1,
					Id_Sender = user.Id,
					Timestamp = message.Timestamp,
					MessageText = message.MessageText
				};

				this.db.Messages.Add(dbMessage);
				await this.db.SaveChangesAsync();
			}
			catch {}
		}

		private Message ConvertMessage(Data.Messages dbMessage)
		{
			var user = this.db.Users.FirstOrDefault(x => x.Id == dbMessage.Id_Sender);
			var sender = (user != null) ? user.Nickname : string.Empty;

			return new Message()
			{
				Sender = sender,
				Timestamp = dbMessage.Timestamp.GetValueOrDefault(),
				MessageText = dbMessage.MessageText
			};
		}
	}
}
