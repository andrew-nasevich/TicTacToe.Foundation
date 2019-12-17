namespace TicTacToe.Foundation.Interfaces
{
    public interface IGameFactory
    {
        IGame CreateGame(IGameConfiguration gameConfiguration);
    }
}