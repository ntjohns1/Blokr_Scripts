using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class B5Selector : Selector
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
                Direction.Up => GetNext(cellB, Direction.Left, isFlipped),
                Direction.Right => GetNext(cellB, Direction.Up, isFlipped),
                Direction.Down => GetNext(cellB, Direction.Right, isFlipped),
                Direction.Left => GetNext(cellB, Direction.Down, isFlipped),
                _ => GetNext(cellB, Direction.Left, isFlipped),
            };
            var cellD = direction switch
            {
                Direction.Up => GetNext(cellA, Direction.Right, isFlipped),
                Direction.Right => GetNext(cellA, Direction.Down, isFlipped),
                Direction.Down => GetNext(cellA, Direction.Left, isFlipped),
                Direction.Left => GetNext(cellA, Direction.Up, isFlipped),
                _ => GetNext(cellA, Direction.Right, isFlipped),
            };
            var cellE = direction switch
            {
                Direction.Up => GetNext(cellD, Direction.Down, isFlipped),
                Direction.Right => GetNext(cellD, Direction.Left, isFlipped),
                Direction.Down => GetNext(cellD, Direction.Up, isFlipped),
                Direction.Left => GetNext(cellD, Direction.Right, isFlipped),
                _ => GetNext(cellD, Direction.Down, isFlipped),
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
