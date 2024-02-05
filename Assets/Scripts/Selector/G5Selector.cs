using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class G5Selector : Selector
    {
        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int cellA, Direction direction, bool isFlipped)
        {
            var cellB = direction switch
            {
                Direction.Up => GetNext(cellA, Direction.Right),
                Direction.Right => GetNext(cellA, Direction.Down),
                Direction.Down => GetNext(cellA, Direction.Left),
                Direction.Left => GetNext(cellA, Direction.Up),
                _ => GetNext(cellA, Direction.Right),
            };
            var cellC = direction switch
            {
                Direction.Up => GetNext(cellB, Direction.Right),
                Direction.Right => GetNext(cellB, Direction.Down),
                Direction.Down => GetNext(cellB, Direction.Left),
                Direction.Left => GetNext(cellB, Direction.Up),
                _ => GetNext(cellB, Direction.Left)
            };
            var cellD = direction switch
            {
                Direction.Up => !isFlipped ? GetNext(cellA, Direction.Up) : GetNext(cellA, Direction.Down),
                Direction.Right => !isFlipped ? GetNext(cellA, Direction.Right) : GetNext(cellA, Direction.Left),
                Direction.Down => !isFlipped ? GetNext(cellA, Direction.Down) : GetNext(cellA, Direction.Up),
                Direction.Left => !isFlipped ? GetNext(cellA, Direction.Left) : GetNext(cellA, Direction.Right),
                _ => !isFlipped ? GetNext(cellA, Direction.Up) : GetNext(cellA, Direction.Down),
            };
            var cellE = direction switch
            {
                Direction.Up => !isFlipped ? GetNext(cellD, Direction.Up) : GetNext(cellD, Direction.Down),
                Direction.Right => !isFlipped ? GetNext(cellD, Direction.Right) : GetNext(cellD, Direction.Left),
                Direction.Down => !isFlipped ? GetNext(cellD, Direction.Down) : GetNext(cellD, Direction.Up),
                Direction.Left => !isFlipped ? GetNext(cellD, Direction.Left) : GetNext(cellD, Direction.Right),
                _ => !isFlipped ? GetNext(cellD, Direction.Up) : GetNext(cellD, Direction.Down),
            };

            List<Vector2Int> cells = new()
        {
            cellA,
            cellB,
            cellC,
            cellD,
            cellE
        };
            return cells;
        }
    }
}