using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.Games.GameResults
{
    public class WinGameResult : GameResult
    {
        public IPlayer WonPlayer { get; }


        public WinGameResult(IPlayer wonPlayer) 
            : base(GameResultType.Win)
        {
            WonPlayer = wonPlayer;
        }
    }
}