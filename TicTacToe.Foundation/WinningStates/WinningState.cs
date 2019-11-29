using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.WinningStates
{
    public abstract class WinningState : IWinningState
    {
        private readonly IReadOnlyCollection<ICell> _cells;

        private bool? _isWinning;


        private bool IsOneType => _cells.Select(cell => cell.Figure.Type)
                                      .Distinct()
                                      .Count() == 1;


        public bool IsWinning => _isWinning ?? 
                                 !_cells.Any(cell => cell.IsEmpty) 
                                 && (_isWinning = IsOneType).Value;


        protected WinningState(IBoard board, Func<ICell, bool> predicate)
        {
            _cells = board.Where(predicate).ToList();
        }
    }
}