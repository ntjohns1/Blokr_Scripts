// This file is deprecated. All piece calculation logic has been moved to IPieceCalculationService.
// Please use PlacementHighlighter with IPieceCalculationService instead.

using System.Collections;
using System.Collections.Generic;
using Blokr.Core.Models;
using Blokr.Core.Services;
                                                                            
namespace Blokr.Highlighter

{
    public class B4Highlighter : PlacementHighlighter
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
                GetNext(gridpoint,OffsetAxis(!isFlipped?Direction.Up:Direction.Down))
            };
            Direction[] refDirections =
            {
                Direction.Left,
                Direction.Left,
                !isFlipped?Direction.Down:Direction.Up,
                !isFlipped?Direction.Down:Direction.Up,
                Direction.Right,
                Direction.Right,
                !isFlipped?Direction.Down:Direction.Up,
                Direction.Right,
                Direction.Right,
                !isFlipped?Direction.Up:Direction.Down,
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
            return new() { adjacentPositions[2], adjacentPositions[4], adjacentPositions[7], adjacentPositions[9], adjacentPositions[12] };
        }

        public override List<GridPosition> GetOccupiedGridPositions(GridPosition baseCell, Direction direction, bool isFlipped)
        {
            List<(GridPosition, int)> cells = new()
            {
                (baseCell, 3),
                (baseCell, 1)
            };
            List<GridPosition> temp = CalculatePositions(baseCell, direction, cells);
            cells.Add(!isFlipped ? (temp[2], 2) : (temp[2], 0));
            return CalculatePositions(baseCell, direction, cells);
        }
    }
}

