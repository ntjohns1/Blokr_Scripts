using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class E5Selector : Selector
    {
        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int baseCell, Direction direction, bool isFlipped)
        {
            List<(Vector2Int, int)> cells = new()
            {
                (baseCell, 1),
                (baseCell, 3),
                !isFlipped ? (baseCell, 0) : (baseCell, 2)
            };
            List<Vector2Int> temp = CalculatePositions(baseCell, direction, cells);
            cells.Add( !isFlipped ? (temp[3], 0) : (temp[3], 2));
            return CalculatePositions(baseCell, direction, cells);        }
    }
}