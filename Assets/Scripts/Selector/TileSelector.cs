using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Blokr
{
    public class TileSelector : MonoBehaviour
    {
        // ************************************************************************************
        // Fields
        // ************************************************************************************

        public GameObject test;

        private GameObject tileHighlight;

        private Collider objectCollider;

        [SerializeField] private LayerMask gridLayer;

        private Piece piece;

        // ************************************************************************************
        // Methods
        // ************************************************************************************

        public void SetHighlight(GameObject highlightPrefab)
        {
            tileHighlight = highlightPrefab;
            objectCollider = highlightPrefab.GetComponent<Collider>();
            piece = GameManager.Instance.SelectedPiece.GetComponent<Piece>();
            InitializePositionAndRotation();
        }
        void Update()
        {
            if (tileHighlight == null) return;

            HandleMouseOver();
            HandleRotationInput();
            HandleFlipInput();
            HandleClickInput();
        }

        void InitializePositionAndRotation()
        {
            if (tileHighlight == null) return;
            tileHighlight.transform.SetPositionAndRotation(Vector3.zero, Quaternion.Euler(0.0f, 90.0f * (int)piece.PieceDirection, 0.0f));
        }
        void HandleMouseOver()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, gridLayer))
            {
                Vector3 point = hit.point;
                Vector2Int gridPoint = Geometry.GridFromPoint(point);
                ISelector selector = tileHighlight.GetComponent<ISelector>();
                List<Vector2Int> occupiedGridPositions = GetOccupiedCellsForType(tileHighlight, gridPoint, piece.PieceDirection, piece.IsFlipped);
                bool allPositionsInBounds = occupiedGridPositions.All(pos => pos.x >= 0 && pos.x <= 19 && pos.y >= 0 && pos.y <= 19);
                if (allPositionsInBounds)
                {
                    tileHighlight.SetActive(true);
                    tileHighlight.transform.position = Geometry.PointFromGrid(gridPoint);
                }
                else
                {
                    tileHighlight.SetActive(false);
                }

            }
            else
            {
                tileHighlight.SetActive(false);
            }
        }

        void HandleRotationInput()
        {
            int initDirection = (int)piece.PieceDirection;
            int dirIndex = initDirection;


            if (Input.GetKeyUp("e"))
            {
                if (!piece.IsFlipped)
                {
                    tileHighlight.transform.Rotate(0f, 90.0f, 0f, Space.Self);
                }
                else
                {
                    tileHighlight.transform.Rotate(0f, -90.0f, 0f, Space.Self);
                }
                if (dirIndex < 3)
                {
                    dirIndex++;
                }
                else
                {
                    dirIndex = 0;
                }
                // dirIndex = dirIndex < 3 ? dirIndex++ : 0;
                piece.PieceDirection = (Direction)dirIndex;
            }
            if (Input.GetKeyUp("q"))
            {
                if (!piece.IsFlipped)
                {
                    tileHighlight.transform.Rotate(0f, -90.0f, 0f, Space.Self);
                }
                else
                {
                    tileHighlight.transform.Rotate(0f, 90.0f, 0f, Space.Self);
                }
                if (dirIndex > 0)
                {
                    dirIndex--;
                }
                else
                {
                    dirIndex = 3;
                }
                // dirIndex = dirIndex > 0 ? dirIndex-- : 3;
                piece.PieceDirection = (Direction)dirIndex;
            }
        }

        void HandleFlipInput()
        {
            if (Input.GetKeyUp("f"))
            {
                piece.IsFlipped = !piece.IsFlipped;
                ApplyFlipTransformation();
            }

        }

        void HandleClickInput()
        {
            if (tileHighlight == null) return;
            if (tileHighlight.activeInHierarchy)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    Debug.Log($"Piece Direction: {piece.PieceDirection}");
                    Debug.Log($"piece.IsFlipped: {piece.IsFlipped}");
                    Vector2Int point = Geometry.GridFromPoint(tileHighlight.transform.position);
                    List<Vector2Int> cells = GetOccupiedCellsForType(tileHighlight, point, piece.PieceDirection, piece.IsFlipped );
                    foreach (Vector2Int cell in cells)
                    {
                        Debug.Log(cell);
                    }

                    // Get Highlight prefab from PiecePool and set active at a specified position and rotation
                    GameObject placedPiece = PiecePool.SharedInstance.GetPiece(piece.PieceType.ToString(), piece.PieceColor);
                    placedPiece.transform.SetPositionAndRotation(Geometry.PointFromGrid(cells[0]), tileHighlight.transform.rotation);
                    GameManager.Instance.AddPiece(cells, piece.PieceType);
                    placedPiece.SetActive(true);
                    piece.gameObject.SetActive(false);
                }
            }
        }


        void ApplyFlipTransformation()
        {
            if (piece.PieceType <= PieceType.A5)
            {
                tileHighlight.transform.rotation = piece.IsFlipped
                    ? Quaternion.Euler(0f, 90.0f * (int)piece.PieceDirection, 180f)
                    : Quaternion.Euler(0f, 90.0f * (int)piece.PieceDirection, 0f);
            }
            else
            {
                tileHighlight.transform.rotation = piece.IsFlipped
                    ? Quaternion.Euler(180f, 90.0f * (int)piece.PieceDirection, 0f)
                    : Quaternion.Euler(0f, 90.0f * (int)piece.PieceDirection, 0f);
            }
        }

        private List<Vector2Int> GetOccupiedCellsForType(GameObject tileHighlight, Vector2Int gridPoint, Direction direction, bool isFlipped)
        {
            ISelector selector = tileHighlight.GetComponent<ISelector>();
            return selector.GetOccupiedGridPositions(gridPoint, direction, isFlipped);
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