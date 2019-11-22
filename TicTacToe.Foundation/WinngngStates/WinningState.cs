using System.Collections.Generic;
using System.Linq;
using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.WinngngStates
{
    public class WinningState : IWinningState
    {
        private readonly ICollection<ICell> collection;

        public WinningState(ICollection<ICell> collection)
        {
            this.collection = collection;
        }

        public CheckCollectionResult CheckCollention()
        {
            var theSame = true;
            ICell cell;

            if (collection == null)
            {
                return CheckCollectionResult.CollectionIsNull;
            }

            cell = collection.FirstOrDefault();
            foreach(ICell item in collection)
            {
                if(item.IsEmpty)
                {
                    return CheckCollectionResult.ALLCellsAreNotFilled;
                }

                theSame = theSame && item.Figure == cell.Figure;
                cell = item;
            }
            
            if(theSame)
            {
                return CheckCollectionResult.FiguresAreTheSame;
            }
            else
            {
                return CheckCollectionResult.FiguresAreNotTheSame;
            }
        }
    }
}