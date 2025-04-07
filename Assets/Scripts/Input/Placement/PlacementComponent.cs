using UnityEngine;
using Blokr.Core.Models;
using Blokr.Highlighter;

namespace Blokr.Input.Selector
{
    public class SelectorComponent : MonoBehaviour
    {
        [SerializeField] private Piece piece;
        [SerializeField] private Direction initialDirection;
        
        private PlacementHighlighter _highlighter;
        private bool _isFlipped;
        private GridPosition _currentPosition;
        private List<GridPosition> _occupiedPositions;
        private List<GridPosition> _adjacentPositions;
        private List<GridPosition> _playablePositions;

        private void Awake()
        {
            _highlighter = GetComponent<PlacementHighlighter>();
            _occupiedPositions = new List<GridPosition>();
            _adjacentPositions = new List<GridPosition>();
            _playablePositions = new List<GridPosition>();
        }

        public void UpdatePosition(GridPosition position)
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
            _occupiedPositions = _highlighter.GetOccupiedGridPositions(
                _currentPosition, initialDirection, _isFlipped);
                
            _adjacentPositions = _highlighter.GetAdjacentGridPositions(
                _currentPosition, initialDirection, _isFlipped);
                
            _playablePositions = _highlighter.GetPlayableGridPositions(
                _adjacentPositions, piece);

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

        public List<GridPosition> GetOccupiedPositions() => _occupiedPositions;
        public List<GridPosition> GetAdjacentPositions() => _adjacentPositions;
        public List<GridPosition> GetPlayablePositions() => _playablePositions;
    }
}
