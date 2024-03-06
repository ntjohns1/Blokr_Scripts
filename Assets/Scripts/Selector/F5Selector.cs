using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class F5Selector : Selector
    {
        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int baseCell, Direction direction, bool isFlipped)
        {
            List<(Vector2Int, int)> cells = new()
            {
                (baseCell, 1),
                (baseCell, 3),
                !isFlipped ? (baseCell, 0) : (baseCell, 2),
                !isFlipped ? (baseCell, 2) : (baseCell, 0)
            };
            return CalculatePositions(baseCell, direction, cells);
        }
    }
}