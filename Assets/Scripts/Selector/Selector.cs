using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{

    public abstract class Selector : MonoBehaviour
    {
        // ************************************************************************************
        // Fields
        // ************************************************************************************

        protected Direction selectorDirection;

        // protected PieceType pieceType;


        // ************************************************************************************
        // Properties
        // ************************************************************************************

        public Direction SelectorDirection
        {
            get { return selectorDirection; }
            set { selectorDirection = value; }
        }

        // public PieceType PieceType
        // {
        //     get { return pieceType; }
        // }


        // ************************************************************************************
        // Methods
        // ************************************************************************************

        protected Vector2Int GetNext(Vector2Int cell, Direction direction, bool isFlipped)
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

        // protected List<Vector2Int> CalculatePositions(Vector2Int initialPosition, Direction direction, bool isFlipped, params (Vector2Int, Direction)[] movements)
        // {
        //     List<Vector2Int> positions = new List<Vector2Int>();
        //     Vector2Int currentPosition = initialPosition;
        //     positions.Add(currentPosition);
        //     foreach (var (cell, next) in movements)
        //     {
        //         currentPosition = GetNext(cell, next);
        //         positions.Add(currentPosition);
        //     }
        //     return positions;
        // }

        protected List<Vector2Int> CalculatePositions(Vector2Int initialCell, Direction direction, bool isFlipped, params (Vector2Int, int)[] positions)
        {
            // based on initial position, and direction/isflipped, generate a list of occupied grid cells for a PieceType

            //  instantiate list to populate and return
            List<Vector2Int> cells = new()
            {
                initialCell
            };
            Vector2Int currentCell = initialCell;
            // cast direction to int to determine relative directions arithmetically
            int baseAxis = (int)direction;
            foreach (var (cell, relativeAxis) in positions)
            {
                int newAxis = (baseAxis + relativeAxis) % 4;
                currentCell = GetNext(cell, (Direction)newAxis, isFlipped);
                cells.Add(currentCell);
            }


            return cells;
        }

        public static Direction AddToDirection(Direction direction, int value)
        {
            // Calculate the new value with wrapping
            int directionCount = Enum.GetNames(typeof(Direction)).Length;
            int newValue = (((int)direction + value) % directionCount + directionCount) % directionCount;

            // Cast back to Direction enum
            return (Direction)newValue;
        }

        public abstract List<Vector2Int> GetOccupiedGridPositions(Vector2Int gridPoint, Direction direction, bool isFlipped);

    }
}

