using TicTacToe.Foundation.Figures;

namespace TicTacToe.Foundation.Interfaces
{
    public interface IPlayerFactory
    {
        IPlayer CreatePlayer(string name, FigureType figureType);
    }
}