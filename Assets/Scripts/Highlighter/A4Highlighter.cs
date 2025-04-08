using System.Collections;
using System.Collections.Generic;
using Blokr.Core.Models;
using Blokr.Core.Services;
                                                                            
namespace Blokr.Highlighter

{
    public class A4Highlighter : PlacementHighlighter
    {
        public static int Size { get { return 4; } }

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
                !isFlipped?Direction.Right:Direction.Left,
                Direction.Down,
                Direction.Down,
                !isFlipped?Direction.Left:Direction.Right,
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
            return new() { adjacentPositions[3], adjacentPositions[5], adjacentPositions[10], adjacentPositions[12] };
        }

        public override List<GridPosition> GetOccupiedGridPositions(GridPosition baseCell, Direction direction, bool isFlipped)
        {
            List<(GridPosition cell, int)> cells = new()
            {
                !isFlipped ? (baseCell, 1) : (baseCell, 3),
                !isFlipped ? (baseCell, 3) : (baseCell, 1)
            };
            List<GridPosition> temp = CalculatePositions(baseCell, direction, cells);
            cells.Add(!isFlipped ? (temp[1], 1) : (temp[1], 3));
            return CalculatePositions(baseCell, direction, cells);
        }
    }
}