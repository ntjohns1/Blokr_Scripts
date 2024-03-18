using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Blokr;
using UnityEngine;


namespace Blokr
{
    public class MoveValidator : MonoBehaviour
    {
        private static MoveValidator instance;
        public static MoveValidator Instance
        {
            get { return instance; }
            // set { instance = value; }
        }

        private List<Vector2Int> initCells;

        void Awake()
        {
            instance = this;
        }

        void Start()
        {
            initCells = new List<Vector2Int>
            {
                new Vector2Int(19, 0),
                new Vector2Int(19, 19),
                new Vector2Int(0, 19),
                new Vector2Int(0, 0)
            };
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

        public bool IsValidMove(List<Vector2Int> occupiedCells, PieceColor color)
        {
            if (TurnHandler.IsFirstTurn)
            {
                if (IsValidForFirstTurn(occupiedCells, color))
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
                return true;
            }
        }
    }
}

