using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.WinningStates
{
    public class WinningStateMainDiagonal : WinningState
    {
        public WinningStateMainDiagonal(IBoard board)
            : base(board, cell => cell.Row == cell.Column)
        {

        }
    }
}