using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class A3Selector : Selector
    {
        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int baseCell, Direction direction, bool isFlipped)
        {
            (Vector2Int cell, int axis)[] cells = new (Vector2Int, int)[] { !isFlipped ? (baseCell, 1) : (baseCell, 3), !isFlipped ? (baseCell, 3) : (baseCell, 1) };
            return CalculatePositions(baseCell, direction, isFlipped, cells);
        }
    }
}