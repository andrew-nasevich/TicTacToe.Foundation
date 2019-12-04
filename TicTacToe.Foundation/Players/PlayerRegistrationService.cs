using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Foundation.Interfaces;
using TicTacToe.Foundation.Figures;

namespace TicTacToe.Foundation.Players
{
    public class PlayerRegistrationService : IPlayerRegistrationService
    {
        private readonly IIoProvider _ioProvider;
        private readonly IPlayerFactory _playerFactory;

        public ICollection<FigureType> AvailableFigureTypes { get; }


        public PlayerRegistrationService(
            IIoProvider ioProvider, 
            IPlayerFactory playerFactory, 
            ICollection<FigureType> availableFigureTypes)
        {
            _ioProvider = ioProvider;
            _playerFactory = playerFactory;
            AvailableFigureTypes = availableFigureTypes;
        }


        public IPlayer RegisterPlayer()
        {
            if (!AvailableFigureTypes.Any())
            {
                throw new InvalidOperationException("There is no more available figure types");
            }

            var name = _ioProvider.GeyPlayerName();
            var figureType = _ioProvider.GetPlayerFigure(AvailableFigureTypes.ToList());

            AvailableFigureTypes.Remove(figureType);

            return _playerFactory.CreatePlayer(name, figureType);
        }
    }
}