using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class C4Selector : Selector
    {
        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int baseCell, Direction direction, bool isFlipped)
        {
            (Vector2Int cell, int axis)[] cells = new (Vector2Int, int)[3];
            cells[0] = !isFlipped ? (baseCell, 0) : (baseCell, 2);
            cells[1] = (baseCell, 1);
            List<Vector2Int> temp = CalculatePositions(baseCell, direction, isFlipped, cells);
            cells[2] = (temp[1], 3);
            return CalculatePositions(baseCell, direction, isFlipped, cells);
        }
    }
}