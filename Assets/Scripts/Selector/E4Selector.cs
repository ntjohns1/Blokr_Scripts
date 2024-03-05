using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class E4Selector : Selector
    {
        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int baseCell, Direction direction, bool isFlipped)
        {
            (Vector2Int cell, int axis)[] cells = new (Vector2Int, int)[3];
            cells[0] = (baseCell, 1);
            cells[1] = (baseCell, 3);
            cells[2] = !isFlipped ? (baseCell, 0) : (baseCell, 2);
            return CalculatePositions(baseCell, direction, isFlipped, cells);
        }
    }
}