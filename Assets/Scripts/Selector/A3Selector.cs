using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class A3Selector : Selector, ISelector
    {
        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int baseCell, Direction direction, bool isFlipped)
        {
            List<(Vector2Int cell, int axis)> cells = new() { !isFlipped ? (baseCell, 1) : (baseCell, 3), !isFlipped ? (baseCell, 3) : (baseCell, 1) };
            return CalculatePositions(baseCell, direction, cells);
        }
    }
}