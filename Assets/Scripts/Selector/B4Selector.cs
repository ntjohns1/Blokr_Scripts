using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class B4Selector : Selector
    {
        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int cellA, Direction direction, bool isFlipped)
        {
            var cellB = direction switch
            {
                Direction.Up => !isFlipped ? GetNext(cellA, Direction.Left) : GetNext(cellA, Direction.Right),
                Direction.Right => !isFlipped ? GetNext(cellA, Direction.Up) : GetNext(cellA, Direction.Down),
                Direction.Down => !isFlipped ? GetNext(cellA, Direction.Right) : GetNext(cellA, Direction.Left),
                Direction.Left => ! isFlipped ? GetNext(cellA, Direction.Down) : GetNext(cellA, Direction.Up),
                _ => !isFlipped ? GetNext(cellA, Direction.Left) : GetNext(cellA, Direction.Right),
            };
            var cellC = direction switch
            {
                Direction.Up => !isFlipped ? GetNext(cellA, Direction.Right) : GetNext(cellA, Direction.Left),
                Direction.Right => !isFlipped ? GetNext(cellA, Direction.Down) : GetNext(cellA, Direction.Up),
                Direction.Down => !isFlipped ? GetNext(cellA, Direction.Left) : GetNext(cellA, Direction.Right),
                Direction.Left => !isFlipped ? GetNext(cellA, Direction.Up) : GetNext(cellA, Direction.Down),
                _ => GetNext(cellA, Direction.Right),
            };
            var cellD = direction switch
            {
                Direction.Up => GetNext(cellC, Direction.Down),
                Direction.Right => GetNext(cellC, Direction.Left),
                Direction.Down => GetNext(cellC, Direction.Up),
                Direction.Left => GetNext(cellC, Direction.Right),
                _ => GetNext(cellC, Direction.Down),
            };
            List<Vector2Int> cells = new()
        {
            cellA,
            cellB,
            cellC,
            cellD
        };
            return cells;
        }
    }
}