using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Blokr.Core.Models;
using Blokr.Core.Services;
using Blokr.Highlighter;
using UnityEngine;
using UnityEngine.Animations;

namespace Blokr.States
{
    public class PiecePlacementState : MonoBehaviour
    {
        // ************************************************************************************
        // Fields
        // ************************************************************************************

        private static PiecePlacementState instance;
        
        private InputManager input;
        private GameObject tileHighlight;

        // private Collider objectCollider;
        [SerializeField] private LayerMask gridLayer;

        private Piece piece;
        private List<GridPosition> occupiedCells;

        private List<GridPosition> adjacentCells;

        private List<GridPosition> playableCells;
        
        private GameObject placedPiece;
        
        // ************************************************************************************
        // Properties
        // ************************************************************************************
        
        public static PiecePlacementState Instance
        {
            get { return instance; }
            set { instance = value; }
        }
        
        public Piece Piece
        {
            get { return piece; }
            set { piece = value; }
        }

        public List<GridPosition> OccupiedCells
        {
            get { return occupiedCells; }
            set { occupiedCells = value; }
        }

        public List<GridPosition> AdjacentCells
        {
            get { return adjacentCells; }
            set { adjacentCells = value; }
        }

        public List<GridPosition> PlayableCells
        {
            get { return playableCells; }
            set { playableCells = value; }
        }
                
        public GameObject PlacedPiece
        {
            get { return placedPiece; }
            set { placedPiece = value; }
        }

        // ************************************************************************************
        // Methods
        // ************************************************************************************
        
        void Awake()
        {
            instance = this;
        }

        void Start() 
        {
            input = InputManager.Instance;
        }

        public void SetHighlight(GameObject highlightPrefab)
        {
            tileHighlight = highlightPrefab;
            // objectCollider = highlightPrefab.GetComponent<Collider>();
            piece = GameManager.Instance.SelectedPiece.GetComponent<Piece>();
            InitializePositionAndRotation();
        }
        void Update()
        {
            if (tileHighlight == null || piece == null) return;

            input.HandleMouseOver(tileHighlight, piece);
            input.HandleRotationInput(tileHighlight, piece);
            input.HandleFlipInput(tileHighlight, piece);
            PlacePiece();
        }

        void InitializePositionAndRotation()
        {
            if (tileHighlight == null) return;
            tileHighlight.transform.SetPositionAndRotation(Vector3.zero, Quaternion.Euler(0.0f, 90.0f * (int)piece.PieceDirection, 0.0f));
        }

        public void PlacePiece()
        {
            if (tileHighlight == null) return;
            if (tileHighlight.activeInHierarchy)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    GridPosition point = Geometry.GridFromPoint(tileHighlight.transform.position);
                    occupiedCells = input.GetOccupiedCellsForType(tileHighlight, point, piece.PieceDirection, piece.IsFlipped);
                    adjacentCells = input.GetAdjacentCellsForType(tileHighlight, point, piece.PieceDirection, piece.IsFlipped);
                    playableCells = input.GetPlayableCellsForType(tileHighlight, adjacentCells);
                    foreach (GridPosition cell in occupiedCells)
                    {
                        Debug.Log(cell);
                    }
                    Player currentPlayer = GameManager.Instance.CurrentPlayer.GetComponent<Player>();
                    currentPlayer.UpdateAdjacentPositions(AdjacentCells);
                    currentPlayer.UpdatePlayablePositions(PlayableCells);
                    placedPiece = PiecePool.SharedInstance.GetPiece(piece.PieceType.ToString(), piece.PieceColor);
                    placedPiece.transform.SetPositionAndRotation(Geometry.PointFromGrid(occupiedCells[0]), tileHighlight.transform.rotation);
                    placedPiece.SetActive(true);
                    piece.gameObject.SetActive(false);
                    ExitState();
                }
            }
        }

        public void EnterState()
        {
            enabled = true;
            if (tileHighlight != null)
            {
                tileHighlight.SetActive(true);
            }
        }

        private void ExitState()
        {
            tileHighlight.SetActive(false);
            enabled = false;
            TurnHandler turnHandler = GetComponent<TurnHandler>();
            turnHandler.EnterState();
        }

        // public void AcceptMove()
        // {
        //     GameManager.Instance.AddPiece(occupiedCells, piece.PieceType);
        //     moveConfirm.SetActive(false);
        //     TurnHandler.Instance.NextPlayer();
        // }

        // public void CancelMove()
        // {
        //     placedPiece.SetActive(false);
        //     piece.gameObject.SetActive(true);
        //     moveConfirm.SetActive(false);
        // }
    }
}
