using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class G5Selector : Selector
    {
        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int baseCell, Direction direction, bool isFlipped)
        {
            List<(Vector2Int, int)> cells = new()
            {
                (baseCell, 1)
            };
            List<Vector2Int> temp = CalculatePositions(baseCell, direction, cells);
            cells.Add((temp[1], 1));
            cells.Add(!isFlipped ? (baseCell, 0) : (baseCell, 2));
            temp = CalculatePositions(baseCell, direction, cells);
            cells.Add(!isFlipped ? (temp[3], 0) : (temp[3], 2));
            return CalculatePositions(baseCell, direction, cells);
        }
    }
}