using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.Boards
{
    public class BoardFactory : IBoardFactory
    {
        public IBoard CreateBoard(ICellFactory cellFactory, IFigureFactory figureFactory, int boardSize)
        {
            return new Board(cellFactory, figureFactory, boardSize);
        }
    }
}