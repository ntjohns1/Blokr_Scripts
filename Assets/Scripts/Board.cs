using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Tilemaps;

// *********************************************************************
// public class Board:
// Keeps track of the visual representations of the pieces.
//  This component also handles the highlighting of individual pieces.
// *********************************************************************
namespace Blokr
{
    public class Board : MonoBehaviour
    {
        private bool[,] occupiedSpaces;

        // Initialize the board
        private void Start()
        {
            occupiedSpaces = new bool[21, 21];
        }

        public List<Vector2Int> AddPiece(List<Vector2Int> positions)
        {
            if (IsValidMove(positions))
            {
                UpdateOccupiedSpaces(positions, true);
                DebugPrintBoard();
                return positions;
            }
            else
            {
                return null;
            }
        }

        // Check if the specified spaces are available
        private bool IsValidMove(List<Vector2Int> gridPositions)
        {
            foreach (Vector2Int cell in gridPositions)
            {
                int x = cell.x, y = cell.y;
                if (x < 0 || x > 19 || y < 0 || y > 19 || occupiedSpaces[x, y])
                {
                    return false;
                }
            }
            return true;
        }

        // Update the occupancy status of the specified spaces
        private void UpdateOccupiedSpaces(List<Vector2Int> gridPositions, bool occupied)
        {
            foreach (Vector2Int cell in gridPositions)
            {
                int x = cell.x, y = cell.y;
                {
                    occupiedSpaces[x, y] = occupied;
                }
            }
        }

        public void DebugPrintBoard()
        {
            for (int i = 0; i < 20; i++) 
            {
                string rowString = "";
                for (int j = 0; j < 20; j++)
                {
                    rowString += occupiedSpaces[i, j] == false ? "|     " : "| X ";
                }
                Debug.Log(rowString + "|"); 
            }
        }
    }
}