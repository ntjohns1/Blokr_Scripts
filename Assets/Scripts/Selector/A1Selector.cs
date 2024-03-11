using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Blokr
{
    public class A1Selector : Selector, ISelector
    {

        public override List<Vector2Int> GetOccupiedGridPositions(Vector2Int baseCell, Direction direction, bool isFlipped)
        {
            List<Vector2Int> cell = new() { baseCell };
            return cell;
        }
    }
}