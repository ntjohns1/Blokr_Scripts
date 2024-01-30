using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class Player
    {
        // Serialized fields that will be visible in the Unity Inspector
        private List<GameObject> pieces;
        private List<GameObject> playedPieces;
        private string name;


        // Constructors
        public Player(string name)
        {
            this.name = name;
            pieces = new List<GameObject>();
            playedPieces = new List<GameObject>();
        }

        // Getters and setters for private fields
        public List<GameObject> Pieces
        {
            get { return pieces; }
            set { pieces = value; }
        }

        public List<GameObject> PlayedPieces
        {
            get { return playedPieces; }
            set { playedPieces = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}