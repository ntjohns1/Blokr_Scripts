using UnityEngine;
using Blokr.Input.Selector;
using Blokr.UnitySync;

namespace Blokr.Input
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private LayerMask boardLayer;
        [SerializeField] private LayerMask pieceLayer;
        
        private SelectorComponent _activeSelector;
        private Vector3 _lastMousePosition;

        private void Update()
        {
            HandleMouseInput();
            HandleKeyboardInput();
        }

        private void HandleMouseInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                HandleLeftClick();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                HandleRightClick();
            }
        }

        private void HandleKeyboardInput()
        {
            if (_activeSelector == null) return;

            if (Input.GetKeyDown(KeyCode.R))
            {
                _activeSelector.Rotate();
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                _activeSelector.Flip();
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                if (_activeSelector.TryPlacePiece())
                {
                    _activeSelector = null;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                CancelSelection();
            }
        }

        private void HandleLeftClick()
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, pieceLayer))
            {
                // Clicked on a piece
                var selector = hit.collider.GetComponent<SelectorComponent>();
                if (selector != null)
                {
                    _activeSelector = selector;
                }
            }
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity, boardLayer))
            {
                // Clicked on the board
                if (_activeSelector != null)
                {
                    Vector2Int gridPosition = GetGridPosition(hit.point);
                    _activeSelector.UpdatePosition(gridPosition);
                }
            }
        }

        private void HandleRightClick()
        {
            CancelSelection();
        }

        private void CancelSelection()
        {
            if (_activeSelector != null)
            {
                _activeSelector = null;
                // Clear any highlights or preview
                var board = FindObjectOfType<BoardComponent>();
                if (board != null)
                {
                    // Clear highlights
                }
            }
        }

        private Vector2Int GetGridPosition(Vector3 worldPosition)
        {
            // Convert world position to grid position
            // This will depend on your board setup
            return new Vector2Int(
                Mathf.RoundToInt(worldPosition.x),
                Mathf.RoundToInt(worldPosition.z)
            );
        }
    }
}
