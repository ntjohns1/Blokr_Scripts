using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class B3Selector : Selector
    {
        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int baseCell, Direction direction, bool isFlipped)
        {
            (Vector2Int cell, int axis)[] cells = new (Vector2Int, int)[] { (baseCell, 1), !isFlipped ? (baseCell, 0) : (baseCell, 2) };
            return CalculatePositions(baseCell, direction, isFlipped, cells);
        }
    }
}