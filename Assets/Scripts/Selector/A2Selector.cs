using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A2Selector : Selector
{
    public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int square1, Direction direction)
    {
        var square2 = direction switch
        {
            Direction.Up => new Vector2Int(square1.x + 1, square1.y),
            Direction.Right => new Vector2Int(square1.x, square1.y - 1),
            Direction.Down => new Vector2Int(square1.x - 1, square1.y),
            Direction.Left => new Vector2Int(square1.x, square1.y + 1),
            _ => new Vector2Int(square1.x + 1, square1.y),
        };
        List<Vector2Int> spaces = new()
        {
            square1,
            square2
        };
        return spaces;
    }
}