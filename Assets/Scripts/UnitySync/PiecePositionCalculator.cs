using UnityEngine;
using System.Collections.Generic;
using Blokr.Core.Models;
using Blokr.Core.Services;

namespace Blokr.UnitySync
{
    /// <summary>
    /// Handles piece position calculations by interfacing with IPieceCalculationService.
    /// This component bridges the gap between Unity components and the core calculation service.
    /// </summary>
    public class PiecePositionCalculator : MonoBehaviour
    {
        private GameStateComponent _gameState;
        private PieceType _pieceType;
        private bool _initialized;

        private void Start()
        {
            if (!_initialized)
            {
                _gameState = GameStateComponent.Instance;
                _pieceType = GetComponent<Piece>()?.PieceType ?? PieceType.A1;
                _initialized = true;
            }
        }

        public void Initialize(PieceType pieceType)
        {
            _gameState = GameStateComponent.Instance;
            _pieceType = pieceType;
            _initialized = true;
        }

        public List<GridPosition> GetOccupiedGridPositions(GridPosition baseCell, Direction direction, bool isFlipped)
        {
            if (!_initialized) return new List<GridPosition>();
            return _gameState.PieceCalculationService.CalculateOccupiedPositions(baseCell, _pieceType, direction, isFlipped);
        }

        public List<GridPosition> CalculateAdjacentPositions(GridPosition gridpoint, Direction direction, bool isFlipped)
        {
            if (!_initialized) return new List<GridPosition>();
            return _gameState.PieceCalculationService.CalculateAdjacentPositions(gridpoint, _pieceType, direction, isFlipped);
        }

        public List<GridPosition> CalculatePlayablePositions(List<GridPosition> adjacentPositions)
        {
            if (!_initialized) return new List<GridPosition>();
            return _gameState.PieceCalculationService.CalculatePlayablePositions(adjacentPositions, _pieceType);
        }
    }
}
