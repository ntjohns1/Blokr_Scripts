using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{

    public interface ISelector
    {
        public List<Vector2Int> GetOccupiedGridPositions(Vector2Int gridPoint, Direction direction, bool isFlipped);
    }
}
