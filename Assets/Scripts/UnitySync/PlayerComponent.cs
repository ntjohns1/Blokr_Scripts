using UnityEngine;
using System.Collections.Generic;
using Blokr.Core.Models;

namespace Blokr.UnitySync
{
    public class PlayerComponent : MonoBehaviour
    {
        [SerializeField] private GameObject piecesContainer;
        [SerializeField] private Material activeMaterial;
        [SerializeField] private Material inactiveMaterial;

        private Player _player;
        private Dictionary<PieceType, PieceComponent> _pieces;
        private bool _isActive;

        public void Initialize(Player player)
        {
            _player = player;
            _pieces = new Dictionary<PieceType, PieceComponent>();
            InitializePieces();
        }

        private void InitializePieces()
        {
            // Find all piece components in the pieces container
            var pieceComponents = piecesContainer.GetComponentsInChildren<PieceComponent>();
            foreach (var piece in pieceComponents)
            {
                _pieces[piece.PieceType] = piece;
                piece.Initialize(_player.Color);
            }
        }

        public void OnTurnStarted()
        {
            _isActive = true;
            UpdatePiecesInteractivity();
        }

        public void OnTurnCompleted()
        {
            _isActive = false;
            UpdatePiecesInteractivity();
        }

        public void UpdateActiveState(bool isActive)
        {
            _isActive = isActive;
            UpdatePiecesInteractivity();
            UpdateVisuals();
        }

        private void UpdatePiecesInteractivity()
        {
            foreach (var piece in _pieces.Values)
            {
                bool isInteractable = _isActive && _player.IsPieceAvailable(piece.PieceType);
                piece.SetInteractable(isInteractable);
            }
        }

        private void UpdateVisuals()
        {
            // Update materials or other visual indicators for active/inactive state
            var renderers = GetComponentsInChildren<Renderer>();
            var material = _isActive ? activeMaterial : inactiveMaterial;
            
            foreach (var renderer in renderers)
            {
                renderer.material = material;
            }
        }

        public void UpdatePlayableArea(bool[,] adjacent, bool[,] playable)
        {
            _player.UpdatePlayableArea(adjacent, playable);
        }

        public bool[,] GetAdjacentPositions() => _player.AdjacentPositions;
        public bool[,] GetPlayablePositions() => _player.PlayablePositions;
    }
}
