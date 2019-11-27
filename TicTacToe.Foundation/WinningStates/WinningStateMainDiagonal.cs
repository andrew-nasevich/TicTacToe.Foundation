using System.Collections.Generic;
using System.Linq;
using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.WinningStates
{
    public class WinningStateMainDiagonal : WinningState
    {
        public WinningStateMainDiagonal(IBoard board)
        {
            _cells = (IReadOnlyCollection<ICell>)Enumerable.Range(0, board.BoardSize)
                .SelectMany(row => Enumerable
                    .Range(0, board.BoardSize)
                    .Select(column => board[row, column]))
                .Where(cell => cell.Row == cell.Column);
        }
    }
}