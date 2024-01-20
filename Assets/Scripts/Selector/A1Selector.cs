using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class A1Selector : Selector
{
    
    public override List< Vector2Int> GetOccupiedGridPositions(Vector2Int cellA, Direction direction)
    {
        ClampToGrid(cellA,0,19);
        List<Vector2Int> spaces = new List<Vector2Int>
        {
            cellA
        };
        return spaces;
    }   
}
