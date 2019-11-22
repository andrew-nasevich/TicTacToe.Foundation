namespace TicTacToe.Foundation.Interfaces
{
    public interface ICell
    {
        int Row { get; }

        int Column { get; }

        IFigure Figure { get; }

        bool IsEmpty { get; }
    }
}