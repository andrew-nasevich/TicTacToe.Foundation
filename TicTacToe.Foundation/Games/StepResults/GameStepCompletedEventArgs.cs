using System;

namespace TicTacToe.Foundation.Games.StepResults
{
    public class GameStepCompletedEventArgs : EventArgs
    {
        public StepResult StepResult { get; }


        public GameStepCompletedEventArgs(StepResult stepResult)
        {
            StepResult = stepResult;
        }
    }
}