using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class A2Selector : Selector
    {
        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int cellA, Direction direction, bool isFlipped)
        {
            var cellB = direction switch
            {
                Direction.Up => !isFlipped ? GetNext(cellA, Direction.Right) : GetNext(cellA, Direction.Left),
                Direction.Right => !isFlipped ? GetNext(cellA, Direction.Down): GetNext(cellA, Direction.Up),
                Direction.Down => !isFlipped ? GetNext(cellA, Direction.Left) : GetNext(cellA, Direction.Right),
                Direction.Left => !isFlipped ? GetNext(cellA, Direction.Up) : GetNext(cellA, Direction.Down),
                _ => !isFlipped ? GetNext(cellA, Direction.Right) : GetNext(cellA, Direction.Left),
            };
            List<Vector2Int> cells = new()
        {
            cellA,
            cellB
        };
            return cells;
        }
    }
}