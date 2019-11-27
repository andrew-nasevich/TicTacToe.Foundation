namespace TicTacToe.Foundation.Interfaces
{
    public interface IPlayer
    {
        IFigure Figure { get; }

        string Name { get; }

        int Id { get; }
    }
}