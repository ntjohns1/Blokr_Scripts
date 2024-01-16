using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

public class Board : MonoBehaviour
{
    private bool[,] occupiedSpaces;

    // Initialize the board
    private void Start()
    {
        occupiedSpaces = new bool[20, 20];
    }

    // Add a piece to the board and update the occupancy status
    public GameObject AddPiece(GameObject piece, GameObject tileHighlight)
    {
        Piece pieceComponent = piece.GetComponent<Piece>();
        TileSelector tileSelector = GetComponent<TileSelector>();

        // Get the grid position from the tileHighlight
        Vector2Int gridPosition = Geometry.GridFromPoint(tileHighlight.transform.position);

        // Check if the spaces are available
        // if (AreSpacesAvailable(gridPosition, pieceComponent.GetSize()))
        // {
            // Add the piece to the board
            GameObject pieceObject = Instantiate(piece, tileHighlight.transform.position, Quaternion.identity);
            // UpdateOccupiedSpaces(gridPosition, pieceComponent.GetSize(), true);

        
            // Calculate the grid positions occupied by the piece
            // List<Vector2Int> occupiedGridPositions = GetOccupiedGridPositions(gridPosition, pieceComponent);
            // Debug.Log("Occupied Grid Positions: " + string.Join(", ", occupiedGridPositions));

            return pieceObject;
        // }
        // else
        // {
        //     // Spaces are not available, handle accordingly (e.g., display a message)
        //     Debug.Log("Cannot place the piece in the selected position.");
        //     return null;
        // }
    }

    // Check if the specified spaces are available
    private bool AreSpacesAvailable(Vector2Int gridPosition, int size)
    {
        for (int x = gridPosition.x; x < gridPosition.x + size; x++)
        {
            for (int y = gridPosition.y; y < gridPosition.y + size; y++)
            {
                if (x < 0 || x >= 20 || y < 0 || y >= 20 || occupiedSpaces[x, y])
                {
                    return false;
                }
            }
        }
        return true;
    }

    // Update the occupancy status of the specified spaces
    private void UpdateOccupiedSpaces(Vector2Int gridPosition, int size, bool occupied)
    {
        for (int x = gridPosition.x; x < gridPosition.x + size; x++)
        {
            for (int y = gridPosition.y; y < gridPosition.y + size; y++)
            {
                occupiedSpaces[x, y] = occupied;
            }
        }
    }

    // Calculate the grid positions occupied by a piece, considering orientation
    // private List<Vector2Int> GetOccupiedGridPositions(Vector2Int gridPosition, Piece piece)
    // {
    //     List<Vector2Int> occupiedPositions = new List<Vector2Int>();

    //     for (int i = 0; i < piece.GetSize(); i++)
    //     {
    //         // Calculate the grid position based on the orientation of the piece
    //         Vector2Int squarePosition = gridPosition + piece. (i);
    //         occupiedPositions.Add(squarePosition);
    //     }

    //     return occupiedPositions;
    // }
}
