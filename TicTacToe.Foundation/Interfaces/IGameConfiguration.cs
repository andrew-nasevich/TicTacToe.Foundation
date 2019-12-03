using System.Collections.Generic;

namespace TicTacToe.Foundation.Interfaces
{
    public interface IGameConfiguration
    {
        int BoardSize { get; }

        IPlayer FirstStepPlayer { get; }

        IReadOnlyCollection<IPlayer> Players { get; }
    }
}