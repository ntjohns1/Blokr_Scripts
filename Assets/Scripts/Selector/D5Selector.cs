using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class D5Selector : Selector
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
                Direction.Up => !isFlipped ? GetNext(cellA, Direction.Up) : GetNext(cellA, Direction.Down),
                Direction.Right => !isFlipped ? GetNext(cellA, Direction.Right) : GetNext(cellA, Direction.Left),
                Direction.Down => !isFlipped ? GetNext(cellA, Direction.Down) : GetNext(cellA, Direction.Up),
                Direction.Left => !isFlipped ? GetNext(cellA, Direction.Left) : GetNext(cellA, Direction.Right),
                _ => !isFlipped ? GetNext(cellA, Direction.Up) : GetNext(cellA, Direction.Down),
            };
            var cellD = direction switch
            {
                Direction.Up => !isFlipped ? GetNext(cellB, Direction.Up) : GetNext(cellB, Direction.Down),
                Direction.Right => !isFlipped ? GetNext(cellB, Direction.Right) : GetNext(cellB, Direction.Left),
                Direction.Down => !isFlipped ? GetNext(cellB, Direction.Down) : GetNext(cellB, Direction.Up),
                Direction.Left => !isFlipped ? GetNext(cellB, Direction.Left) : GetNext(cellB, Direction.Right),
                _ => !isFlipped ? GetNext(cellB, Direction.Up) : GetNext(cellB, Direction.Down),
            };

            var cellE = direction switch
            {
                Direction.Up => GetNext(cellA, Direction.Left),
                Direction.Right => GetNext(cellA, Direction.Up),
                Direction.Down => GetNext(cellA, Direction.Right),
                Direction.Left => GetNext(cellA, Direction.Down),
                _ => GetNext(cellA, Direction.Left),
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