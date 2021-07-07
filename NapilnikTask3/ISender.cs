namespace NapilnikTask3
{
    public interface ISender
    {
        string Nickname { get; }

        void ShowNewMessage(Message message);
    }
}
