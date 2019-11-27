using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.WinningStates
{
    public class WinningStateRow : WinningState
    {
        public WinningStateRow(IBoard board, int rowToCheck) 
            : base(board, cell => cell.Row == rowToCheck)
        {

        }
    }
}