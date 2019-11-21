using System;
using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.Board
{
    public class Board : IBoardInternal
    {
        private readonly ICellInternal[,] Cells;


        public int BoardSize { get; }


        public Board(int boardSize)
        {
            BoardSize = boardSize;
            Cells = new Cell.Cell[boardSize, boardSize];
        }


        void IBoardInternal.PlaceFigure(int row, int column, IFigure figure)
        {
            if (row <= 0 || row > BoardSize || column <= 0 || column > BoardSize)
            {
                throw new ArgumentException("Invalid cell position");
            }
            if (figure == null)
            {
                throw new ArgumentException("Invalid figure");
            }
            Cells[row - 1, column - 1].SetFigure(figure);
        }


        public ICell GetCell(int row, int column)
        {
            if (row <= 0 || row > BoardSize || column <= 0 || column > BoardSize)
            {
                throw new ArgumentException("Invalid cell position");
            }

            return Cells[row, column];
        }

        public IFigure GetFigureFromCell(int row, int column)
        {
            if (row <= 0 || row > BoardSize || column <= 0 || column > BoardSize)
            {
                throw new ArgumentException("Invalid cell position");
            }

            return Cells[row, column].Figure;
        }
    }
}