using  TicTacToe.Foundation.Figures;

namespace TicTacToe.Foundation.Interfaces
{
    public interface IPlayer
    {
        string Name { get; }

        FigureType FigureType { get; }
    }
}