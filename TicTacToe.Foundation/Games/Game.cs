using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Foundation.Boards;
using TicTacToe.Foundation.Interfaces;
using TicTacToe.Foundation.Games.StepResults;
using TicTacToe.Foundation.Games.GameResults;

namespace TicTacToe.Foundation.Games
{
    public class Game : IGame
    {
        private readonly IGameInputProvider _gameInputProvider;
        private readonly IReadOnlyCollection<IPlayer> _players;
        private readonly IBoardInternal _board;
        private readonly IReadOnlyCollection<IWinningState> _winningStates;

        private int _currentPlayerIndex;


        public event EventHandler<GameStepCompletedEventArgs> GameStepCompleted;

        public event EventHandler<GameFinishedEventArgs> GameFinished;


        public Game(
            IGameInputProvider gameInputProvider,
            IGameConfiguration gameConfiguration,
            IBoardFactory boardFactory,
            IWinningStateFactory winningStateFactory)
        {
            _gameInputProvider = gameInputProvider;
            _players = gameConfiguration.Players;
            _board = (IBoardInternal)boardFactory.CreateBoard(gameConfiguration.BoardSize);
            _winningStates = winningStateFactory.CreateWinningStatesCollection(_board);

            _currentPlayerIndex = _players.ToList().IndexOf(gameConfiguration.FirstStepPlayer);
        }


        private void InvokeGameFinished(GameResult gameResult)
        {
            var gameFinishedEventArgs = new GameFinishedEventArgs(gameResult);
            GameFinished?.Invoke(this, gameFinishedEventArgs);
        }

        private void InvokeGameStepCompleted(StepResult stepResult)
        {
            var gameStepCompletedEventArgs = new GameStepCompletedEventArgs(stepResult);
            GameStepCompleted?.Invoke(this, gameStepCompletedEventArgs);
        }

        private void MakeStep()
        {
            PlaceFigureResult placeFigureResult;
            do
            {
                _gameInputProvider.GetStepCoordinates(out var row, out var column, _players.ElementAt(_currentPlayerIndex));

                placeFigureResult = _board.PlaceFigure(row, column, _players.ElementAt(_currentPlayerIndex).FigureType);

                StepResult stepResult;
                switch (placeFigureResult)
                {
                    case PlaceFigureResult.Success:
                        stepResult = new SuccessStepResult();
                        InvokeGameStepCompleted(stepResult);
                        break;
                    case PlaceFigureResult.CellIsAlreadyFilled:
                        stepResult = new CellIsAlreadyFilledStepResult(_board[row, column]);
                        InvokeGameStepCompleted(stepResult);
                        break;
                    case PlaceFigureResult.InvalidCellPosition:
                        stepResult = new InvalidCellPositionStepResult(row, column);
                        InvokeGameStepCompleted(stepResult);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(placeFigureResult), $"There is no result of placing figure with this placeFigureCompletedResult: {placeFigureResult}");
                }

            } while (placeFigureResult != PlaceFigureResult.Success);
        }

        private void MoveToNextPlayer()
        {
            _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Count;
        }

        public GameResult Run()
        {
            GameResult gameResult;
            do
            {
                MakeStep();
                if (_winningStates.Any(el => el.IsWinning))
                {
                    gameResult = new WinGameResult(_players.ElementAt(_currentPlayerIndex));
                    InvokeGameFinished(gameResult);

                    return gameResult;
                }
                MoveToNextPlayer();
            } while (_board.All(cell => !cell.IsEmpty));

            gameResult = new DrawGameResult();
            InvokeGameFinished(gameResult);

            return gameResult;
        }
    }
}