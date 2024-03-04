using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class B4Selector : Selector
    {
        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int baseCell, Direction direction, bool isFlipped)
        {

            int d = (int)direction;



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
            //         Direction.Up => GetNext(cellA, Direction.Right),
            //         Direction.Right => GetNext(cellA, Direction.Down),
            //         Direction.Down => GetNext(cellA, Direction.Left),
            //         Direction.Left => GetNext(cellA, Direction.Up),
            //         _ => GetNext(cellA, Direction.Right),
            //     };
            //     var cellD = direction switch
            //     {
            //         Direction.Up => !isFlipped ? GetNext(cellC, Direction.Down) : GetNext(cellC, Direction.Up),
            //         Direction.Right => !isFlipped ? GetNext(cellC, Direction.Left) : GetNext(cellC, Direction.Right),
            //         Direction.Down => !isFlipped ? GetNext(cellC, Direction.Up) : GetNext(cellC, Direction.Down),
            //         Direction.Left => !isFlipped ? GetNext(cellC, Direction.Right) : GetNext(cellC, Direction.Left),
            //         _ => !isFlipped ? GetNext(cellC, Direction.Down) : GetNext(cellC, Direction.Up),
            //     };
            //     List<Vector2Int> cells = new()
            // {
            //     cellA,
            //     cellB,
            //     cellC,
            //     cellD
            // };
            //     return cells;
            // };

//  TODO: Reminder the reason this is wrong is we are trying to assign the modified value before the operation has been completed, in this case CalculatePositions does the modification that would update. Could recursion help here?

            (Vector2Int cell, int axis)[] cells = new (Vector2Int, int)[3];
            cells[0] = (baseCell, 3);
            cells[1] = (baseCell,1);
            List<Vector2Int> temp = CalculatePositions(baseCell, direction, isFlipped, cells);
            cells[2] = !isFlipped ? (temp[2], 2) : (temp[2], 0);
            return CalculatePositions(baseCell, direction, isFlipped, cells);
        }
    }
}

