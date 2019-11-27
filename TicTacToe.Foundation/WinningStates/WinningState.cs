using System.Collections.Generic;
using System.Linq;
using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.WinningStates
{
    public abstract class WinningState : IWinningState
    {
        protected IReadOnlyCollection<ICell> _cells;


        public bool IsWinningState => !_cells.Any(cell => cell.IsEmpty) && _cells.Select(cell => cell.Figure.Type).Distinct().Count() == 1;
    }
}