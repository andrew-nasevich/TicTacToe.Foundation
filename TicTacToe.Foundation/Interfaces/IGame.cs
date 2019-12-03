using System;
using TicTacToe.Foundation.Games;

namespace TicTacToe.Foundation.Interfaces
{
    public interface IGame
    {
        event EventHandler<GameStepEventArgs> GameStep;

        event EventHandler<GameIsFinishedEventArgs> GameIsFinished;


        void Run();
    }
}