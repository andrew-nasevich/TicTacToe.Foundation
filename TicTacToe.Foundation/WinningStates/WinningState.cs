using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.WinningStates
{
    public abstract class WinningState : IWinningState
    {
        private readonly IReadOnlyCollection<ICell> _cells;

        private bool? _winning;


        public bool IsWinning
        {
            get
            {
                if (_winning != null)
                {
                    return _winning == true;
                }
                if (_cells.Any(cell => cell.IsEmpty))
                {
                    return false;
                }

                _winning = _cells.Select(cell => cell.Figure.Type)
                                       .Distinct()
                                       .Count() == 1;

                return _winning == true;
            }
        }


        protected WinningState(IBoard board, Func<ICell, bool> predicate)
        {
            _cells = (IReadOnlyCollection<ICell>) board.Where(predicate);
        }
    }
}