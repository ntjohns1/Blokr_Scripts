using System.Collections.Generic;
using UnityEngine;

namespace Blokr.Core.Services
{
    public class PieceCalculationService : IPieceCalculationService
    {
        private readonly Dictionary<PieceType, (List<(Vector2Int, int)> positions, int size)> _pieceDefinitions;

        public PieceCalculationService()
        {
            _pieceDefinitions = new Dictionary<PieceType, (List<(Vector2Int, int)> positions, int size)>();
            InitializePieceDefinitions();
        }

        private void InitializePieceDefinitions()
        {
            // Example for piece D4 (you'll need to add all piece definitions)
            _pieceDefinitions[PieceType.D4] = (new List<(Vector2Int, int)>
            {
                (new Vector2Int(0, 1), 0),  // Up from initial
                (new Vector2Int(1, 0), 1),  // Right from first point
                (new Vector2Int(1, 0), 1)   // Right from second point
            }, 4);

            // Add other piece definitions here...
        }

        public List<Vector2Int> CalculateOccupiedPositions(Vector2Int initialPosition, PieceType pieceType, Direction direction, bool isFlipped)
        {
            if (!_pieceDefinitions.TryGetValue(pieceType, out var definition))
            {
                return new List<Vector2Int> { initialPosition };
            }

            var positions = new List<Vector2Int> { initialPosition };
            var baseAxis = (int)direction;

            foreach (var (offset, relativeAxis) in definition.positions)
            {
                var currentPos = positions[positions.Count - 1];
                var newAxis = (baseAxis + (isFlipped ? -relativeAxis : relativeAxis)) % 4;
                positions.Add(GetNextPosition(currentPos, (Direction)newAxis));
            }

            return positions;
        }

        public List<Vector2Int> CalculateAdjacentPositions(Vector2Int initialPosition, PieceType pieceType, Direction direction, bool isFlipped)
        {
            var occupiedPositions = CalculateOccupiedPositions(initialPosition, pieceType, direction, isFlipped);
            var adjacentPositions = new HashSet<Vector2Int>();

            foreach (var pos in occupiedPositions)
            {
                // Add orthogonally adjacent positions
                foreach (Direction dir in System.Enum.GetValues(typeof(Direction)))
                {
                    var adjacent = GetNextPosition(pos, dir);
                    if (!occupiedPositions.Contains(adjacent))
                    {
                        adjacentPositions.Add(adjacent);
                    }
                }

                // Add diagonally adjacent positions
                for (int i = 0; i < 4; i++)
                {
                    var diagonal = GetDiagonalPosition(pos, (Direction)i);
                    if (!occupiedPositions.Contains(diagonal))
                    {
                        adjacentPositions.Add(diagonal);
                    }
                }
            }

            return new List<Vector2Int>(adjacentPositions);
        }

        public List<Vector2Int> CalculatePlayablePositions(List<Vector2Int> adjacentPositions, PieceType pieceType)
        {
            // This will vary by piece type - implement the specific rules
            // For now, returning a subset of adjacent positions
            var playablePositions = new List<Vector2Int>();
            
            // Example logic - can be customized per piece type
            for (int i = 0; i < adjacentPositions.Count; i += 2)
            {
                if (i < adjacentPositions.Count)
                {
                    playablePositions.Add(adjacentPositions[i]);
                }
            }

            return playablePositions;
        }

        public Vector2Int GetNextPosition(Vector2Int current, Direction direction)
        {
            return direction switch
            {
                Direction.Up => new Vector2Int(current.x, current.y + 1),
                Direction.Right => new Vector2Int(current.x + 1, current.y),
                Direction.Down => new Vector2Int(current.x, current.y - 1),
                Direction.Left => new Vector2Int(current.x - 1, current.y),
                _ => current,
            };
        }

        public Vector2Int GetDiagonalPosition(Vector2Int current, Direction direction)
        {
            return direction switch
            {
                Direction.Up => new Vector2Int(current.x + 1, current.y + 1),
                Direction.Right => new Vector2Int(current.x + 1, current.y - 1),
                Direction.Down => new Vector2Int(current.x - 1, current.y - 1),
                Direction.Left => new Vector2Int(current.x - 1, current.y + 1),
                _ => current,
            };
        }
    }
}
