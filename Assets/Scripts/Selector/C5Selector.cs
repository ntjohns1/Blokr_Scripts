using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class C5Selector : Selector
    {
        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int baseCell, Direction direction, bool isFlipped)
        {
            List<(Vector2Int, int)> cells = new()
            {
                !isFlipped ? (baseCell, 0) : (baseCell, 2),
                (baseCell, 1)
            };
            List<Vector2Int> temp = CalculatePositions(baseCell, direction, cells);
            cells.Add((temp[1], 3));
            temp = CalculatePositions(baseCell, direction, cells);
            cells.Add((temp[3], 3));
            return CalculatePositions(baseCell, direction, cells);
        }
    }
}