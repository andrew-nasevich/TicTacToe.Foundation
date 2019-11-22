using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.Cells
{
    public class CellFactory : ICellFactory
    {
        public ICell CreateCell(int row, int column)
        {
            return new Cell(row, column);
        }
    }
}