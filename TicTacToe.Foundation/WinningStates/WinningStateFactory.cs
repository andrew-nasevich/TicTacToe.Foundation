using System.Linq;
using System.Collections.Generic;
using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.WinningStates
{
    public class WinningStateFactory : IWinningStateFactory
    {
        public IReadOnlyCollection<IWinningState> CreateWinningStatesCollection(IBoard board)
        {
            var columns = Enumerable.Range(0, board.BoardSize)
                .Select(column => (IWinningState) new WinningStateColumn(board, column));
            var rows = Enumerable.Range(0, board.BoardSize)
                .Select(row => (IWinningState) new WinningStateRow(board, row));
            var diagonals = new List<IWinningState> {new WinningStateMainDiagonal(board), new WinningStateSecondaryDiagonal(board)};

            return columns.Concat(rows).Concat(diagonals).ToList();
        }
    }
}