using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class A3Selector : Selector
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
            var cellC = direction switch
            {
                Direction.Up => GetNext(cellA, Direction.Left, isFlipped),
                Direction.Right => GetNext(cellA, Direction.Up, isFlipped),
                Direction.Down => GetNext(cellA, Direction.Right, isFlipped),
                Direction.Left => GetNext(cellA, Direction.Down, isFlipped),
                _ => GetNext(cellA, Direction.Left, isFlipped),
            };
            List<Vector2Int> cells = new()
        {
            cellA,
            cellB,
            cellC
        };
            return cells;
        }
    }
}