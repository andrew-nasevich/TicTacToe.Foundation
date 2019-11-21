using TicTacToe.Foundation.Cells;

namespace TicTacToe.Foundation.Interfaces
{
    internal interface ICellFactory
    {
        ICellInternal CreateCell(int row, int column);
    }
}