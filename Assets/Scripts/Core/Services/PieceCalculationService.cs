using System.Collections.Generic;
using Blokr.Core.Models;

namespace Blokr.Core.Services
{
    public class PieceCalculationService : IPieceCalculationService
    {
        private readonly Dictionary<PieceType, PieceDefinition> _pieceDefinitions;

        public PieceCalculationService()
        {
            _pieceDefinitions = new Dictionary<PieceType, PieceDefinition>();
            InitializePieceDefinitions();
        }

        private void InitializePieceDefinitions()
        {
            // Initialize D4 (T-shaped piece)
            _pieceDefinitions[PieceType.D4] = PieceDefinition.CreateTPiece(PieceType.D4, 2, 3);
            
            // Add other piece definitions here...
        }

        public List<GridPosition> CalculateOccupiedPositions(GridPosition initialPosition, PieceType pieceType, Direction direction, bool isFlipped)
        {
            if (!_pieceDefinitions.TryGetValue(pieceType, out var definition))
            {
                return new List<GridPosition> { initialPosition };
            }

            var positions = new List<GridPosition> { initialPosition };

            foreach (var cell in definition.Cells)
            {
                var offset = cell.Offset;
                var newDirection = isFlipped ? 
                    direction.Rotate(-cell.RelativeRotation) : 
                    direction.Rotate(cell.RelativeRotation);
                
                positions.Add(GetNextPosition(positions[positions.Count - 1], newDirection));
            }

            return positions;
        }

        public List<GridPosition> CalculateAdjacentPositions(GridPosition initialPosition, PieceType pieceType, Direction direction, bool isFlipped)
        {
            var occupiedPositions = CalculateOccupiedPositions(initialPosition, pieceType, direction, isFlipped);
            var adjacentPositions = new HashSet<GridPosition>();

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

            return new List<GridPosition>(adjacentPositions);
        }

        public List<GridPosition> CalculatePlayablePositions(List<GridPosition> adjacentPositions, PieceType pieceType)
        {
            if (!_pieceDefinitions.TryGetValue(pieceType, out var definition))
            {
                return new List<GridPosition>();
            }

            var playablePositions = new List<GridPosition>();
            foreach (var index in definition.PlayablePositionIndices)
            {
                if (index < adjacentPositions.Count)
                {
                    playablePositions.Add(adjacentPositions[index]);
                }
            }

            return playablePositions;
        }

        public GridPosition GetNextPosition(GridPosition current, Direction direction)
        {
            return direction switch
            {
                Direction.Up => new GridPosition(current.X, current.Y + 1),
                Direction.Right => new GridPosition(current.X + 1, current.Y),
                Direction.Down => new GridPosition(current.X, current.Y - 1),
                Direction.Left => new GridPosition(current.X - 1, current.Y),
                _ => current,
            };
        }

        public GridPosition GetDiagonalPosition(GridPosition current, Direction direction)
        {
            return direction switch
            {
                Direction.Up => new GridPosition(current.X + 1, current.Y + 1),
                Direction.Right => new GridPosition(current.X + 1, current.Y - 1),
                Direction.Down => new GridPosition(current.X - 1, current.Y - 1),
                Direction.Left => new GridPosition(current.X - 1, current.Y + 1),
                _ => current,
            };
        }
    }
}
