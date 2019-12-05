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
            _players = gameConfiguration.Players.ToList();

            _board = (IBoardInternal)boardFactory.CreateBoard(gameConfiguration.BoardSize);
            _winningStates = winningStateFactory.CreateWinningStatesCollection(_board);

            _currentPlayerIndex = _players.ToList().IndexOf(gameConfiguration.FirstStepPlayer);
        }


        public GameResult Run()
        {
            GameResult gameResult;
            do
            {
                MakeStep();
                if (_winningStates.Any(ws => ws.IsWinning))
                {
                    gameResult = new WinGameResult(CurrentPlayer);
                    InvokeGameFinished(gameResult);

                    return gameResult;
                }
                MoveToNextPlayer();
            } while (_board.All(cell => !cell.IsEmpty));

            gameResult = new DrawGameResult();
            InvokeGameFinished(gameResult);

            return gameResult;
        }


        private void InvokeGameFinished(GameResult gameResult)
        {
            var gameFinishedEventArgs = new GameFinishedEventArgs(gameResult);
            GameFinished.Raise(this, gameFinishedEventArgs);
        }

        private void InvokeGameStepCompleted(StepResult stepResult)
        {
            var gameStepCompletedEventArgs = new GameStepCompletedEventArgs(stepResult);
            GameStepCompleted.Raise(this, gameStepCompletedEventArgs);
        }

        private void MakeStep()
        {
            PlaceFigureResult placeFigureResult;
            do
            {
                _gameInputProvider.GetNextCellPosition(out var row, out var column, CurrentPlayer);

                placeFigureResult = _board.PlaceFigure(row, column, CurrentPlayer.FigureType);

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
                        throw new ArgumentOutOfRangeException(nameof(placeFigureResult), $"Unknown placeFigureCompletedResult: {placeFigureResult}");
                }

            } while (placeFigureResult != PlaceFigureResult.Success);
        }

        private void MoveToNextPlayer()
        {
            _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Count;
        }
    }
}