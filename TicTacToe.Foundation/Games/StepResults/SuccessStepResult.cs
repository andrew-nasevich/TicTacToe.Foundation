using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.Games.StepResults
{
    public class SuccessStepResult : StepResult
    {
        public IBoard Board { get; }

        public SuccessStepResult(IBoard board) 
            : base(StepResultType.Success)
        {
            Board = board;
        }
    }
}