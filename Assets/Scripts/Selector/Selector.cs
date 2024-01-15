using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Selector : MonoBehaviour
{
    [SerializeField]
    [Range(1, 5)]
    protected int size;

    [SerializeField]
    protected PieceType pieceType;

    public PieceType PieceType
    {
        get { return pieceType; }
    }

    private bool isSelected = false;

    public int GetSize()
    {
        return size;
    }

    // void OnMouseDown()
    // {
    //     if (!isSelected)
    //     {
    //         GameManager.Instance.SelectPiece(gameObject);
    //         isSelected = true;
    //     }
    //     else
    //     {
    //         GameManager.Instance.DeselectPiece(gameObject);
    //         isSelected = false;
    //     }
    // }

    public abstract List<Vector2Int> GetOccupiedGridPositions(Vector2Int gridPoint, Direction direction);
}
