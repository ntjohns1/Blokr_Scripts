using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{

    public interface ISelector
    {
        public List<Vector2Int> GetOccupiedGridPositions(Vector2Int gridPoint, Direction direction, bool isFlipped);
        public List<Vector2Int> CalculateAdjacentPositions(Vector2Int gridpoint, Direction direction, bool isFlipped);
        public List<Vector2Int> CalculatePlayablePositions(List<Vector2Int> adjacentPositions);
    }
}
