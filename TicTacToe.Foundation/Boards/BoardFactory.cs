using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.Boards
{
    public class BoardFactory : IBoardFactory
    {
        private readonly ICellFactory _cellFactory;
        private readonly IFigureFactory _figureFactory;


        public BoardFactory(ICellFactory cellFactory, IFigureFactory figureFactory)
        {
            _cellFactory = cellFactory;
            _figureFactory = figureFactory;
        }


        public IBoard CreateBoard(int boardSize)
        {
            return new Board(_cellFactory, _figureFactory, boardSize);
        }
    }
}