using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class L5Selector : Selector
    {
        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int baseCell, Direction direction, bool isFlipped)
        {
            (Vector2Int cell, int axis)[] cells = new (Vector2Int, int)[4];
            cells[0] = (baseCell, 1);
            cells[1] = (baseCell, 3);
            cells[2] = !isFlipped ? (baseCell, 2) : (baseCell, 0);
            List<Vector2Int> temp = CalculatePositions(baseCell, direction, isFlipped, cells);
            cells[3] = !isFlipped ? (temp[2], 0) : (temp[2], 2);
            return CalculatePositions(baseCell, direction, isFlipped, cells);
        }
    }
}