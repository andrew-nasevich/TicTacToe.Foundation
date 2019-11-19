using TicTacToe.Foundation.Figure;

namespace TicTacToe.Foundation.Cell
{
    class Cell : ICellIternal
    {
        public int Column { get; }

        public int Row { get; }


        public IFigure Figure { get; set; }


        public Cell(int row, int column) 
        {
            Row = row;
            Column = column;
        }
    }
}
