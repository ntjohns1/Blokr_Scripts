using System.Collections.Generic;
using UnityEngine;

namespace Blokr.Core.Services
{
    public interface IPieceCalculationService
    {
        List<Vector2Int> CalculateOccupiedPositions(Vector2Int initialPosition, PieceType pieceType, Direction direction, bool isFlipped);
        List<Vector2Int> CalculateAdjacentPositions(Vector2Int initialPosition, PieceType pieceType, Direction direction, bool isFlipped);
        List<Vector2Int> CalculatePlayablePositions(List<Vector2Int> adjacentPositions, PieceType pieceType);
        Vector2Int GetNextPosition(Vector2Int current, Direction direction);
        Vector2Int GetDiagonalPosition(Vector2Int current, Direction direction);
    }
}
