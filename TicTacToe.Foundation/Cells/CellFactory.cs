using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.Cells
{
    internal class CellFactory : ICellFactory
    {
        public ICellInternal CreateCell(int row, int column)
        {
            return new Cell(row, column);
        }
    }
}