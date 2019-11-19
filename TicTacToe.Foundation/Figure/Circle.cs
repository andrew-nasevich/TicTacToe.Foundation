namespace TicTacToe.Foundation.Figure
{
    class Circle : IFigure
    {
        public FigureType Type { get; }


        public Circle()
        {
            Type = FigureType.Circle;
        }
    }
}
