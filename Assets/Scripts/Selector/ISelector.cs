using System.Collections;
using System.Collections.Generic;
using Blokr.Core.Models;


namespace Blokr
{

    public interface ISelector
    {
        public List<GridPosition> GetOccupiedGridPositions(GridPosition gridPoint, Direction direction, bool isFlipped);
        public List<GridPosition> CalculateAdjacentPositions(GridPosition gridpoint, Direction direction, bool isFlipped);
        public List<GridPosition> CalculatePlayablePositions(List<GridPosition> adjacentPositions);
    }
}
