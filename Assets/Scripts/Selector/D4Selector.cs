using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class D4Selector : Selector
    {
        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int baseCell, Direction direction, bool isFlipped)
        {
            (Vector2Int, int)[] cells = new (Vector2Int, int)[3];
            cells[0] = (baseCell, 1);
            cells[1] = !isFlipped ? (baseCell, 0) : (baseCell, 2);
            List<Vector2Int> temp = CalculatePositions(baseCell, direction, isFlipped, cells);
            cells[2] = !isFlipped ? (temp[1], 0) : (temp[1], 2);
            return CalculatePositions(baseCell, direction, isFlipped, cells);
        }
    }
}