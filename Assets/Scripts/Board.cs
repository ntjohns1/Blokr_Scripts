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
        // ************************************************************************************
        // Fields
        // ************************************************************************************
        private static Board instance;
        private bool[,] occupiedSpaces;

        private List<Vector2Int> initCells;

        // ************************************************************************************
        // Properties
        // ************************************************************************************
        public static Board Instance
        {
            get { return instance; }
        }

        void Awake()
        {
            instance = this;
        }



        // Initialize the board
        private void Start()
        {
            occupiedSpaces = new bool[20, 20];
            initCells = new List<Vector2Int>
            {
                new Vector2Int(19, 0),
                new Vector2Int(0, 0),
                new Vector2Int(0, 19),
                new Vector2Int(19, 19)
            };
        }

        public List<Vector2Int> AddPiece(List<Vector2Int> positions, PieceColor color)
        {
            if (IsValidMove(positions, color))
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


        // Check if the specified spaces are available
        public bool IsValidMove(List<Vector2Int> gridPositions, PieceColor color)
        {
            if (TurnHandler.IsFirstTurn)
            {
                if (IsValidForFirstTurn(gridPositions, color))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
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
        }

        public bool BelongsToCurrentPlayer(GameObject playerObj, PieceColor color)
        {
            Player player = playerObj.GetComponent<Player>();
            return player.Color == color;
        }

        public bool IsValidForFirstTurn(List<Vector2Int> occupiedCells, PieceColor color)
        {
            return color switch
            {
                PieceColor.Red => occupiedCells.Contains(initCells[0]),
                PieceColor.Green => occupiedCells.Contains(initCells[1]),
                PieceColor.Blue => occupiedCells.Contains(initCells[2]),
                PieceColor.Yellow => occupiedCells.Contains(initCells[3]),
                _ => occupiedCells.Contains(initCells[0]),
            };
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