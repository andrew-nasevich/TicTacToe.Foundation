using System.Collections.Generic;
using TicTacToe.Foundation.Figures;

namespace TicTacToe.Foundation.Interfaces
{
    public interface IIoProvider
    {
        string GeyPlayerName();
        FigureType GetPlayerFigure(IReadOnlyCollection<FigureType> availableFigureTypes);
    }
}