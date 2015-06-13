using WpfChatApp.ChatServices;

namespace WpfChatApp
{
	public static class MessageExtensions
	{
		public static string AsString(this Message message)
		{
			return string.Format("{0}:  {1} - {2}", message.Timestamp, message.Sender, message.MessageText);
		}
	}
}