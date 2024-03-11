using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class B5Selector : Selector, ISelector
    {
        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int baseCell, Direction direction, bool isFlipped)
        {
            List<(Vector2Int, int)> cells = new()
            {
                (baseCell, 3)
            };
            List<Vector2Int> temp = CalculatePositions(baseCell, direction, cells);
            cells.Add( (temp[1], 3));
            cells.Add( (baseCell, 1));
            temp = CalculatePositions(baseCell, direction, cells);
            cells.Add( !isFlipped? (temp[3], 2) : (temp[3],0));
            return CalculatePositions(baseCell, direction, cells);
        }
    }
}
