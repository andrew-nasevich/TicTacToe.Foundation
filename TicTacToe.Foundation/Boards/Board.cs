using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Foundation.Interfaces;
using TicTacToe.Foundation.Cells;

namespace TicTacToe.Foundation.Boards
{
    public class Board : IBoardInternal, IEnumerable
    {
        private readonly List<ICellInternal> Cells;


        public int BoardSize { get; }

        public ICell this[int row, int column]
        {
            get
            {
                if (row <= 0 || row > BoardSize || column <= 0 || column > BoardSize)
                {
                    throw new ArgumentException("Invalid cell position");
                }
                ICellInternal cell;
                GetCell(row, column, out cell);

                return cell;
            }
        }


        public Board(int boardSize)
        {
            BoardSize = boardSize;

            Cells = new List<ICellInternal>();
            ICellFactory cellFactory = new CellFactory();
            for(var i = 1; i <= boardSize; i++)
            {
                for(var j = 0; j <= boardSize; j++)
                {
                    Cells.Add((ICellInternal)cellFactory.CreateCell(i, j));
                }
            }
        }

        PlaceFigureResult IBoardInternal.PlaceFigure(int row, int column, IFigure figure)
        {
            if (row <= 0 || row > BoardSize || column <= 0 || column > BoardSize)
            {
                return PlaceFigureResult.InvalidCellPosition;
            }

            ICellInternal cell;
            GetCell(row, column, out cell);

            if (!cell.IsEmpty)
            {
                return PlaceFigureResult.CellIsAlreadyFilled;
            }

            cell.SetFigure(figure);

            return PlaceFigureResult.Success;
        }


        public IEnumerator GetEnumerator()
        {
            return Cells.GetEnumerator();
        }


        private bool GetCell(int row, int column, out ICellInternal cell)
        {
            cell = Cells.FirstOrDefault(_cell => _cell.Row == row && _cell.Column == column);
            
            return null != cell;
        }        
    }
}