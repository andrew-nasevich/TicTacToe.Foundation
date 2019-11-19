using System;
using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.Cell
{
    public class Cell : ICellInternal
    {
        public int Column { get; }

        public int Row { get; }

        public IFigure Figure { get; private set; }

        public bool IsEmpty
        { 
            get
            { 
                return Figure == null; 
            }
        }


        public void SetFigure(IFigure figure)
        {
            if (!IsEmpty)
                throw new ArgumentException("The cell is already filled");

            Figure = figure;
        }


        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}