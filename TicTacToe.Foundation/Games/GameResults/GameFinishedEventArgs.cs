namespace TicTacToe.Foundation.Games.GameResults
{
    public class GameFinishedEventArgs
    {
        public GameResult GameResult { get; }


        public GameFinishedEventArgs(GameResult gameResult)
        {
            GameResult = gameResult;
        }
    }
}