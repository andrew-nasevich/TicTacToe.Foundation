using TicTacToe.Foundation.Figures;
using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.Players
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string name, FigureType figureType)
        {
            return new Player(name, figureType);
        }
    }
}