using UnityEngine;
using System.Collections.Generic;
using Blokr.Core.Services;
using Blokr.UnitySync;

namespace Blokr.Input.Selector
{
    public class SelectorComponent : MonoBehaviour
    {
        [SerializeField] private PieceType pieceType;
        [SerializeField] private Direction initialDirection;
        
        private IPieceCalculationService _calculationService;
        private bool _isFlipped;
        private Vector2Int _currentPosition;
        private List<Vector2Int> _occupiedPositions;
        private List<Vector2Int> _adjacentPositions;
        private List<Vector2Int> _playablePositions;

        private void Awake()
        {
            _calculationService = new PieceCalculationService();
            _occupiedPositions = new List<Vector2Int>();
            _adjacentPositions = new List<Vector2Int>();
            _playablePositions = new List<Vector2Int>();
        }

        public void UpdatePosition(Vector2Int position)
        {
            _currentPosition = position;
            CalculatePositions();
        }

        public void Rotate()
        {
            initialDirection = (Direction)(((int)initialDirection + 1) % 4);
            CalculatePositions();
        }

        public void Flip()
        {
            _isFlipped = !_isFlipped;
            CalculatePositions();
        }

        private void CalculatePositions()
        {
            _occupiedPositions = _calculationService.CalculateOccupiedPositions(
                _currentPosition, pieceType, initialDirection, _isFlipped);
                
            _adjacentPositions = _calculationService.CalculateAdjacentPositions(
                _currentPosition, pieceType, initialDirection, _isFlipped);
                
            _playablePositions = _calculationService.CalculatePlayablePositions(
                _adjacentPositions, pieceType);

            // Update visuals through the board component
            var board = FindObjectOfType<BoardComponent>();
            if (board != null)
            {
                // Clear previous highlights
                foreach (var pos in _adjacentPositions)
                {
                    board.ClearHighlight(pos);
                }

                // Show new positions
                foreach (var pos in _occupiedPositions)
                {
                    board.HighlightCell(pos);
                }
            }
        }

        public bool TryPlacePiece()
        {
            var gameState = GameStateComponent.Instance;
            if (gameState != null && IsValidPlacement())
            {
                gameState.PlacePiece(_occupiedPositions);
                return true;
            }
            return false;
        }

        private bool IsValidPlacement()
        {
            // All positions should be within bounds and unoccupied
            foreach (var pos in _occupiedPositions)
            {
                if (pos.x < 0 || pos.x >= 20 || pos.y < 0 || pos.y >= 20)
                {
                    return false;
                }
            }
            return true;
        }

        public List<Vector2Int> GetOccupiedPositions() => _occupiedPositions;
        public List<Vector2Int> GetAdjacentPositions() => _adjacentPositions;
        public List<Vector2Int> GetPlayablePositions() => _playablePositions;
    }
}
