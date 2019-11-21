namespace TicTacToe.Foundation.Interfaces
{
    public interface IBoard
    {
        int BoardSize { get; }


        IFigure GetFigureFromCell(int row, int column);

        ICell GetCell(int row, int column);
    }
}