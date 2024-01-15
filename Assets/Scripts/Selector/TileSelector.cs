using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelector : MonoBehaviour
{
    // public GameObject tileHighlightPrefab;

    private GameObject tileHighlight;

    [SerializeField] private LayerMask gridLayer;



    // void Start ()
    // {
    //     Vector2Int gridPoint = Geometry.GridPoint(0, 0);
    //     Vector3 point = Geometry.PointFromGrid(gridPoint);
    //     tileHighlight = Instantiate(tileHighlightPrefab, point, Quaternion.identity, gameObject.transform);
    //     tileHighlight.SetActive(false);
    // }

    public void SetHighlight(GameObject highlightPrefab)
    {
        tileHighlight = highlightPrefab;
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f, gridLayer))
        {
            Vector3 point = hit.point;
            Vector2Int gridPoint = Geometry.GridFromPoint(point);
            tileHighlight.SetActive(true);
            tileHighlight.transform.position = Geometry.PointFromGrid(gridPoint);
            if (Input.GetKeyUp("e"))
            {
                tileHighlight.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
            }
            if (Input.GetKeyUp("q"))
            {
                tileHighlight.transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self);
            }
            if (Input.GetMouseButtonUp(0))
            {
                GameObject piece = GameManager.Instance.SelectedPiece;
                GameManager.Instance.AddPiece(piece, tileHighlight);
            }
        }
        else
        {
            tileHighlight.SetActive(false);
        }
    }

    public void EnterState()
    {
        enabled = true;
    }

    private void ExitState(GameObject movingPiece)
    {
        this.enabled = false;
        tileHighlight.SetActive(false);
        // MoveSelector move = GetComponent<MoveSelector>();
        // move.EnterState(movingPiece);
    }
}
