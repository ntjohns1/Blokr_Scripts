using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class Player : MonoBehaviour
    {

        // ************************************************************************************
        // Fields
        // ************************************************************************************
        private string playerName;
        private PieceColor color;

        private Dictionary<PieceType, bool> pieces;

        private bool[,] adjacentPositions;
        private bool[,] playablePositions;


        // ************************************************************************************
        // Properties
        // ************************************************************************************

        public string PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        public PieceColor Color
        {
            get { return color; }
            set { color = value; }
        }
        public Dictionary<PieceType, bool> Pieces
        {
            get { return pieces; }
            // set { pieces = value; }
        }

        public bool[,] PlayablePositions
        {
            get { return playablePositions; }
            set { playablePositions = value; }
        }
        public bool[,] AdjacentPositions
        {
            get { return adjacentPositions; }
            set { adjacentPositions = value; }
        }

        // public List<GameObject> PlayedPieces
        // {
        //     get { 
        //         return null; }
        //     set { playedPieces = value; }
        // }


        // ************************************************************************************
        // Methods
        // ************************************************************************************

        // Constructors
        public void Start()
        {
            pieces = new();
            for (int i = 0; i < 21; i++)
            {
                pieces.Add((PieceType)i, false);
            }
            adjacentPositions = new bool[20, 20];
            playablePositions = new bool[20, 20];
        }

        public void UpdateAdjacentPositions(List<Vector2Int> positions)
        {
            foreach (Vector2Int cell in positions)
            {
                int x = cell.x, y = cell.y;
                if (x >= 0 && x < 20 && y >= 0 && y < 20)
                {
                    adjacentPositions[x, y] = true;
                }
            }
        }

        public void UpdatePlayablePositions(List<Vector2Int> positions)
        {
            foreach (Vector2Int cell in positions)
            {
                int x = cell.x, y = cell.y;
                if (x >= 0 && x < 20 && y >= 0 && y < 20)
                {
                    playablePositions[x, y] = true;
                }
            }
        }

        public void PlayPiece(PieceType type, Vector2Int gridPosition)
        {
            if (pieces[type]) return;
            pieces[type] = true;
        }

    }
}