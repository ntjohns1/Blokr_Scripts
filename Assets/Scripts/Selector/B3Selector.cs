using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class B3Selector : Selector, ISelector
    {
        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int baseCell, Direction direction, bool isFlipped)
        {
            List<(Vector2Int cell, int axis)> cells = new() { (baseCell, 1), !isFlipped ? (baseCell, 0) : (baseCell, 2) };
            return CalculatePositions(baseCell, direction, cells);
        }
    }
}