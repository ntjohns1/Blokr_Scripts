using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Tilemaps;

namespace Blokr
{
    public class InputManager : MonoBehaviour
    {

        // ************************************************************************************
        // Fields
        // ************************************************************************************
        
        private static InputManager instance;
        
        // ************************************************************************************
        // Properties
        // ************************************************************************************

        public static InputManager Instance
        {

            get { return instance; }
        }

        [SerializeField] private LayerMask gridLayer;

        // ************************************************************************************
        // Methods
        // ************************************************************************************
        void Awake()
        {
            instance = this;
        }

        public void HandleMouseOver(GameObject tileHighlight, Piece piece)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, gridLayer))
            {
                Vector3 point = hit.point;
                Vector2Int gridPoint = Geometry.GridFromPoint(point);
                ISelector selector = tileHighlight.GetComponent<ISelector>();
                List<Vector2Int> occupiedCells = GetOccupiedCellsForType(tileHighlight, gridPoint, piece.PieceDirection, piece.IsFlipped);
                bool allPositionsInBounds = occupiedCells.All(pos => pos.x >= 0 && pos.x <= 19 && pos.y >= 0 && pos.y <= 19);
                bool isValidMove = Board.Instance.IsValidMove(occupiedCells, piece.PieceColor);
                if (allPositionsInBounds && isValidMove)
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


        public List<Vector2Int> GetOccupiedCellsForType(GameObject tileHighlight, Vector2Int gridPoint, Direction direction, bool isFlipped)
        {
            ISelector selector = tileHighlight.GetComponent<ISelector>();
            return selector.GetOccupiedGridPositions(gridPoint, direction, isFlipped);
        }

        public List<Vector2Int> GetAdjacentCellsForType(GameObject tileHighlight, Vector2Int gridPoint, Direction direction, bool isFlipped)
        {
            ISelector selector = tileHighlight.GetComponent<ISelector>();
            return selector.CalculateAdjacentPositions(gridPoint, direction, isFlipped);
        }

        public List<Vector2Int> GetPlayableCellsForType(GameObject tileHighlight, List<Vector2Int> adjacentCells)
        {
            ISelector selector = tileHighlight.GetComponent<ISelector>();
            return selector.CalculatePlayablePositions(adjacentCells);
        }

        public void HandleRotationInput(GameObject tileHighlight, Piece piece)
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

        public void HandleFlipInput(GameObject tileHighlight, Piece piece)
        {
            if (Input.GetKeyUp("f"))
            {
                piece.IsFlipped = !piece.IsFlipped;
                ApplyFlipTransformation(tileHighlight, piece);
            }

        }

        public void ApplyFlipTransformation(GameObject tileHighlight, Piece piece)
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

        // public void HandleClickInput(GameObject tileHighlight, GameObject moveConfirm, Piece piece)
        // {
        //     // conditional based on if click is on Selector Layer or Grid Layer 
        //     if (tileHighlight == null) return;
        //     if (tileHighlight.activeInHierarchy)
        //     {
        //         if (Input.GetMouseButtonUp(0))
        //         {
        //             Vector2Int point = Geometry.GridFromPoint(tileHighlight.transform.position);
        //             List<Vector2Int> occupiedCells = GetOccupiedCellsForType(tileHighlight, point, piece.PieceDirection, piece.IsFlipped);
        //             foreach (Vector2Int cell in occupiedCells)
        //             {
        //                 Debug.Log(cell);
        //             }
        //             placedPiece = PiecePool.SharedInstance.GetPiece(piece.PieceType.ToString(), piece.PieceColor);
        //             placedPiece.transform.SetPositionAndRotation(Geometry.PointFromGrid(occupiedCells[0]), tileHighlight.transform.rotation);
        //             placedPiece.SetActive(true);
        //             piece.gameObject.SetActive(false);
        //             moveConfirm.SetActive(true);
        //         }
        //     }
        // }

    }
}
