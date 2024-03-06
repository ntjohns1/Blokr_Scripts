using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public enum PieceType
    { A1, A2, A3, A4, A5, B3, B4, B5, C4, C5, D4, D5, E4, E5, F5, G5, H5, I5, J5, K5, L5 };
    public enum PieceColor { Red, Green, Blue, Yellow };
    public enum Direction { Up, Right, Down, Left };
    public class Piece : MonoBehaviour
    {

        // ************************************************************************************
        // Fields
        // ************************************************************************************

        [SerializeField]
        private PieceType pieceType;

        [SerializeField]
        private PieceColor pieceColor;

        [SerializeField]
        private Direction pieceDirection;
        
        private bool isFlipped = false;
        private bool isSelected = false;

        // ************************************************************************************
        // Properties
        // ************************************************************************************

        public PieceType PieceType
        {
            get { return pieceType; }
            set { pieceType = value; }
        }

        public PieceColor PieceColor
        {
            get { return pieceColor; }
            set { pieceColor = value; }
        }
        public Direction PieceDirection
        {
            get { return pieceDirection; }
            set { pieceDirection = value; }
        }

        public bool IsFlipped
        {
            get { return isFlipped; }
            set { isFlipped = value; }
        }

        // ************************************************************************************
        // Methods
        // ************************************************************************************

        void OnMouseDown()
        {
            if (gameObject.layer == LayerMask.NameToLayer("Selector"))
            {

                if (!isSelected)
                {
                    GameManager.Instance.SelectPiece(gameObject);
                    isSelected = true;
                }
                else
                {
                    GameManager.Instance.DeselectPiece(gameObject);
                    isSelected = false;
                }
            }
        }
    }
}