using UnityEngine;
using System.Collections.Generic;
using Blokr.Core.Models;
using Blokr.Core.Services;
                                                                            
namespace Blokr.Highlighter

{
    public class HighlighterPool : MonoBehaviour
    {
        // ************************************************************************************
        // Fields
        // ************************************************************************************

        public static HighlighterPool SharedInstance;
        private Dictionary<PieceType, GameObject> _pool;
        private Dictionary<PieceType, GameObject> _activePieces;

        // ************************************************************************************
        // Methods
        // ************************************************************************************

        void Awake()
        {
            SharedInstance = this;
        }

        void Start()
        {
            _pool = new Dictionary<PieceType, GameObject>();
            _activePieces = new Dictionary<PieceType, GameObject>();

            foreach (PieceType pieceType in System.Enum.GetValues(typeof(PieceType)))
            {
                GameObject prefab = Resources.Load<GameObject>($"Prefabs/Pieces/{pieceType}");
                if (prefab != null)
                {
                    GameObject obj = Instantiate(prefab);
                    obj.SetActive(false);
                    obj.layer = LayerMask.NameToLayer("Highlighter");
                    obj.name = $"{pieceType}Highlighter";
                    _pool.Add(pieceType, obj);
                    obj.transform.SetParent(gameObject.transform);
                }
            }
        }

        public GameObject GetHighlighter(PieceType pieceType)
        {
            if (_pool.TryGetValue(pieceType, out GameObject obj))
            {
                if (!_activePieces.ContainsKey(pieceType))
                {
                    obj.SetActive(true);
                    _activePieces.Add(pieceType, obj);
                    return obj;
                }
            }
            return null;
        }

        public void ReturnToPool(PieceType pieceType)
        {
            if (_activePieces.TryGetValue(pieceType, out GameObject obj))
            {
                obj.SetActive(false);
                _activePieces.Remove(pieceType);
            }
        }
    }
}
