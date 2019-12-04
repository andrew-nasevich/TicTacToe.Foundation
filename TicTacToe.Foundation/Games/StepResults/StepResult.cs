namespace TicTacToe.Foundation.Games.StepResults
{
    public abstract class StepResult
    {
        public StepResultType StepResultType { get; }


        protected StepResult(StepResultType stepResultType)
        {
            StepResultType = stepResultType;
        }
    }
}