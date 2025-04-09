using UnityEngine;
using Blokr.Core.Models;

namespace Blokr.UnitySync
{
    /// <summary>
    /// Utility class that handles coordinate transformations between Unity's Vector3 space
    /// and the game's grid coordinate system. This is part of the UnitySync package as it
    /// bridges Unity-specific types with the game's core types.
    /// </summary>
    public static class GridGeometry 
    {
        /// <summary>
        /// Converts a grid position to a Unity world position.
        /// </summary>
        /// <param name="gridPoint">The grid position to convert</param>
        /// <returns>A Vector3 representing the center point of the grid cell in Unity space</returns>
        public static Vector3 PointFromGrid(GridPosition gridPoint)
        {
            float x = 0.5f + gridPoint.X;
            float z = 0.5f + gridPoint.Y;
            return new Vector3(x, 0.0f, z);
        }

        /// <summary>
        /// Creates a new grid position from column and row coordinates.
        /// </summary>
        /// <param name="col">Column index (X coordinate)</param>
        /// <param name="row">Row index (Y coordinate)</param>
        /// <returns>A new GridPosition instance</returns>
        public static GridPosition CreateGridPoint(int col, int row)
        {
            return new GridPosition(col, row);
        }

        /// <summary>
        /// Converts a Unity world position to a grid position.
        /// </summary>
        /// <param name="point">The Unity world position to convert</param>
        /// <returns>A GridPosition representing the grid cell that contains the point</returns>
        public static GridPosition GridFromPoint(Vector3 point)
        {
            int col = Mathf.FloorToInt(point.x);
            int row = Mathf.FloorToInt(point.z);
            return new GridPosition(col, row);
        }
    }
}
