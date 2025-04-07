using System;

namespace Blokr.Core.Models
{
    public class GameState
    {
        public int CurrentPlayerIndex { get; private set; }
        public int TurnCount { get; private set; }
        public bool IsFirstTurn => TurnCount < 4;
        public PieceColor[] PlayerColors { get; }
        public event Action<int> OnPlayerChanged;
        public event Action<int> OnTurnCountChanged;

        public GameState()
        {
            CurrentPlayerIndex = 0;
            TurnCount = 0;
            PlayerColors = new[] { PieceColor.Red, PieceColor.Green, PieceColor.Blue, PieceColor.Yellow };
        }

        public void NextPlayer()
        {
            CurrentPlayerIndex = (CurrentPlayerIndex + 1) % 4;
            OnPlayerChanged?.Invoke(CurrentPlayerIndex);
            
            TurnCount++;
            OnTurnCountChanged?.Invoke(TurnCount);
        }

        public void Reset()
        {
            CurrentPlayerIndex = 0;
            TurnCount = 0;
            OnPlayerChanged?.Invoke(CurrentPlayerIndex);
            OnTurnCountChanged?.Invoke(TurnCount);
        }

        public PieceColor GetCurrentPlayerColor()
        {
            return PlayerColors[CurrentPlayerIndex];
        }
    }
}
