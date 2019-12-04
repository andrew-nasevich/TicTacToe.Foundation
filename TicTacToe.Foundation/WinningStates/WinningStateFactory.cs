using System.Linq;
using System.Collections.Generic;
using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.WinningStates
{
    public class WinningStateFactory : IWinningStateFactory
    {
        public IReadOnlyCollection<IWinningState> CreateWinningStatesCollection(IBoard board)
        {
            return Enumerable.Range(0, board.BoardSize)
                .Select(column => (IWinningState) new WinningStateColumn(board, column))
                .Concat(Enumerable
                    .Range(0, board.BoardSize)
                    .Select(row => (IWinningState) new WinningStateRow(board, row)))
                .Append(new WinningStateMainDiagonal(board))
                .Append(new WinningStateSecondaryDiagonal(board))
                .ToList();
        }
    }
}