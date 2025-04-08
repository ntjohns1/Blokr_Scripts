using System.Collections;
using System.Collections.Generic;
using Blokr.Core.Models;
using Blokr.Core.Services;
                                                                            
namespace Blokr.Highlighter

{
    public class B3Highlighter : PlacementHighlighter
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
                GetNext(gridpoint,OffsetAxis(!isFlipped?Direction.Down:Direction.Up))
            };
            Direction[] refDirections =
            {
                Direction.Right,
                Direction.Right,
                !isFlipped?Direction.Up:Direction.Down,
                !isFlipped?Direction.Up:Direction.Down,
                Direction.Left,
                !isFlipped?Direction.Up:Direction.Down,
                Direction.Left,
                Direction.Left,
                !isFlipped?Direction.Down:Direction.Up,
                !isFlipped?Direction.Down:Direction.Up,
                !isFlipped?Direction.Down:Direction.Up
            };

            for (int i = 0; i < refDirections.Length; i++)
            {
                output.Add(GetNext(output[i], OffsetAxis(refDirections[i])));

            }
            return output;
        }

        public override List<GridPosition> CalculatePlayablePositions(List<GridPosition> adjacentPositions)
        {
            return new() { adjacentPositions[2], adjacentPositions[4], adjacentPositions[6], adjacentPositions[8], adjacentPositions[11] };
        }

        public override List<GridPosition> GetOccupiedGridPositions(GridPosition baseCell, Direction direction, bool isFlipped)
        {
            List<(GridPosition cell, int axis)> cells = new() { (baseCell, 1), !isFlipped ? (baseCell, 0) : (baseCell, 2) };
            return CalculatePositions(baseCell, direction, cells);
        }
    }
}