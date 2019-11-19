namespace TicTacToe.Foundation.Figure
{
    class Cross : IFigure
    {
        public FigureType Type { get; }


        public Cross()
        {
            Type = FigureType.Cross;
        }
    }
}
