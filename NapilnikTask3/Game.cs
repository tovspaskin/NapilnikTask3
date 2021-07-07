using System.Collections.Generic;

namespace NapilnikTask3
{
    public class Game : IRoomCreator, IRoomDeleter
    {
        private readonly List<Room> _rooms = new List<Room>();
        private readonly List<Player> _players = new List<Player>();

        public Room CreateRoom(string name, int maxPlayers)
        {
            Room room = new Room(name, maxPlayers, this);
            _rooms.Add(room);
            return room;
        }

        public void DeleteRoom(Room room)
        {
            _rooms.Remove(room);
        }

        public Player EnterPlayer(string nickname)
        {
            Player newPlayer = new Player(nickname, this);
            _players.Add(newPlayer);
            return newPlayer;
        }
    }
}
