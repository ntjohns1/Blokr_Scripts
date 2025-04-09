// This file is deprecated. Grid geometry utilities have been moved to GridGeometry in the UnitySync package.
// Please use Blokr.UnitySync.GridGeometry instead.

using UnityEngine;
using Blokr.Core.Models;
using Blokr.UnitySync;

namespace Blokr
{
    [System.Obsolete("This class is deprecated. Use Blokr.UnitySync.GridGeometry instead.")]
    public class Geometry 
    {
        static public Vector3 PointFromGrid(GridPosition gridPoint)
        {
            return GridGeometry.PointFromGrid(gridPoint);
        }

        static public GridPosition GridPoint(int col, int row)
        {
            return GridGeometry.CreateGridPoint(col, row);
        }

        static public GridPosition GridFromPoint(Vector3 point)
        {
            return GridGeometry.GridFromPoint(point);
        }
    }
}