using System.Collections.Generic;
using TicTacToe.Foundation.Figures;

namespace TicTacToe.Foundation.Interfaces
{
    public interface IPlayerRegistrationInputProvider
    {
        string GeyPlayerName();
        FigureType GetPlayerFigure(IReadOnlyCollection<FigureType> availableFigureTypes);
    }
}