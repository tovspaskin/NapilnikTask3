using System;
using System.Collections.Generic;

namespace NapilnikTask3
{
    public class Room : IRoomInteract
    {
        private readonly IRoomDeleter _deleter;
        private readonly Dictionary<ISender, StatusPlayer> _statusesOfPlayers;
        private readonly int _maxPlayers;
        private readonly IMesseger _messeger;
        private StatusRoom _status;

        public Room(string name, int maxPlayers, IRoomDeleter deleter)
        {
            Name = name;
            _maxPlayers = maxPlayers;
            _messeger = new Chat();
            _status = StatusRoom.Lobby;
            _statusesOfPlayers = new Dictionary<ISender, StatusPlayer>();
            _deleter = deleter;
        }

        public string Name { get; private set; }

        public void EnterPlayer(ISender sender)
        {
            _statusesOfPlayers.Add(sender, StatusPlayer.NotReady);
            _messeger.OnSendMessage += sender.ShowNewMessage;
        }

        public void ExitPlayer(ISender sender)
        {
            _messeger.OnSendMessage -= sender.ShowNewMessage;
            _statusesOfPlayers.Remove(sender);
            if (_statusesOfPlayers.Count == 0)
            {
                _deleter.DeleteRoom(this);
            }
        }

        public void ReadyPlayer(ISender player)
        {
            if (_statusesOfPlayers[player] == StatusPlayer.Ready)
            {
                _statusesOfPlayers[player] = StatusPlayer.NotReady;
            }
            else
            {
                _statusesOfPlayers[player] = StatusPlayer.Ready;
            }

            RunGame();
        }

        public void SendMessage(ISender sender, string message)
        {
            if (CanPlayerSend(sender))
            {
                _messeger.SendMessage(new Message(sender, message));
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private void RunGame()
        {
            if (IsReadyRoom())
            {
                _status = StatusRoom.InGame;
            }

            foreach (var player in _statusesOfPlayers)
            {
                if (player.Value == StatusPlayer.NotReady)
                {
                    _messeger.OnSendMessage -= player.Key.ShowNewMessage;
                }
            }
        }

        private bool IsReadyRoom()
        {
            int readyPlayers = 0;
            foreach (var player in _statusesOfPlayers)
            {
                if (player.Value == StatusPlayer.Ready)
                {
                    readyPlayers++;
                }
            }

            if (readyPlayers > _maxPlayers)
            {
                throw new ArgumentOutOfRangeException();
            }

            return readyPlayers == _maxPlayers;
        }

        private bool CanPlayerSend(ISender sender)
        {
            if (_status == StatusRoom.InGame && _statusesOfPlayers[sender] == StatusPlayer.NotReady)
            {
                return false;
            }

            return true;
        }
    }
}
