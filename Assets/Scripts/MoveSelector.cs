using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Blokr;
using UnityEngine;


namespace Blokr
{
    public class MoveSelector : MonoBehaviour
    {
        private static MoveSelector instance;
        public static MoveSelector Instance
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
                new Vector2Int(20, 0),
                new Vector2Int(20, 20),
                new Vector2Int(0, 20),
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
    }
}


