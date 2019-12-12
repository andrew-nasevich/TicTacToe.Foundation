using System.Collections.Generic;

namespace TicTacToe.Foundation.Interfaces
{
    public interface IWinningState
    {
        IReadOnlyCollection<ICell> Cells { get; }

        bool IsWinning { get; }
    }
}