using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Blokr.Core.Models;

// *********************************************************************
// public class Geometry:
// Utility class that handles the conversion between row and column 
// notation and Vector3 points.
// *********************************************************************
namespace Blokr
{
    public class Geometry 
    {
        static public Vector3 PointFromGrid(GridPosition gridPoint)
        {
            float x = 0.5f + 1.0f * gridPoint.x;
            float z = 0.5f + 1.0f * gridPoint.y;
            return new Vector3(x, 0.0f, z);
        }

        static public GridPosition GridPoint(int col, int row)
        {
            return new GridPosition(col, row);
        }

        static public GridPosition GridFromPoint(Vector3 point)
        {
            int col = Mathf.FloorToInt(point.x);
            int row = Mathf.FloorToInt(point.z);
            return new GridPosition(col, row);
        }
    }
}