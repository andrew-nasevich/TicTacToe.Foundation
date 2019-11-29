using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.WinningStates
{
    public class WinningStateColumn : WinningState
    {
        public WinningStateColumn(IBoard board, int columnToCheck) 
            : base(board, cell => cell.Column == columnToCheck)
        {

        }
    }
}