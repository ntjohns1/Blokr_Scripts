using UnityEngine;
using Blokr.Core.Models;

namespace Blokr.UnitySync
{
    public static class GridPositionExtensions
    {
        public static Vector2Int ToVector2Int(this GridPosition position)
        {
            return new Vector2Int(position.X, position.Y);
        }

        public static GridPosition ToGridPosition(this Vector2Int vector)
        {
            return new GridPosition(vector.x, vector.y);
        }

        public static Vector3Int ToVector3Int(this GridPosition position)
        {
            return new Vector3Int(position.X, position.Y, 0);
        }
    }
}
