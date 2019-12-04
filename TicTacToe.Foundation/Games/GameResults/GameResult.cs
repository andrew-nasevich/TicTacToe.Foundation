namespace TicTacToe.Foundation.Games.GameResults
{
    public abstract class GameResult
    {
        public GameResultType GameResultType { get; }


        protected GameResult(GameResultType gameResult)
        {
            GameResultType = gameResult;
        }
    }
}