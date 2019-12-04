namespace TicTacToe.Foundation.Games.StepResults
{
    public class GameStepCompletedEventArgs
    {
        public StepResult StepResult { get; }


        public GameStepCompletedEventArgs(StepResult stepResult)
        {
            StepResult = stepResult;
        }
    }
}