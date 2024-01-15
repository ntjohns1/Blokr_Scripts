using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D4 : Piece
{
    public override List< Vector2Int> GetOccupiedGridPositions(Vector2Int gridPoint)
    {
        List<Vector2Int> spaces = new List<Vector2Int>
        {
            gridPoint
        };
        return spaces;
    }   
}
