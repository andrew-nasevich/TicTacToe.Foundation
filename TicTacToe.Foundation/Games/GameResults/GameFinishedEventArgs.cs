using System;

namespace TicTacToe.Foundation.Games.GameResults
{
    public class GameFinishedEventArgs : EventArgs
    {
        public GameResult GameResult { get; }


        public GameFinishedEventArgs(GameResult gameResult)
        {
            GameResult = gameResult;
        }
    }
}