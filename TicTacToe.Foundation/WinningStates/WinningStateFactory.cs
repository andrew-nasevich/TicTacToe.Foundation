using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.WinningStates
{
    public class WinningStateFactory : IWinningStateFactory
    {
        public IWinningState CreateWinningStateColumn(IBoard board, int columnToCheck)
        {
            return new WinningStateColumn(board, columnToCheck);
        }

        public IWinningState CreateWinningStateMainDiagonal(IBoard board)
        {
            return new WinningStateMainDiagonal(board);
        }

        public IWinningState CreateWinningStateRow(IBoard board, int rowToCheck)
        {
            return new WinningStateRow(board, rowToCheck);
        }

        public IWinningState CreateWinningStateSecondaryDiagonal(IBoard board)
        {
            return new WinningStateSecondaryDiagonal(board);
        }
    }
}