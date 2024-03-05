using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class B4Selector : Selector
    {
        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int baseCell, Direction direction, bool isFlipped)
        {
            (Vector2Int cell, int axis)[] cells = new (Vector2Int, int)[3];
            cells[0] = (baseCell, 3);
            cells[1] = (baseCell,1);
            List<Vector2Int> temp = CalculatePositions(baseCell, direction, isFlipped, cells);
            cells[2] = !isFlipped ? (temp[2], 2) : (temp[2], 0);
            return CalculatePositions(baseCell, direction, isFlipped, cells);
        }
    }
}

