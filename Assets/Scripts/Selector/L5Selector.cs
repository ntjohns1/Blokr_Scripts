using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class L5Selector : Selector, ISelector
    {

        public static int Size { get { return 5; } }
        
        public override List<Vector2Int> CalculateAdjacentPositions(Vector2Int gridpoint, Direction direction, bool isFlipped)
        {
            Direction OffsetAxis(Direction offset)
            {
                return (Direction)(((int)direction + (int)offset) % 4);
            }
            List<Vector2Int> output = new()
            {
                GetNext(gridpoint,OffsetAxis(!isFlipped?Direction.Up:Direction.Down))
            };
            Direction[] refDirections =
            {
                !isFlipped?Direction.Up:Direction.Down,
                Direction.Left,
                Direction.Left,
                !isFlipped?Direction.Down:Direction.Up,
                !isFlipped?Direction.Down:Direction.Up,
                !isFlipped?Direction.Down:Direction.Up,
                Direction.Right,
                !isFlipped?Direction.Down:Direction.Up,
                Direction.Right,
                Direction.Right,
                !isFlipped?Direction.Up:Direction.Down,
                Direction.Right,
                !isFlipped?Direction.Up:Direction.Down,
                !isFlipped?Direction.Up:Direction.Down,
                Direction.Left
            };

            for (int i = 0; i < refDirections.Length; i++)
            {
                output.Add(GetNext(output[i], OffsetAxis(refDirections[i])));

            }
            return output;
        }

        public override List<Vector2Int> CalculatePlayablePositions(List<Vector2Int> adjacentPositions)
        {
            return new() {adjacentPositions[1],adjacentPositions[3],adjacentPositions[6],adjacentPositions[8],adjacentPositions[10],adjacentPositions[12]};
        }

        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int baseCell, Direction direction, bool isFlipped)
        {
            List<(Vector2Int, int)> cells = new()
            {
                (baseCell, 1),
                (baseCell, 3),
                !isFlipped ? (baseCell, 2) : (baseCell, 0)
            };
            List<Vector2Int> temp = CalculatePositions(baseCell, direction, cells);
            cells.Add(!isFlipped ? (temp[2], 0) : (temp[2], 2));
            return CalculatePositions(baseCell, direction, cells);
        }
    }
}