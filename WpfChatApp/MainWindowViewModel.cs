using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Windows.Input;
using WpfChatApp.ChatServices;

namespace WpfChatApp
{
	internal class MainWindowViewModel : INotifyPropertyChanged, IChatServiceCallback, IDisposable
	{
		private readonly ChatServiceClient proxy;

		private readonly DelegateCommand connectCmd;

		private readonly DelegateCommand sendCmd;

		private ObservableCollection<string> chatMessages;

		private string messageText;

		private string nickname;

		private bool isConnected;

		public event PropertyChangedEventHandler PropertyChanged;

		public ICommand ConnectCmd
		{
			get
			{
				return this.connectCmd;
			}
		}

		public ICommand SendCmd
		{
			get
			{
				return this.sendCmd;
			}
		}

		public string Nickname
		{
			get
			{
				return this.nickname;
			}
			set
			{
				if (this.messageText != value)
				{
					this.nickname = value;
					this.OnPropertyChanged("Nickname");
					this.connectCmd.RaiseCanExecuteChanged();
				}
			}
		}

		public string MessageText
		{
			get
			{
				return this.messageText;
			}
			set
			{
				if (this.messageText != value)
				{
					this.messageText = value;
					this.OnPropertyChanged("MessageText");
					this.sendCmd.RaiseCanExecuteChanged();
				}
			}
		}

		public IEnumerable<string> ChatMessages
		{
			get
			{
				return this.chatMessages;
			}
		}

		public MainWindowViewModel()
		{
			this.proxy = new ChatServiceClient(new InstanceContext(this));

			this.connectCmd = new DelegateCommand(this.Connect, _ => !string.IsNullOrEmpty(this.Nickname));
			this.sendCmd = new DelegateCommand(this.SendMessage, _ => this.isConnected && !string.IsNullOrEmpty(this.MessageText));
		}

		public void Dispose()
		{
			if (proxy.State == CommunicationState.Opened)
			{
				if (this.isConnected)
				{
					proxy.Disconnect(this.Nickname);
				}

				proxy.Close();
			}
		}

		public void OnMessageAdded(Message message)
		{
			this.chatMessages.Add(message.AsString());
			this.OnPropertyChanged("ChatMessages");
		}

		protected void OnPropertyChanged(string propertyName)
		{
			var handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		private async void Connect(object parameter)
		{
			if (this.isConnected)
				return;

			try
			{
				this.isConnected = await this.proxy.ConnectAsync(this.Nickname);

				if (this.isConnected)
				{
					var chatHistory = await this.proxy.GetChatHistoryAsync();

					var chatHistoryStrings = chatHistory.Select(x => x.AsString());
					this.chatMessages = new ObservableCollection<string>(chatHistoryStrings);
					this.OnPropertyChanged("ChatMessages");
				}
			}
			catch {}
		}

		private async void SendMessage(object parameter)
		{
			if (!this.isConnected)
				return;

			try
			{
				await this.proxy.SendMessageAsync(this.Nickname, this.MessageText);
			}
			catch {}

			this.MessageText = string.Empty;
		}
	}
}
