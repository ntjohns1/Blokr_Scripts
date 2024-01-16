using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField]
    private Board board;

    [SerializeField]
    private List<GameObject> redPieces;
    [SerializeField]
    private List<GameObject> greenPieces;
    [SerializeField]
    private List<GameObject> bluePieces;
    [SerializeField]
    private List<GameObject> yellowPieces;

    [SerializeField]
    private List<GameObject> highlightPrefabs;

    private GameObject previousHighlightPrefab;
    private GameObject[,] pieces;

    private GameObject selectedPiece;
    public GameObject SelectedPiece
    {
        get { return selectedPiece; }
    }
    

    private Player currentPlayer;
    public Player CurrentPlayer
    {
        get { return currentPlayer; }
        set { currentPlayer = value; }
    }


    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                // If the instance is null, try to find an existing GameManager in the scene
                instance = FindObjectOfType<GameManager>();

                // If no GameManager is found, create a new one
                if (instance == null)
                {
                    GameObject managerObject = new GameObject("GameManager");
                    instance = managerObject.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }
    public Board Board
    {
        get { return board; }
        set { board = value; }
    }

    // Ensure that the GameManager persists between scenes
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If another GameManager already exists, destroy this one
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialize your GameManager here
    }

    public void AddPiece(GameObject piece, GameObject tileHighlight)
    {
        GameObject pieceObject = board.AddPiece(piece,tileHighlight);
        // player.Pieces.Add(pieceObject);
    }

    // public void SelectPieceAtGrid(Vector2Int gridPoint)
    // {
    //     GameObject selectedPiece = pieces[gridPoint.x, gridPoint.y];
    //     if (selectedPiece)
    //     {
    //         board.SelectPiece(selectedPiece);
    //     }
    // }

    // public List<Vector2Int> MovesForPiece(GameObject pieceObject)
    // {
    //     Piece piece = pieceObject.GetComponent<Piece>();
    //     Vector2Int gridPoint = GridForPiece(pieceObject);
    //     List<Vector2Int> locations = piece.MoveLocations(gridPoint);

    //     // filter out offboard locations
    //     locations.RemoveAll(gp => gp.x < 0 || gp.x > 7 || gp.y < 0 || gp.y > 7);

    //     // filter out locations with friendly piece
    //     locations.RemoveAll(gp => FriendlyPieceAt(gp));

    //     return locations;
    // }

    public void SelectPiece(GameObject piece)
    {
        this.selectedPiece = piece;

        // Determine the piece type and instantiate the corresponding highlight prefab
        Piece pieceComponent = piece.GetComponent<Piece>();
        TileSelector tileSelector = board.GetComponent<TileSelector>();
        GameObject newHighlightPrefab = GetHighlightPrefabForPiece(pieceComponent.PieceType);

        // Destroy the previous highlight prefab instance if it exists
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

        // Hide the current highlight prefab if it exists
        if (previousHighlightPrefab != null)
        {
            Destroy(previousHighlightPrefab);
        }

        // Set the default highlight prefab
        previousHighlightPrefab = GetHighlightPrefabForPiece(PieceType.A1);
        tileSelector.SetHighlight(previousHighlightPrefab);
    }


    // public bool DoesPieceBelongToCurrentPlayer(GameObject piece)
    // {
    //     return CurrentPlayer.Pieces.Contains(piece);
    // }

    // public GameObject PieceAtGrid(Vector2Int gridPoint)
    // {
    //     if (gridPoint.x > 7 || gridPoint.y > 7 || gridPoint.x < 0 || gridPoint.y < 0)
    //     {
    //         return null;
    //     }
    //     return pieces[gridPoint.x, gridPoint.y];
    // }

    private GameObject GetHighlightPrefabForPiece(PieceType pieceType)
    {
        switch (pieceType)
        {
            case PieceType.A1:
                return highlightPrefabs[0];
            case PieceType.A2:
                return highlightPrefabs[1];
            case PieceType.A3:
                return highlightPrefabs[2];
            case PieceType.B3:
                return highlightPrefabs[3];
            case PieceType.A4:
                return highlightPrefabs[4];
            case PieceType.B4:
                return highlightPrefabs[5];
            case PieceType.C4:
                return highlightPrefabs[6];
            case PieceType.D4:
                return highlightPrefabs[7];
            case PieceType.E4:
                return highlightPrefabs[8];
            case PieceType.A5:
                return highlightPrefabs[9];
            case PieceType.B5:
                return highlightPrefabs[10];
            case PieceType.C5:
                return highlightPrefabs[11];
            case PieceType.D5:
                return highlightPrefabs[12];
            case PieceType.E5:
                return highlightPrefabs[13];
            case PieceType.F5:
                return highlightPrefabs[14];
            case PieceType.G5:
                return highlightPrefabs[15];
            case PieceType.H5:
                return highlightPrefabs[16];
            case PieceType.I5:
                return highlightPrefabs[17];
            case PieceType.J5:
                return highlightPrefabs[18];
            case PieceType.K5:
                return highlightPrefabs[19];
            case PieceType.L5:
                return highlightPrefabs[20];
            default:
                return highlightPrefabs[0];
        }
    }

    // public Vector2Int GridForPiece(GameObject piece)
    // {
    //     for (int i = 0; i < 20; i++)
    //     {
    //         for (int j = 0; j < 8; j++)
    //         {
    //             if (pieces[i, j] == piece)
    //             {
    //                 return new Vector2Int(i, j);
    //             }
    //         }
    //     }

    //     return new Vector2Int(-1, -1);
    // }

    // public bool FriendlyPieceAt(Vector2Int gridPoint)
    // {
    //     GameObject piece = PieceAtGrid(gridPoint);

    //     if (piece == null)
    //     {
    //         return false;
    //     }

    //     if (otherPlayer.pieces.Contains(piece))
    //     {
    //         return false;
    //     }

    //     return true;
    // }

    // public void NextPlayer()
    // {
    //     Player tempPlayer = currentPlayer;
    //     currentPlayer = otherPlayer;
    //     otherPlayer = tempPlayer;
    // }
}
