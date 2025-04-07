using System;
using System.Collections.Generic;
using Blokr.Core.Models;

namespace Blokr.Core.Services
{
    public interface IGameStateService
    {
        // Game state
        GameState CurrentState { get; }
        Turn CurrentTurn { get; }
        Player CurrentPlayer { get; }
        bool IsGameOver { get; }
        
        // Events
        event Action<Turn> OnTurnStarted;
        event Action<Turn> OnTurnCompleted;
        event Action<Player> OnPlayerChanged;
        event Action<bool> OnGameOver;

        // Game flow methods
        void StartGame();
        void EndGame();
        void StartNextTurn();
        
        // Turn actions
        void SelectPiece(PieceType pieceType);
        void PlacePiece(List<Vector2Int> positions);
        void ConfirmMove();
        void CancelMove();
        
        // Player methods
        Player GetPlayer(PieceColor color);
        void UpdatePlayerPlayableArea(PieceColor color, bool[,] adjacent, bool[,] playable);
    }
}
