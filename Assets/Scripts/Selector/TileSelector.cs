using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileSelector : MonoBehaviour
{
    // public GameObject tileHighlightPrefab;

    private GameObject tileHighlight;

    private Collider objectCollider;


    [SerializeField] private LayerMask gridLayer;



    // void Start ()
    // {
    //     Vector2Int gridPoint = Geometry.GridPoint(0, 0);
    //     Vector3 point = Geometry.PointFromGrid(gridPoint);
    //     tileHighlight = Instantiate(tileHighlightPrefab, point, Quaternion.identity, gameObject.transform);
    //     tileHighlight.SetActive(false);
    // }

    public void SetHighlight(GameObject highlightPrefab)
    {
        tileHighlight = highlightPrefab;
        objectCollider = highlightPrefab.GetComponent<Collider>();
    }
    void Update()
    {
        if (tileHighlight != null)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f, gridLayer))
            {
                Vector3 point = hit.point;
                Vector2Int gridPoint = Geometry.GridFromPoint(point);
                Piece piece = GameManager.Instance.SelectedPiece.GetComponent<Piece>();
                Debug.Log(piece.PieceType);
                int initDirection = (int)piece.PieceDirection;
                int dirIndex = initDirection;

                List<Vector2Int> occupiedGridPositions = GetOccupiedCellsForType(piece.PieceType, piece.PieceDirection, gridPoint, tileHighlight);
                bool allPositionsInBounds = occupiedGridPositions.All(pos => pos.x >= 0 && pos.x <= 19 && pos.y >= 0 && pos.y <= 19);

                if (allPositionsInBounds)
                {
                    tileHighlight.transform.position = Geometry.PointFromGrid(gridPoint);
                    tileHighlight.SetActive(true);
                }
                else
                {
                    tileHighlight.SetActive(false);
                }


                if (Input.GetKeyUp("e"))
                {
                    tileHighlight.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
                    if (dirIndex < 3)
                    {
                        piece.PieceDirection = (Direction)dirIndex++;
                    }
                    else
                    {
                        piece.PieceDirection = (Direction)0;
                    }
                }
                if (Input.GetKeyUp("q"))
                {
                    tileHighlight.transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self);
                }
                if (Input.GetMouseButtonUp(0))
                {
                    List<Vector2Int> list = GetOccupiedCellsForType(piece.PieceType, piece.PieceDirection, gridPoint, tileHighlight);
                    foreach (Vector2Int i in list)
                    {
                        Debug.Log(i);
                    }
                    // GameManager.Instance.AddPiece(piece, tileHighlight);
                }
            }
            else
            {
                if (tileHighlight != null)
                {
                    tileHighlight.SetActive(false);
                }
            }
        }
    }

    // Function to check if bounds are intersecting
    private bool AreBoundsIntersecting(Bounds bounds1, Bounds bounds2)
    {
        return bounds1.Intersects(bounds2);
    }
    /*
    *** Tile Highlight should not display if any cell is out of bounds.
    - Possible approach - use Update to track the values of the Selector child object 
      and only set the object to active if they are in bounds
    */

    private List<Vector2Int> GetOccupiedCellsForType(PieceType pieceType, Direction direction, Vector2Int gridPoint, GameObject tileHighlight)
    {
        List<Vector2Int> list = new List<Vector2Int>();
        switch (pieceType)
        {
            case PieceType.A1:
                A1Selector a1Selector = tileHighlight.GetComponent<A1Selector>();
                return a1Selector.GetOccupiedGridPositions(gridPoint, direction);
            case PieceType.A2:
                A2Selector a2Selector = tileHighlight.GetComponent<A2Selector>();
                return a2Selector.GetOccupiedGridPositions(gridPoint, direction);
            case PieceType.A3:
                A3Selector a3Selector = tileHighlight.GetComponent<A3Selector>();
                return a3Selector.GetOccupiedGridPositions(gridPoint, direction);
            case PieceType.B3:
                B3Selector b3Selector = tileHighlight.GetComponent<B3Selector>();
                return b3Selector.GetOccupiedGridPositions(gridPoint, direction);
            case PieceType.A4:
                A4Selector a4Selector = tileHighlight.GetComponent<A4Selector>();
                return a4Selector.GetOccupiedGridPositions(gridPoint, direction);
            case PieceType.B4:
                A1Selector b4Selector = tileHighlight.GetComponent<A1Selector>();
                return b4Selector.GetOccupiedGridPositions(gridPoint, direction);
            case PieceType.C4:
                A1Selector c4Selector = tileHighlight.GetComponent<A1Selector>();
                return c4Selector.GetOccupiedGridPositions(gridPoint, direction);
            case PieceType.D4:
                A1Selector d4Selector = tileHighlight.GetComponent<A1Selector>();
                return d4Selector.GetOccupiedGridPositions(gridPoint, direction);
            case PieceType.E4:
                A1Selector e4Selector = tileHighlight.GetComponent<A1Selector>();
                return e4Selector.GetOccupiedGridPositions(gridPoint, direction);
            case PieceType.A5:
                A5Selector a5Selector = tileHighlight.GetComponent<A5Selector>();
                return a5Selector.GetOccupiedGridPositions(gridPoint, direction);
            case PieceType.B5:
                B5Selector b5Selector = tileHighlight.GetComponent<B5Selector>();
                return b5Selector.GetOccupiedGridPositions(gridPoint, direction);
            case PieceType.C5:
                C5Selector c5Selector = tileHighlight.GetComponent<C5Selector>();
                return c5Selector.GetOccupiedGridPositions(gridPoint, direction);
            case PieceType.D5:
                D5Selector d5Selector = tileHighlight.GetComponent<D5Selector>();
                return d5Selector.GetOccupiedGridPositions(gridPoint, direction);
            case PieceType.E5:
                E5Selector e5Selector = tileHighlight.GetComponent<E5Selector>();
                return e5Selector.GetOccupiedGridPositions(gridPoint, direction);
            case PieceType.F5:
                F5Selector f5Selector = tileHighlight.GetComponent<F5Selector>();
                return f5Selector.GetOccupiedGridPositions(gridPoint, direction);
            case PieceType.G5:
                G5Selector g5Selector = tileHighlight.GetComponent<G5Selector>();
                return g5Selector.GetOccupiedGridPositions(gridPoint, direction);
            case PieceType.H5:
                H5Selector h5Selector = tileHighlight.GetComponent<H5Selector>();
                return h5Selector.GetOccupiedGridPositions(gridPoint, direction);
            case PieceType.I5:
                I5Selector i5Selector = tileHighlight.GetComponent<I5Selector>();
                return i5Selector.GetOccupiedGridPositions(gridPoint, direction);
            case PieceType.J5:
                J5Selector j5Selector = tileHighlight.GetComponent<J5Selector>();
                return j5Selector.GetOccupiedGridPositions(gridPoint, direction);
            case PieceType.K5:
                K5Selector k5Selector = tileHighlight.GetComponent<K5Selector>();
                return k5Selector.GetOccupiedGridPositions(gridPoint, direction);
            case PieceType.L5:
                L5Selector l5Selector = tileHighlight.GetComponent<L5Selector>();
                return l5Selector.GetOccupiedGridPositions(gridPoint, direction);
            default:
                A1Selector a1 = tileHighlight.GetComponent<A1Selector>();
                return a1.GetOccupiedGridPositions(gridPoint, direction);
        }
    }


    public void EnterState()
    {
        enabled = true;
    }

    private void ExitState(GameObject movingPiece)
    {
        this.enabled = false;
        tileHighlight.SetActive(false);
        // MoveSelector move = GetComponent<MoveSelector>();
        // move.EnterState(movingPiece);
    }
}
