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
            }

            throw new ArgumentException("Invalid figureType");
        }
    }
}