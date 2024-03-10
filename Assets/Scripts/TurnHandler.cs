using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Blokr
{
    public class TurnHandler : MonoBehaviour
    {
        private static int  turnCount;
        
        private static bool isFirstTurn;
        
        private Player[] players;
        
        public static int  TurnCount
        {
            get { return turnCount; }
            set { turnCount = value; }
        }

        public static bool IsFirstTurn
        {
            get { return isFirstTurn = turnCount == 1; }
        }
        
        
        // Start is called before the first frame update
        void Start()
        {
            turnCount = 0;
            players = new Player[4];
            for (int i = 0; i < players.Length; i++)
            {
                PieceColor color = (PieceColor)i;
                players[i] = new Player($"{color}_Player");
            }
        }
    }
}