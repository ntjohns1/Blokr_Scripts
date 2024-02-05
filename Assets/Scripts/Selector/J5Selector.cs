using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class J5Selector : Selector
    {
        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int cellA, Direction direction, bool isFlipped)
        {

            var cellB = direction switch
            {
                Direction.Up => GetNext(cellA, Direction.Left),
                Direction.Right => GetNext(cellA, Direction.Up),
                Direction.Down => GetNext(cellA, Direction.Right),
                Direction.Left => GetNext(cellA, Direction.Down),
                _ => GetNext(cellA, Direction.Left),
            };
            var cellC = direction switch
            {
                Direction.Up => GetNext(cellA, Direction.Right),
                Direction.Right => GetNext(cellA, Direction.Down),
                Direction.Down => GetNext(cellA, Direction.Left),
                Direction.Left => GetNext(cellA, Direction.Up),
                _ => GetNext(cellA, Direction.Right),
            };
            var cellD = direction switch
            {
                Direction.Up => !isFlipped ? GetNext(cellC, Direction.Down) : GetNext(cellC, Direction.Up),
                Direction.Right => !isFlipped ? GetNext(cellC, Direction.Left) : GetNext(cellC, Direction.Right),
                Direction.Down => !isFlipped ? GetNext(cellC, Direction.Up) : GetNext(cellC, Direction.Down),
                Direction.Left => !isFlipped ? GetNext(cellC, Direction.Right) : GetNext(cellC, Direction.Left),
                _ => !isFlipped ? GetNext(cellC, Direction.Down) : GetNext(cellC, Direction.Up),
            };
            var cellE = direction switch
            {
                Direction.Up => !isFlipped ? GetNext(cellB, Direction.Up) : GetNext(cellB, Direction.Down),
                Direction.Right => !isFlipped ? GetNext(cellB, Direction.Right) : GetNext(cellB, Direction.Left),
                Direction.Down => !isFlipped ? GetNext(cellB, Direction.Down) : GetNext(cellB, Direction.Up),
                Direction.Left => !isFlipped ? GetNext(cellB, Direction.Left) : GetNext(cellB, Direction.Right),
                _ => !isFlipped ? GetNext(cellB, Direction.Up) : GetNext(cellB, Direction.Down),
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