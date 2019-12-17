using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.Games
{
    public class GameFactory : IGameFactory
    {
        private readonly IGameInputProvider _gameInputProvider;
        private readonly IBoardFactory _boardFactory;
        private readonly IWinningStateFactory _winningStateFactory;


        public GameFactory(
            IGameInputProvider gameInputProvider,
            IBoardFactory boardFactory,
            IWinningStateFactory winningStateFactory)
        {
            _gameInputProvider = gameInputProvider;
            _boardFactory = boardFactory;
            _winningStateFactory = winningStateFactory;
        }


        public IGame CreateGame(IGameConfiguration gameConfiguration)
        {
            return new Game(_gameInputProvider, gameConfiguration, _boardFactory, _winningStateFactory);
        }
    }
}