using TicTacToe.Foundation.Figures;

namespace TicTacToe.Foundation.Interfaces
{
    public interface IFigureFactory
    {
        IFigure CreateFigure(FigureType figureType);
    }
}