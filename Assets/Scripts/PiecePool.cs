using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class PiecePool : MonoBehaviour

    {
        public static PiecePool SharedInstance;
        private readonly Dictionary<string, GameObject> redPieces = new Dictionary<string, GameObject>();
        private readonly Dictionary<string, GameObject> greenPieces = new Dictionary<string, GameObject>();
        private readonly Dictionary<string, GameObject> bluePieces = new Dictionary<string, GameObject>();
        private readonly Dictionary<string, GameObject> yellowPieces = new Dictionary<string, GameObject>();

        [SerializeField]
        private GameObject[] objectTypesToPool;

        [SerializeField]
        private Material[] materials;

        void Awake()
        {
            SharedInstance = this;

            Dictionary<string, GameObject>[] dictionaries = { redPieces, greenPieces, bluePieces, yellowPieces };

            for (int i = 0; i < dictionaries.Length; i++)
            {
                for (int j = 0; j < objectTypesToPool.Length; j++)
                {
                    GameObject obj = Instantiate(objectTypesToPool[j]);
                    Piece pieceComponent = obj.GetComponent<Piece>();
                    obj.SetActive(false);
                    pieceComponent.PieceColor = (PieceColor)i;
                    pieceComponent.PieceType = (PieceType)j;
                    pieceComponent.PieceDirection = (Direction)i;
                    MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();
                    meshRenderer.material = materials[i];
                    string name = pieceComponent.PieceType.ToString();
                    dictionaries[i].Add(name, obj);
                }
            }
        }

        public GameObject GetPiece(string typeName, PieceColor color)
        {
            Dictionary<string, GameObject> selectedDictionary = null;

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
                return selectedDictionary[typeName];
            }

            return null;
        }

    }
}