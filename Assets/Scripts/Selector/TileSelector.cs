using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Blokr
{
    public class TileSelector : MonoBehaviour
    {
        // public GameObject tileHighlightPrefab;

        private GameObject tileHighlight;

        private Collider objectCollider;

        private Vector3 currentRotation;

        [SerializeField] private LayerMask gridLayer;

        private bool isFlipped = false;

        public void SetHighlight(GameObject highlightPrefab)
        {
            tileHighlight = highlightPrefab;
            objectCollider = highlightPrefab.GetComponent<Collider>();
            InitializePositionAndRotation(); // Call the new initialization method here
        }
        void Update()
        {
            if (tileHighlight == null) return;

            HandleMouseOver();
            HandleRotationInput();
            HandleFlipInput();
        }

        void InitializePositionAndRotation()
        {
            if (tileHighlight == null) return;
            // Initialize with a default position and rotation if needed
            tileHighlight.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        }
        void HandleMouseOver()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, gridLayer))
            {
                Vector3 point = hit.point;
                Vector2Int gridPoint = Geometry.GridFromPoint(point);
                tileHighlight.SetActive(true);
                // Adjust position based on grid point, without resetting rotation
                tileHighlight.transform.position = Geometry.PointFromGrid(gridPoint);
            }
            else
            {
                tileHighlight.SetActive(false);
            }
        }

        void HandleRotationInput()
        {
            Piece piece = GameManager.Instance.SelectedPiece.GetComponent<Piece>();
            int initDirection = (int)piece.PieceDirection;
            int dirIndex = initDirection;

            if (Input.GetKeyUp("e"))
            {
                tileHighlight.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
                if (dirIndex < 3)
                {
                    dirIndex++;
                }
                else
                {
                    dirIndex = 0;
                }

                piece.PieceDirection = (Direction)dirIndex;
                currentRotation = tileHighlight.transform.eulerAngles;
            }

            if (Input.GetKeyUp("q"))
            {
                tileHighlight.transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self);
                if (dirIndex > 0)
                {
                    dirIndex--;
                }
                else
                {
                    dirIndex = 3;
                }

                piece.PieceDirection = (Direction)dirIndex;
                currentRotation = tileHighlight.transform.eulerAngles;
            }
        }

        void HandleFlipInput()
        {
            if (Input.GetKeyUp("f"))
            {
                isFlipped = !isFlipped;
                ApplyFlipTransformation();
            }
        }

        void ApplyFlipTransformation()
        {
            Piece piece = GameManager.Instance.SelectedPiece.GetComponent<Piece>();
            if (piece.PieceType <= PieceType.A4)
            {
                float zRotation = isFlipped ? 180f : 0f;
                tileHighlight.transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, zRotation);
            }
            else
            {
                float xRotation = isFlipped ? 180f : 0f;
                tileHighlight.transform.rotation = Quaternion.Euler(xRotation, currentRotation.y, currentRotation.z);
            }
        }

        private List<Vector2Int> GetOccupiedCellsForType(PieceType pieceType, Direction direction, bool isFlipped, Vector2Int gridPoint, GameObject tileHighlight)
        {
            List<Vector2Int> list = new List<Vector2Int>();
            switch (pieceType)
            {
                case PieceType.A1:
                    A1Selector a1Selector = tileHighlight.GetComponent<A1Selector>();
                    a1Selector.SelectorDirection = direction;
                    // Debug.Log("Selector Direction: " + a1Selector.SelectorDirection);
                    return a1Selector.GetOccupiedGridPositions(gridPoint, direction, isFlipped);
                case PieceType.A2:
                    A2Selector a2Selector = tileHighlight.GetComponent<A2Selector>();
                    a2Selector.SelectorDirection = direction;
                    // Debug.Log("Selector Direction: " + a2Selector.SelectorDirection);
                    return a2Selector.GetOccupiedGridPositions(gridPoint, direction, isFlipped);
                case PieceType.A3:
                    A3Selector a3Selector = tileHighlight.GetComponent<A3Selector>();
                    a3Selector.SelectorDirection = direction;
                    // Debug.Log("Selector Direction: " + a3Selector.SelectorDirection);
                    return a3Selector.GetOccupiedGridPositions(gridPoint, direction, isFlipped);
                case PieceType.A4:
                    A4Selector a4Selector = tileHighlight.GetComponent<A4Selector>();
                    a4Selector.SelectorDirection = direction;
                    // Debug.Log("Selector Direction: " + a4Selector.SelectorDirection);
                    return a4Selector.GetOccupiedGridPositions(gridPoint, direction, isFlipped);
                case PieceType.A5:
                    A5Selector a5Selector = tileHighlight.GetComponent<A5Selector>();
                    a5Selector.SelectorDirection = direction;
                    // Debug.Log("Selector Direction: " + a5Selector.SelectorDirection);
                    return a5Selector.GetOccupiedGridPositions(gridPoint, direction, isFlipped);
                case PieceType.B3:
                    B3Selector b3Selector = tileHighlight.GetComponent<B3Selector>();
                    b3Selector.SelectorDirection = direction;
                    // Debug.Log("Selector Direction: " + b3Selector.SelectorDirection);
                    return b3Selector.GetOccupiedGridPositions(gridPoint, direction, isFlipped);
                case PieceType.B4:
                    B4Selector b4Selector = tileHighlight.GetComponent<B4Selector>();
                    // Debug.Log("Selector Direction: " + b4Selector.SelectorDirection);
                    b4Selector.SelectorDirection = direction;
                    return b4Selector.GetOccupiedGridPositions(gridPoint, direction, isFlipped);
                case PieceType.B5:
                    B5Selector b5Selector = tileHighlight.GetComponent<B5Selector>();
                    b5Selector.SelectorDirection = direction;
                    // Debug.Log("Selector Direction: " + b5Selector.SelectorDirection);
                    return b5Selector.GetOccupiedGridPositions(gridPoint, direction, isFlipped);
                case PieceType.C4:
                    C4Selector c4Selector = tileHighlight.GetComponent<C4Selector>();
                    c4Selector.SelectorDirection = direction;
                    // Debug.Log("Selector Direction: " + c4Selector.SelectorDirection);
                    return c4Selector.GetOccupiedGridPositions(gridPoint, direction, isFlipped);
                case PieceType.C5:
                    C5Selector c5Selector = tileHighlight.GetComponent<C5Selector>();
                    c5Selector.SelectorDirection = direction;
                    // Debug.Log("Selector Direction: " + c5Selector.SelectorDirection);
                    return c5Selector.GetOccupiedGridPositions(gridPoint, direction, isFlipped);
                case PieceType.D4:
                    D4Selector d4Selector = tileHighlight.GetComponent<D4Selector>();
                    d4Selector.SelectorDirection = direction;
                    // Debug.Log("Selector Direction: " + d4Selector.SelectorDirection);
                    return d4Selector.GetOccupiedGridPositions(gridPoint, direction, isFlipped);
                case PieceType.D5:
                    D5Selector d5Selector = tileHighlight.GetComponent<D5Selector>();
                    d5Selector.SelectorDirection = direction;
                    // Debug.Log("Selector Direction: " + d5Selector.SelectorDirection);
                    return d5Selector.GetOccupiedGridPositions(gridPoint, direction, isFlipped);
                case PieceType.E4:
                    E4Selector e4Selector = tileHighlight.GetComponent<E4Selector>();
                    e4Selector.SelectorDirection = direction;
                    // Debug.Log("Selector Direction: " + e4Selector.SelectorDirection);
                    return e4Selector.GetOccupiedGridPositions(gridPoint, direction, isFlipped);
                case PieceType.E5:
                    E5Selector e5Selector = tileHighlight.GetComponent<E5Selector>();
                    e5Selector.SelectorDirection = direction;
                    // Debug.Log("Selector Direction: " + e5Selector.SelectorDirection);
                    return e5Selector.GetOccupiedGridPositions(gridPoint, direction, isFlipped);
                case PieceType.F5:
                    F5Selector f5Selector = tileHighlight.GetComponent<F5Selector>();
                    f5Selector.SelectorDirection = direction;
                    // Debug.Log("Selector Direction: " + f5Selector.SelectorDirection);
                    return f5Selector.GetOccupiedGridPositions(gridPoint, direction, isFlipped);
                case PieceType.G5:
                    G5Selector g5Selector = tileHighlight.GetComponent<G5Selector>();
                    g5Selector.SelectorDirection = direction;
                    // Debug.Log("Selector Direction: " + g5Selector.SelectorDirection);
                    return g5Selector.GetOccupiedGridPositions(gridPoint, direction, isFlipped);
                case PieceType.H5:
                    H5Selector h5Selector = tileHighlight.GetComponent<H5Selector>();
                    h5Selector.SelectorDirection = direction;
                    // Debug.Log("Selector Direction: " + h5Selector.SelectorDirection);
                    return h5Selector.GetOccupiedGridPositions(gridPoint, direction, isFlipped);
                case PieceType.I5:
                    I5Selector i5Selector = tileHighlight.GetComponent<I5Selector>();
                    i5Selector.SelectorDirection = direction;
                    // Debug.Log("Selector Direction: " + i5Selector.SelectorDirection);
                    return i5Selector.GetOccupiedGridPositions(gridPoint, direction, isFlipped);
                case PieceType.J5:
                    J5Selector j5Selector = tileHighlight.GetComponent<J5Selector>();
                    j5Selector.SelectorDirection = direction;
                    // Debug.Log("Selector Direction: " + j5Selector.SelectorDirection);
                    return j5Selector.GetOccupiedGridPositions(gridPoint, direction, isFlipped);
                case PieceType.K5:
                    K5Selector k5Selector = tileHighlight.GetComponent<K5Selector>();
                    k5Selector.SelectorDirection = direction;
                    // Debug.Log("Selector Direction: " + k5Selector.SelectorDirection);
                    return k5Selector.GetOccupiedGridPositions(gridPoint, direction, isFlipped);
                case PieceType.L5:
                    L5Selector l5Selector = tileHighlight.GetComponent<L5Selector>();
                    l5Selector.SelectorDirection = direction;
                    // Debug.Log("Selector Direction: " + l5Selector.SelectorDirection);
                    return l5Selector.GetOccupiedGridPositions(gridPoint, direction, isFlipped);
                default:
                    A1Selector a1 = tileHighlight.GetComponent<A1Selector>();
                    // Debug.Log("Selector Direction: " + a1.SelectorDirection);
                    return a1.GetOccupiedGridPositions(gridPoint, direction, isFlipped);
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
}