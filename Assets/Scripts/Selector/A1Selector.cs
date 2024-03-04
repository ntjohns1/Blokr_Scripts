using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Blokr
{
    public class A1Selector : Selector
    {

        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int baseCell, Direction direction, bool isFlipped)
        {
            List<Vector2Int> spaces = new List<Vector2Int>
        {
            baseCell
        };
            return spaces;
        }
    }
}