using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.WinningStates
{
    public abstract class WinningState : IWinningState
    {
        private bool? _isWinning;


        private bool IsOneType => Cells.Select(cell => cell.Figure.Type)
                                      .Distinct()
                                      .Count() == 1;


        public IReadOnlyCollection<ICell> Cells { get; }


        public bool IsWinning => _isWinning ?? 
                                 !Cells.Any(cell => cell.IsEmpty) 
                                 && (_isWinning = IsOneType).Value;


        protected WinningState(IBoard board, Func<ICell, bool> predicate)
        {
            Cells = board.Where(predicate).ToList();
        }
    }
}