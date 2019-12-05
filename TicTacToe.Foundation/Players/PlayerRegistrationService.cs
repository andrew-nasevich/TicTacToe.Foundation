using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Foundation.Interfaces;
using TicTacToe.Foundation.Figures;

namespace TicTacToe.Foundation.Players
{
    public class PlayerRegistrationService : IPlayerRegistrationService
    {
        private readonly IPlayerRegistrationInputProvider _playerRegistrationInputProvider;
        private readonly IPlayerFactory _playerFactory;

        public ICollection<FigureType> AvailableFigureTypes { get; }


        public PlayerRegistrationService(
            IPlayerRegistrationInputProvider playerRegistrationInputProvider, 
            IPlayerFactory playerFactory, 
            ICollection<FigureType> availableFigureTypes)
        {
            _playerRegistrationInputProvider = playerRegistrationInputProvider;
            _playerFactory = playerFactory;
            AvailableFigureTypes = availableFigureTypes;
        }


        public IPlayer RegisterPlayer()
        {
            if (!AvailableFigureTypes.Any())
            {
                throw new InvalidOperationException("There is no more available figure types");
            }

            var name = _playerRegistrationInputProvider.GeyPlayerName();
            var figureType = _playerRegistrationInputProvider.GetPlayerFigure(AvailableFigureTypes.ToList());

            AvailableFigureTypes.Remove(figureType);

            return _playerFactory.CreatePlayer(name, figureType);
        }
    }
}