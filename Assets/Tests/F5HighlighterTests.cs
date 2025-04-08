using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Blokr;

// *********************************************************************
// F5Highlighter Tests
// *********************************************************************
namespace Tests
{
    public class F5HighlighterTests
    {
        [Test]
        public void F5Highlighter_GetOccupiedGridPositions_WithUpDirection_ReturnsCorrectPositions()
        {
            F5Highlighter highlighter = new GameObject().AddComponent<F5Highlighter>();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = false;


            List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);

            // foreach (GridPosition item in result)
            // {
            //     Debug.Log($"[x:{item.x}, y:{item.y}]");
            // }

            Assert.AreEqual(new GridPosition(3, 3), result[0]);
            Assert.AreEqual(new GridPosition(4, 3), result[1]);
            Assert.AreEqual(new GridPosition(2, 3), result[2]);
            Assert.AreEqual(new GridPosition(3, 4), result[3]);
            Assert.AreEqual(new GridPosition(3, 2), result[4]);

            result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
        }

        [Test]
        public void F5Highlighter_GetOccupiedGridPositions_WithUpDirectionAndFlipped_ReturnsCorrectPositions()
        {
            F5Highlighter highlighter = new GameObject().AddComponent<F5Highlighter>();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = true;


            List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);

            // foreach (GridPosition item in result)
            // {
            //     Debug.Log($"[x:{item.x}, y:{item.y}]");
            // }

            Assert.AreEqual(new GridPosition(3, 3), result[0]);
            Assert.AreEqual(new GridPosition(4, 3), result[1]);
            Assert.AreEqual(new GridPosition(2, 3), result[2]);
            Assert.AreEqual(new GridPosition(3, 2), result[3]);
            Assert.AreEqual(new GridPosition(3, 4), result[4]);

            result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
        }

        [Test]
        public void F5Highlighter_GetOccupiedGridPositions_WithRightDirection_ReturnsCorrectPositions()
        {
            F5Highlighter highlighter = new GameObject().AddComponent<F5Highlighter>();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = false;


            List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);

            // foreach (GridPosition item in result)
            // {
            //     Debug.Log($"[x:{item.x}, y:{item.y}]");
            // }

            Assert.AreEqual(new GridPosition(3, 3), result[0]);
            Assert.AreEqual(new GridPosition(3, 2), result[1]);
            Assert.AreEqual(new GridPosition(3, 4), result[2]);
            Assert.AreEqual(new GridPosition(4, 3), result[3]);
            Assert.AreEqual(new GridPosition(2, 3), result[4]);

            result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
        }

        [Test]
        public void F5Highlighter_GetOccupiedGridPositions_WithRightDirectionAndFlipped_ReturnsCorrectPositions()
        {
            F5Highlighter highlighter = new GameObject().AddComponent<F5Highlighter>();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = true;


            List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);

            // foreach (GridPosition item in result)
            // {
            //     Debug.Log($"[x:{item.x}, y:{item.y}]");
            // }

            Assert.AreEqual(new GridPosition(3, 3), result[0]);
            Assert.AreEqual(new GridPosition(3, 2), result[1]);
            Assert.AreEqual(new GridPosition(3, 4), result[2]);
            Assert.AreEqual(new GridPosition(2, 3), result[3]);
            Assert.AreEqual(new GridPosition(4, 3), result[4]);

            result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
        }

        [Test]
        public void F5Highlighter_GetOccupiedGridPositions_WithDownDirection_ReturnsCorrectPositions()
        {
            F5Highlighter highlighter = new GameObject().AddComponent<F5Highlighter>();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = false;


            List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);

            // foreach (GridPosition item in result)
            // {
            //     Debug.Log($"[x:{item.x}, y:{item.y}]");
            // }

            Assert.AreEqual(new GridPosition(3, 3), result[0]);
            Assert.AreEqual(new GridPosition(2, 3), result[1]);
            Assert.AreEqual(new GridPosition(4, 3), result[2]);
            Assert.AreEqual(new GridPosition(3, 2), result[3]);
            Assert.AreEqual(new GridPosition(3, 4), result[4]);
            
            result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
        }

        [Test]
        public void F5Highlighter_GetOccupiedGridPositions_WithDownDirectionAndFlipped_ReturnsCorrectPositions()
        {
            F5Highlighter highlighter = new GameObject().AddComponent<F5Highlighter>();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = true;


            List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);

            // foreach (GridPosition item in result)
            // {
            //     Debug.Log($"[x:{item.x}, y:{item.y}]");
            // }

            Assert.AreEqual(new GridPosition(3, 3), result[0]);
            Assert.AreEqual(new GridPosition(2, 3), result[1]);
            Assert.AreEqual(new GridPosition(4, 3), result[2]);
            Assert.AreEqual(new GridPosition(3, 4), result[3]);
            Assert.AreEqual(new GridPosition(3, 2), result[4]);
            
            result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }        
        }

        [Test]
        public void F5Highlighter_GetOccupiedGridPositions_WithLeftDirection_ReturnsCorrectPositions()
        {
            F5Highlighter highlighter = new GameObject().AddComponent<F5Highlighter>();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = false;


            List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);

            // foreach (GridPosition item in result)
            // {
            //     Debug.Log($"[x:{item.x}, y:{item.y}]");
            // }

            Assert.AreEqual(new GridPosition(3, 3), result[0]);
            Assert.AreEqual(new GridPosition(3, 4), result[1]);
            Assert.AreEqual(new GridPosition(3, 2), result[2]);
            Assert.AreEqual(new GridPosition(2, 3), result[3]);
            Assert.AreEqual(new GridPosition(4, 3), result[4]);
        
            result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }        
        }

        [Test]
        public void F5Highlighter_GetOccupiedGridPositions_WithLeftDirectionAndFlipped_ReturnsCorrectPositions()
        {
            F5Highlighter highlighter = new GameObject().AddComponent<F5Highlighter>();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = true;


            List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);

            // foreach (GridPosition item in result)
            // {
            //     Debug.Log($"[x:{item.x}, y:{item.y}]");
            // }

            Assert.AreEqual(new GridPosition(3, 3), result[0]);
            Assert.AreEqual(new GridPosition(3, 4), result[1]);
            Assert.AreEqual(new GridPosition(3, 2), result[2]);
            Assert.AreEqual(new GridPosition(4, 3), result[3]);
            Assert.AreEqual(new GridPosition(2, 3), result[4]);
            
            result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }
        }

    }
}