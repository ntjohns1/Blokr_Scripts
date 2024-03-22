using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class A5Selector : Selector, ISelector
    {
        public override List<Vector2Int> CalculatePlayablePositions(Vector2Int gridpoint, Direction direction, bool isFlipped)
        {
            throw new System.NotImplementedException();
        }

        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int baseCell, Direction direction, bool isFlipped)
        {
            List<(Vector2Int cell, int axis)> cells = new()
            {
                !isFlipped ? (baseCell, 1) : (baseCell, 3),
                !isFlipped ? (baseCell, 3) : (baseCell, 1)
            };
            List<Vector2Int> temp = CalculatePositions(baseCell,direction,cells);
            cells.Add(!isFlipped ? (temp[1], 1) : (temp[1], 3));
            cells.Add(!isFlipped ? (temp[2], 3) : (temp[2], 1));
            return CalculatePositions(baseCell, direction, cells);
        }
    }
}