using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class D4Selector : Selector
    {
        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int baseCell, Direction direction, bool isFlipped)
        {
            List<(Vector2Int, int)> cells = new()
            {
                (baseCell, 1),
                !isFlipped ? (baseCell, 0) : (baseCell, 2)
            };
            List<Vector2Int> temp = CalculatePositions(baseCell, direction, cells);
            cells.Add(!isFlipped ? (temp[1], 0) : (temp[1], 2));
            return CalculatePositions(baseCell, direction, cells);
        }
    }
}