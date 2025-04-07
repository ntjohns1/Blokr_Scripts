using UnityEngine;
using System.Collections.Generic;
using Blokr.Core.Models;
using Blokr.Highlighter;

namespace Blokr.Highlighter
{
    public class A1Highlighter : PlacementHighlighter
    {
        public static int Size { get { return 1; } }

        public override List<GridPosition> CalculateAdjacentPositions(GridPosition gridpoint, Direction direction, bool isFlipped)
        {
            Direction OffsetAxis(Direction offset)
            {
                return (Direction)(((int)direction + (int)offset) % 4);
            }

            List<GridPosition> output = new()
            {
                GetNext(gridpoint, OffsetAxis(!isFlipped ? Direction.Up : Direction.Down))
            };

            Direction[] refDirections =
            {
                Direction.Right,
                !isFlipped ? Direction.Down : Direction.Up,
                !isFlipped ? Direction.Down : Direction.Up,
                Direction.Left,
                Direction.Left,
                !isFlipped ? Direction.Up : Direction.Down,
                !isFlipped ? Direction.Up : Direction.Down,
                Direction.Right
            };

            for (int i = 0; i < refDirections.Length; i++)
            {
                output.Add(GetNext(output[i], OffsetAxis(refDirections[i])));
            }
            return output;
        }

        public override List<GridPosition> CalculatePlayablePositions(List<GridPosition> adjacentPositions)
        {
            return new() { adjacentPositions[1], adjacentPositions[3], adjacentPositions[5], adjacentPositions[7] };
        }

        public override List<GridPosition> GetOccupiedGridPositions(GridPosition baseCell, Direction direction, bool isFlipped)
        {
            List<GridPosition> cell = new() { baseCell };
            return cell;
        }
    }
}