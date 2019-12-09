using System.Collections.Generic;
using TicTacToe.Foundation.Figures;

namespace TicTacToe.Foundation.Interfaces
{
    public interface IPlayerRegistrationService
    {
        IPlayer RegisterPlayer(ICollection<FigureType> availableFigureTypes);
    }
}