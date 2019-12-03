using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Foundation.Interfaces;
using TicTacToe.Foundation.Figures;

namespace TicTacToe.Foundation.Players
{
    public class PlayerRegistrationService
    {
        private IEnumerable<IPlayer> _players;

        private IEnumerable<FigureType> _allFigureTypes;
        public PlayerRegistrationService(IEnumerable<FigureType> allFigureTypes)
        {
            
        }
        
    }
}