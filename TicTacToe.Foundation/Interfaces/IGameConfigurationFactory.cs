using System.Collections.Generic;

namespace TicTacToe.Foundation.Interfaces
{
    public interface IGameConfigurationFactory
    {
        IGameConfiguration CreateGameConfiguration(int boardSize, IReadOnlyCollection<IPlayer> players, IPlayer firstStepPlayer);
    }
}