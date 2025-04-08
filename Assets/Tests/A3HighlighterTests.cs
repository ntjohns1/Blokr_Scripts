using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Blokr;

// *********************************************************************
// A3Highlighter Tests
// *********************************************************************
namespace Tests
{
    public class A3HighlighterTests
    {

        [Test]
        public void A3Highlighter_GetOccupiedGridPositions_WithUpDirection_ReturnsCorrectPositions()
        {

            A3Highlighter highlighter = new GameObject().AddComponent<A3Highlighter>();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = false;

            List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new GridPosition(3, 3), result[0]);
            Assert.AreEqual(new GridPosition(4, 3), result[1]);
            Assert.AreEqual(new GridPosition(2, 3), result[2]);

            result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
            Assert.AreEqual(new GridPosition(3, 4), result[0]);
            Assert.AreEqual(new GridPosition(4, 4), result[1]);
            Assert.AreEqual(new GridPosition(5, 4), result[2]);
            Assert.AreEqual(new GridPosition(5, 3), result[3]);
            Assert.AreEqual(new GridPosition(5, 2), result[4]);
            Assert.AreEqual(new GridPosition(4, 2), result[5]);
            Assert.AreEqual(new GridPosition(3, 2), result[6]);
            Assert.AreEqual(new GridPosition(2, 2), result[7]);
            Assert.AreEqual(new GridPosition(1, 2), result[8]);
            Assert.AreEqual(new GridPosition(1, 3), result[9]);
            Assert.AreEqual(new GridPosition(1, 4), result[10]);
            Assert.AreEqual(new GridPosition(2, 4), result[11]);
        }
        [Test]
        public void A3Highlighter_GetOccupiedGridPositions_WithUpDirectionAndFlipped_ReturnsCorrectPositions()
        {

            A3Highlighter highlighter = new GameObject().AddComponent<A3Highlighter>();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = true;

            List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);

            Assert.AreEqual(new GridPosition(3, 3), result[0]);
            Assert.AreEqual(new GridPosition(2, 3), result[1]);
            Assert.AreEqual(new GridPosition(4, 3), result[2]);

