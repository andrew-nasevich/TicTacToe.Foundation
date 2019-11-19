using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.Figures
{
    public class Circle : IFigure
    {
        public FigureType Type { get; }


        public Circle()
        {
            Type = FigureType.Circle;
        }
    }
}