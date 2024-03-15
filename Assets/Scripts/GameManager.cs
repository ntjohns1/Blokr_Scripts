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

        [SerializeField]
        private List<GameObject> highlightPrefabs;

        private GameObject previousHighlightPrefab;
        private GameObject selectedPiece;
        private GameObject currentPlayer;

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

        public GameObject[] Players
        {
            get { return players; }
            // set { players = value; }
        }

        public GameObject SelectedPiece
        {
            get { return selectedPiece; }
        }

        public List<GameObject> HighlightPrefabs
        {
            get { return highlightPrefabs; }
            set { highlightPrefabs = value; }
        }


        public GameObject CurrentPlayer
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
            // TODO: 
            // Select first Player from list instead of hard-coding
            // Change order of colors
            currentPlayer = players[0];
        }

        public void AddPiece(List<Vector2Int> positions, PieceType type)
        {
            board.AddPiece(positions);
            // currentPlayer.MarkAsPlayed(type);
        }

        public void SelectPiece(GameObject piece)
        {
            selectedPiece = piece;

            Piece pieceComponent = piece.GetComponent<Piece>();
            TileSelector tileSelector = board.GetComponent<TileSelector>();
            bool belongsToCurrentPlayer = MoveSelector.Instance.BelongsToCurrentPlayer(currentPlayer, pieceComponent.PieceColor);
            GameObject newHighlightPrefab;
            if (belongsToCurrentPlayer)
            {
                newHighlightPrefab = SelectorPool.SharedInstance.GetSelector(pieceComponent.PieceType);
            }
            else
            {
                return;
            }

            if (previousHighlightPrefab != null)
            {
                previousHighlightPrefab.SetActive(false);
                previousHighlightPrefab.transform.SetParent(SelectorPool.SharedInstance.transform);

            }

            previousHighlightPrefab = newHighlightPrefab;
            previousHighlightPrefab.transform.SetParent(piece.transform);

            // workaround for incorrectly sized prefab
            Vector3 adjustedScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
            previousHighlightPrefab.transform.localScale = adjustedScale;

            tileSelector.SetHighlight(previousHighlightPrefab);
        }

        public void DeselectPiece(GameObject piece)
        {
            TileSelector tileSelector = board.GetComponent<TileSelector>();

            if (previousHighlightPrefab != null)
            {
                previousHighlightPrefab.SetActive(false);
                previousHighlightPrefab.transform.SetParent(SelectorPool.SharedInstance.transform);
            }

            previousHighlightPrefab = SelectorPool.SharedInstance.GetSelector(PieceType.A1);
            tileSelector.SetHighlight(previousHighlightPrefab);
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