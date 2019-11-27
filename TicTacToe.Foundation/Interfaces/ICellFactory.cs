namespace TicTacToe.Foundation.Interfaces
{
    public interface ICellFactory
    {
        ICell CreateCell(int row, int column);
    }
}