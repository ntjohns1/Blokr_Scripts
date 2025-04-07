using System.Collections;
using System.Collections.Generic;
using Blokr.Core.Models;


namespace Blokr
{
    public class L5Highlighter : Selector, ISelector
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

        public override List<GridPosition> CalculatePlayablePositions(List<GridPosition> adjacentPositions)
        {
            return new() {adjacentPositions[1],adjacentPositions[3],adjacentPositions[6],adjacentPositions[8],adjacentPositions[10],adjacentPositions[12]};
        }

        public override List<GridPosition> GetOccupiedGridPositions(GridPosition baseCell, Direction direction, bool isFlipped)
        {
            List<(GridPosition, int)> cells = new()
            {
                (baseCell, 1),
                (baseCell, 3),
                !isFlipped ? (baseCell, 2) : (baseCell, 0)
            };
            List<GridPosition> temp = CalculatePositions(baseCell, direction, cells);
            cells.Add(!isFlipped ? (temp[2], 0) : (temp[2], 2));
            return CalculatePositions(baseCell, direction, cells);
        }
    }
}