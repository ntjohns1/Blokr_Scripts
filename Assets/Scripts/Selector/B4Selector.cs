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
                Direction.Up => GetNext(cellA, Direction.Left, isFlipped),
                Direction.Right => GetNext(cellA, Direction.Up, isFlipped),
                Direction.Down => GetNext(cellA, Direction.Right, isFlipped),
                Direction.Left => GetNext(cellA, Direction.Down, isFlipped),
                _ => GetNext(cellA, Direction.Left, isFlipped),
            };
            var cellC = direction switch
            {
                Direction.Up => GetNext(cellA, Direction.Right, isFlipped),
                Direction.Right => GetNext(cellA, Direction.Down, isFlipped),
                Direction.Down => GetNext(cellA, Direction.Left, isFlipped),
                Direction.Left => GetNext(cellA, Direction.Up, isFlipped),
                _ => GetNext(cellA, Direction.Right, isFlipped),
            };
            var cellD = direction switch
            {
                Direction.Up => GetNext(cellC, Direction.Down, isFlipped),
                Direction.Right => GetNext(cellC, Direction.Left, isFlipped),
                Direction.Down => GetNext(cellC, Direction.Up, isFlipped),
                Direction.Left => GetNext(cellC, Direction.Right, isFlipped),
                _ => GetNext(cellC, Direction.Down, isFlipped),
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