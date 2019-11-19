using TicTacToe.Foundation.Figure;

namespace TicTacToe.Foundation.Cell
{
    interface ICell
    {
        int Column { get; }

        int Row { get; }


        IFigure Figure { get; }
    }
}
