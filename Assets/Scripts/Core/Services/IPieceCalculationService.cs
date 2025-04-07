using System.Collections.Generic;
using Blokr.Core.Models;

namespace Blokr.Core.Services
{
    public interface IPieceCalculationService
    {
        List<GridPosition> CalculateOccupiedPositions(GridPosition initialPosition, PieceType pieceType, Direction direction, bool isFlipped);
        List<GridPosition> CalculateAdjacentPositions(GridPosition initialPosition, PieceType pieceType, Direction direction, bool isFlipped);
        List<GridPosition> CalculatePlayablePositions(List<GridPosition> adjacentPositions, PieceType pieceType);
        GridPosition GetNextPosition(GridPosition current, Direction direction);
        GridPosition GetDiagonalPosition(GridPosition current, Direction direction);
    }
}
