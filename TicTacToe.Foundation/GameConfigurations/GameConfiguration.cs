using System.Collections.Generic;
using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.GameConfigurations
{
    public class GameConfiguration : IGameConfiguration
    {
        public int BoardSize { get; }

        public IReadOnlyCollection<IPlayer> Players { get; }

        public IPlayer FirstStepPlayer { get; }

        public GameConfiguration(int boardSize, IReadOnlyCollection<IPlayer> players, IPlayer firstStepPlayer)
        {
            BoardSize = boardSize;
            Players = players;
            FirstStepPlayer = firstStepPlayer;
        }
    }
}