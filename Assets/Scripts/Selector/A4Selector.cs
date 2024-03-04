using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class A4Selector : Selector
    {
        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int baseCell, Direction direction, bool isFlipped)
        {

            //     var cellB = direction switch
            //     {
            //         Direction.Up => !isFlipped ? GetNext(cellA, Direction.Right) : GetNext(cellA, Direction.Left),
            //         Direction.Right => !isFlipped ? GetNext(cellA, Direction.Down): GetNext(cellA, Direction.Up),
            //         Direction.Down => !isFlipped ? GetNext(cellA, Direction.Left) : GetNext(cellA, Direction.Right),
            //         Direction.Left => !isFlipped ? GetNext(cellA, Direction.Up) : GetNext(cellA, Direction.Down),
            //         _ => !isFlipped ? GetNext(cellA, Direction.Right) : GetNext(cellA, Direction.Left),
            //     };
            //     var cellC = direction switch
            //     {
            //         Direction.Up => !isFlipped ? GetNext(cellA, Direction.Left) : GetNext(cellA, Direction.Right),
            //         Direction.Right => !isFlipped ? GetNext(cellA, Direction.Up) : GetNext(cellA, Direction.Down),
            //         Direction.Down => !isFlipped ? GetNext(cellA, Direction.Right) : GetNext(cellA, Direction.Left),
            //         Direction.Left => !isFlipped ? GetNext(cellA, Direction.Down) : GetNext(cellA, Direction.Up),
            //         _ => !isFlipped ? GetNext(cellA, Direction.Left) : GetNext(cellA, Direction.Right),
            //     };            var cellD = direction switch
            //     {
            //        Direction.Up => !isFlipped ? GetNext(cellB, Direction.Right) : GetNext(cellB, Direction.Left),
            //         Direction.Right => !isFlipped ? GetNext(cellB, Direction.Down): GetNext(cellB, Direction.Up),
            //         Direction.Down => !isFlipped ? GetNext(cellB, Direction.Left) : GetNext(cellB, Direction.Right),
            //         Direction.Left => !isFlipped ? GetNext(cellB, Direction.Up) : GetNext(cellB, Direction.Down),
            //         _ => !isFlipped ? GetNext(cellB, Direction.Right) : GetNext(cellB, Direction.Left),
            //     };
            //     List<Vector2Int> cells = new()
            // {
            //     cellA,
            //     cellB,
            //     cellC,
            //     cellD
            // };
            //     return cells;
            (Vector2Int cell, int)[] cells = new (Vector2Int, int)[3];
            cells[0] = (baseCell, 1);
            cells[1] = (baseCell, 3);
            cells[2] = (cells[0].cell, 1);
            return CalculatePositions(baseCell, direction, isFlipped, cells);
        }
    }
}