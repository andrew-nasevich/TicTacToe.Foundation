using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.Games.StepResults
{
    public class CellIsAlreadyFilledStepResult : StepResult
    {
        public ICell Cell { get; }


        public CellIsAlreadyFilledStepResult(ICell cell) 
            : base(StepResultType.CellIsAlreadyFilled)
        {
            Cell = cell;
        }
    }
}