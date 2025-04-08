using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Blokr.Core.Models;
using Blokr.Core.Services;
using Blokr.Highlighter;

namespace Blokr.UnitySync
{
    public class PlacementValidationComponent : MonoBehaviour
    {
        [SerializeField] private LayerMask boardLayer;
        
        private Camera _mainCamera;
        private PieceHighlightComponent _highlightComponent;
        private IPieceCalculationService _pieceCalculationService;
        private IGameStateService _gameStateService;

        public void Initialize(Camera mainCamera, PieceHighlightComponent highlightComponent, 
            IPieceCalculationService pieceCalculationService, IGameStateService gameStateService)
        {
            _mainCamera = mainCamera;
            _highlightComponent = highlightComponent;
            _pieceCalculationService = pieceCalculationService;
            _gameStateService = gameStateService;
        }

        public bool ValidateMousePosition(Piece piece)
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, boardLayer))
            {
                Vector3 point = hit.point;
                GridPosition gridPoint = Geometry.GridFromPoint(point);
                
                var occupiedPositions = _pieceCalculationService.CalculateOccupiedPositions(
                    gridPoint, piece.PieceType, piece.PieceDirection, piece.IsFlipped);

                if (IsValidPlacement(occupiedPositions, piece.PieceColor))
                {
                    _highlightComponent.UpdateVisibility(true);
                    _highlightComponent.UpdatePosition(Geometry.PointFromGrid(gridPoint));
                    return true;
                }
            }

            _highlightComponent.UpdateVisibility(false);
            return false;
        }

        private bool IsValidPlacement(List<GridPosition> positions, PieceColor color)
        {
            bool allPositionsInBounds = positions.All(pos => 
                pos.X >= 0 && pos.X <= 19 && pos.Y >= 0 && pos.Y <= 19);

            return allPositionsInBounds && 
                   _gameStateService.BoardService.IsValidMove(positions, color);
        }
    }
}
