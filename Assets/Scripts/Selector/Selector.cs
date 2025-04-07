using System;
using System.Collections;
using System.Collections.Generic;
using Blokr.Core.Models;

namespace Blokr
{
    public delegate List<GridPosition> CalculatePositions(GridPosition initialCell, Direction direction, List<(GridPosition, int)> positions);

    public abstract class Selector : ISelector
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

        protected GridPosition GetNext(GridPosition cell, Direction direction)
        {
            return direction switch
            {
                Direction.Up => new GridPosition(cell.x, cell.y + 1),
                Direction.Right => new GridPosition(cell.x + 1, cell.y),
                Direction.Down => new GridPosition(cell.x, cell.y - 1),
                Direction.Left => new GridPosition(cell.x - 1, cell.y),
                _ => cell,
            };
        }
        protected GridPosition GetDiagonal(GridPosition cell, Direction direction)
        {
            return direction switch
            {
                Direction.Up => new GridPosition(cell.x + 1, cell.y + 1),
                Direction.Right => new GridPosition(cell.x + 1, cell.y - 1),
                Direction.Down => new GridPosition(cell.x - 1, cell.y - 1),
                Direction.Left => new GridPosition(cell.x - 1, cell.y + 1),
                _ => cell,
            };
        }

        // ************************************************************************************
        // protected List<GridPosition> CalculatePositions           
        // based on initial position, and direction/isflipped, generate a list of occupied grid cells for a PieceType
        // ************************************************************************************
        protected List<GridPosition> CalculatePositions(GridPosition initialCell, Direction direction, List<(GridPosition, int)> positions)
        {
            //  instantiate list to populate and return
            List<GridPosition> cells = new()
            {
                initialCell
            };

            // cast direction to int to determine relative directions arithmetically
            int baseAxis = (int)direction;

            // Now we pass a series of tuplets containing a GridPosition referencing a cell, and an int representing a directional offset:
            // Direction.Up == 0, Direction.Right == 1, Direction.Down == 2, Direction.Left == 3
            foreach (var (cell, relativeAxis) in positions)
            {
                // this eliminates the need for the switch statements in the child classes
                int newAxis = (baseAxis + relativeAxis) % 4;
                GridPosition currentCell = GetNext(cell, (Direction)newAxis);
                cells.Add(currentCell);
            }

            return cells;
        }
        
    
        public abstract List<GridPosition> GetOccupiedGridPositions(GridPosition gridPoint, Direction direction, bool isFlipped);

        public abstract List<GridPosition> CalculateAdjacentPositions(GridPosition gridpoint, Direction direction, bool isFlipped);

        public abstract List<GridPosition> CalculatePlayablePositions(List<GridPosition> adjacentPositions);
    }
}