            result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
            Assert.AreEqual(new GridPosition(3, 4), result[0]);
            Assert.AreEqual(new GridPosition(2, 4), result[1]);
            Assert.AreEqual(new GridPosition(1, 4), result[2]);
            Assert.AreEqual(new GridPosition(1, 3), result[3]);
            Assert.AreEqual(new GridPosition(1, 2), result[4]);
            Assert.AreEqual(new GridPosition(2, 2), result[5]);
            Assert.AreEqual(new GridPosition(3, 2), result[6]);
            Assert.AreEqual(new GridPosition(4, 2), result[7]);
            Assert.AreEqual(new GridPosition(5, 2), result[8]);
            Assert.AreEqual(new GridPosition(5, 3), result[9]);
            Assert.AreEqual(new GridPosition(5, 4), result[10]);
            Assert.AreEqual(new GridPosition(4, 4), result[11]);
        }

        [Test]
        public void A3Highlighter_GetOccupiedGridPositions_WithRightDirection_ReturnsCorrectPositions()
        {
            A3Highlighter highlighter = new GameObject().AddComponent<A3Highlighter>();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = false;

            List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);



            Assert.AreEqual(new GridPosition(3, 3), result[0]);
            Assert.AreEqual(new GridPosition(3, 2), result[1]);
            Assert.AreEqual(new GridPosition(3, 4), result[2]);
            result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
            Assert.AreEqual(new GridPosition(4, 3), result[0]);
            Assert.AreEqual(new GridPosition(4, 2), result[1]);
            Assert.AreEqual(new GridPosition(4, 1), result[2]);
            Assert.AreEqual(new GridPosition(3, 1), result[3]);
            Assert.AreEqual(new GridPosition(2, 1), result[4]);
            Assert.AreEqual(new GridPosition(2, 2), result[5]);
            Assert.AreEqual(new GridPosition(2, 3), result[6]);
            Assert.AreEqual(new GridPosition(2, 4), result[7]);
            Assert.AreEqual(new GridPosition(2, 5), result[8]);
            Assert.AreEqual(new GridPosition(3, 5), result[9]);
            Assert.AreEqual(new GridPosition(4, 5), result[10]);
            Assert.AreEqual(new GridPosition(4, 4), result[11]);
        }

        [Test]
        public void A3Highlighter_GetOccupiedGridPositions_WithRightDirectionAndFlipped_ReturnsCorrectPositions()
        {

            A3Highlighter highlighter = new GameObject().AddComponent<A3Highlighter>();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = true;

            List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);

            Assert.AreEqual(new GridPosition(3, 3), result[0]);
            Assert.AreEqual(new GridPosition(3, 4), result[1]);
            Assert.AreEqual(new GridPosition(3, 2), result[2]);
            
            result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
            Assert.AreEqual(new GridPosition(4, 3), result[0]);
            Assert.AreEqual(new GridPosition(4, 4), result[1]);
            Assert.AreEqual(new GridPosition(4, 5), result[2]);
            Assert.AreEqual(new GridPosition(3, 5), result[3]);
            Assert.AreEqual(new GridPosition(2, 5), result[4]);
            Assert.AreEqual(new GridPosition(2, 4), result[5]);
            Assert.AreEqual(new GridPosition(2, 3), result[6]);
            Assert.AreEqual(new GridPosition(2, 2), result[7]);
            Assert.AreEqual(new GridPosition(2, 1), result[8]);
            Assert.AreEqual(new GridPosition(3, 1), result[9]);
            Assert.AreEqual(new GridPosition(4, 1), result[10]);
            Assert.AreEqual(new GridPosition(4, 2), result[11]);
        }

        [Test]
        public void A3Highlighter_GetOccupiedGridPositions_WithDownDirection_ReturnsCorrectPositions()
        {
            A3Highlighter highlighter = new GameObject().AddComponent<A3Highlighter>();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = false;

            List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);

            Assert.AreEqual(new GridPosition(3, 3), result[0]);
            Assert.AreEqual(new GridPosition(2, 3), result[1]);
            Assert.AreEqual(new GridPosition(4, 3), result[2]);
            
            result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
            Assert.AreEqual(new GridPosition(3, 2), result[0]);
            Assert.AreEqual(new GridPosition(2, 2), result[1]);
            Assert.AreEqual(new GridPosition(1, 2), result[2]);
            Assert.AreEqual(new GridPosition(1, 3), result[3]);
            Assert.AreEqual(new GridPosition(1, 4), result[4]);
            Assert.AreEqual(new GridPosition(2, 4), result[5]);
            Assert.AreEqual(new GridPosition(3, 4), result[6]);
            Assert.AreEqual(new GridPosition(4, 4), result[7]);
            Assert.AreEqual(new GridPosition(5, 4), result[8]);
            Assert.AreEqual(new GridPosition(5, 3), result[9]);
            Assert.AreEqual(new GridPosition(5, 2), result[10]);
            Assert.AreEqual(new GridPosition(4, 2), result[11]);

        }

        [Test]
        public void A3Highlighter_GetOccupiedGridPositions_WithDownDirectionAndFlipped_ReturnsCorrectPositions()
        {
            A3Highlighter highlighter = new GameObject().AddComponent<A3Highlighter>();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = true;

            List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);

            Assert.AreEqual(new GridPosition(3, 3), result[0]);
            Assert.AreEqual(new GridPosition(4, 3), result[1]);
            Assert.AreEqual(new GridPosition(2, 3), result[2]);
            
            result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
            Assert.AreEqual(new GridPosition(3, 2), result[0]);
            Assert.AreEqual(new GridPosition(4, 2), result[1]);
            Assert.AreEqual(new GridPosition(5, 2), result[2]);
            Assert.AreEqual(new GridPosition(5, 3), result[3]);
            Assert.AreEqual(new GridPosition(5, 4), result[4]);
            Assert.AreEqual(new GridPosition(4, 4), result[5]);
            Assert.AreEqual(new GridPosition(3, 4), result[6]);
            Assert.AreEqual(new GridPosition(2, 4), result[7]);
            Assert.AreEqual(new GridPosition(1, 4), result[8]);
            Assert.AreEqual(new GridPosition(1, 3), result[9]);
            Assert.AreEqual(new GridPosition(1, 2), result[10]);
            Assert.AreEqual(new GridPosition(2, 2), result[11]);

        }

        [Test]
        public void A3Highlighter_GetOccupiedGridPositions_WithLeftDirection_ReturnsCorrectPositions()
        {
            A3Highlighter highlighter = new GameObject().AddComponent<A3Highlighter>();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = false;

            List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);

            Assert.AreEqual(new GridPosition(3, 3), result[0]);
            Assert.AreEqual(new GridPosition(3, 4), result[1]);
            Assert.AreEqual(new GridPosition(3, 2), result[2]);
            
            

            result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
            Assert.AreEqual(new GridPosition(2, 3), result[0]);
            Assert.AreEqual(new GridPosition(2, 4), result[1]);
            Assert.AreEqual(new GridPosition(2, 5), result[2]);
            Assert.AreEqual(new GridPosition(3, 5), result[3]);
            Assert.AreEqual(new GridPosition(4, 5), result[4]);
            Assert.AreEqual(new GridPosition(4, 4), result[5]);
            Assert.AreEqual(new GridPosition(4, 3), result[6]);
            Assert.AreEqual(new GridPosition(4, 2), result[7]);
            Assert.AreEqual(new GridPosition(4, 1), result[8]);
            Assert.AreEqual(new GridPosition(3, 1), result[9]);
            Assert.AreEqual(new GridPosition(2, 1), result[10]);
            Assert.AreEqual(new GridPosition(2, 2), result[11]);
        }

        [Test]
        public void A3Highlighter_GetOccupiedGridPositions_WithLeftDirectionAndFlipped_ReturnsCorrectPositions()
        {
            A3Highlighter highlighter = new GameObject().AddComponent<A3Highlighter>();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = true;

            List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);

            Assert.AreEqual(new GridPosition(3, 3), result[0]);
            Assert.AreEqual(new GridPosition(3, 2), result[1]);
            Assert.AreEqual(new GridPosition(3, 4), result[2]);

            result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
            Assert.AreEqual(new GridPosition(2, 3), result[0]);
            Assert.AreEqual(new GridPosition(2, 2), result[1]);
            Assert.AreEqual(new GridPosition(2, 1), result[2]);
            Assert.AreEqual(new GridPosition(3, 1), result[3]);
            Assert.AreEqual(new GridPosition(4, 1), result[4]);
            Assert.AreEqual(new GridPosition(4, 2), result[5]);
            Assert.AreEqual(new GridPosition(4, 3), result[6]);
            Assert.AreEqual(new GridPosition(4, 4), result[7]);
            Assert.AreEqual(new GridPosition(4, 5), result[8]);
            Assert.AreEqual(new GridPosition(3, 5), result[9]);
            Assert.AreEqual(new GridPosition(2, 5), result[10]);
            Assert.AreEqual(new GridPosition(2, 4), result[11]);

        }
    }
}
