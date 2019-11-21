namespace TicTacToe.Foundation.Interfaces
{
    internal interface IBoardInternal: IBoard
    {
        void PlaceFigure(int row, int column, IFigure figure);
    }
}