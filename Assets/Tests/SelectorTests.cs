using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Blokr;

namespace Tests
{
    public class SelectorTests
    {

        // *********************************************************************
        // B4Selector Tests
        // *********************************************************************

        [Test]
        public void B4Selector_GetOccupiedGridPositions_WithUpDirection_ReturnsCorrectPositions()
        {

            B4Selector selector = new GameObject().AddComponent<B4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = false;

            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);

            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(2, 3), result[1]);
            Assert.AreEqual(new Vector2Int(4, 3), result[2]);
            Assert.AreEqual(new Vector2Int(4, 2), result[3]);
        }
        [Test]
        public void B4Selector_GetOccupiedGridPositions_WithUpDirectionAndFlipped_ReturnsCorrectPositions()
        {

            B4Selector selector = new GameObject().AddComponent<B4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(4, 3), result[1]);
            Assert.AreEqual(new Vector2Int(2, 3), result[2]);
            Assert.AreEqual(new Vector2Int(2, 4), result[3]);
        }

        [Test]
        public void B4Selector_GetOccupiedGridPositions_WithRightDirectionAndFlipped_ReturnsCorrectPositions()
        {

            B4Selector selector = new GameObject().AddComponent<B4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 4), result[2]);
            Assert.AreEqual(new Vector2Int(4, 4), result[3]);
        }

        // *********************************************************************
        // B5Selector Tests
        // *********************************************************************

        [Test]
        public void B5Selector_GetOccupiedGridPositions_WithUpDirection_ReturnsCorrectPositions()
        {

            B5Selector selector = new GameObject().AddComponent<B5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(2, 3), result[1]);
            Assert.AreEqual(new Vector2Int(1, 3), result[2]);
            Assert.AreEqual(new Vector2Int(4, 3), result[3]);
            Assert.AreEqual(new Vector2Int(4, 2), result[4]);
        }
        [Test]
        public void B5Selector_GetOccupiedGridPositions_WithUpDirectionAndFlipped_ReturnsCorrectPositions()
        {

            B5Selector selector = new GameObject().AddComponent<B5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(4, 3), result[1]);
            Assert.AreEqual(new Vector2Int(5, 3), result[2]);
            Debug.Log(isFlipped);
            Assert.AreEqual(new Vector2Int(2, 3), result[3]);
            Debug.Log(isFlipped);
            Assert.AreEqual(new Vector2Int(2, 4), result[4]);
        }

        [Test]
        public void B5Selector_GetOccupiedGridPositions_WithRightDirectionAndFlipped_ReturnsCorrectPositions()
        {

            B5Selector selector = new GameObject().AddComponent<B5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(4, 4), result[4]);
        }


        // *********************************************************************
        // C4Selector Tests
        // *********************************************************************
        // *********************************************************************
        // C5Selector Tests
        // *********************************************************************
        // *********************************************************************
        // D4Selector Tests
        // *********************************************************************
        // *********************************************************************
        // D5Selector Tests
        // *********************************************************************
        // *********************************************************************
        // E4Selector Tests
        // *********************************************************************
        // *********************************************************************
        // F5Selector Tests
        // *********************************************************************
        // *********************************************************************
        // G5Selector Tests
        // *********************************************************************
        // *********************************************************************
        // H5Selector Tests
        // *********************************************************************
        // *********************************************************************
        // I5Selector Tests
        // *********************************************************************
        // *********************************************************************
        // J5Selector Tests
        // *********************************************************************
        // *********************************************************************
        // K5Selector Tests
        // *********************************************************************
        // *********************************************************************
        // L5Selector Tests
        // *********************************************************************
    }
}
