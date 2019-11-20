using System;
using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.Cell
{
    public class Cell : ICellInternal
    {
        public int Column { get; }

        public int Row { get; }

        public IFigure Figure { get; private set; }

        public bool IsEmpty => Figure == null; 


        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
        }
         

        void ICellInternal.SetFigure(IFigure figure)
        {
            if (!IsEmpty)
            {
                throw new InvalidOperationException("The cell is already filled");
            }

            Figure = figure;
        }
    }
}