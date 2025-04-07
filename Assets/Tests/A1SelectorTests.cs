using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Blokr.Core.Models;
using Blokr.Selector;

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

            A1Selector selector = new A1Selector();
            GridPosition cellA = new(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = false;

            List<GridPosition> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);



            result = selector.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
            Assert.AreEqual(new GridPosition(3, 4), result[0]);
            Assert.AreEqual(new GridPosition(4, 4), result[1]);
            Assert.AreEqual(new GridPosition(4, 3), result[2]);
            Assert.AreEqual(new GridPosition(4, 2), result[3]);
            Assert.AreEqual(new GridPosition(3, 2), result[4]);
            Assert.AreEqual(new GridPosition(2, 2), result[5]);
            Assert.AreEqual(new GridPosition(2, 3), result[6]);
            Assert.AreEqual(new GridPosition(2, 4), result[7]);

        }
        [Test]
        public void A1Selector_GetOccupiedGridPositions_WithUpDirectionAndFlipped_ReturnsCorrectPositions()
        {

            A1Selector selector = new A1Selector();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = true;

            List<GridPosition> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);

            // foreach (GridPosition item in result)
            // {
            //     Debug.Log($"[x:{item.x}, y:{item.y}]");
            // }

            Assert.AreEqual(new GridPosition(3, 3), result[0]);

            result = selector.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
            Assert.AreEqual(new GridPosition(3, 2), result[0]);
            Assert.AreEqual(new GridPosition(4, 2), result[1]);
            Assert.AreEqual(new GridPosition(4, 3), result[2]);
            Assert.AreEqual(new GridPosition(4, 4), result[3]);
            Assert.AreEqual(new GridPosition(3, 4), result[4]);
            Assert.AreEqual(new GridPosition(2, 4), result[5]);
            Assert.AreEqual(new GridPosition(2, 3), result[6]);
            Assert.AreEqual(new GridPosition(2, 2), result[7]);

        }

        [Test]
        public void A1Selector_GetOccupiedGridPositions_WithRightDirection_ReturnsCorrectPositions()
        {
            A1Selector selector = new A1Selector();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = false;

            List<GridPosition> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);

            // foreach (GridPosition item in result)
            // {
            //     Debug.Log($"[x:{item.x}, y:{item.y}]");
            // }

            Assert.AreEqual(new GridPosition(3, 3), result[0]);


            result = selector.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
            Assert.AreEqual(new GridPosition(4, 3), result[0]);
            Assert.AreEqual(new GridPosition(4, 2), result[1]);
            Assert.AreEqual(new GridPosition(3, 2), result[2]);
            Assert.AreEqual(new GridPosition(2, 2), result[3]);
            Assert.AreEqual(new GridPosition(2, 3), result[4]);
            Assert.AreEqual(new GridPosition(2, 4), result[5]);
            Assert.AreEqual(new GridPosition(3, 4), result[6]);
            Assert.AreEqual(new GridPosition(4, 4), result[7]);
        }

        [Test]
        public void A1Selector_GetOccupiedGridPositions_WithRightDirectionAndFlipped_ReturnsCorrectPositions()
        {

            A1Selector selector = new A1Selector();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = true;

            List<GridPosition> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);

            // foreach (GridPosition item in result)
            // {
            //     Debug.Log($"[x:{item.x}, y:{item.y}]");
            // }

            Assert.AreEqual(new GridPosition(3, 3), result[0]);

            result = selector.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
            Assert.AreEqual(new GridPosition(2, 3), result[0]);
            Assert.AreEqual(new GridPosition(2, 2), result[1]);
            Assert.AreEqual(new GridPosition(3, 2), result[2]);
            Assert.AreEqual(new GridPosition(4, 2), result[3]);
            Assert.AreEqual(new GridPosition(4, 3), result[4]);
            Assert.AreEqual(new GridPosition(4, 4), result[5]);
            Assert.AreEqual(new GridPosition(3, 4), result[6]);
            Assert.AreEqual(new GridPosition(2, 4), result[7]);
        }

        [Test]
        public void A1Selector_GetOccupiedGridPositions_WithDownDirection_ReturnsCorrectPositions()
        {
            A1Selector selector = new A1Selector();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = false;

            List<GridPosition> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);

            // foreach (GridPosition item in result)
            // {
            //     Debug.Log($"[x:{item.x}, y:{item.y}]");
            // }

            Assert.AreEqual(new GridPosition(3, 3), result[0]);

            result = selector.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
            Assert.AreEqual(new GridPosition(3, 2), result[0]);
            Assert.AreEqual(new GridPosition(2, 2), result[1]);
            Assert.AreEqual(new GridPosition(2, 3), result[2]);
            Assert.AreEqual(new GridPosition(2, 4), result[3]);
            Assert.AreEqual(new GridPosition(3, 4), result[4]);
            Assert.AreEqual(new GridPosition(4, 4), result[5]);
            Assert.AreEqual(new GridPosition(4, 3), result[6]);
            Assert.AreEqual(new GridPosition(4, 2), result[7]);
        }

        [Test]
        public void A1Selector_GetOccupiedGridPositions_WithDownDirectionAndFlipped_ReturnsCorrectPositions()
        {
            A1Selector selector = new A1Selector();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = true;

            List<GridPosition> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);

            // foreach (GridPosition item in result)
            // {
            //     Debug.Log($"[x:{item.x}, y:{item.y}]");
            // }

            Assert.AreEqual(new GridPosition(3, 3), result[0]);

            result = selector.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
            Assert.AreEqual(new GridPosition(3, 4), result[0]);
            Assert.AreEqual(new GridPosition(2, 4), result[1]);
            Assert.AreEqual(new GridPosition(2, 3), result[2]);
            Assert.AreEqual(new GridPosition(2, 2), result[3]);
            Assert.AreEqual(new GridPosition(3, 2), result[4]);
            Assert.AreEqual(new GridPosition(4, 2), result[5]);
            Assert.AreEqual(new GridPosition(4, 3), result[6]);
            Assert.AreEqual(new GridPosition(4, 4), result[7]);
        }

        [Test]
        public void A1Selector_GetOccupiedGridPositions_WithLeftDirection_ReturnsCorrectPositions()
        {
            A1Selector selector = new A1Selector();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = false;

            List<GridPosition> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);

            // foreach (GridPosition item in result)
            // {
            //     Debug.Log($"[x:{item.x}, y:{item.y}]");
            // }

            Assert.AreEqual(new GridPosition(3, 3), result[0]);

            result = selector.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
            Assert.AreEqual(new GridPosition(2, 3), result[0]);
            Assert.AreEqual(new GridPosition(2, 4), result[1]);
            Assert.AreEqual(new GridPosition(3, 4), result[2]);
            Assert.AreEqual(new GridPosition(4, 4), result[3]);
            Assert.AreEqual(new GridPosition(4, 3), result[4]);
            Assert.AreEqual(new GridPosition(4, 2), result[5]);
            Assert.AreEqual(new GridPosition(3, 2), result[6]);
            Assert.AreEqual(new GridPosition(2, 2), result[7]);
        }

        [Test]
        public void A1Selector_GetOccupiedGridPositions_WithLeftDirectionAndFlipped_ReturnsCorrectPositions()
        {
            A1Selector selector = new A1Selector();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = true;

            List<GridPosition> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);

            // foreach (GridPosition item in result)
            // {
            //     Debug.Log($"[x:{item.x}, y:{item.y}]");
            // }

            Assert.AreEqual(new GridPosition(3, 3), result[0]);

            result = selector.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
            Assert.AreEqual(new GridPosition(4, 3), result[0]);
            Assert.AreEqual(new GridPosition(4, 4), result[1]);
            Assert.AreEqual(new GridPosition(3, 4), result[2]);
            Assert.AreEqual(new GridPosition(2, 4), result[3]);
            Assert.AreEqual(new GridPosition(2, 3), result[4]);
            Assert.AreEqual(new GridPosition(2, 2), result[5]);
            Assert.AreEqual(new GridPosition(3, 2), result[6]);
            Assert.AreEqual(new GridPosition(4, 2), result[7]);
        }
    }
}
