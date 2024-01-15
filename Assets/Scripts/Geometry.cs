using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// *********************************************************************
// public class Geometry:
// Utility class that handles the conversion between row and column 
// notation and Vector3 points.
// *********************************************************************
public class Geometry : MonoBehaviour
{
    static public Vector3 PointFromGrid(Vector2Int gridPoint)
    {
        float x = -9.5f + 1.0f * gridPoint.x;
        float z = -9.5f + 1.0f * gridPoint.y;
        return new Vector3(x, 0.0f, z);
    }

    static public Vector2Int GridPoint(int col, int row)
    {
        return new Vector2Int(col, row);
    }

    static public Vector2Int GridFromPoint(Vector3 point)
    {
        int col = Mathf.FloorToInt(10.0f + point.x);
        int row = Mathf.FloorToInt(10.0f + point.z);
        return new Vector2Int(col, row);
    }
}
