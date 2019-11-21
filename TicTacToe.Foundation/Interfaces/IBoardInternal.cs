using TicTacToe.Foundation.Boards;

namespace TicTacToe.Foundation.Interfaces
{
    internal interface IBoardInternal: IBoard
    {
        PlaceFigureResult PlaceFigure(int row, int column, IFigure figure);
    }
}