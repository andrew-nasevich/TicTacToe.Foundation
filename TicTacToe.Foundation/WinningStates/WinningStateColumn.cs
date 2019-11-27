using System.Linq;
using System.Collections.Generic;
using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.WinningStates
{
    public class WinningStateColumn : WinningState
    {
        public WinningStateColumn(IBoard board, int columnToCheck)
        {
            _cells = (IReadOnlyCollection<ICell>)Enumerable.Range(0, board.BoardSize)
                .SelectMany(row => Enumerable
                    .Range(0, board.BoardSize)
                    .Select(column => board[row, column]))
                .Where(cell => cell.Column == columnToCheck);
        }
    }
}