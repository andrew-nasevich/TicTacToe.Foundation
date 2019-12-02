namespace TicTacToe.Foundation.Interfaces
{
    public interface IWinningStateFactory
    {
        IWinningState CreateWinningStateColumn(IBoard board, int columnToCheck);

        IWinningState CreateWinningStateMainDiagonal(IBoard board);

        IWinningState CreateWinningStateRow(IBoard board, int rowToCheck);

        IWinningState CreateWinningStateSecondaryDiagonal(IBoard board);
    }
}