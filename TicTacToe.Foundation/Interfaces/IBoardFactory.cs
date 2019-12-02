namespace TicTacToe.Foundation.Interfaces
{
    public interface IBoardFactory
    {
        IBoard CreateBoard(ICellFactory cellFactory, IFigureFactory figureFactory, int boardSize);
    }
}