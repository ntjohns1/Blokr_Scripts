using System;
using System.Collections.Generic;

namespace Blokr.Core.Models
{
    public enum TurnPhase
    {
        SelectPiece,
        PlacePiece,
        ConfirmMove,
        Complete
    }

    public class Turn
    {
        public int TurnNumber { get; private set; }
        public Player CurrentPlayer { get; private set; }
        public TurnPhase Phase { get; private set; }
        public PieceType? SelectedPieceType { get; private set; }
        public List<Vector2Int> PlacedPositions { get; private set; }
        
        public event Action<TurnPhase> OnPhaseChanged;
        public event Action<Turn> OnTurnCompleted;

        public Turn(int turnNumber, Player player)
        {
            TurnNumber = turnNumber;
            CurrentPlayer = player;
            Phase = TurnPhase.SelectPiece;
            PlacedPositions = new List<Vector2Int>();
        }

        public void SelectPiece(PieceType pieceType)
        {
            if (Phase != TurnPhase.SelectPiece || !CurrentPlayer.IsPieceAvailable(pieceType))
            {
                return;
            }

            SelectedPieceType = pieceType;
            Phase = TurnPhase.PlacePiece;
            OnPhaseChanged?.Invoke(Phase);
        }

        public void PlacePiece(List<Vector2Int> positions)
        {
            if (Phase != TurnPhase.PlacePiece || positions == null || positions.Count == 0)
            {
                return;
            }

            PlacedPositions = positions;
            Phase = TurnPhase.ConfirmMove;
            OnPhaseChanged?.Invoke(Phase);
        }

        public void ConfirmMove()
        {
            if (Phase != TurnPhase.ConfirmMove || !SelectedPieceType.HasValue)
            {
                return;
            }

            CurrentPlayer.UsePiece(SelectedPieceType.Value);
            Phase = TurnPhase.Complete;
            OnPhaseChanged?.Invoke(Phase);
            OnTurnCompleted?.Invoke(this);
        }

        public void CancelMove()
        {
            if (Phase == TurnPhase.PlacePiece)
            {
                SelectedPieceType = null;
                Phase = TurnPhase.SelectPiece;
            }
            else if (Phase == TurnPhase.ConfirmMove)
            {
                PlacedPositions.Clear();
                Phase = TurnPhase.PlacePiece;
            }
            OnPhaseChanged?.Invoke(Phase);
        }
    }
}
