using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Selector : MonoBehaviour
{
    [SerializeField]
    [Range(1, 5)]
    protected int size;

    protected Direction selectorDirection;
    public Direction SelectorDirection
    {
        get { return selectorDirection; }
        set { selectorDirection = value; }
    }


    [SerializeField]
    protected PieceType pieceType;

    public PieceType PieceType
    {
        get { return pieceType; }
    }

    public int GetSize()
    {
        return size;
    }

    public abstract List<Vector2Int> GetOccupiedGridPositions(Vector2Int gridPoint, Direction direction);

    protected Vector2Int ClampToGrid(Vector2Int vector, int min, int max)
    {
        int clampedX = Mathf.Clamp(vector.x, min, max);
        int clampedY = Mathf.Clamp(vector.y, min, max);
        return new Vector2Int(clampedX, clampedY);
    }
}
