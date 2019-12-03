namespace TicTacToe.Foundation.Games.GameResults
{
    public class GameResult
    {
        public GameResultType GameResultType { get; }


        public GameResult(GameResultType gameResult)
        {
            GameResultType = gameResult;
        }
    }
}