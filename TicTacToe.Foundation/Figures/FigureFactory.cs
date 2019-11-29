using System;
using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.Figures
{
    public class FigureFactory : IFigureFactory
    {
        public IFigure CreateFigure(FigureType figureType)
        {
            switch (figureType)
            {
                case FigureType.Circle:
                    return new Circle();
                case FigureType.Cross:
                    return new Cross();
                default:
                    throw new ArgumentOutOfRangeException(nameof(figureType), $"There is no figure with this figureType: {figureType}");
            }
        }
    }
}