using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.Figures
{
    public class Cross : IFigure
    {
        public FigureType Type { get; }


        public Cross()
        {
            Type = FigureType.Cross;
        }
    }
}