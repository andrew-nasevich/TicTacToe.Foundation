using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.WinngngStates
{
    public class WinningStateSecondaryDiagonal : IWinningState
    {
        private readonly IBoard _board;


        public WinningStateSecondaryDiagonal(IBoard board)
        {
            _board = board;
        }


        public CheckCollectionResult Check()
        {
            var previousCell = _board[0, _board.BoardSize];
            ICell currentCell;

            for (var position = 1; position < _board.BoardSize; position++)
            {
                currentCell = _board[position, _board.BoardSize - position];

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