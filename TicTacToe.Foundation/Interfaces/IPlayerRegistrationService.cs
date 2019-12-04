using System.Collections.Generic;
using TicTacToe.Foundation.Figures;

namespace TicTacToe.Foundation.Interfaces
{
    public interface IPlayerRegistrationService
    {
        ICollection<FigureType> AvailableFigureTypes { get; }


        IPlayer RegisterPlayer();
    }
}