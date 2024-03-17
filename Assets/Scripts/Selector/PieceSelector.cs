using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Animations;

namespace Blokr
{
    public class PieceSelector : MonoBehaviour
    {
        // ************************************************************************************
        // Fields
        // ************************************************************************************
        
        private PieceSelector instance;

        private GameObject tileHighlight;

        private Collider objectCollider;

        [SerializeField] private LayerMask gridLayer;

        private Piece piece;




        
        // ************************************************************************************
        // Properties
        // ************************************************************************************
        
        public PieceSelector Instance
        {
            get { return instance; }
        }
        




        // ************************************************************************************
        // Methods
        // ************************************************************************************

        void Awake()
        {
            instance = this;
        }

        public void SetHighlight(GameObject highlightPrefab)
        {
            tileHighlight = highlightPrefab;
            objectCollider = highlightPrefab.GetComponent<Collider>();
            piece = GameManager.Instance.SelectedPiece.GetComponent<Piece>();
            InitializePositionAndRotation();
        }


        void InitializePositionAndRotation()
        {
            if (tileHighlight == null) return;
            tileHighlight.transform.SetPositionAndRotation(Vector3.zero, Quaternion.Euler(0.0f, 90.0f * (int)piece.PieceDirection, 0.0f));
        }
    

        public void EnterState()
        {
            enabled = true;
        }

        private void ExitState(GameObject tileHighlight, Piece piece)
        {
            this.enabled = false;
            tileHighlight.SetActive(false);
            MoveSelector move = GetComponent<MoveSelector>();
            move.EnterState(tileHighlight, piece);
        }


    }
}