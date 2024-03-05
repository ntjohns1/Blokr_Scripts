using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class A5Selector : Selector
    {
        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int baseCell, Direction direction, bool isFlipped)
        {
            (Vector2Int cell, int axis)[] cells = new (Vector2Int, int)[4];
            cells[0] = !isFlipped ? (baseCell, 1) : (baseCell, 3);
            cells[1] = !isFlipped ? (baseCell, 3) : (baseCell, 1);
            List<Vector2Int> temp = CalculatePositions(baseCell, direction, isFlipped, cells);
            cells[2] = !isFlipped ? (temp[1], 1) : (temp[1], 3);
            cells[3] = !isFlipped ? (temp[2], 3) : (temp[2], 1);
            return CalculatePositions(baseCell, direction, isFlipped, cells);
        }
    }
}