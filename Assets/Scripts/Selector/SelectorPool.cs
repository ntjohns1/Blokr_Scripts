using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public class SelectorPool : MonoBehaviour
    {
        // ************************************************************************************
        // Fields
        // ************************************************************************************

        public static SelectorPool SharedInstance;
        private readonly Dictionary<string, GameObject> selectors = new();

        private Material[] materials;
        private List<GameObject> highlightPrefabs;

        // ************************************************************************************
        // Methods
        // ************************************************************************************

        void Awake()
        {
            SharedInstance = this;
        }

        void Start()
        {
            highlightPrefabs = GameManager.Instance.HighlightPrefabs;

            for (int j = 0; j < highlightPrefabs.Count; j++)
            {
                GameObject obj = Instantiate(highlightPrefabs[j]);
                obj.SetActive(false);
                PieceType pieceType = (PieceType)j;
                obj.transform.SetParent(gameObject.transform);
                obj.layer = LayerMask.NameToLayer("Selector");
                obj.name = $"{pieceType}Selector";
                selectors.Add(obj.name, obj);
            }

        }

        public GameObject GetSelector(string typeName)
        {
            if (selectors.ContainsKey(typeName) && !selectors[typeName].activeInHierarchy)
            {
                return selectors[typeName];
            }

            return null;
        }

    }
}
