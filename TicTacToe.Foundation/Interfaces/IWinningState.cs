using System.Collections.Generic;

namespace TicTacToe.Foundation.Interfaces
{
    public interface IWinningState
    {
        bool IsWinning { get; }

        IReadOnlyCollection<ICell> GetWinningCollection();
    }
}