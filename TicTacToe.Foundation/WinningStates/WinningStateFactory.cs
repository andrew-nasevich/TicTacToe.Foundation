using System.Linq;
using System.Collections.Generic;
using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.WinningStates
{
    public class WinningStateFactory : IWinningStateFactory
    {
        public IReadOnlyCollection<IWinningState> CreateWinningStateCollection(IBoard board)
        {
            var winningStates = new List<IWinningState>
            {
                new WinningStateMainDiagonal(board),
                new WinningStateSecondaryDiagonal(board)
            };
            winningStates.AddRange(Enumerable.Range(0, board.BoardSize)
                .Select(column => new WinningStateColumn(board, column)));
            winningStates.AddRange(Enumerable.Range(0, board.BoardSize)
                .Select(row => new WinningStateRow(board, row)));

            return winningStates;
        }
    }
}