using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class Player
    {
        // Serialized fields that will be visible in the Unity Inspector
        // private List<GameObject> pieces;
        // private (PieceType pieceType, bool isPlayed)[] pieces;
        private readonly Dictionary<PieceType, bool> pieces;

        private string playerName;


        // Constructors
        public Player(string playerName)
        {
            this.playerName = playerName;
            pieces = new();
            for (int i = 0; i < 20; i++)
            {
                pieces.Add((PieceType)i,false);
            }
        }

        // Getters and setters for private fields
        public Dictionary<PieceType, bool> Pieces
        {
            get { return pieces; }
            // set { pieces = value; }
        }

        // public List<GameObject> PlayedPieces
        // {
        //     get { 
        //         return null; }
        //     set { playedPieces = value; }
        // }

        public string PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        // Methods
        public void MarkAsPlayed(PieceType type)
        {
            if (pieces[type]) return;
            pieces[type] = true;
        }

    }
}