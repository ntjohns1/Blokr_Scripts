using UnityEngine;
using Blokr.Core.Models;

namespace Blokr.UnitySync
{
    public class PieceHighlightComponent : MonoBehaviour
    {
        private PieceType _pieceType;

        public void Initialize(PieceType pieceType)
        {
            _pieceType = pieceType;
        }

        public void ApplyRotation(bool isFlipped, bool clockwise)
        {
            float rotationAngle = clockwise ? 90.0f : -90.0f;
            if (isFlipped)
            {
                rotationAngle *= -1;
            }
            transform.Rotate(0f, rotationAngle, 0f, Space.Self);
        }

        public void ApplyFlipTransformation(Direction direction, bool isFlipped)
        {
            if (_pieceType <= PieceType.A5)
            {
                transform.rotation = isFlipped
                    ? Quaternion.Euler(0f, 90.0f * (int)direction, 180f)
                    : Quaternion.Euler(0f, 90.0f * (int)direction, 0f);
            }
            else
            {
                transform.rotation = isFlipped
                    ? Quaternion.Euler(180f, 90.0f * (int)direction, 0f)
                    : Quaternion.Euler(0f, 90.0f * (int)direction, 0f);
            }
        }

        public void UpdateVisibility(bool isVisible)
        {
            gameObject.SetActive(isVisible);
        }

        public void UpdatePosition(Vector3 position)
        {
            transform.position = position;
        }
    }
}
