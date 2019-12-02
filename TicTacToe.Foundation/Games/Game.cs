using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Foundation.Boards;
using TicTacToe.Foundation.Interfaces;

namespace TicTacToe.Foundation.Game
{
    public class Game : IGame
    {
        private bool _isFinished;
        private int _boardSize;
        private IPlayer _firstStepPlayer;
        private IReadOnlyCollection<IPlayer> _players;
        //TODO dependencies
        private IBoard _board;
        private IReadOnlyCollection<IWinningState> _winningStates;

        public event EventHandler GameStep;

        public event EventHandler GameIsFinished;


        public Game(IGameConfiguration gameConfiguration, 
            IBoardFactory boardFactory, 
            ICellFactory cellFactory, 
            IFigureFactory figureFactory,
            IWinningStateFactory winningStateFactory)
        {
            _boardSize = gameConfiguration.BoardSize;
            _firstStepPlayer = gameConfiguration.FirstStepPlayer;
            _players = gameConfiguration.Players;

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
                
            }
        }
    }
}