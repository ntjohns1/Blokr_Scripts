using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Blokr;
using UnityEngine;


namespace Blokr
{
    public class MoveSelector : MonoBehaviour
    {
        private GameObject tileHighlight;

        private Piece piece;


        GameObject placedPiece;

        private List<Vector2Int> occupiedCells;


        [SerializeField]
        private readonly GameObject moveConfirm;

        private static MoveSelector instance;
        public static MoveSelector Instance
        {
            get { return instance; }
            // set { instance = value; }
        }

        private List<Vector2Int> initCells;

        public GameObject MoveConfirm
        {
            get { return moveConfirm; }
            // set { moveConfirm = value; }
        }

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

        void Update()
        {
            if (tileHighlight == null) return;

            // To Do : This should all go in MoveSelector
            InputManager.Instance.HandleMouseOver(tileHighlight, piece);
            InputManager.Instance.HandleRotationInput(tileHighlight, piece);
            InputManager.Instance.HandleFlipInput(tileHighlight, piece);
            InputManager.Instance.HandleClickInput(tileHighlight, moveConfirm, piece);

            // HandleMouseOver();
            // HandleRotationInput();
            // HandleFlipInput();
            // HandleClickInput();
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

        public void AcceptMove()
        {
            GameManager.Instance.AddPiece(occupiedCells, piece.PieceType);
            moveConfirm.SetActive(false);
            TurnHandler.Instance.NextPlayer();
        }

        public void CancelMove()
        {
            placedPiece.SetActive(false);
            piece.gameObject.SetActive(true);
            moveConfirm.SetActive(false);
        }

        public void EnterState(GameObject tileHighlight, Piece piece)
        {
            enabled = true;
            this.piece = piece;
            this.tileHighlight = tileHighlight;
        }

        private void ExitState()
        {
            enabled = false;
        }
    }
}


