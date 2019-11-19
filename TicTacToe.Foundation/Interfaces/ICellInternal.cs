namespace TicTacToe.Foundation.Interfaces
{
    interface ICellInternal : ICell
    {
        void SetFigure(IFigure figure);
    }
}