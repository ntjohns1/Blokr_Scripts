using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class D5Selector : Selector
    {
        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int cellA, Direction direction, bool isFlipped)
        {
            var cellB = direction switch
            {
                Direction.Up => new Vector2Int(cellA.x + 1, cellA.y),
                Direction.Right => new Vector2Int(cellA.x, cellA.y - 1),
                Direction.Down => new Vector2Int(cellA.x - 1, cellA.y),
                Direction.Left => new Vector2Int(cellA.x, cellA.y + 1),
                _ => new Vector2Int(cellA.x + 1, cellA.y),
            };
            var cellC = direction switch
            {
                Direction.Up => new Vector2Int(cellA.x - 1, cellA.y),
                Direction.Right => new Vector2Int(cellA.x, cellA.y + 1),
                Direction.Down => new Vector2Int(cellA.x + 1, cellA.y),
                Direction.Left => new Vector2Int(cellA.x, cellA.y - 1),
                _ => new Vector2Int(cellA.x - 1, cellA.y),
            };
            var cellD = direction switch
            {
                Direction.Up => new Vector2Int(cellA.x, cellA.y + 1),
                Direction.Right => new Vector2Int(cellA.x + 1, cellA.y),
                Direction.Down => new Vector2Int(cellA.x, cellA.y - 1),
                Direction.Left => new Vector2Int(cellA.x - 1, cellA.y),
                _ => new Vector2Int(cellA.x, cellA.y + 1),
            };
            var cellE = direction switch
            {
                Direction.Up => new Vector2Int(cellA.x + 1, cellA.y + 1),
                Direction.Right => new Vector2Int(cellA.x + 1, cellA.y - 1),
                Direction.Down => new Vector2Int(cellA.x - 1, cellA.y - 1),
                Direction.Left => new Vector2Int(cellA.x - 1, cellA.y + 1),
                _ => new Vector2Int(cellA.x + 1, cellA.y + 1),
            };
            List<Vector2Int> cells = new()
        {
            cellA,
            cellB,
            cellC,
            cellD,
            cellE
        };
            return cells;
        }
    }
}