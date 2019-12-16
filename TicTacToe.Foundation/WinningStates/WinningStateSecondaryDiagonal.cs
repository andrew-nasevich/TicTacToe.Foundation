using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.WinningStates
{
    public class WinningStateSecondaryDiagonal : WinningState
    {
        public WinningStateSecondaryDiagonal(IBoard board) 
            : base(board, cell => cell.Row == board.BoardSize - 1 - cell.Column)
        {

        }
    }
}