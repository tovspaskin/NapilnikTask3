namespace NapilnikTask3
{
    public interface IRoomInteract
    {
        void EnterPlayer(ISender sender);

        void ExitPlayer(ISender sender);

        void ReadyPlayer(ISender player);

        void SendMessage(ISender sender, string message);
    }
}
