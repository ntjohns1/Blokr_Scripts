using UnityEngine;
using System;
using Blokr.Core.Models;
using Blokr.UnitySync;

namespace Blokr.Input
{
    public class InputHandler : MonoBehaviour
    {
        // Events for input actions
        public event Action<Piece> OnPieceSelected;
        public event Action<GridPosition> OnPositionSelected;
        public event Action OnRotateClockwise;
        public event Action OnRotateCounterClockwise;
        public event Action OnFlip;
        public event Action OnCancel;

        [SerializeField] private Camera mainCamera;
        [SerializeField] private LayerMask boardLayer;
        [SerializeField] private LayerMask pieceLayer;
        
        private Piece _activePiece;
        private PieceHighlightComponent _highlightComponent;
        private PlacementValidationComponent _validationComponent;
        private GameStateComponent _gameState;
        private bool _isInputEnabled = true;

        public bool IsInputEnabled
        {
            get => _isInputEnabled;
            set => _isInputEnabled = value;
        }

        private static InputHandler _instance;
        public static InputHandler Instance => _instance;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }
            _instance = this;
        }

        private void Start()
        {
            _gameState = GameStateComponent.Instance;
            _validationComponent = GetComponent<PlacementValidationComponent>();
            if (_validationComponent == null)
            {
                _validationComponent = gameObject.AddComponent<PlacementValidationComponent>();
            }
        }

        private void Update()
        {
            if (!_isInputEnabled) return;

            HandleMouseInput();
            HandleKeyboardInput();
            if (_activePiece != null)
            {
                _validationComponent.ValidateMousePosition(_activePiece);
            }
        }

        private void HandleMouseInput()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                HandleLeftClick();
            }
            else if (UnityEngine.Input.GetMouseButtonDown(1))
            {
                HandleRightClick();
            }
        }

        private void HandleKeyboardInput()
        {
            if (_activePiece == null) return;

            if (UnityEngine.Input.GetKeyUp(KeyCode.E))
            {
                _gameState.PieceTransformService.RotateClockwise(_activePiece);
                _highlightComponent.ApplyRotation(_activePiece.IsFlipped, true);
                OnRotateClockwise?.Invoke();
            }
            else if (UnityEngine.Input.GetKeyUp(KeyCode.Q))
            {
                _gameState.PieceTransformService.RotateCounterClockwise(_activePiece);
                _highlightComponent.ApplyRotation(_activePiece.IsFlipped, false);
                OnRotateCounterClockwise?.Invoke();
            }
            else if (UnityEngine.Input.GetKeyUp(KeyCode.F))
            {
                _gameState.PieceTransformService.Flip(_activePiece);
                _highlightComponent.ApplyFlipTransformation(_activePiece.PieceDirection, _activePiece.IsFlipped);
                OnFlip?.Invoke();
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
            {
                CancelSelection();
            }
        }

        private void HandleLeftClick()
        {
            Ray ray = mainCamera.ScreenPointToRay(UnityEngine.Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, pieceLayer))
            {
                // Clicked on a piece
                var pieceComponent = hit.collider.GetComponent<PieceComponent>();
                if (pieceComponent != null)
                {
                    var playerComponent = pieceComponent.GetComponentInParent<PlayerComponent>();
                    if (playerComponent != null)
                    {
                        _activePiece = new Piece { 
                            PieceType = pieceComponent.PieceType,
                            PieceColor = _gameState.GameStateService.CurrentPlayer.Color
                        };
                        _highlightComponent = hit.collider.GetComponent<PieceHighlightComponent>();
                        if (_highlightComponent == null)
                        {
                            _highlightComponent = hit.collider.gameObject.AddComponent<PieceHighlightComponent>();
                            _highlightComponent.Initialize(_activePiece.PieceType);
                        }
                        OnPieceSelected?.Invoke(_activePiece);
                    }
                }
            }
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity, boardLayer) && _activePiece != null)
            {
                // Try to place piece
                if (_validationComponent.ValidateMousePosition(_activePiece))
                {
                    var position = GridGeometry.GridFromPoint(hit.point);
                    OnPositionSelected?.Invoke(position);
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
            OnCancel?.Invoke();
        }

        public bool GetMouseButtonUp(int button)
        {
            return UnityEngine.Input.GetMouseButtonUp(button);
        }

        public Vector3 GetMousePosition()
        {
            return UnityEngine.Input.mousePosition;
        }
    }
}
