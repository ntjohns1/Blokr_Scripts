using System.Collections;
using System.Collections.Generic;
using Blokr.Core.Models;


namespace Blokr.Highlighter
{
    public class H5Highlighter : PlacementHighlighter
    {

        public static int Size { get { return 5; } }
        
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
                Direction.Left,
                !isFlipped?Direction.Up:Direction.Down,
                Direction.Left,
                !isFlipped?Direction.Up:Direction.Down,
                !isFlipped?Direction.Up:Direction.Down,
                Direction.Right,
                Direction.Right,
                Direction.Right,
                !isFlipped?Direction.Down:Direction.Up,
                Direction.Right,
                !isFlipped?Direction.Down:Direction.Up,
                !isFlipped?Direction.Down:Direction.Up,
                !isFlipped?Direction.Down:Direction.Up,
                Direction.Left,
                Direction.Left
            };

            for (int i = 0; i < refDirections.Length; i++)
            {
                output.Add(GetNext(output[i], OffsetAxis(refDirections[i])));

            }
            return output;
        }

        public override List<GridPosition> CalculatePlayablePositions(List<GridPosition> adjacentPositions)
        {
            return new() { adjacentPositions[1], adjacentPositions[3], adjacentPositions[5], adjacentPositions[8], adjacentPositions[10], adjacentPositions[13], adjacentPositions[15] };
        }

        public override List<GridPosition> GetOccupiedGridPositions(GridPosition baseCell, Direction direction, bool isFlipped)
        {
            List<(GridPosition, int)> cells = new()
            {
                !isFlipped ? (baseCell, 0) : (baseCell, 2),
                (baseCell, 1)
            };
            List<GridPosition> temp = CalculatePositions(baseCell, direction, cells);
            cells.Add((temp[1], 3));
            cells.Add(!isFlipped ? (temp[2], 2) : (temp[2], 0));
            return CalculatePositions(baseCell, direction, cells);
        }
    }
}