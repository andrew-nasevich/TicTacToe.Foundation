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
        private readonly IReadOnlyCollection<IPlayer> _players;
        private readonly IBoardInternal _board;
        private readonly IReadOnlyCollection<IWinningState> _winningStates;

        private int _currentPlayerIndex;
        

        public event EventHandler<StepResult> GameStepCompleted;

        public event EventHandler<GameResult> GameFinished;


        public Game(
            IGameConfiguration gameConfiguration,
            IBoardFactory boardFactory,
            IWinningStateFactory winningStateFactory)
        {
            _currentPlayerIndex = _players.ToList().IndexOf(gameConfiguration.FirstStepPlayer);
            _players = gameConfiguration.Players;
            _players = gameConfiguration.Players;

            _board = (IBoardInternal)boardFactory.CreateBoard(gameConfiguration.BoardSize);

            _winningStates = winningStateFactory.CreateWinningStateCollection(_board);
        }


        public GameResult Run()
        {
            GameResult gameResult;
            do
            {
                MakeStep();

                if (_winningStates.Any(el => el.IsWinning))
                {
                    gameResult = new GameResult(GameResultType.Win);
                    GameFinished.Invoke(this, gameResult);

                    return gameResult;
                }

                MoveToNextPlayer();

            } while (_board.All(cell => !cell.IsEmpty));

            gameResult = new GameResult(GameResultType.Win);
            GameFinished.Invoke(this, gameResult);

            return gameResult;
        }


        private void MoveToNextPlayer()
        {
            _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Count;
        }

        private void MakeStep()
        {
            int row = 1;
            int column = 1;
            PlaceFigureResult placeFigureResult;

            do
            {
                //TODO getting step coordinates

                placeFigureResult = _board.PlaceFigure(row, column, _players.ElementAt(_currentPlayerIndex).FigureType);

                StepResult gameStepEventArgs;
                switch (placeFigureResult)
                { 
                    case PlaceFigureResult.Success:
                        gameStepEventArgs = new StepResult(StepResultType.Success);
                        GameStepCompleted.Invoke(this, gameStepEventArgs);
                        break;
                    case PlaceFigureResult.CellIsAlreadyFilled:
                        gameStepEventArgs = new StepResult(StepResultType.CellIsAlreadyFilled);
                        GameStepCompleted.Invoke(this, gameStepEventArgs);
                        break;
                    case PlaceFigureResult.InvalidCellPosition:
                        gameStepEventArgs = new StepResult(StepResultType.InvalidCellPosition);
                        GameStepCompleted.Invoke(this, gameStepEventArgs);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(placeFigureResult), $"There is no result of placing figure with this placeFigureCompletedResult: {placeFigureResult}");
                }
                
            } while (placeFigureResult == PlaceFigureResult.Success);
        }
    }
}