using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    // Field for storing grid position values
    private int posX;
    private int posY;

    // private field to store clicks for cycling through mesh renderer materials
    int numClick = 0;

    // Property for numClick
    public int NumClick
    {
        get { return numClick; }
        set { numClick = value; }
    }

    // Saves a reference to the game object that gets placed on this cell
    public GameObject objectInThisGridSpace = null;

    //Saves if the grid space is occupied or not
    public bool isOccupied = false;




    // Property for setting Vector2 grid position
    public void SetPosition(int x, int y)
    {
        posX = x;
        posY = y;
    }

    // Accessor property for Vector2 grid position 
    public Vector2Int GetPosition()
    {
        return new Vector2Int(posX, posY);
    }

}


