using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class B3Selector : Selector
    {
        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int baseCell, Direction direction, bool isFlipped)
        {

            //     var cellB = direction switch
            //     {
            //         Direction.Up => GetNext(cellA, Direction.Right),
            //         Direction.Right => GetNext(cellA, Direction.Down),
            //         Direction.Down => GetNext(cellA, Direction.Left),
            //         Direction.Left => GetNext(cellA, Direction.Up),
            //         _ => GetNext(cellA, Direction.Right),
            //     };
            //     var cellC = direction switch
            //     {
            //         Direction.Up => !isFlipped ? GetNext(cellA, Direction.Up) : GetNext(cellA, Direction.Down),
            //         Direction.Right => !isFlipped ? GetNext(cellA, Direction.Right) : GetNext(cellA, Direction.Left),
            //         Direction.Down => !isFlipped ? GetNext(cellA, Direction.Down) : GetNext(cellA, Direction.Up),
            //         Direction.Left => !isFlipped ? GetNext(cellA, Direction.Left) : GetNext(cellA, Direction.Right),
            //         _ => !isFlipped ? GetNext(cellA, Direction.Up) : GetNext(cellA, Direction.Down),
            //     };
            //     List<Vector2Int> cells = new()
            // {
            //     cellA,
            //     cellB,
            //     cellC
            // };
            //     return cells;
            (Vector2Int cell, int axis)[] cells = new (Vector2Int, int)[] { (baseCell, 3), (baseCell, 0) };
            return CalculatePositions(baseCell, direction, isFlipped, cells);
        }
    }
}