using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PieceType
{ A1, A2, A3, B3, A4, B4, C4, D4, E4, A5, B5, C5, D5, E5, F5, G5, H5, I5, J5, K5, L5 };
public enum PieceColor { Red, Green, Blue, Yellow };
public enum Direction { Up, Right, Down, Left };
public class Piece : MonoBehaviour
{
    [SerializeField]
    [Range(1, 5)]
    private int size;

    [SerializeField]
    private PieceColor pieceColor;

    [SerializeField]
    private PieceType pieceType;

    public PieceColor PieceColor
    {
        get { return pieceColor; }
        // set { pieceColor = value; }
    }

    public PieceType PieceType
    {
        get { return pieceType; }
    }

    private bool isSelected = false;

    public int GetSize()
    {
        return size;
    }

    void OnMouseDown()
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
