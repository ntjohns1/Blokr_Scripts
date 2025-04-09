using UnityEngine;
using System.Collections.Generic;
using Blokr.Core.Models;
using Blokr.Highlighter;
using Blokr.UnitySync;
using Blokr.Core.Services;

namespace Blokr.Input.Placement
{
    public class PlacementComponent : MonoBehaviour
    {
        [SerializeField] private Piece piece;
        [SerializeField] private Direction initialDirection;
        
        private PlacementHighlighter _highlighter;
        private PlacementValidationComponent _validationComponent;
        private IBoardService _boardService;
        private bool _isFlipped;
        private GridPosition _currentPosition;
        private List<GridPosition> _occupiedPositions;
        private List<GridPosition> _adjacentPositions;
        private List<GridPosition> _playablePositions;

        private void Awake()
        {
            _highlighter = GetComponent<PlacementHighlighter>();
            _validationComponent = GetComponent<PlacementValidationComponent>();
            _occupiedPositions = new List<GridPosition>();
            _adjacentPositions = new List<GridPosition>();
            _playablePositions = new List<GridPosition>();
        }

        private void Start()
        {
            _boardService = GameStateComponent.Instance?.BoardService;
            if (_highlighter != null && piece != null)
            {
                _highlighter.Initialize(
                    GameStateComponent.Instance?.PieceCalculationService,
                    piece.PieceType);
            }
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
            if (_highlighter == null) return;

            _occupiedPositions = _highlighter.GetOccupiedGridPositions(
                _currentPosition, initialDirection, _isFlipped);
                
            _adjacentPositions = _highlighter.CalculateAdjacentPositions(
                _currentPosition, initialDirection, _isFlipped);
                
            _playablePositions = _highlighter.CalculatePlayablePositions(
                _adjacentPositions);

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
            if (gameState != null && _boardService != null && _boardService.IsValidMove(_occupiedPositions, piece.PieceColor))
            {
                gameState.PlacePiece(_occupiedPositions.ToVector2Int());
                return true;
            }
            return false;
        }

        public List<GridPosition> GetOccupiedPositions() => _occupiedPositions;
        public List<GridPosition> GetAdjacentPositions() => _adjacentPositions;
        public List<GridPosition> GetPlayablePositions() => _playablePositions;
    }
}
