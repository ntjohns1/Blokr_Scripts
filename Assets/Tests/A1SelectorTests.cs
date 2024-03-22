using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Blokr;

// *********************************************************************
// A1Selector Tests
// *********************************************************************
namespace Tests
{
    public class A1SelectorTests
    {

        [Test]
        public void A1Selector_GetOccupiedGridPositions_WithUpDirection_ReturnsCorrectPositions()
        {

            A1Selector selector = new GameObject().AddComponent<A1Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = false;

            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);



            result = selector.CalculatePlayablePositions(cellA, direction, isFlipped);
            foreach (Vector2Int item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
            Assert.AreEqual(new Vector2Int(3, 4), result[0]);
            Assert.AreEqual(new Vector2Int(4, 4), result[1]);
            Assert.AreEqual(new Vector2Int(4, 3), result[2]);
            Assert.AreEqual(new Vector2Int(4, 2), result[3]);
            Assert.AreEqual(new Vector2Int(3, 2), result[4]);
            Assert.AreEqual(new Vector2Int(2, 2), result[5]);
            Assert.AreEqual(new Vector2Int(2, 3), result[6]);
            Assert.AreEqual(new Vector2Int(2, 4), result[7]);

        }
        [Test]
        public void A1Selector_GetOccupiedGridPositions_WithUpDirectionAndFlipped_ReturnsCorrectPositions()
        {

            A1Selector selector = new GameObject().AddComponent<A1Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = true;

            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);

            foreach (Vector2Int item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
        }

        [Test]
        public void A1Selector_GetOccupiedGridPositions_WithRightDirection_ReturnsCorrectPositions()
        {
            A1Selector selector = new GameObject().AddComponent<A1Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = false;

            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);

            foreach (Vector2Int item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
        }

        [Test]
        public void A1Selector_GetOccupiedGridPositions_WithRightDirectionAndFlipped_ReturnsCorrectPositions()
        {

            A1Selector selector = new GameObject().AddComponent<A1Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = true;

            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);

            foreach (Vector2Int item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
        }

        [Test]
        public void A1Selector_GetOccupiedGridPositions_WithDownDirection_ReturnsCorrectPositions()
        {
            A1Selector selector = new GameObject().AddComponent<A1Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = false;

            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);

            foreach (Vector2Int item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }

            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
        }

        [Test]
        public void A1Selector_GetOccupiedGridPositions_WithDownDirectionAndFlipped_ReturnsCorrectPositions()
        {
            A1Selector selector = new GameObject().AddComponent<A1Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = true;

            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);

            foreach (Vector2Int item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }

            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
        }

        [Test]
        public void A1Selector_GetOccupiedGridPositions_WithLeftDirection_ReturnsCorrectPositions()
        {
            A1Selector selector = new GameObject().AddComponent<A1Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = false;

            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);

            foreach (Vector2Int item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
        }

        [Test]
        public void A1Selector_GetOccupiedGridPositions_WithLeftDirectionAndFlipped_ReturnsCorrectPositions()
        {
            A1Selector selector = new GameObject().AddComponent<A1Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = true;

            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);

            foreach (Vector2Int item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
        }
    }
}
