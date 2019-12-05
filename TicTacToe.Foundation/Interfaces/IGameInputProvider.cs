namespace TicTacToe.Foundation.Interfaces
{
    public interface IGameInputProvider
    {
        void GetNextCellPosition(out int row, out int column, IPlayer player);
    }
}