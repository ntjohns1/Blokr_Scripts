using System.Collections.Generic;
using Blokr.Core.Models;

namespace Blokr.Highlighter
{
    public delegate List<GridPosition> CalculatePositions(GridPosition initialCell, Direction direction, List<(GridPosition, int)> positions);

    public abstract class PlacementHighlighter
    {
        protected GridPosition GetNext(GridPosition current, Direction direction)
        {
            return direction switch
            {
                Direction.Up => new GridPosition(current.x, current.y + 1),
                Direction.Right => new GridPosition(current.x + 1, current.y),
                Direction.Down => new GridPosition(current.x, current.y - 1),
                Direction.Left => new GridPosition(current.x - 1, current.y),
                _ => current
            };
        }

        protected List<GridPosition> CalculatePositions(GridPosition initialCell, Direction direction, List<(GridPosition, int)> positions)
        {
            List<GridPosition> output = new();
            GridPosition current = initialCell;

            foreach ((GridPosition offset, int steps) in positions)
            {
                for (int i = 0; i < steps; i++)
                {
                    current = GetNext(current, direction);
                }
                output.Add(new GridPosition(current.x + offset.x, current.y + offset.y));
                current = initialCell;
            }

            return output;
        }

        public abstract List<GridPosition> CalculateAdjacentPositions(GridPosition gridpoint, Direction direction, bool isFlipped);
        
        public abstract List<GridPosition> CalculatePlayablePositions(List<GridPosition> adjacentPositions);
        
        public abstract List<GridPosition> GetOccupiedGridPositions(GridPosition baseCell, Direction direction, bool isFlipped);
    }
}
