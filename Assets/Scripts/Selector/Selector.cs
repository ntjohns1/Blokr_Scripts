using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{

    public abstract class Selector : MonoBehaviour
    {
        [SerializeField]
        [Range(1, 5)]
        protected int size;

        protected Direction selectorDirection;
        public Direction SelectorDirection
        {
            get { return selectorDirection; }
            set { selectorDirection = value; }
        }


        [SerializeField]
        protected PieceType pieceType;

        public PieceType PieceType
        {
            get { return pieceType; }
        }

        public int GetSize()
        {
            return size;
        }

        public abstract List<Vector2Int> GetOccupiedGridPositions(Vector2Int gridPoint, Direction direction, bool isFlipped);

        // public Vector2Int GetNext(Vector2Int cell, Direction direction, bool isFlipped)
        // {
        //     if (!isFlipped)
        //     {
        //         return direction switch
        //         {
        //             Direction.Up => new Vector2Int(cell.x, cell.y + 1),
        //             Direction.Right => new Vector2Int(cell.x + 1, cell.y),
        //             Direction.Down => new Vector2Int(cell.x, cell.y - 1),
        //             Direction.Left => new Vector2Int(cell.x - 1, cell.y),
        //             _ => cell,
        //         };
        //     }
        //     else
        //     {
        //         return direction switch
        //         {
        //             Direction.Up => new Vector2Int(cell.x, cell.y - 1),
        //             Direction.Right => new Vector2Int(cell.x - 1, cell.y),
        //             Direction.Down => new Vector2Int(cell.x, cell.y + 1),
        //             Direction.Left => new Vector2Int(cell.x + 1, cell.y),
        //             _ => cell,
        //         };
        //     }
        // }
        
        public Vector2Int GetNext(Vector2Int cell, Direction direction)
        {
            return direction switch
            {
                Direction.Up => new Vector2Int(cell.x, cell.y + 1),
                Direction.Right => new Vector2Int(cell.x + 1, cell.y),
                Direction.Down => new Vector2Int(cell.x, cell.y - 1),
                Direction.Left => new Vector2Int(cell.x - 1, cell.y),
                _ => cell,
            };
        }
    }
}

