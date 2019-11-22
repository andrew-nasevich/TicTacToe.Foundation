using System.Collections.Generic;

namespace TicTacToe.Foundation.Interfaces
{
    public interface IBoard : IEnumerable<ICell>
    {
        int BoardSize { get; }

        ICell this[int row, int column] { get; }
    }
}