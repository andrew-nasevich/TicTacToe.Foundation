using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Foundation.Boards;
using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.Games
{
    public class Game : IGame
    {
        private readonly IReadOnlyCollection<IPlayer> _players;
        private readonly IBoardInternal _board;
        private readonly IReadOnlyCollection<IWinningState> _winningStates;

        private bool _isFinished;
        private int _boardSize;
        private IPlayer _currentPlayer;
        

        public event EventHandler<GameStepEventArgs> GameStep;

        public event EventHandler<GameIsFinishedEventArgs> GameIsFinished;


        public Game(
            IGameConfiguration gameConfiguration,
            IBoardFactory boardFactory,
            ICellFactory cellFactory,
            IFigureFactory figureFactory,
            IWinningStateFactory winningStateFactory)
        {
            _boardSize = gameConfiguration.BoardSize;
            _currentPlayer = gameConfiguration.FirstStepPlayer;
            _players = gameConfiguration.Players;
            IList<IPlayer> players = gameConfiguration.Players.ToList();

            _board = new Board(cellFactory, figureFactory, gameConfiguration.BoardSize);

            var winningStates = new List<IWinningState>
            {
                winningStateFactory.CreateWinningStateMainDiagonal(_board),
                winningStateFactory.CreateWinningStateSecondaryDiagonal(_board)
            };
            winningStates.AddRange(Enumerable.Range(0, _boardSize)
                .Select(column => winningStateFactory.CreateWinningStateColumn(_board, column)));
            winningStates.AddRange(Enumerable.Range(0, _boardSize)
                .Select(row => winningStateFactory.CreateWinningStateRow(_board, row)));

            _winningStates = winningStates;
        }


        public void Run()
        {
            while (!_isFinished)
            {
                MakeStep();

                _isFinished = _winningStates.Any(el => el.IsWinning);
                if (_isFinished)
                {
                    var gameIsFinishedEventArgs = new GameIsFinishedEventArgs(_currentPlayer);
                    GameIsFinished.Invoke(this, gameIsFinishedEventArgs);

                    return;
                }

                MoveToNextPlayer();
            }
        }


        private void MoveToNextPlayer()
        {
            _currentPlayer = _players.ElementAt(_players.ToList().IndexOf(_currentPlayer) + 1 % _players.Count);
        }

        private void MakeStep()
        {
            int row = 1;
            int column = 1;
            PlaceFigureResult placeFigureResult;

            do
            {
                //TODO getting step coordinates

                placeFigureResult = _board.PlaceFigure(row, column, _currentPlayer.FigureType);

                GameStepEventArgs gameStepEventArgs;
                switch (placeFigureResult)
                { 
                    case PlaceFigureResult.Success:
                        gameStepEventArgs = new GameStepEventArgs(GameStepResult.Success, _board);
                        GameStep.Invoke(this, gameStepEventArgs);
                        break;
                    case PlaceFigureResult.CellIsAlreadyFilled:
                        gameStepEventArgs = new GameStepEventArgs(GameStepResult.CellIsAlreadyFilled, _board);
                        GameStep.Invoke(this, gameStepEventArgs);
                        break;
                    case PlaceFigureResult.InvalidCellPosition:
                        gameStepEventArgs = new GameStepEventArgs(GameStepResult.InvalidCellPosition, _board);
                        GameStep.Invoke(this, gameStepEventArgs);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(placeFigureResult), $"There is no result of placing figure with this placeFigureResult: {placeFigureResult}");
                }
                
            } while (placeFigureResult == PlaceFigureResult.Success);
        }
    }
}