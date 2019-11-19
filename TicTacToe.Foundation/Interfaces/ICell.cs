namespace TicTacToe.Foundation.Interfaces
{
    public interface ICell
    {
        int Column { get; }

        int Row { get; }

        IFigure Figure { get; }

        bool IsEmpty { get; }
    }
}