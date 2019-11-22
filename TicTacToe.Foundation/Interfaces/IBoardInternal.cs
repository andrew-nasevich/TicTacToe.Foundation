using TicTacToe.Foundation.Boards;
using TicTacToe.Foundation.Figures;

namespace TicTacToe.Foundation.Interfaces
{
    internal interface IBoardInternal: IBoard
    {
        PlaceFigureResult PlaceFigure(int row, int column, FigureType figureType);
    }
}