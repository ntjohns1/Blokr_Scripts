using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class F5Selector : Selector, ISelector
    {
        public override List<Vector2Int> CalculateAdjacentPositions(Vector2Int gridpoint, Direction direction, bool isFlipped)
        {
            Direction OffsetAxis(Direction offset)
            {
                return (Direction)(((int)direction + (int)offset) % 4);
            }
            gridpoint = GetNext(gridpoint, OffsetAxis(!isFlipped?Direction.Up:Direction.Down));
            List<Vector2Int> output = new()
            {
                GetNext(gridpoint,OffsetAxis(!isFlipped?Direction.Up:Direction.Down))
            };
            Direction[] refDirections =
            {
                Direction.Left,
                !isFlipped?Direction.Down:Direction.Up,
                Direction.Left,
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
                Direction.Left,
                !isFlipped?Direction.Up:Direction.Down
            };

            for (int i = 0; i < refDirections.Length; i++)
            {
                output.Add(GetNext(output[i], OffsetAxis(refDirections[i])));

            }
            return output;
        }

        public override List<Vector2Int> CalculatePlayablePositions(List<Vector2Int> adjacentPositions)
        {
            return new() { adjacentPositions[1], adjacentPositions[3], adjacentPositions[5], adjacentPositions[7], adjacentPositions[9], adjacentPositions[11], adjacentPositions[13], adjacentPositions[15] };
        }

        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int baseCell, Direction direction, bool isFlipped)
        {
            List<(Vector2Int, int)> cells = new()
            {
                (baseCell, 1),
                (baseCell, 3),
                !isFlipped ? (baseCell, 0) : (baseCell, 2),
                !isFlipped ? (baseCell, 2) : (baseCell, 0)
            };
            return CalculatePositions(baseCell, direction, cells);
        }
    }
}