namespace TicTacToe.Foundation.Interfaces
{
    public interface IGameInputProvider
    {
        void GetStepCoordinates(out int row, out int column, IPlayer player);
    }
}