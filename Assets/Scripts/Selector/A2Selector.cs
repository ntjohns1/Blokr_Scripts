using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class A2Selector : Selector, ISelector
    {
        public override List<Vector2Int> CalculatePlayablePositions(Vector2Int gridpoint, Direction direction, bool isFlipped)
        {
            Direction OffsetAxis(Direction offset)
            {
                return (Direction)(((int)direction + (int)offset) % 4);
            }
            List<Vector2Int> output = new()
            {
                GetNext(gridpoint,OffsetAxis(Direction.Up))
            };
            Direction[] refDirections =
            {
                !isFlipped?Direction.Right:Direction.Left, 
                !isFlipped?Direction.Right:Direction.Left, 
                Direction.Down,
                Direction.Down,
                !isFlipped?Direction.Left:Direction.Right,
                !isFlipped?Direction.Left:Direction.Right,
                !isFlipped?Direction.Left:Direction.Right,
                Direction.Up,
                Direction.Up
            };

            for (int i = 0; i < refDirections.Length; i++)
            {
                output.Add(GetNext(output[i], OffsetAxis(refDirections[i])));

            }
            return output;
        }

        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int baseCell, Direction direction, bool isFlipped)
        {
            List<(Vector2Int, int)> cells = new() { !isFlipped ? (baseCell, 1) : (baseCell, 3) };
            return CalculatePositions(baseCell, direction, cells);
        }
    }
}