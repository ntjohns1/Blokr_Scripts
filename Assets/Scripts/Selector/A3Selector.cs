using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A3Selector : Selector
{
    public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int cellA, Direction direction)
    {
        ClampToGrid(cellA, 0, 19);
        var cellB = ClampToGrid(direction switch
        {
            Direction.Up => new Vector2Int(cellA.x + 1, cellA.y),
            Direction.Right => new Vector2Int(cellA.x, cellA.y - 1),
            Direction.Down => new Vector2Int(cellA.x - 1, cellA.y),
            Direction.Left => new Vector2Int(cellA.x, cellA.y + 1),
            _ => new Vector2Int(cellA.x + 1, cellA.y),
        },0,19);
        var cellC = ClampToGrid(direction switch
        {
            Direction.Up => new Vector2Int(cellA.x - 1, cellA.y),
            Direction.Right => new Vector2Int(cellA.x, cellA.y + 1),
            Direction.Down => new Vector2Int(cellA.x + 1, cellA.y),
            Direction.Left => new Vector2Int(cellA.x, cellA.y - 1),
            _ => new Vector2Int(cellA.x - 1, cellA.y),
        },0,19);
        List<Vector2Int> cells = new()
        {
            cellA,
            cellB,
            cellC
        };
        return cells;
    }
}
