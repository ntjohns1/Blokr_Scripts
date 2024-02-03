using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Blokr;

// *********************************************************************
// E4Selector Tests
// *********************************************************************
namespace Tests
{
    public class E4SelectorTests
    {
        [Test]
        public void E4Selector_GetOccupiedGridPositions_WithUpDirection_ReturnsCorrectPositions()
        {
            E4Selector selector = new GameObject().AddComponent<E4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);

            foreach (Vector2Int item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }

            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(4, 3), result[1]);
            Assert.AreEqual(new Vector2Int(2, 3), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
        }

        [Test]
        public void E4Selector_GetOccupiedGridPositions_WithUpDirectionAndFlipped_ReturnsCorrectPositions()
        {
            E4Selector selector = new GameObject().AddComponent<E4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);

            foreach (Vector2Int item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }

            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(4, 3), result[1]);
            Assert.AreEqual(new Vector2Int(2, 3), result[2]);
            Assert.AreEqual(new Vector2Int(3, 2), result[3]);
        }

        [Test]
        public void E4Selector_GetOccupiedGridPositions_WithRightDirection_ReturnsCorrectPositions()
        {
            E4Selector selector = new GameObject().AddComponent<E4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);

            foreach (Vector2Int item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }

            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 4), result[2]);
            Assert.AreEqual(new Vector2Int(4, 3), result[3]);
        }

        [Test]
        public void E4Selector_GetOccupiedGridPositions_WithRightDirectionAndFlipped_ReturnsCorrectPositions()
        {
            E4Selector selector = new GameObject().AddComponent<E4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);

            foreach (Vector2Int item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }

            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 4), result[2]);
            Assert.AreEqual(new Vector2Int(2, 3), result[3]);
        }

        [Test]
        public void E4Selector_GetOccupiedGridPositions_WithDownDirection_ReturnsCorrectPositions()
        {
            E4Selector selector = new GameObject().AddComponent<E4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);

            foreach (Vector2Int item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }

            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(2, 3), result[1]);
            Assert.AreEqual(new Vector2Int(4, 3), result[2]);
            Assert.AreEqual(new Vector2Int(3, 2), result[3]);
        }

        [Test]
        public void E4Selector_GetOccupiedGridPositions_WithDownDirectionAndFlipped_ReturnsCorrectPositions()
        {
            E4Selector selector = new GameObject().AddComponent<E4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);

            foreach (Vector2Int item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }

            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(2, 3), result[1]);
            Assert.AreEqual(new Vector2Int(4, 3), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
        }

        [Test]
        public void E4Selector_GetOccupiedGridPositions_WithLeftDirection_ReturnsCorrectPositions()
        {
            E4Selector selector = new GameObject().AddComponent<E4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);

            foreach (Vector2Int item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }

            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 4), result[1]);
            Assert.AreEqual(new Vector2Int(3, 2), result[2]);
            Assert.AreEqual(new Vector2Int(2, 3), result[3]);
        }

        [Test]
        public void E4Selector_GetOccupiedGridPositions_WithLeftDirectionAndFlipped_ReturnsCorrectPositions()
        {
            E4Selector selector = new GameObject().AddComponent<E4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);

            foreach (Vector2Int item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }

            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 4), result[1]);
            Assert.AreEqual(new Vector2Int(3, 2), result[2]);
            Assert.AreEqual(new Vector2Int(4, 3), result[3]);
        }

    }
}
