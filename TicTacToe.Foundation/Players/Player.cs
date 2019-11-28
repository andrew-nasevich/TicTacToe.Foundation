using TicTacToe.Foundation.Interfaces;
using TicTacToe.Foundation.Figures;

namespace TicTacToe.Foundation.Players
{
    public class Player : IPlayer
    {
        public string Name { get; }

        public FigureType FigureType { get; }


        public Player(string name, FigureType figureType)
        {
            FigureType = figureType;
            Name = name;
        }
    }
}