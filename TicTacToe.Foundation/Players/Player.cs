using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.Players
{
    public class Player : IPlayer
    {
        public IFigure Figure { get; }

        public string Name { get; }

        public int Id { get; }


        public Player(IFigure figure, string name, int id)
        {
            Figure = figure;
            Name = name;
            Id = id;
        }
    }
}