using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public delegate List<Vector2Int> CalculatePositions(Vector2Int initialCell, Direction direction, List<(Vector2Int, int)> positions);

    public abstract class Selector : MonoBehaviour, ISelector
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

        protected Vector2Int GetNext(Vector2Int cell, Direction direction)
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

        // ************************************************************************************
        // protected List<Vector2Int> CalculatePositions           
        // based on initial position, and direction/isflipped, generate a list of occupied grid cells for a PieceType
        // ************************************************************************************
        protected List<Vector2Int> CalculatePositions(Vector2Int initialCell, Direction direction, List<(Vector2Int, int)> positions)
        {
            //  instantiate list to populate and return
            List<Vector2Int> cells = new()
            {
                initialCell
            };

            // cast direction to int to determine relative directions arithmetically
            int baseAxis = (int)direction;

            // Now we pass a series of tuplets containing a Vector2Int referencing a cell, and an int representing a directional offset:
            // Direction.Up == 0, Direction.Right == 1, Direction.Down == 2, Direction.Left == 3
            foreach (var (cell, relativeAxis) in positions)
            {
                // this eliminates the need for the switch statements in the child classes
                int newAxis = (baseAxis + relativeAxis) % 4;
                Vector2Int currentCell = GetNext(cell, (Direction)newAxis);
                cells.Add(currentCell);
            }

            return cells;
        }

        public abstract List<Vector2Int> GetOccupiedGridPositions(Vector2Int gridPoint, Direction direction, bool isFlipped);

    }
}

