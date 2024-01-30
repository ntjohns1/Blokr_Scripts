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
                Direction.Up => GetNext(cellA, Direction.Right, isFlipped),
                Direction.Right => GetNext(cellA, Direction.Down, isFlipped),
                Direction.Down => GetNext(cellA, Direction.Left, isFlipped),
                Direction.Left => GetNext(cellA, Direction.Up, isFlipped),
                _ => GetNext(cellA, Direction.Right, isFlipped),
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