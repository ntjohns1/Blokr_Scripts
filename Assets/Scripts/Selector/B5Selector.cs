using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class B5Selector : Selector
    {
        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int baseCell, Direction direction, bool isFlipped)
        {
            //     var cellB = direction switch
            //     {
            //         Direction.Up => GetNext(cellA, Direction.Left),
            //         Direction.Right => GetNext(cellA, Direction.Up),
            //         Direction.Down => GetNext(cellA, Direction.Right),
            //         Direction.Left => GetNext(cellA, Direction.Down),
            //         _ => GetNext(cellA, Direction.Left),
            //     };
            //     var cellC = direction switch
            //     {
            //         Direction.Up => GetNext(cellB, Direction.Left),
            //         Direction.Right => GetNext(cellB, Direction.Up),
            //         Direction.Down => GetNext(cellB, Direction.Right),
            //         Direction.Left => GetNext(cellB, Direction.Down),
            //         _ => GetNext(cellB, Direction.Left),
            //     };
            //     var cellD = direction switch
            //     {
            //         Direction.Up => GetNext(cellA, Direction.Right),
            //         Direction.Right => GetNext(cellA, Direction.Down),
            //         Direction.Down => GetNext(cellA, Direction.Left),
            //         Direction.Left => GetNext(cellA, Direction.Up),
            //         _ => GetNext(cellA, Direction.Right),
            //     };
            //     var cellE = direction switch
            //     {
            //         Direction.Up => !isFlipped ? GetNext(cellD, Direction.Down) : GetNext(cellD, Direction.Up),
            //         Direction.Right => !isFlipped ? GetNext(cellD, Direction.Left) : GetNext(cellD, Direction.Right),
            //         Direction.Down => !isFlipped ? GetNext(cellD, Direction.Up) : GetNext(cellD, Direction.Down),
            //         Direction.Left => !isFlipped ? GetNext(cellD, Direction.Right) : GetNext(cellD, Direction.Left),
            //         _ => !isFlipped ? GetNext(cellD, Direction.Down) : GetNext(cellD, Direction.Up),
            //     };
            //     List<Vector2Int> cells = new()
            // {
            //     cellA,
            //     cellB,
            //     cellC,
            //     cellD,
            //     cellE
            // };
            //     return cells;
            (Vector2Int cell, int axis)[] cells = new (Vector2Int, int)[4];
            cells[0] = (baseCell, 1);
            cells[1] = (baseCell, 3);
            cells[2] = (cells[0].cell, 1);
            cells[3] = (cells[1].cell, 3);
            return CalculatePositions(baseCell, direction, isFlipped, cells);
        }
    }
}
