using System;
using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.Games
{
    public class GameIsFinishedEventArgs : EventArgs
    {
        public IPlayer WonPlayer { get; }


        public GameIsFinishedEventArgs(IPlayer wonPlayer)
        {
            WonPlayer = wonPlayer;
        }
    }
}