using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Foundation.Interfaces;
using TicTacToe.Foundation.Figures;

namespace TicTacToe.Foundation.Players
{
    public class PlayerRegistrationService : IPlayerRegistrationService
    {
        private readonly IPlayerFactory _playerFactory;
        private readonly IConsole _console;


        public PlayerRegistrationService(
            IPlayerFactory playerFactory,
            IConsole console)
        { 
            _playerFactory = playerFactory;
            _console = console;
        }


        public IPlayer RegisterPlayer(ICollection<FigureType> availableFigureTypes)
        {
            _console.WriteLine("Please, enter player's name: ");
            var name = _console.ReadLine();
            var figureType = ChooseFigure(availableFigureTypes);

            return _playerFactory.CreatePlayer(name, figureType);
        }


        private FigureType ChooseFigure(ICollection<FigureType> availableFigureTypes)
        {
            if (!availableFigureTypes.Any())
            {
                throw new InvalidOperationException("There is no more available figure types");
            }
            if (availableFigureTypes.Count == 1)
            {
                _console.WriteLine($"There is only one figure type left. You figure type: {availableFigureTypes.First().ToString().ToUpper()}");

                return availableFigureTypes.Single();
            }

            _console.WriteLine("Available figures types:");
            var figureTypes = availableFigureTypes.Select(ft => ft.ToString().ToUpper()).ToList();
            figureTypes.ForEach(ft => _console.WriteLine(ft));

            string chosenFigureType;
            do
            {
                _console.WriteLine("Please, write your figure type:");
                chosenFigureType = _console.ReadLine().ToUpper();
            } while (figureTypes.Any(ft => ft.Equals(chosenFigureType)));

            return availableFigureTypes.ElementAt(figureTypes.IndexOf(chosenFigureType));
        }
    }
}