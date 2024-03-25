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

        private readonly Dictionary<PieceType, bool> pieces;

        private List<Vector2Int> playablePositions;

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
        
        public List<Vector2Int> PlayablePositions
        {
            get { return playablePositions; }
            set { playablePositions = value; }
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
        public Player(string playerName)
        {
            this.playerName = playerName;
            pieces = new();
            for (int i = 0; i < 20; i++)
            {
                pieces.Add((PieceType)i, false);
            }
            playablePositions = new();
        }

        public void MarkAsPlayed(PieceType type)
        {
            if (pieces[type]) return;
            pieces[type] = true;
        }

    }
}