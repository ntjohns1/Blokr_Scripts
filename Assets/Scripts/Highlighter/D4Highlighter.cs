using System.Collections;
using System.Collections.Generic;
using Blokr.Core.Models;


namespace Blokr
{
    public class D4Highlighter : Selector, ISelector
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
                GetNext(gridpoint,OffsetAxis(!isFlipped?Direction.Down:Direction.Up))
            };
            Direction[] refDirections =
            {
                Direction.Left,
                !isFlipped?Direction.Up:Direction.Down,
                !isFlipped?Direction.Up:Direction.Down,
                !isFlipped?Direction.Up:Direction.Down,
                Direction.Right,
                Direction.Right,
                Direction.Right,
                !isFlipped?Direction.Down:Direction.Up,
                !isFlipped?Direction.Down:Direction.Up,
                !isFlipped?Direction.Down:Direction.Up,
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
            return new() { adjacentPositions[1], adjacentPositions[4], adjacentPositions[7], adjacentPositions[10] };
        }

        public override List<GridPosition> GetOccupiedGridPositions(GridPosition baseCell, Direction direction, bool isFlipped)
        {
            List<(GridPosition, int)> cells = new()
            {
                (baseCell, 1),
                !isFlipped ? (baseCell, 0) : (baseCell, 2)
            };
            List<GridPosition> temp = CalculatePositions(baseCell, direction, cells);
            cells.Add(!isFlipped ? (temp[1], 0) : (temp[1], 2));
            return CalculatePositions(baseCell, direction, cells);
        }
    }
}