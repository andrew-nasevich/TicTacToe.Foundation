using System.Collections.Generic;

namespace TicTacToe.Foundation.Interfaces
{
    public interface IGameConfigurationFactory
    {
        IGameConfiguration CreateGameConfiguration(int boardSize, IPlayer firstStepPlayer, IReadOnlyCollection<IPlayer> players);
    }
}