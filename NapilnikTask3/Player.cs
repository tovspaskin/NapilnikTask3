using System;

namespace NapilnikTask3
{
    public class Player : ISender
    {
        private readonly IRoomCreator _roomCreator;
        private IRoomInteract _room;

        public Player(string nickname, IRoomCreator roomCreator)
        {
            Nickname = nickname;
            _roomCreator = roomCreator;
        }

        public string Nickname { get; private set; }

        public void CreateRoom(string name, int maxPlayers)
        {
            if (_room != null)
            {
                _room.EnterPlayer(this);
            }

            _room = _roomCreator.CreateRoom(name, maxPlayers);
            JoinRoom(_room);
        }

        public void JoinRoom(IRoomInteract room)
        {
            if (room == null)
            {
                room.EnterPlayer(this);
                _room = room;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public void ExitRoom()
        {
            _room.EnterPlayer(this);
            _room = null;
        }

        public void Ready()
        {
            _room.ReadyPlayer(this);
        }

        public void SendMessage(string messame)
        {
            _room.SendMessage(this, messame);
        }

        public void ShowNewMessage(Message message)
        {
            Console.WriteLine(message.GetStandartFormat());
        }
    }
}
