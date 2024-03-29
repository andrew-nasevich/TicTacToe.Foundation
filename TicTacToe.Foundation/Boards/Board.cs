﻿using System;
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
                : throw new InvalidOperationException($"There is no cell at position row = {row} and column = {column}");


        public Board(ICellFactory cellFactory, IFigureFactory figureFactory, int boardSize)
        {
            _figureFactory = figureFactory;
            BoardSize = boardSize;

            _cells = Enumerable.Range(0, boardSize)
                .SelectMany(row => Enumerable
                    .Range(0, boardSize)
                    .Select(column => cellFactory.CreateCell(row, column)))
                .Cast<ICellInternal>()
                .ToList();
        }


        PlaceFigureResult IBoardInternal.PlaceFigure(int row, int column, FigureType figureType)
        {
            if (!TryGetCell(row, column, out var cell))
            {
                return PlaceFigureResult.InvalidCellPosition;
            }
            if (!cell.IsEmpty)
            {
                return PlaceFigureResult.CellIsAlreadyFilled;
            }

            var figure = _figureFactory.CreateFigure(figureType);
            cell.SetFigure(figure);

            return PlaceFigureResult.Success;
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