using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Blokr.Core.Models;
using Blokr.Core.Services;

namespace Blokr.UnitySync
{
    public class PlacementValidationComponent : MonoBehaviour
    {
        [SerializeField] private LayerMask boardLayer;
        
        private Camera _mainCamera;
        private PieceHighlightComponent _highlightComponent;
        private GameStateComponent _gameState;
        private bool _initialized;

        private void Start()
        {
            if (!_initialized)
            {
                _mainCamera = Camera.main;
                _highlightComponent = GetComponent<PieceHighlightComponent>();
                _gameState = GameStateComponent.Instance;
                _initialized = true;
            }
        }

        public void Initialize(Camera mainCamera, PieceHighlightComponent highlightComponent)
        {
            _mainCamera = mainCamera;
            _highlightComponent = highlightComponent;
            _gameState = GameStateComponent.Instance;
            _initialized = true;
        }

        public bool ValidateMousePosition(Piece piece)
        {
            if (!_initialized) return false;

            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, boardLayer))
            {
                Vector3 point = hit.point;
                GridPosition gridPoint = GridGeometry.GridFromPoint(point);
                
                if (ValidatePosition(gridPoint, piece))
                {
                    _highlightComponent.UpdateVisibility(true);
                    _highlightComponent.UpdatePosition(GridGeometry.PointFromGrid(gridPoint));
                    return true;
                }
            }

            _highlightComponent.UpdateVisibility(false);
            return false;
        }

        public bool ValidatePosition(GridPosition position, Piece piece)
        {
            if (!_initialized) return false;

            var occupiedPositions = _gameState.PieceCalculationService.CalculateOccupiedPositions(
                position, piece.PieceType, piece.PieceDirection, piece.IsFlipped);

            return IsValidPlacement(occupiedPositions, piece.PieceColor);
        }

        public bool ValidatePositions(List<GridPosition> positions, PieceColor color)
        {
            if (!_initialized) return false;
            return IsValidPlacement(positions, color);
        }

        private bool IsValidPlacement(List<GridPosition> positions, PieceColor color)
        {
            bool allPositionsInBounds = positions.All(pos => 
                pos.X >= 0 && pos.X <= 19 && pos.Y >= 0 && pos.Y <= 19);

            return allPositionsInBounds && 
                   _gameState.BoardService.IsValidMove(positions, color);
        }
    }
}
