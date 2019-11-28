using System.Collections.Generic;
using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.GameConfigurations
{
    public class GameConfiguration : IGameConfiguration
    {
        public int BoardSize { get; }

        public IPlayer FirstStepPlayer { get; }

        public IReadOnlyCollection<IPlayer> Players { get; }


        public GameConfiguration(int boardSize, IPlayer firstStepPlayer, IReadOnlyCollection<IPlayer> players)
        {
            BoardSize = boardSize;
            FirstStepPlayer = firstStepPlayer;
            Players = players;
        }
    }
}