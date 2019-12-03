using System;
using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.Games
{
    public class GameStepEventArgs : EventArgs
    {
        public GameStepResult Result{ get; }

        public IBoard Board { get; }


        public GameStepEventArgs(GameStepResult placeFigureResult, IBoard board)
        {
            Result = placeFigureResult;
            Board = board;
        }
    }
}