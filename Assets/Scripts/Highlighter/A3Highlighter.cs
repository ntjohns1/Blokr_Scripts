using System.Collections;
using System.Collections.Generic;
using Blokr.Core.Models;
using Blokr.Core.Services;

namespace Blokr.Highlighter
{
    public class A3Highlighter : PlacementHighlighter
    {

        public static int Size { get { return 3; } }

        public override List<GridPosition> CalculateAdjacentPositions(GridPosition gridpoint, Direction direction, bool isFlipped)
        {
            Direction OffsetAxis(Direction offset)
            {
                return (Direction)(((int)direction + (int)offset) % 4);
            }
            List<GridPosition> output = new()
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
                !isFlipped?Direction.Left:Direction.Right,
                Direction.Up,
                Direction.Up,
                !isFlipped?Direction.Right:Direction.Left,
            };

            for (int i = 0; i < refDirections.Length; i++)
            {
                output.Add(GetNext(output[i], OffsetAxis(refDirections[i])));

            }
            return output;
        }

        public override List<GridPosition> CalculatePlayablePositions(List<GridPosition> adjacentPositions)
        {
            return new() { adjacentPositions[2], adjacentPositions[4], adjacentPositions[8], adjacentPositions[10] };
        }

        public override List<GridPosition> GetOccupiedGridPositions(GridPosition baseCell, Direction direction, bool isFlipped)
        {
            List<(GridPosition cell, int axis)> cells = new() { !isFlipped ? (baseCell, 1) : (baseCell, 3), !isFlipped ? (baseCell, 3) : (baseCell, 1) };
            return CalculatePositions(baseCell, direction, cells);
        }
    }
}