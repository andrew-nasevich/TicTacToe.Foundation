using System;
using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.WinngngStates
{
    public class WinningStateRow : IWinningState
    {
        private readonly IBoard _board;

        private readonly int _rowToCheck;


        public WinningStateRow(IBoard board, int rowToCheck)
        {
            _board = board;

            if(rowToCheck < 0 || rowToCheck >= board.BoardSize)
            {
                throw new InvalidOperationException("There is no such row(int rowToCheck) in board");
            }

            _rowToCheck = rowToCheck;
        }


        public CheckCollectionResult Check()
        {
            var previousCell = _board[_rowToCheck, 0];
            ICell currentCell;

            for (var col = 1; col < _board.BoardSize; col++)
            {
                currentCell = _board[_rowToCheck, col];

                if (currentCell.IsEmpty)
                {
                    return CheckCollectionResult.CellsHaveNoTheSameFigure;
                }

                if (currentCell.Figure == previousCell.Figure)
                {
                    previousCell = currentCell;
                }
                else
                {
                    return CheckCollectionResult.CellsHaveNoTheSameFigure;
                }
            }

            return CheckCollectionResult.CellsHaveTheSameFigure;
        }
    }
}