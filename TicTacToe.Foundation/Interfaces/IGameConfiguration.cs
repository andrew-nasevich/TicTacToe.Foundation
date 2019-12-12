using System.Collections.Generic;

namespace TicTacToe.Foundation.Interfaces
{
    public interface IGameConfiguration
    {
        int BoardSize { get; }

        IReadOnlyCollection<IPlayer> Players { get; }

        IPlayer FirstStepPlayer { get; }
    }
}