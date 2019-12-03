using System;
using TicTacToe.Foundation.Games.StepResults;
using TicTacToe.Foundation.Games.GameResults;

namespace TicTacToe.Foundation.Interfaces
{
    public interface IGame
    {
        event EventHandler<StepResult> GameStepCompleted;

        event EventHandler<GameResult> GameFinished;


        GameResult Run();
    }
}