namespace TicTacToe.Foundation.Interfaces
{
    public interface IIoProvider
    {
        void GetStepCoordinates(out int row, out int column, IPlayer player);
    }
}