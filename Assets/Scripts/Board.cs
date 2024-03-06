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
// public class Board : MonoBehaviour
// {

//     public GameObject AddPiece(GameObject piece, GameObject tileHighlght)
//     {
//         piece.transform.position = tileHighlght.transform.position;
//         tileHighlght.SetActive(false);
//         return piece;
//     }

// }

// public class Board : MonoBehaviour
// {
//     private bool[,] occupiedSpaces;

//     // Initialize the board
//     private void Start()
//     {
//         occupiedSpaces = new bool[20, 20];
//     }

//     // Add a piece to the board and update the occupancy status
//     public GameObject AddPiece(GameObject piece, GameObject tileHighlight)
//     {
//         Piece pieceComponent = piece.GetComponent<Piece>();
//         TileSelector tileSelector = GetComponent<TileSelector>();

//         // Get the grid position from the tileHighlight
//         Vector2Int gridPosition = Geometry.GridFromPoint(tileHighlight.transform.position);

//         // Check if the spaces are available
//         // if (AreSpacesAvailable(gridPosition, pieceComponent.GetSize()))
//         // {
//             // Add the piece to the board
//             GameObject pieceObject = Instantiate(piece, tileHighlight.transform.position, Quaternion.identity);
//             UpdateOccupiedSpaces(gridPosition, pieceComponent.GetSize(), true);

//             return pieceObject;
//         // }
//         // else
//         // {
//         //     // Spaces are not available, handle accordingly (e.g., display a message)
//         //     Debug.Log("Cannot place the piece in the selected position.");
//         //     return null;
//         // }
//     }

//     // Check if the specified spaces are available
//     private bool AreSpacesAvailable(Vector2Int gridPosition, int size)
//     {
//         for (int x = gridPosition.x; x < gridPosition.x + size; x++)
//         {
//             for (int y = gridPosition.y; y < gridPosition.y + size; y++)
//             {
//                 if (x < 0 || x >= 20 || y < 0 || y >= 20 || occupiedSpaces[x, y])
//                 {
//                     return false;
//                 }
//             }
//         }
//         return true;
//     }

//     // Update the occupancy status of the specified spaces
//     private void UpdateOccupiedSpaces(Vector2Int gridPosition, int size, bool occupied)
//     {
//         for (int x = gridPosition.x; x < gridPosition.x + size; x++)
//         {
//             for (int y = gridPosition.y; y < gridPosition.y + size; y++)
//             {
//                 occupiedSpaces[x, y] = occupied;
//             }
//         }
//     }
// }
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
                if (x < 0 || x > 20 || y < 0 || y > 20 || occupiedSpaces[x, y])
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