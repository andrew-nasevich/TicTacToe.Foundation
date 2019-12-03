namespace TicTacToe.Foundation.Interfaces
{
    public interface IBoardFactory
    {
        IBoard CreateBoard(int boardSize);
    }
}