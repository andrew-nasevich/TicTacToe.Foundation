using TicTacToe.Foundation.Figure;

namespace TicTacToe.Foundation.Cell
{
    interface ICellIternal : ICell
    {
        new IFigure Figure { set; get; }
    }
}
