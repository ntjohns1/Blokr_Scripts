using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using Blokr.Core.Models;
using Blokr.Highlighter;

// *********************************************************************
// A1Highlighter Tests
// *********************************************************************
namespace Tests
{
    public class A1HighlighterTests
    {

        [Test]
        public void A1Highlighter_GetOccupiedGridPositions_WithUpDirection_ReturnsCorrectPositions()
        {

            A1Highlighter highlighter = new A1Highlighter();
            GridPosition cellA = new(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = false;

            List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);



            result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.X}, y:{item.Y}]");
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
        public void A1Highlighter_GetOccupiedGridPositions_WithUpDirectionAndFlipped_ReturnsCorrectPositions()
        {

            A1Highlighter highlighter = new A1Highlighter();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = true;

            List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);

            // foreach (GridPosition item in result)
            // {
            //     Debug.Log($"[x:{item.X}, y:{item.Y}]");
            // }

            Assert.AreEqual(new GridPosition(3, 3), result[0]);

            result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.X}, y:{item.Y}]");
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
        public void A1Highlighter_GetOccupiedGridPositions_WithRightDirection_ReturnsCorrectPositions()
        {
            A1Highlighter highlighter = new A1Highlighter();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = false;

            List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);

            // foreach (GridPosition item in result)
            // {
            //     Debug.Log($"[x:{item.X}, y:{item.Y}]");
            // }

            Assert.AreEqual(new GridPosition(3, 3), result[0]);


            result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.X}, y:{item.Y}]");
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
        public void A1Highlighter_GetOccupiedGridPositions_WithRightDirectionAndFlipped_ReturnsCorrectPositions()
        {

            A1Highlighter highlighter = new A1Highlighter();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = true;

            List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);

            // foreach (GridPosition item in result)
            // {
            //     Debug.Log($"[x:{item.X}, y:{item.Y}]");
            // }

            Assert.AreEqual(new GridPosition(3, 3), result[0]);

            result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.X}, y:{item.Y}]");
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
        public void A1Highlighter_GetOccupiedGridPositions_WithDownDirection_ReturnsCorrectPositions()
        {
            A1Highlighter highlighter = new A1Highlighter();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = false;

            List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);

            // foreach (GridPosition item in result)
            // {
            //     Debug.Log($"[x:{item.X}, y:{item.Y}]");
            // }

            Assert.AreEqual(new GridPosition(3, 3), result[0]);

            result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.X}, y:{item.Y}]");
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
        public void A1Highlighter_GetOccupiedGridPositions_WithDownDirectionAndFlipped_ReturnsCorrectPositions()
        {
            A1Highlighter highlighter = new A1Highlighter();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = true;

            List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);

            // foreach (GridPosition item in result)
            // {
            //     Debug.Log($"[x:{item.X}, y:{item.Y}]");
            // }

            Assert.AreEqual(new GridPosition(3, 3), result[0]);

            result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.X}, y:{item.Y}]");
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
        public void A1Highlighter_GetOccupiedGridPositions_WithLeftDirection_ReturnsCorrectPositions()
        {
            A1Highlighter highlighter = new A1Highlighter();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = false;

            List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);

            // foreach (GridPosition item in result)
            // {
            //     Debug.Log($"[x:{item.X}, y:{item.Y}]");
            // }

            Assert.AreEqual(new GridPosition(3, 3), result[0]);

            result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.X}, y:{item.Y}]");
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
        public void A1Highlighter_GetOccupiedGridPositions_WithLeftDirectionAndFlipped_ReturnsCorrectPositions()
        {
            A1Highlighter highlighter = new A1Highlighter();
            GridPosition cellA = new GridPosition(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = true;

            List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);

            // foreach (GridPosition item in result)
            // {
            //     Debug.Log($"[x:{item.X}, y:{item.Y}]");
            // }

            Assert.AreEqual(new GridPosition(3, 3), result[0]);

            result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
            foreach (GridPosition item in result)
            {
                Debug.Log($"[x:{item.X}, y:{item.Y}]");
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
