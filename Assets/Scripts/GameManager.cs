using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Blokr
{
    public class GameManager : MonoBehaviour
    {
        // ************************************************************************************
        // Fields
        // ************************************************************************************

        private static GameManager instance;

        [SerializeField]
        private Board board;

        [SerializeField]
        private GameObject[] basePieces;

        [SerializeField]
        private Material[] pieceMaterials;

        [SerializeField]
        private GameObject[] players;
        public GameObject[] Players
        {
            get { return players; }
            // set { players = value; }
        }


        [SerializeField]
        private List<GameObject> highlightPrefabs;

        private GameObject previousHighlightPrefab;
        private GameObject selectedPiece;
        private Player currentPlayer;

        // ************************************************************************************
        // Properties
        // ************************************************************************************

        public GameObject[] BasePieces
        {
            get { return basePieces; }
            set { basePieces = value; }
        }

        public Material[] PieceMaterials
        {
            get { return pieceMaterials; }
            set { pieceMaterials = value; }
        }

        public GameObject SelectedPiece
        {
            get { return selectedPiece; }
        }

        public Player CurrentPlayer
        {
            get { return currentPlayer; }
            set { currentPlayer = value; }
        }

        public Board Board
        {
            get { return board; }
            set { board = value; }
        }


        // ************************************************************************************
        // Constructor
        // ************************************************************************************
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<GameManager>();

                    if (instance == null)
                    {
                        GameObject managerObject = new("GameManager");
                        instance = managerObject.AddComponent<GameManager>();
                    }
                }
                return instance;
            }
        }


        // ************************************************************************************
        // Methods
        // ************************************************************************************
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            InitializeBoard();
        }

        void Start()
        {
        }

        public void AddPiece(GameObject piece, GameObject tileHighlight)
        {
            GameObject pieceObject = board.AddPiece(piece, tileHighlight);
            // player.Pieces.Add(pieceObject);
        }

        public void SelectPiece(GameObject piece)
        {
            this.selectedPiece = piece;

            Piece pieceComponent = piece.GetComponent<Piece>();
            TileSelector tileSelector = board.GetComponent<TileSelector>();
            GameObject newHighlightPrefab = GetHighlightPrefabForPiece(pieceComponent.PieceType);

            if (previousHighlightPrefab != null)
            {
                Destroy(previousHighlightPrefab);
            }

            previousHighlightPrefab = Instantiate(newHighlightPrefab, piece.transform.position, Quaternion.identity, piece.transform);
            tileSelector.SetHighlight(previousHighlightPrefab);
        }

        public void DeselectPiece(GameObject piece)
        {
            TileSelector tileSelector = board.GetComponent<TileSelector>();

            if (previousHighlightPrefab != null)
            {
                Destroy(previousHighlightPrefab);
            }

            previousHighlightPrefab = GetHighlightPrefabForPiece(PieceType.A1);
            tileSelector.SetHighlight(previousHighlightPrefab);
        }

        private GameObject GetHighlightPrefabForPiece(PieceType pieceType)
        {
            return pieceType switch
            {
                PieceType.A1 => highlightPrefabs[0],
                PieceType.A2 => highlightPrefabs[1],
                PieceType.A3 => highlightPrefabs[2],
                PieceType.A4 => highlightPrefabs[3],
                PieceType.A5 => highlightPrefabs[4],
                PieceType.B3 => highlightPrefabs[5],
                PieceType.B4 => highlightPrefabs[6],
                PieceType.B5 => highlightPrefabs[7],
                PieceType.C4 => highlightPrefabs[8],
                PieceType.C5 => highlightPrefabs[9],
                PieceType.D4 => highlightPrefabs[10],
                PieceType.D5 => highlightPrefabs[11],
                PieceType.E4 => highlightPrefabs[12],
                PieceType.E5 => highlightPrefabs[13],
                PieceType.F5 => highlightPrefabs[14],
                PieceType.G5 => highlightPrefabs[15],
                PieceType.H5 => highlightPrefabs[16],
                PieceType.I5 => highlightPrefabs[17],
                PieceType.J5 => highlightPrefabs[18],
                PieceType.K5 => highlightPrefabs[19],
                PieceType.L5 => highlightPrefabs[20],
                _ => highlightPrefabs[0],
            };
        }
        private void InitializeBoard()
        {
            PieceType pieceType;
            Direction direction;
            PieceColor color;
            for (int i = 0; i < 4; i++)
            {
                color = (PieceColor)i;
                direction = (Direction)i;
                GameObject parent = GameObject.FindGameObjectWithTag(color.ToString());
                for (int j = 0; j < 21; j++)
                {
                    pieceType = (PieceType)j;
                    string pieceName = $"{pieceType}_{color}";
                    Transform pieceTransform = parent.transform.Find(pieceName);
                    if (pieceTransform != null)
                    {
                        Piece piece = pieceTransform.gameObject.GetComponent<Piece>();
                        piece.PieceType = pieceType;
                        piece.PieceColor = color;
                        piece.PieceDirection = direction;
                    }
                }
            }
        }
    }

}