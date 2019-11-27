using System.Collections.Generic;

namespace TicTacToe.Foundation.Interfaces
{
    public interface IGameConfiguration
    {
        IReadOnlyCollection<IPlayer> Players { get; }

        IPlayer FirstStepPlayer { get; }

        int BoardSize { get; }
    }
}