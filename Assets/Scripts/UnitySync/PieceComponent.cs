using UnityEngine;
using Blokr.Core.Models;

namespace Blokr.UnitySync
{
    public class PieceComponent : MonoBehaviour
    {
        [SerializeField] private PieceType pieceType;
        [SerializeField] private MeshRenderer meshRenderer;
        
        private PieceColor _color;
        private bool _isInteractable;

        public PieceType PieceType => pieceType;

        public void Initialize(PieceColor color)
        {
            _color = color;
            UpdateVisuals();
        }

        public void SetInteractable(bool isInteractable)
        {
            _isInteractable = isInteractable;
            UpdateVisuals();
        }

        private void UpdateVisuals()
        {
            if (meshRenderer != null)
            {
                // Update material based on color and interactable state
                // You'll need to set up the proper materials in Unity
                meshRenderer.material.color = _isInteractable ? GetColorForPiece() : Color.gray;
            }
        }

        private Color GetColorForPiece()
        {
            return _color switch
            {
                PieceColor.Blue => Color.blue,
                PieceColor.Red => Color.red,
                PieceColor.Green => Color.green,
                PieceColor.Yellow => Color.yellow,
                _ => Color.white
            };
        }
    }
}
