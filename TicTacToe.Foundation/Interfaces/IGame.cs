using System;

namespace TicTacToe.Foundation.Interfaces
{
    public interface IGame
    {
        event EventHandler GameStep;

        event EventHandler GameIsFinished;


        void Run();
    }
}