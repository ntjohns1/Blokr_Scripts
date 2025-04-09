using System;
using System.Collections.Generic;
using Blokr.Core.Models;
using Blokr.Core.Services;
using Blokr.Input;
using Blokr.UnitySync;
using UnityEngine;

namespace Blokr.States
{
    public class PiecePlacementState : MonoBehaviour
    {
        private static PiecePlacementState instance;
        
        private InputHandler input;
        private GameObject tileHighlight;
        private PlacementValidationComponent validationComponent;
        private PiecePositionCalculator positionCalculator;

        [SerializeField] private LayerMask gridLayer;

        private Piece piece;
        private List<GridPosition> occupiedCells;
        private List<GridPosition> adjacentCells;
        private List<GridPosition> playableCells;
        private GameObject placedPiece;
        
        public static PiecePlacementState Instance
        {
            get { return instance; }
            set { instance = value; }
        }
        
        public Piece Piece
        {
            get { return piece; }
            set { piece = value; }
        }

        void Awake()
        {
            instance = this;
            validationComponent = GetComponent<PlacementValidationComponent>();
            positionCalculator = GetComponent<PiecePositionCalculator>();
        }

        void Start() 
        {
            input = InputHandler.Instance;
            SubscribeToInputEvents();
        }

        void OnDestroy()
        {
            UnsubscribeFromInputEvents();
        }

        private void SubscribeToInputEvents()
        {
            if (input != null)
            {
                input.OnPieceSelected += HandlePieceSelected;
                input.OnPositionSelected += HandlePositionSelected;
                input.OnRotateClockwise += HandleRotateClockwise;
                input.OnRotateCounterClockwise += HandleRotateCounterClockwise;
                input.OnFlip += HandleFlip;
                input.OnCancel += HandleCancel;
            }
        }

        private void UnsubscribeFromInputEvents()
        {
            if (input != null)
            {
                input.OnPieceSelected -= HandlePieceSelected;
                input.OnPositionSelected -= HandlePositionSelected;
                input.OnRotateClockwise -= HandleRotateClockwise;
                input.OnRotateCounterClockwise -= HandleRotateCounterClockwise;
                input.OnFlip -= HandleFlip;
                input.OnCancel -= HandleCancel;
            }
        }

        private void HandlePieceSelected(Piece selectedPiece)
        {
            piece = selectedPiece;
            if (tileHighlight != null)
            {
                tileHighlight.SetActive(true);
                InitializePositionAndRotation();
            }
        }

        private void HandlePositionSelected(GridPosition position)
        {
            if (validationComponent.ValidatePosition(position, piece))
            {
                occupiedCells = positionCalculator.GetOccupiedGridPositions(position, piece.PieceDirection, piece.IsFlipped);
                adjacentCells = positionCalculator.CalculateAdjacentPositions(position, piece.PieceDirection, piece.IsFlipped);
                playableCells = positionCalculator.CalculatePlayablePositions(adjacentCells);
                        
                Player currentPlayer = GameManager.Instance.CurrentPlayer.GetComponent<Player>();
                currentPlayer.UpdateAdjacentPositions(adjacentCells);
                currentPlayer.UpdatePlayablePositions(playableCells);
                
                placedPiece = PiecePool.SharedInstance.GetPiece(piece.PieceType.ToString(), piece.PieceColor);
                placedPiece.transform.SetPositionAndRotation(
                    GridGeometry.PointFromGrid(occupiedCells[0]), 
                    tileHighlight.transform.rotation);
                placedPiece.SetActive(true);
                piece.gameObject.SetActive(false);
                
                ExitState();
            }
        }

        private void HandleRotateClockwise()
        {
            if (tileHighlight != null)
            {
                tileHighlight.transform.Rotate(0f, 90f, 0f);
                CalculatePositions();
            }
        }

        private void HandleRotateCounterClockwise()
        {
            if (tileHighlight != null)
            {
                tileHighlight.transform.Rotate(0f, -90f, 0f);
                CalculatePositions();
            }
        }

        private void HandleFlip()
        {
            if (tileHighlight != null)
            {
                tileHighlight.transform.Rotate(180f, 0f, 0f);
                CalculatePositions();
            }
        }

        private void HandleCancel()
        {
            if (tileHighlight != null)
            {
                tileHighlight.SetActive(false);
            }
            piece = null;
            ExitState();
        }

        private void CalculatePositions()
        {
            if (piece == null || tileHighlight == null) return;

            GridPosition position = GridGeometry.GridFromPoint(tileHighlight.transform.position);
            occupiedCells = positionCalculator.GetOccupiedGridPositions(position, piece.PieceDirection, piece.IsFlipped);
            adjacentCells = positionCalculator.CalculateAdjacentPositions(position, piece.PieceDirection, piece.IsFlipped);
            playableCells = positionCalculator.CalculatePlayablePositions(adjacentCells);
        }

        public void SetHighlight(GameObject highlightPrefab)
        {
            tileHighlight = highlightPrefab;
            if (piece != null)
            {
                InitializePositionAndRotation();
            }
        }

        void InitializePositionAndRotation()
        {
            if (tileHighlight == null) return;
            tileHighlight.transform.SetPositionAndRotation(
                Vector3.zero, 
                Quaternion.Euler(0.0f, 90.0f * (int)piece.PieceDirection, 0.0f));
        }

        public void EnterState()
        {
            enabled = true;
            if (tileHighlight != null)
            {
                tileHighlight.SetActive(true);
            }
        }

        private void ExitState()
        {
            if (tileHighlight != null)
            {
                tileHighlight.SetActive(false);
            }
            enabled = false;
            TurnHandler turnHandler = GetComponent<TurnHandler>();
            turnHandler.EnterState();
        }
    }
}
