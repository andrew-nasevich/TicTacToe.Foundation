using System.Collections.Generic;

namespace TicTacToe.Foundation.Interfaces
{
    public interface IWinningStateFactory
    {
        IReadOnlyCollection<IWinningState> CreateWinningStatesCollection(IBoard board);
    }
}