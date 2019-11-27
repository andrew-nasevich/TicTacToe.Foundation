using System.Collections.Generic;
using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.GameConfigurations
{
    public class GameConfiguration : IGameConfiguration
    {
        public IReadOnlyCollection<IPlayer> Players { get; }

        public IPlayer FirstStepPlayer { get; }

        public int BoardSize { get; }


        public GameConfiguration(IReadOnlyCollection<IPlayer> players, IPlayer firstStepPlayer, int boardSize)
        {
            Players = players;
            FirstStepPlayer = firstStepPlayer;
            BoardSize = boardSize;
        }
    }
}