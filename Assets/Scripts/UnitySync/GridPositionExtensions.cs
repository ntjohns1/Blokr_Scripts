using UnityEngine;
using System.Collections.Generic;
using System.Linq;
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

        public static List<GridPosition> ToGridPosition(this List<Vector2Int> vectors)
        {
            return vectors.Select(v => v.ToGridPosition()).ToList();
        }

        public static List<Vector2Int> ToVector2Int(this List<GridPosition> positions)
        {
            return positions.Select(p => p.ToVector2Int()).ToList();
        }
    }
}
