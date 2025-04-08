using UnityEngine;
using Blokr.Core.Models;
using Blokr.Core.Services;
using Blokr.UnitySync;

namespace Blokr.Input
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private LayerMask boardLayer;
        [SerializeField] private LayerMask pieceLayer;
        
        private Piece _activePiece;
        private PieceHighlightComponent _highlightComponent;
        private PlacementValidationComponent _validationComponent;
        private IPieceTransformService _transformService;

        private void Start()
        {
            _transformService = new PieceTransformService();
            _validationComponent = GetComponent<PlacementValidationComponent>();
            if (_validationComponent == null)
            {
                _validationComponent = gameObject.AddComponent<PlacementValidationComponent>();
            }
        }

        private void Update()
        {
            HandleMouseInput();
            HandleKeyboardInput();
            if (_activePiece != null)
            {
                _validationComponent.ValidateMousePosition(_activePiece);
            }
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
            if (_activePiece == null) return;

            if (Input.GetKeyUp(KeyCode.E))
            {
                _transformService.RotateClockwise(_activePiece);
                _highlightComponent.ApplyRotation(_activePiece.IsFlipped, true);
            }
            else if (Input.GetKeyUp(KeyCode.Q))
            {
                _transformService.RotateCounterClockwise(_activePiece);
                _highlightComponent.ApplyRotation(_activePiece.IsFlipped, false);
            }
            else if (Input.GetKeyUp(KeyCode.F))
            {
                _transformService.Flip(_activePiece);
                _highlightComponent.ApplyFlipTransformation(_activePiece.PieceDirection, _activePiece.IsFlipped);
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
                var pieceComponent = hit.collider.GetComponent<PieceComponent>();
                if (pieceComponent != null)
                {
                    _activePiece = new Piece { PieceType = pieceComponent.PieceType };
                    _highlightComponent = hit.collider.GetComponent<PieceHighlightComponent>();
                    if (_highlightComponent == null)
                    {
                        _highlightComponent = hit.collider.gameObject.AddComponent<PieceHighlightComponent>();
                        _highlightComponent.Initialize(_activePiece.PieceType);
                    }
                }
            }
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity, boardLayer) && _activePiece != null)
            {
                // Try to place piece
                if (_validationComponent.ValidateMousePosition(_activePiece))
                {
                    // Place piece logic here
                    CancelSelection();
                }
            }
        }

        private void HandleRightClick()
        {
            CancelSelection();
        }

        private void CancelSelection()
        {
            if (_highlightComponent != null)
            {
                _highlightComponent.UpdateVisibility(false);
                _highlightComponent = null;
            }
            _activePiece = null;
        }
    }
}
