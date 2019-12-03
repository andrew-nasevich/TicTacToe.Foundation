namespace TicTacToe.Foundation.Games.StepResults
{
    public class StepResult
    {
        public StepResultType CompletedResult{ get; }


        public StepResult(StepResultType stepResultType)
        {
            CompletedResult = stepResultType;
        }
    }
}