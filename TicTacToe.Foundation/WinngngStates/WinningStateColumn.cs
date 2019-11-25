using System;
using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.WinngngStates
{
    public class WinningStateColumn : IWinningState
    {
        private readonly IBoard _board;

        private readonly int _columnToCheck;


        public WinningStateColumn(IBoard board, int columnToCheck)
        {
            _board = board;

            if (columnToCheck < 0 || columnToCheck >= board.BoardSize)
            {
                throw new InvalidOperationException("There is no such column(int columnToCheck) in board");
            }

            _columnToCheck = columnToCheck;
        }


        public CheckCollectionResult Check()
        {
            var previousCell = _board[0, _columnToCheck];
            ICell currentCell;

            for(var row = 1; row < _board.BoardSize; row++)
            {
                currentCell = _board[row, _columnToCheck];

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