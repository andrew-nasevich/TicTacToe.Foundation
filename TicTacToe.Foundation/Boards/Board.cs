using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Foundation.Interfaces;
using TicTacToe.Foundation.Figures;
using TicTacToe.Foundation.Cells;

namespace TicTacToe.Foundation.Boards
{
    public class Board : IBoardInternal
    {
        private readonly IReadOnlyCollection<ICellInternal> _cells;
        private readonly IFigureFactory _figureFactory;


        public int BoardSize { get; }

        public ICell this[int row, int column]
        {
            get
            {
                ICellInternal cell;
                if (TryGetCell(row, column, out cell))
                {
                    return cell;
                }
                else
                {
                    throw new ArgumentException("Invalid cell position");
                }
            }
        }


        public Board(int boardSize, ICellFactory cellFactory, IFigureFactory figureFactory)
        {
            BoardSize = boardSize;
            _figureFactory = figureFactory;

            _cells = new List<ICellInternal>();
            Enumerable.Range(1, boardSize).Select(i => Enumerable.Range(1, boardSize).
            Select(j => cellFactory.CreateCell(i, j)));
        }


        PlaceFigureResult IBoardInternal.PlaceFigure(int row, int column, FigureType figureType)
        {
            if (TryGetCell(row, column, out ICellInternal cell))
            {
                cell.SetFigure(_figureFactory.CreateFigure(figureType));

                return PlaceFigureResult.Success;
            }
            else
            {
                return PlaceFigureResult.InvalidCellPosition;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public IEnumerator<ICell> GetEnumerator()
        {
            foreach (Cell cell in _cells)
            {
                yield return cell;
            }
        }


        private bool TryGetCell(int row, int column, out ICellInternal cell)
        {
            cell = _cells.SingleOrDefault(c => c.Row == row && c.Column == column);
            
            return null != cell;
        }
    }
}