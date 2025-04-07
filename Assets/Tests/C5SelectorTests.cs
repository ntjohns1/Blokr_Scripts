using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Blokr;

// *********************************************************************
// C5Selector Tests
// *********************************************************************
namespace Tests
{
    public class C5SelectorTests
    {

        [Test]
        public void C5Selector_GetOccupiedGridPositions_WithUpDirection_ReturnsCorrectPositions()
        {
            C5Selector selector = new GameObject().AddComponent<C5Selector>();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = false;


            List<GridPosition> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new GridPosition(3, 3), result[0]);
            Assert.AreEqual(new GridPosition(3, 4), result[1]);
            Assert.AreEqual(new GridPosition(4, 3), result[2]);
            Assert.AreEqual(new GridPosition(2, 4), result[3]);
            Assert.AreEqual(new GridPosition(1, 4), result[4]);

            result = selector.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
        }

        [Test]
        public void C5Selector_GetOccupiedGridPositions_WithUpDirectionAndFlipped_ReturnsCorrectPositions()
        {
            C5Selector selector = new GameObject().AddComponent<C5Selector>();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = true;


            List<GridPosition> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new GridPosition(3, 3), result[0]);
            Assert.AreEqual(new GridPosition(3, 2), result[1]);
            Assert.AreEqual(new GridPosition(4, 3), result[2]);
            Assert.AreEqual(new GridPosition(2, 2), result[3]);
            Assert.AreEqual(new GridPosition(1, 2), result[4]);

            result = selector.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
        }

        [Test]
        public void C5Selector_GetOccupiedGridPositions_WithRightDirection_ReturnsCorrectPositions()
        {
            C5Selector selector = new GameObject().AddComponent<C5Selector>();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = false;


            List<GridPosition> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new GridPosition(3, 3), result[0]);
            Assert.AreEqual(new GridPosition(4, 3), result[1]);
            Assert.AreEqual(new GridPosition(3, 2), result[2]);
            Assert.AreEqual(new GridPosition(4, 4), result[3]);
            Assert.AreEqual(new GridPosition(4, 5), result[4]);

            result = selector.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
        }

        [Test]
        public void C5Selector_GetOccupiedGridPositions_WithRightDirectionAndFlipped_ReturnsCorrectPositions()
        {
            C5Selector selector = new GameObject().AddComponent<C5Selector>();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = true;


            List<GridPosition> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new GridPosition(3, 3), result[0]);
            Assert.AreEqual(new GridPosition(2, 3), result[1]);
            Assert.AreEqual(new GridPosition(3, 2), result[2]);
            Assert.AreEqual(new GridPosition(2, 4), result[3]);
            Assert.AreEqual(new GridPosition(2, 5), result[4]);

            result = selector.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
        }

        [Test]
        public void C5Selector_GetOccupiedGridPositions_WithDownDirection_ReturnsCorrectPositions()
        {
            C5Selector selector = new GameObject().AddComponent<C5Selector>();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = false;


            List<GridPosition> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new GridPosition(3, 3), result[0]);
            Assert.AreEqual(new GridPosition(3, 2), result[1]);
            Assert.AreEqual(new GridPosition(2, 3), result[2]);
            Assert.AreEqual(new GridPosition(4, 2), result[3]);
            Assert.AreEqual(new GridPosition(5, 2), result[4]);

            result = selector.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
        }

        [Test]
        public void C5Selector_GetOccupiedGridPositions_WithDownDirectionAndFlipped_ReturnsCorrectPositions()
        {
            C5Selector selector = new GameObject().AddComponent<C5Selector>();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = true;


            List<GridPosition> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new GridPosition(3, 3), result[0]);
            Assert.AreEqual(new GridPosition(3, 4), result[1]);
            Assert.AreEqual(new GridPosition(2, 3), result[2]);
            Assert.AreEqual(new GridPosition(4, 4), result[3]);
            Assert.AreEqual(new GridPosition(5, 4), result[4]);

            result = selector.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
        }

        [Test]
        public void C5Selector_GetOccupiedGridPositions_WithLeftDirection_ReturnsCorrectPositions()
        {
            C5Selector selector = new GameObject().AddComponent<C5Selector>();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = false;


            List<GridPosition> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new GridPosition(3, 3), result[0]);
            Assert.AreEqual(new GridPosition(2, 3), result[1]);
            Assert.AreEqual(new GridPosition(3, 4), result[2]);
            Assert.AreEqual(new GridPosition(2, 2), result[3]);
            Assert.AreEqual(new GridPosition(2, 1), result[4]);

            result = selector.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
        }

        [Test]
        public void C5Selector_GetOccupiedGridPositions_WithLeftDirectionAndFlipped_ReturnsCorrectPositions()
        {
            C5Selector selector = new GameObject().AddComponent<C5Selector>();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = true;


            List<GridPosition> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new GridPosition(3, 3), result[0]);
            Assert.AreEqual(new GridPosition(4, 3), result[1]);
            Assert.AreEqual(new GridPosition(3, 4), result[2]);
            Assert.AreEqual(new GridPosition(4, 2), result[3]);
            Assert.AreEqual(new GridPosition(4, 1), result[4]);

            result = selector.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
        }

    }
}
