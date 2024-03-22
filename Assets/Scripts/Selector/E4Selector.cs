using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class E4Selector : Selector, ISelector
    {
        public override List<Vector2Int> CalculatePlayablePositions(Vector2Int gridpoint, Direction direction, bool isFlipped)
        {
            throw new System.NotImplementedException();
        }

        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int baseCell, Direction direction, bool isFlipped)
        {
            List<(Vector2Int, int)> cells = new() { (baseCell, 1), (baseCell, 3), !isFlipped ? (baseCell, 0) : (baseCell, 2) };
            return CalculatePositions(baseCell, direction, cells);
        }
    }
}