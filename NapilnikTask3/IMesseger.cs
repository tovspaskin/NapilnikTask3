using System;

namespace NapilnikTask3
{
    public interface IMesseger
    {
        event Action<Message> OnSendMessage;

        void SendMessage(Message message);

        void ShowAllMessages();
    }
}
