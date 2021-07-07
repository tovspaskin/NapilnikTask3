using System;
using System.Collections.Generic;
using System.Text;

namespace NapilnikTask3
{
    public class Chat : IMesseger
    {
        public Chat()
        {
            Messages = new List<Message>();
        }

        public event Action<Message> OnSendMessage;

        public List<Message> Messages { get; private set; }

        public void SendMessage(Message message)
        {
            Messages.Add(message);
            OnSendMessage.Invoke(message);
        }

        public void ShowAllMessages()
        {
            StringBuilder outMessagesBuilder = new StringBuilder();
            foreach (var message in Messages)
            {
                outMessagesBuilder.AppendLine(message.GetStandartFormat());
            }

            Console.WriteLine(outMessagesBuilder.ToString());
        }
    }
}
