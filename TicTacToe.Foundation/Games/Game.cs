using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Common.EventExtensions;
using TicTacToe.Foundation.Boards;
using TicTacToe.Foundation.Interfaces;
using TicTacToe.Foundation.Games.StepResults;
using TicTacToe.Foundation.Games.GameResults;

namespace TicTacToe.Foundation.Games
{
    public class Game : IGame
    {
        private readonly IGameInputProvider _gameInputProvider;
        private readonly IReadOnlyList<IPlayer> _players;

        private readonly IBoardInternal _board;
        private readonly IReadOnlyCollection<IWinningState> _winningStates;

        private int _currentPlayerIndex;


        private IPlayer CurrentPlayer => _players[_currentPlayerIndex]; 


        public event EventHandler<GameStepCompletedEventArgs> GameStepCompleted;

        public event EventHandler<GameFinishedEventArgs> GameFinished;


        public Game(
            IGameInputProvider gameInputProvider,
            IGameConfiguration gameConfiguration,
            IBoardFactory boardFactory,
            IWinningStateFactory winningStateFactory)
        {
            _gameInputProvider = gameInputProvider;
            var players = gameConfiguration.Players.ToList();
            _players = players;

            _board = (IBoardInternal)boardFactory.CreateBoard(gameConfiguration.BoardSize);
            _winningStates = winningStateFactory.CreateWinningStatesCollection(_board);

            _currentPlayerIndex = players.IndexOf(gameConfiguration.FirstStepPlayer);
        }


        public GameResult Run()
        {
            GameResult gameResult;
            do
            {
                MakeStep();

                var winningCombination = _winningStates.SingleOrDefault(ws => ws.IsWinning);
                if (winningCombination != null)
                {
                    gameResult = new WinGameResult(CurrentPlayer, winningCombination.GetWinningCollection());
                    OnGameFinished(gameResult);

                    return gameResult;
                }
                MoveToNextPlayer();
            } while (_board.All(cell => !cell.IsEmpty));

            gameResult = new DrawGameResult();
            OnGameFinished(gameResult);

            return gameResult;
        }


        private void OnGameFinished(GameResult gameResult)
        {
            var gameFinishedEventArgs = new GameFinishedEventArgs(gameResult);
            GameFinished.Raise(this, gameFinishedEventArgs);
        }

        private void OnGameStepCompleted(StepResult stepResult)
        {
            var gameStepCompletedEventArgs = new GameStepCompletedEventArgs(stepResult);
            GameStepCompleted.Raise(this, gameStepCompletedEventArgs);
        }

        private void MakeStep()
        {
            PlaceFigureResult placeFigureResult;
            var currentPlayer = CurrentPlayer;
            do
            {
                _gameInputProvider.GetNextCellPosition(out var row, out var column, currentPlayer);

                placeFigureResult = _board.PlaceFigure(row, column, currentPlayer.FigureType);

                StepResult stepResult;
                switch (placeFigureResult)
                {
                    case PlaceFigureResult.Success:
                        stepResult = new SuccessStepResult();
                        OnGameStepCompleted(stepResult);
                        break;
                    case PlaceFigureResult.CellIsAlreadyFilled:
                        stepResult = new CellIsAlreadyFilledStepResult(_board[row, column]);
                        OnGameStepCompleted(stepResult);
                        break;
                    case PlaceFigureResult.InvalidCellPosition:
                        stepResult = new InvalidCellPositionStepResult(row, column);
                        OnGameStepCompleted(stepResult);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(placeFigureResult), $"Unknown placeFigureResult: {placeFigureResult}");
                }

            } while (placeFigureResult != PlaceFigureResult.Success);
        }

        private void MoveToNextPlayer()
        {
            _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Count;
        }
    }
}