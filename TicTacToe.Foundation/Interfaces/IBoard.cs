namespace TicTacToe.Foundation.Interfaces
{
    public interface IBoard
    {
        int BoardSize { get; }

        ICell this[int row, int column] { get; }
    }
}