using System.Collections.Generic;
using UnityEngine;
using Blokr.Core.Models;
using Blokr.Core.Services;
using Blokr.UnitySync;

namespace Blokr.Highlighter
{
    public class PlacementHighlighter : MonoBehaviour
    {
        private IPieceCalculationService _pieceCalculationService;
        private PieceType _pieceType;
        private bool _initialized;

        private void Start()
        {
            if (!_initialized)
            {
                _pieceCalculationService = GameStateComponent.Instance.PieceCalculationService;
                _pieceType = GetComponent<Piece>()?.PieceType ?? PieceType.A1;
                _initialized = true;
            }
        }

        public void Initialize(IPieceCalculationService pieceCalculationService, PieceType pieceType)
        {
            _pieceCalculationService = pieceCalculationService;
            _pieceType = pieceType;
            _initialized = true;
        }

        public List<GridPosition> GetOccupiedGridPositions(GridPosition baseCell, Direction direction, bool isFlipped)
        {
            if (!_initialized) return new List<GridPosition>();
            return _pieceCalculationService.CalculateOccupiedPositions(baseCell, _pieceType, direction, isFlipped);
        }

        public List<GridPosition> CalculateAdjacentPositions(GridPosition gridpoint, Direction direction, bool isFlipped)
        {
            if (!_initialized) return new List<GridPosition>();
            return _pieceCalculationService.CalculateAdjacentPositions(gridpoint, _pieceType, direction, isFlipped);
        }

        public List<GridPosition> CalculatePlayablePositions(List<GridPosition> adjacentPositions)
        {
            if (!_initialized) return new List<GridPosition>();
            return _pieceCalculationService.CalculatePlayablePositions(adjacentPositions, _pieceType);
        }
    }
}
