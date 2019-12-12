using System.Collections.Generic;
using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.GameConfigurations
{
    public class GameConfigurationFactory : IGameConfigurationFactory
    {
        public IGameConfiguration CreateGameConfiguration(int boardSize, IReadOnlyCollection<IPlayer> players, IPlayer firstStepPlayer)
        {
            return new GameConfiguration(boardSize, players, firstStepPlayer);
        }
    }
}