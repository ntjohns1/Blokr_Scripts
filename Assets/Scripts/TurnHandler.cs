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

        [SerializeField]
        private GameObject moveConfirm;

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
            get { return isFirstTurn = turnCount < 4; }
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
            currentPlayerIndex = currentPlayerIndex < 3 ? ++currentPlayerIndex : currentPlayerIndex = 0;
            GameManager.Instance.CurrentPlayer = GameManager.Instance.Players[currentPlayerIndex];
            turnCount++;
        }
        public void AcceptMove()
        {
            GameManager.Instance.AddPiece(MoveSelector.Instance.OccupiedCells, MoveSelector.Instance.Piece.PieceType, MoveSelector.Instance.Piece.PieceColor);
            moveConfirm.SetActive(false);
            MoveSelector.Instance.Piece = null;
            MoveSelector.Instance.OccupiedCells.Clear();
            MoveSelector.Instance.PlacedPiece = null;
            NextPlayer();
            ExitState();
        }

        public void CancelMove()
        {
            MoveSelector.Instance.PlacedPiece.SetActive(false);
            MoveSelector.Instance.Piece.gameObject.SetActive(true);
            moveConfirm.SetActive(false);
            ExitState();
        }

        public void EnterState()
        {
            moveConfirm.SetActive(true);

            Debug.Log($"CurrentPlayerIndex: {currentPlayerIndex}");
        }

        private void ExitState()
        {
            MoveSelector move = MoveSelector.Instance;
            move.EnterState();
        }
    }
}