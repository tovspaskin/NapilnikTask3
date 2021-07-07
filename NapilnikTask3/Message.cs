using System;
using System.Text;

namespace NapilnikTask3
{
    public struct Message
    {
        private readonly ISender _sender;
        private readonly string _body;
        private readonly string _timeOfSending;

        public Message(ISender sender, string body)
        {
            _sender = sender;
            _body = body;
            _timeOfSending = DateTime.Now.ToLongTimeString();
        }

        public string GetStandartFormat()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(_sender.Nickname);
            stringBuilder.AppendLine(_body);
            stringBuilder.AppendLine(_timeOfSending);
            return stringBuilder.ToString();
        }
    }
}
