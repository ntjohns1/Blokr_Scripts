using System;
using System.Collections.Generic;
using System.Linq;
using Blokr.Core.Models;

namespace Blokr.Core.Services
{
    public class GameStateService : IGameStateService
    {
        private readonly GameState _gameState;
        private readonly Dictionary<PieceColor, Player> _players;
        private Turn _currentTurn;
        
        public GameState CurrentState => _gameState;
        public Turn CurrentTurn => _currentTurn;
        public Player CurrentPlayer => GetPlayer(_gameState.GetCurrentPlayerColor());
        public bool IsGameOver { get; private set; }

        public event Action<Turn> OnTurnStarted;
        public event Action<Turn> OnTurnCompleted;
        public event Action<Player> OnPlayerChanged;
        public event Action<bool> OnGameOver;

        public GameStateService()
        {
            _gameState = new GameState();
            _players = new Dictionary<PieceColor, Player>();
            InitializePlayers();
        }

        private void InitializePlayers()
        {
            foreach (PieceColor color in Enum.GetValues(typeof(PieceColor)))
            {
                _players[color] = new Player($"{color}_Player", color);
            }
        }

        public void StartGame()
        {
            _gameState.Reset();
            IsGameOver = false;
            StartNextTurn();
        }

        public void EndGame()
        {
            IsGameOver = true;
            OnGameOver?.Invoke(true);
        }

        public void StartNextTurn()
        {
            if (IsGameOver) return;

            _currentTurn = new Turn(_gameState.TurnCount + 1, CurrentPlayer);
            _currentTurn.OnTurnCompleted += HandleTurnCompleted;
            OnTurnStarted?.Invoke(_currentTurn);
        }

        private void HandleTurnCompleted(Turn turn)
        {
            turn.OnTurnCompleted -= HandleTurnCompleted;
            OnTurnCompleted?.Invoke(turn);
            
            _gameState.NextPlayer();
            OnPlayerChanged?.Invoke(CurrentPlayer);
            
            // Check for game over condition
            if (CheckGameOver())
            {
                EndGame();
            }
            else
            {
                StartNextTurn();
            }
        }

        private bool CheckGameOver()
        {
            // Game is over if any player has no valid moves left
            return _players.Values.Any(player => 
                player.AvailablePieces.Values.All(available => !available));
        }

        public void SelectPiece(PieceType pieceType)
        {
            _currentTurn?.SelectPiece(pieceType);
        }

        public void PlacePiece(List<Vector2Int> positions)
        {
            _currentTurn?.PlacePiece(positions);
        }

        public void ConfirmMove()
        {
            _currentTurn?.ConfirmMove();
        }

        public void CancelMove()
        {
            _currentTurn?.CancelMove();
        }

        public Player GetPlayer(PieceColor color)
        {
            return _players.TryGetValue(color, out var player) ? player : null;
        }

        public void UpdatePlayerPlayableArea(PieceColor color, bool[,] adjacent, bool[,] playable)
        {
            if (_players.TryGetValue(color, out var player))
            {
                player.UpdatePlayableArea(adjacent, playable);
            }
        }
    }
}
