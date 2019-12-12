using System.Collections.Generic;
using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.GameConfigurations
{
    public class GameConfigurationFactory : IGameConfigurationFactory
    {
        public IGameConfiguration CreateGameConfiguration(int boardSize, IPlayer firstStepPlayer, IReadOnlyCollection<IPlayer> players)
        {
            return new GameConfiguration(boardSize, firstStepPlayer, players);
        }
    }
}