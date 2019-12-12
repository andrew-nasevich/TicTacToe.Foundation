using System.Collections.Generic;
using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.Games.GameResults
{
    public class WinGameResult : GameResult
    {
        public IPlayer WonPlayer { get; }

        public IReadOnlyCollection<ICell> WinningCollection { get; }


        public WinGameResult(IPlayer wonPlayer, IReadOnlyCollection<ICell> winningCollection) 
            : base(GameResultType.Win)
        {
            WonPlayer = wonPlayer;
            WinningCollection = winningCollection;
        }
    }
}