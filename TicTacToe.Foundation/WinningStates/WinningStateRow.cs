using System.Linq;
using System.Collections.Generic;
using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.WinningStates
{
    public class WinningStateRow : WinningState
    {
        public WinningStateRow(IBoard board, int rowToCheck)
        {
            _cells = (IReadOnlyCollection<ICell>)Enumerable.Range(0, board.BoardSize)
                .SelectMany(row => Enumerable
                    .Range(0, board.BoardSize)
                    .Select(column => board[row, column]))
                .Where(cell => cell.Row == rowToCheck);
        }
    }
}