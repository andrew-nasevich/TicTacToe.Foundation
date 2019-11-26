using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Foundation.Interfaces;
using TicTacToe.Foundation.Figures;

namespace TicTacToe.Foundation.Boards
{
    public class Board : IBoardInternal
    {
        private readonly IFigureFactory _figureFactory;

        private readonly IReadOnlyCollection<ICellInternal> _cells;
       

        public int BoardSize { get; }

        public ICell this[int row, int column] => 
            TryGetCell(row, column, out var cell) 
            ? cell 
            : throw new InvalidOperationException("There is no cell at position row(" + row + ") and column(" + column + ")");


        public Board(ICellFactory cellFactory, IFigureFactory figureFactory, int boardSize)
        {
            _figureFactory = figureFactory;
            BoardSize = boardSize;

            _cells = Enumerable.Range(0, boardSize)
                .SelectMany(i => Enumerable.Range(0, boardSize)
                .Select(j => cellFactory.CreateCell(i, j)))
                .Cast<ICellInternal>()
                .ToList();
        }


        PlaceFigureResult IBoardInternal.PlaceFigure(int row, int column, FigureType figureType)
        {
            if (!TryGetCell(row, column, out var cell))
            {
                return PlaceFigureResult.InvalidCellPosition;
            }

            if (cell.IsEmpty)
            {
                cell.SetFigure(_figureFactory.CreateFigure(figureType));

                return PlaceFigureResult.Success;
            }

            return PlaceFigureResult.CellIsAlreadyFilled;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public IEnumerator<ICell> GetEnumerator()
        {
            return _cells.GetEnumerator();
        }


        private bool TryGetCell(int row, int column, out ICellInternal cell)
        {
            cell = _cells.SingleOrDefault(c => c.Row == row && c.Column == column);
            
            return cell != null;
        }
    }
}