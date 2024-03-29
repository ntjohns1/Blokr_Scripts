using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Blokr
{
    public class PiecePool : MonoBehaviour
    {
        // ************************************************************************************
        // Fields
        // ************************************************************************************

        public static PiecePool SharedInstance;
        private readonly Dictionary<string, GameObject> redPieces = new();
        private readonly Dictionary<string, GameObject> greenPieces = new();
        private readonly Dictionary<string, GameObject> bluePieces = new();
        private readonly Dictionary<string, GameObject> yellowPieces = new();

        private Material[] materials;
        private GameObject[] pieces;
        private GameObject[] players;

        // ************************************************************************************
        // Methods
        // ************************************************************************************

        void Awake()
        {
            SharedInstance = this;
        }

        void Start()
        {
            Dictionary<string, GameObject>[] dictionaries = { redPieces, greenPieces, bluePieces, yellowPieces };

            materials = GameManager.Instance.PieceMaterials;
            pieces = GameManager.Instance.BasePieces;
            players = GameManager.Instance.Players;

            for (int i = 0; i < dictionaries.Length; i++)
            {
                for (int j = 0; j < pieces.Length; j++)
                {
                    GameObject obj = Instantiate(pieces[j]);
                    Piece pieceComponent = obj.GetComponent<Piece>();
                    obj.SetActive(false);
                    PieceType pieceType = (PieceType)j;
                    obj.transform.SetParent(players[i].transform);
                    obj.layer = LayerMask.NameToLayer("Piece");
                    pieceComponent.PieceColor = (PieceColor)i;
                    pieceComponent.PieceType = (PieceType)j;
                    MeshRenderer[] cells = obj.GetComponentsInChildren<MeshRenderer>();
                    foreach (MeshRenderer cell in cells)
                    {
                        cell.material = materials[i];
                    }
                    obj.name = $"{pieceType}_{pieceComponent.PieceColor}";
                    dictionaries[i].Add(pieceType.ToString(), obj);
                }
            }
        }

        public GameObject GetPiece(string typeName, PieceColor color)
        {
            Dictionary<string, GameObject> selectedDictionary;
            switch (color)
            {
                case PieceColor.Red:
                    selectedDictionary = redPieces;
                    break;
                case PieceColor.Green:
                    selectedDictionary = greenPieces;
                    break;
                case PieceColor.Blue:
                    selectedDictionary = bluePieces;
                    break;
                case PieceColor.Yellow:
                    selectedDictionary = yellowPieces;
                    break;
                default:
                    // Handle unexpected color value
                    // TODO: Throw an exception or log a warning
                    return null;
            }

            if (selectedDictionary.ContainsKey(typeName) && !selectedDictionary[typeName].activeInHierarchy)
            {
                Debug.Log(selectedDictionary[typeName].name);
                return selectedDictionary[typeName];
            }

            return null;
        }

    }
}