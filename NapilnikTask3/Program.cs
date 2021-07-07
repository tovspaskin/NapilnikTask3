using System.Linq;
using System.Threading.Tasks;

namespace NapilnikTask3
{
    public enum StatusPlayer
    {
        NotReady,
        Ready,
    }

    public enum StatusRoom
    {
        Lobby,
        InGame,
    }

    internal class Program
    {
        private static void Main()
        {
            var game = new Game();
            var player = game.EnterPlayer("Mishan");
            player.CreateRoom("room", 5);
            player.SendMessage("Hello");
            player.Ready();
        }
    }
}

/*
    Есть игра, у неё есть доступные игровые комнаты. Каждый игрок может создать игровую комнату или присоединиться. Игрок не может находится в двух комната одновременно,
    но у игрока есть статус относящийся к конкретной комнате. Игрок может быть готов или не готов к игре.

    У каждой комнаты есть максимальное количество игроков. Игрок не может вступить в комнату в которой максимальное количество готовых к игре игроков.

    Игроки в комнате могут писать в чат и читать его.

    Когда достигается максимальное количество готовых игроков, комната переходит в режиме в игре. Все игрока которые были в статусе неготов теряют возможность читать чат и писать в него.

*/
