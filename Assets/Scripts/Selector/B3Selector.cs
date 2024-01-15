using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B3Selector : Selector
{
    public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int cellA, Direction direction)
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
        List<Vector2Int> cells = new()
        {
            cellA,
            cellB,
            cellC
        };
        return cells;
    }
}
