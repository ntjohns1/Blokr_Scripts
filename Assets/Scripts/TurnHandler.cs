using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Blokr
{
    public class TurnHandler : MonoBehaviour
    {
        private static TurnHandler instance;
        
        private static int turnCount;

        private static int currentPlayerIndex;

        private static bool isFirstTurn;

        private Player[] players;

        public static TurnHandler Instance
        {
            get { return instance; }
            set { instance = value; }
        }

        public static int TurnCount
        {
            get { return turnCount; }
            set { turnCount = value; }
        }
        void Awake()
        {
            instance = this;
        }

        public static bool IsFirstTurn
        {
            get { return isFirstTurn = turnCount < 3; }
        }


        // To Do: Make color order more dynamic
        void Start()
        {
            turnCount = 0;
            players = new Player[4];
            for (int i = 0; i < players.Length; i++)
            {
                PieceColor color = (PieceColor)i;
                players[i] = GameManager.Instance.Players[i].GetComponent<Player>();
                // players[i].PlayerName = $"{color}_Player";
                players[i].Color = color;
            }
        }

        public void NextPlayer()
        {
            GameManager.Instance.CurrentPlayer = GameManager.Instance.Players[currentPlayerIndex];
            currentPlayerIndex = currentPlayerIndex < 3 ? currentPlayerIndex++ : currentPlayerIndex = 0;
            turnCount++;
        }
        // void EnterState()
        // {
        // }

        // void ExiitState()
        // {
        //     //PieceSelector.SetActive for CurrentPlayer
        // }
    }
}