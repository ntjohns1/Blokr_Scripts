using UnityEngine;
using System.Collections.Generic;
using Blokr.Core.Models;
using Blokr.Core.Services;
using Blokr.UnitySync;

namespace Blokr.Input.Placement
{
    public class PlacementComponent : MonoBehaviour
    {
        [SerializeField] private Piece piece;
        [SerializeField] private Direction initialDirection;
        
        private PiecePositionCalculator _positionCalculator;
        private PlacementValidationComponent _validationComponent;
        private IBoardService _boardService;
        private bool _isFlipped;
        private bool _hasValidPosition;
        private GridPosition _currentPosition;
        private List<GridPosition> _occupiedPositions;
        private List<GridPosition> _adjacentPositions;
        private List<GridPosition> _playablePositions;

        private void Awake()
        {
            _positionCalculator = GetComponent<PiecePositionCalculator>();
            _validationComponent = GetComponent<PlacementValidationComponent>();
            _occupiedPositions = new List<GridPosition>();
            _adjacentPositions = new List<GridPosition>();
            _playablePositions = new List<GridPosition>();
            _hasValidPosition = false;
        }

        private void Start()
        {
            _boardService = GameStateComponent.Instance?.BoardService;
            if (_positionCalculator != null && piece != null)
            {
                _positionCalculator.Initialize(piece.PieceType);
            }
        }

        public void UpdatePosition(GridPosition position)
        {
            _currentPosition = position;
            _hasValidPosition = true;
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
            if (!_hasValidPosition || _positionCalculator == null) return;

            _occupiedPositions = _positionCalculator.GetOccupiedGridPositions(
                _currentPosition, initialDirection, _isFlipped);
            _adjacentPositions = _positionCalculator.CalculateAdjacentPositions(
                _currentPosition, initialDirection, _isFlipped);
            _playablePositions = _positionCalculator.CalculatePlayablePositions(_adjacentPositions);
        }

        public bool ValidateCurrentPosition()
        {
            return _validationComponent.ValidatePositions(_occupiedPositions, piece.PieceColor);
        }

        public List<GridPosition> GetOccupiedPositions()
        {
            return _occupiedPositions;
        }

        public List<GridPosition> GetAdjacentPositions()
        {
            return _adjacentPositions;
        }

        public List<GridPosition> GetPlayablePositions()
        {
            return _playablePositions;
        }
    }
}
