using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class B5Selector : Selector
    {
        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int baseCell, Direction direction, bool isFlipped)
        {
            (Vector2Int cell, int axis)[] cells = new (Vector2Int, int)[4];
            cells[0] = (baseCell, 3);
            List<Vector2Int> temp = CalculatePositions(baseCell, direction, isFlipped, cells);
            cells[1] = (temp[1], 3);
            cells[2] = (baseCell, 1);
            temp = CalculatePositions(baseCell, direction, isFlipped, cells);
            cells[3] = !isFlipped? (temp[3], 2) : (temp[3],0);
            return CalculatePositions(baseCell, direction, isFlipped, cells);
        }
    }
}
