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

            Debug.Log("B4Selector Up");

            foreach (Vector2Int item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }

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

            Debug.Log("B4Selector Up Flipped");


            foreach (Vector2Int item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(4, 3), result[1]);
            Assert.AreEqual(new Vector2Int(2, 3), result[2]);
            Assert.AreEqual(new Vector2Int(2, 4), result[3]);
        }

        [Test]
        public void B4Selector_GetOccupiedGridPositions_WithRightDirection_ReturnsCorrectPositions()
        {
            B4Selector selector = new GameObject().AddComponent<B4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);

            Debug.Log("B4Selector Right");
            foreach (Vector2Int item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 4), result[1]);
            Assert.AreEqual(new Vector2Int(3, 2), result[2]);
            Assert.AreEqual(new Vector2Int(2, 2), result[3]);
        }

        [Test]
        public void B4Selector_GetOccupiedGridPositions_WithRightDirectionAndFlipped_ReturnsCorrectPositions()
        {

            B4Selector selector = new GameObject().AddComponent<B4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);

            Debug.Log("B4Selector Right Flipped");
            foreach (Vector2Int item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 4), result[2]);
            Assert.AreEqual(new Vector2Int(4, 4), result[3]);
        }

        [Test]
        public void B4Selector_GetOccupiedGridPositions_WithDownDirection_ReturnsCorrectPositions()
        {
            B4Selector selector = new GameObject().AddComponent<B4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);

            Debug.Log("B4Selector Down");

            foreach (Vector2Int item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }

            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(4, 3), result[1]);
            Assert.AreEqual(new Vector2Int(2, 3), result[2]);
            Assert.AreEqual(new Vector2Int(2, 2), result[3]);
        }

        [Test]
        public void B4Selector_GetOccupiedGridPositions_WithDownDirectionAndFlipped_ReturnsCorrectPositions()
        {
            B4Selector selector = new GameObject().AddComponent<B4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);

            Debug.Log("B4Selector Down Flipped");
            foreach (Vector2Int item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }

            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(2, 3), result[1]);
            Assert.AreEqual(new Vector2Int(4, 3), result[2]);
            Assert.AreEqual(new Vector2Int(4, 2), result[3]);
        }

        [Test]
        public void B4Selector_GetOccupiedGridPositions_WithLeftDirection_ReturnsCorrectPositions()
        {
            B4Selector selector = new GameObject().AddComponent<B4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);

            Debug.Log("B4Selector Left");

            foreach (Vector2Int item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
        }

        [Test]
        public void B4Selector_GetOccupiedGridPositions_WithLeftDirectionAndFlipped_ReturnsCorrectPositions()
        {
            B4Selector selector = new GameObject().AddComponent<B4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);

            Debug.Log("B4Selector Left Flipped");

            foreach (Vector2Int item in result)
            {
                Debug.Log($"[x:{item.x}, y:{item.y}]");
            }


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
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

        [Test]
        public void B5Selector_GetOccupiedGridPositions_WithDownDirection_ReturnsCorrectPositions()
        {
            B5Selector selector = new GameObject().AddComponent<B5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
        }

        [Test]
        public void B5Selector_GetOccupiedGridPositions_WithDownDirectionAndFlipped_ReturnsCorrectPositions()
        {
            B5Selector selector = new GameObject().AddComponent<B5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
        }

        [Test]
        public void B5Selector_GetOccupiedGridPositions_WithLeftDirection_ReturnsCorrectPositions()
        {
            B5Selector selector = new GameObject().AddComponent<B5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
        }

        [Test]
        public void B5Selector_GetOccupiedGridPositions_WithLeftDirectionAndFlipped_ReturnsCorrectPositions()
        {
            B5Selector selector = new GameObject().AddComponent<B5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
        }


        // *********************************************************************
        // C4Selector Tests
        // *********************************************************************

        [Test]
        public void C4Selector_GetOccupiedGridPositions_WithUpDirection_ReturnsCorrectPositions()
        {
            C4Selector selector = new GameObject().AddComponent<C4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(2, 3), result[1]);
            Assert.AreEqual(new Vector2Int(1, 3), result[2]);
            Assert.AreEqual(new Vector2Int(4, 3), result[3]);
        }

        [Test]
        public void C4Selector_GetOccupiedGridPositions_WithUpDirectionAndFlipped_ReturnsCorrectPositions()
        {
            C4Selector selector = new GameObject().AddComponent<C4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(4, 3), result[1]);
            Assert.AreEqual(new Vector2Int(5, 3), result[2]);
            Assert.AreEqual(new Vector2Int(2, 3), result[3]);
        }

        [Test]
        public void C4Selector_GetOccupiedGridPositions_WithRightDirection_ReturnsCorrectPositions()
        {
            C4Selector selector = new GameObject().AddComponent<C4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
        }

        [Test]
        public void C4Selector_GetOccupiedGridPositions_WithRightDirectionAndFlipped_ReturnsCorrectPositions()
        {
            C4Selector selector = new GameObject().AddComponent<C4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
        }

        [Test]
        public void C4Selector_GetOccupiedGridPositions_WithDownDirection_ReturnsCorrectPositions()
        {
            C4Selector selector = new GameObject().AddComponent<C4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
        }

        [Test]
        public void C4Selector_GetOccupiedGridPositions_WithDownDirectionAndFlipped_ReturnsCorrectPositions()
        {
            C4Selector selector = new GameObject().AddComponent<C4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
        }

        [Test]
        public void C4Selector_GetOccupiedGridPositions_WithLeftDirection_ReturnsCorrectPositions()
        {
            C4Selector selector = new GameObject().AddComponent<C4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
        }

        [Test]
        public void C4Selector_GetOccupiedGridPositions_WithLeftDirectionAndFlipped_ReturnsCorrectPositions()
        {
            C4Selector selector = new GameObject().AddComponent<C4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
        }

        // *********************************************************************
        // C5Selector Tests
        // *********************************************************************

        [Test]
        public void C5Selector_GetOccupiedGridPositions_WithUpDirection_ReturnsCorrectPositions()
        {
            C5Selector selector = new GameObject().AddComponent<C5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(2, 3), result[1]);
            Assert.AreEqual(new Vector2Int(1, 3), result[2]);
            Assert.AreEqual(new Vector2Int(4, 3), result[3]);
            Assert.AreEqual(new Vector2Int(4, 3), result[4]);
        }

        [Test]
        public void C5Selector_GetOccupiedGridPositions_WithUpDirectionAndFlipped_ReturnsCorrectPositions()
        {
            C5Selector selector = new GameObject().AddComponent<C5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(4, 3), result[1]);
            Assert.AreEqual(new Vector2Int(5, 3), result[2]);
            Assert.AreEqual(new Vector2Int(2, 3), result[3]);
            Assert.AreEqual(new Vector2Int(2, 3), result[4]);
        }

        [Test]
        public void C5Selector_GetOccupiedGridPositions_WithRightDirection_ReturnsCorrectPositions()
        {
            C5Selector selector = new GameObject().AddComponent<C5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void C5Selector_GetOccupiedGridPositions_WithRightDirectionAndFlipped_ReturnsCorrectPositions()
        {
            C5Selector selector = new GameObject().AddComponent<C5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void C5Selector_GetOccupiedGridPositions_WithDownDirection_ReturnsCorrectPositions()
        {
            C5Selector selector = new GameObject().AddComponent<C5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void C5Selector_GetOccupiedGridPositions_WithDownDirectionAndFlipped_ReturnsCorrectPositions()
        {
            C5Selector selector = new GameObject().AddComponent<C5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void C5Selector_GetOccupiedGridPositions_WithLeftDirection_ReturnsCorrectPositions()
        {
            C5Selector selector = new GameObject().AddComponent<C5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void C5Selector_GetOccupiedGridPositions_WithLeftDirectionAndFlipped_ReturnsCorrectPositions()
        {
            C5Selector selector = new GameObject().AddComponent<C5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        // *********************************************************************
        // D4Selector Tests
        // *********************************************************************

        [Test]
        public void D4Selector_GetOccupiedGridPositions_WithUpDirection_ReturnsCorrectPositions()
        {
            D4Selector selector = new GameObject().AddComponent<D4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(2, 3), result[1]);
            Assert.AreEqual(new Vector2Int(1, 3), result[2]);
            Assert.AreEqual(new Vector2Int(4, 3), result[3]);
        }

        [Test]
        public void D4Selector_GetOccupiedGridPositions_WithUpDirectionAndFlipped_ReturnsCorrectPositions()
        {
            D4Selector selector = new GameObject().AddComponent<D4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(4, 3), result[1]);
            Assert.AreEqual(new Vector2Int(5, 3), result[2]);
            Assert.AreEqual(new Vector2Int(2, 3), result[3]);
        }

        [Test]
        public void D4Selector_GetOccupiedGridPositions_WithRightDirection_ReturnsCorrectPositions()
        {
            D4Selector selector = new GameObject().AddComponent<D4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
        }

        [Test]
        public void D4Selector_GetOccupiedGridPositions_WithRightDirectionAndFlipped_ReturnsCorrectPositions()
        {
            D4Selector selector = new GameObject().AddComponent<D4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
        }

        [Test]
        public void D4Selector_GetOccupiedGridPositions_WithDownDirection_ReturnsCorrectPositions()
        {
            D4Selector selector = new GameObject().AddComponent<D4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
        }

        [Test]
        public void D4Selector_GetOccupiedGridPositions_WithDownDirectionAndFlipped_ReturnsCorrectPositions()
        {
            D4Selector selector = new GameObject().AddComponent<D4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
        }

        [Test]
        public void D4Selector_GetOccupiedGridPositions_WithLeftDirection_ReturnsCorrectPositions()
        {
            D4Selector selector = new GameObject().AddComponent<D4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
        }

        [Test]
        public void D4Selector_GetOccupiedGridPositions_WithLeftDirectionAndFlipped_ReturnsCorrectPositions()
        {
            D4Selector selector = new GameObject().AddComponent<D4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
        }

        // *********************************************************************
        // D5Selector Tests
        // *********************************************************************

        [Test]
        public void D5Selector_GetOccupiedGridPositions_WithUpDirection_ReturnsCorrectPositions()
        {
            D5Selector selector = new GameObject().AddComponent<D5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(2, 3), result[1]);
            Assert.AreEqual(new Vector2Int(1, 3), result[2]);
            Assert.AreEqual(new Vector2Int(4, 3), result[3]);
            Assert.AreEqual(new Vector2Int(4, 3), result[4]);
        }

        [Test]
        public void D5Selector_GetOccupiedGridPositions_WithUpDirectionAndFlipped_ReturnsCorrectPositions()
        {
            D5Selector selector = new GameObject().AddComponent<D5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(4, 3), result[1]);
            Assert.AreEqual(new Vector2Int(5, 3), result[2]);
            Assert.AreEqual(new Vector2Int(2, 3), result[3]);
            Assert.AreEqual(new Vector2Int(2, 3), result[4]);
        }

        [Test]
        public void D5Selector_GetOccupiedGridPositions_WithRightDirection_ReturnsCorrectPositions()
        {
            D5Selector selector = new GameObject().AddComponent<D5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void D5Selector_GetOccupiedGridPositions_WithRightDirectionAndFlipped_ReturnsCorrectPositions()
        {
            D5Selector selector = new GameObject().AddComponent<D5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void D5Selector_GetOccupiedGridPositions_WithDownDirection_ReturnsCorrectPositions()
        {
            D5Selector selector = new GameObject().AddComponent<D5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void D5Selector_GetOccupiedGridPositions_WithDownDirectionAndFlipped_ReturnsCorrectPositions()
        {
            D5Selector selector = new GameObject().AddComponent<D5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void D5Selector_GetOccupiedGridPositions_WithLeftDirection_ReturnsCorrectPositions()
        {
            D5Selector selector = new GameObject().AddComponent<D5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void D5Selector_GetOccupiedGridPositions_WithLeftDirectionAndFlipped_ReturnsCorrectPositions()
        {
            D5Selector selector = new GameObject().AddComponent<D5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        // *********************************************************************
        // E4Selector Tests
        // *********************************************************************

        [Test]
        public void E4Selector_GetOccupiedGridPositions_WithUpDirection_ReturnsCorrectPositions()
        {
            E4Selector selector = new GameObject().AddComponent<E4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(2, 3), result[1]);
            Assert.AreEqual(new Vector2Int(1, 3), result[2]);
            Assert.AreEqual(new Vector2Int(4, 3), result[3]);
        }

        [Test]
        public void E4Selector_GetOccupiedGridPositions_WithUpDirectionAndFlipped_ReturnsCorrectPositions()
        {
            E4Selector selector = new GameObject().AddComponent<E4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(4, 3), result[1]);
            Assert.AreEqual(new Vector2Int(5, 3), result[2]);
            Assert.AreEqual(new Vector2Int(2, 3), result[3]);
        }

        [Test]
        public void E4Selector_GetOccupiedGridPositions_WithRightDirection_ReturnsCorrectPositions()
        {
            E4Selector selector = new GameObject().AddComponent<E4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
        }

        [Test]
        public void E4Selector_GetOccupiedGridPositions_WithRightDirectionAndFlipped_ReturnsCorrectPositions()
        {
            E4Selector selector = new GameObject().AddComponent<E4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
        }

        [Test]
        public void E4Selector_GetOccupiedGridPositions_WithDownDirection_ReturnsCorrectPositions()
        {
            E4Selector selector = new GameObject().AddComponent<E4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
        }

        [Test]
        public void E4Selector_GetOccupiedGridPositions_WithDownDirectionAndFlipped_ReturnsCorrectPositions()
        {
            E4Selector selector = new GameObject().AddComponent<E4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
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


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
        }

        [Test]
        public void E4Selector_GetOccupiedGridPositions_WithLeftDirectionAndFlipped_ReturnsCorrectPositions()
        {
            E4Selector selector = new GameObject().AddComponent<E4Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
        }

        // *********************************************************************
        // F5Selector Tests
        // *********************************************************************


        [Test]
        public void F5Selector_GetOccupiedGridPositions_WithUpDirection_ReturnsCorrectPositions()
        {
            F5Selector selector = new GameObject().AddComponent<F5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(2, 3), result[1]);
            Assert.AreEqual(new Vector2Int(1, 3), result[2]);
            Assert.AreEqual(new Vector2Int(4, 3), result[3]);
            Assert.AreEqual(new Vector2Int(4, 3), result[4]);
        }

        [Test]
        public void F5Selector_GetOccupiedGridPositions_WithUpDirectionAndFlipped_ReturnsCorrectPositions()
        {
            F5Selector selector = new GameObject().AddComponent<F5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(4, 3), result[1]);
            Assert.AreEqual(new Vector2Int(5, 3), result[2]);
            Assert.AreEqual(new Vector2Int(2, 3), result[3]);
            Assert.AreEqual(new Vector2Int(2, 3), result[4]);
        }

        [Test]
        public void F5Selector_GetOccupiedGridPositions_WithRightDirection_ReturnsCorrectPositions()
        {
            F5Selector selector = new GameObject().AddComponent<F5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void F5Selector_GetOccupiedGridPositions_WithRightDirectionAndFlipped_ReturnsCorrectPositions()
        {
            F5Selector selector = new GameObject().AddComponent<F5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void F5Selector_GetOccupiedGridPositions_WithDownDirection_ReturnsCorrectPositions()
        {
            F5Selector selector = new GameObject().AddComponent<F5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void F5Selector_GetOccupiedGridPositions_WithDownDirectionAndFlipped_ReturnsCorrectPositions()
        {
            F5Selector selector = new GameObject().AddComponent<F5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void F5Selector_GetOccupiedGridPositions_WithLeftDirection_ReturnsCorrectPositions()
        {
            F5Selector selector = new GameObject().AddComponent<F5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void F5Selector_GetOccupiedGridPositions_WithLeftDirectionAndFlipped_ReturnsCorrectPositions()
        {
            F5Selector selector = new GameObject().AddComponent<F5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        // *********************************************************************
        // G5Selector Tests
        // *********************************************************************


        [Test]
        public void G5Selector_GetOccupiedGridPositions_WithUpDirection_ReturnsCorrectPositions()
        {
            G5Selector selector = new GameObject().AddComponent<G5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(2, 3), result[1]);
            Assert.AreEqual(new Vector2Int(1, 3), result[2]);
            Assert.AreEqual(new Vector2Int(4, 3), result[3]);
            Assert.AreEqual(new Vector2Int(4, 3), result[4]);
        }

        [Test]
        public void G5Selector_GetOccupiedGridPositions_WithUpDirectionAndFlipped_ReturnsCorrectPositions()
        {
            G5Selector selector = new GameObject().AddComponent<G5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(4, 3), result[1]);
            Assert.AreEqual(new Vector2Int(5, 3), result[2]);
            Assert.AreEqual(new Vector2Int(2, 3), result[3]);
            Assert.AreEqual(new Vector2Int(2, 3), result[4]);
        }

        [Test]
        public void G5Selector_GetOccupiedGridPositions_WithRightDirection_ReturnsCorrectPositions()
        {
            G5Selector selector = new GameObject().AddComponent<G5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void G5Selector_GetOccupiedGridPositions_WithRightDirectionAndFlipped_ReturnsCorrectPositions()
        {
            G5Selector selector = new GameObject().AddComponent<G5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void G5Selector_GetOccupiedGridPositions_WithDownDirection_ReturnsCorrectPositions()
        {
            G5Selector selector = new GameObject().AddComponent<G5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void G5Selector_GetOccupiedGridPositions_WithDownDirectionAndFlipped_ReturnsCorrectPositions()
        {
            G5Selector selector = new GameObject().AddComponent<G5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void G5Selector_GetOccupiedGridPositions_WithLeftDirection_ReturnsCorrectPositions()
        {
            G5Selector selector = new GameObject().AddComponent<G5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void G5Selector_GetOccupiedGridPositions_WithLeftDirectionAndFlipped_ReturnsCorrectPositions()
        {
            G5Selector selector = new GameObject().AddComponent<G5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        // *********************************************************************
        // H5Selector Tests
        // *********************************************************************


        [Test]
        public void H5Selector_GetOccupiedGridPositions_WithUpDirection_ReturnsCorrectPositions()
        {
            H5Selector selector = new GameObject().AddComponent<H5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(2, 3), result[1]);
            Assert.AreEqual(new Vector2Int(1, 3), result[2]);
            Assert.AreEqual(new Vector2Int(4, 3), result[3]);
            Assert.AreEqual(new Vector2Int(4, 3), result[4]);
        }

        [Test]
        public void H5Selector_GetOccupiedGridPositions_WithUpDirectionAndFlipped_ReturnsCorrectPositions()
        {
            H5Selector selector = new GameObject().AddComponent<H5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(4, 3), result[1]);
            Assert.AreEqual(new Vector2Int(5, 3), result[2]);
            Assert.AreEqual(new Vector2Int(2, 3), result[3]);
            Assert.AreEqual(new Vector2Int(2, 3), result[4]);
        }

        [Test]
        public void H5Selector_GetOccupiedGridPositions_WithRightDirection_ReturnsCorrectPositions()
        {
            H5Selector selector = new GameObject().AddComponent<H5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void H5Selector_GetOccupiedGridPositions_WithRightDirectionAndFlipped_ReturnsCorrectPositions()
        {
            H5Selector selector = new GameObject().AddComponent<H5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void H5Selector_GetOccupiedGridPositions_WithDownDirection_ReturnsCorrectPositions()
        {
            H5Selector selector = new GameObject().AddComponent<H5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void H5Selector_GetOccupiedGridPositions_WithDownDirectionAndFlipped_ReturnsCorrectPositions()
        {
            H5Selector selector = new GameObject().AddComponent<H5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void H5Selector_GetOccupiedGridPositions_WithLeftDirection_ReturnsCorrectPositions()
        {
            H5Selector selector = new GameObject().AddComponent<H5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void H5Selector_GetOccupiedGridPositions_WithLeftDirectionAndFlipped_ReturnsCorrectPositions()
        {
            H5Selector selector = new GameObject().AddComponent<H5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        // *********************************************************************
        // I5Selector Tests
        // *********************************************************************


        [Test]
        public void I5Selector_GetOccupiedGridPositions_WithUpDirection_ReturnsCorrectPositions()
        {
            I5Selector selector = new GameObject().AddComponent<I5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(2, 3), result[1]);
            Assert.AreEqual(new Vector2Int(1, 3), result[2]);
            Assert.AreEqual(new Vector2Int(4, 3), result[3]);
            Assert.AreEqual(new Vector2Int(4, 3), result[4]);
        }

        [Test]
        public void I5Selector_GetOccupiedGridPositions_WithUpDirectionAndFlipped_ReturnsCorrectPositions()
        {
            I5Selector selector = new GameObject().AddComponent<I5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(4, 3), result[1]);
            Assert.AreEqual(new Vector2Int(5, 3), result[2]);
            Assert.AreEqual(new Vector2Int(2, 3), result[3]);
            Assert.AreEqual(new Vector2Int(2, 3), result[4]);
        }

        [Test]
        public void I5Selector_GetOccupiedGridPositions_WithRightDirection_ReturnsCorrectPositions()
        {
            I5Selector selector = new GameObject().AddComponent<I5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void I5Selector_GetOccupiedGridPositions_WithRightDirectionAndFlipped_ReturnsCorrectPositions()
        {
            I5Selector selector = new GameObject().AddComponent<I5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void I5Selector_GetOccupiedGridPositions_WithDownDirection_ReturnsCorrectPositions()
        {
            I5Selector selector = new GameObject().AddComponent<I5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void I5Selector_GetOccupiedGridPositions_WithDownDirectionAndFlipped_ReturnsCorrectPositions()
        {
            I5Selector selector = new GameObject().AddComponent<I5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void I5Selector_GetOccupiedGridPositions_WithLeftDirection_ReturnsCorrectPositions()
        {
            I5Selector selector = new GameObject().AddComponent<I5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void I5Selector_GetOccupiedGridPositions_WithLeftDirectionAndFlipped_ReturnsCorrectPositions()
        {
            I5Selector selector = new GameObject().AddComponent<I5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        // *********************************************************************
        // J5Selector Tests
        // *********************************************************************


        [Test]
        public void J5Selector_GetOccupiedGridPositions_WithUpDirection_ReturnsCorrectPositions()
        {
            J5Selector selector = new GameObject().AddComponent<J5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(2, 3), result[1]);
            Assert.AreEqual(new Vector2Int(1, 3), result[2]);
            Assert.AreEqual(new Vector2Int(4, 3), result[3]);
            Assert.AreEqual(new Vector2Int(4, 3), result[4]);
        }

        [Test]
        public void J5Selector_GetOccupiedGridPositions_WithUpDirectionAndFlipped_ReturnsCorrectPositions()
        {
            J5Selector selector = new GameObject().AddComponent<J5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(4, 3), result[1]);
            Assert.AreEqual(new Vector2Int(5, 3), result[2]);
            Assert.AreEqual(new Vector2Int(2, 3), result[3]);
            Assert.AreEqual(new Vector2Int(2, 3), result[4]);
        }

        [Test]
        public void J5Selector_GetOccupiedGridPositions_WithRightDirection_ReturnsCorrectPositions()
        {
            J5Selector selector = new GameObject().AddComponent<J5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void J5Selector_GetOccupiedGridPositions_WithRightDirectionAndFlipped_ReturnsCorrectPositions()
        {
            J5Selector selector = new GameObject().AddComponent<J5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void J5Selector_GetOccupiedGridPositions_WithDownDirection_ReturnsCorrectPositions()
        {
            J5Selector selector = new GameObject().AddComponent<J5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void J5Selector_GetOccupiedGridPositions_WithDownDirectionAndFlipped_ReturnsCorrectPositions()
        {
            J5Selector selector = new GameObject().AddComponent<J5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void J5Selector_GetOccupiedGridPositions_WithLeftDirection_ReturnsCorrectPositions()
        {
            J5Selector selector = new GameObject().AddComponent<J5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void J5Selector_GetOccupiedGridPositions_WithLeftDirectionAndFlipped_ReturnsCorrectPositions()
        {
            J5Selector selector = new GameObject().AddComponent<J5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        // *********************************************************************
        // K5Selector Tests
        // *********************************************************************


        [Test]
        public void K5Selector_GetOccupiedGridPositions_WithUpDirection_ReturnsCorrectPositions()
        {
            K5Selector selector = new GameObject().AddComponent<K5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(2, 3), result[1]);
            Assert.AreEqual(new Vector2Int(1, 3), result[2]);
            Assert.AreEqual(new Vector2Int(4, 3), result[3]);
            Assert.AreEqual(new Vector2Int(4, 3), result[4]);
        }

        [Test]
        public void K5Selector_GetOccupiedGridPositions_WithUpDirectionAndFlipped_ReturnsCorrectPositions()
        {
            K5Selector selector = new GameObject().AddComponent<K5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(4, 3), result[1]);
            Assert.AreEqual(new Vector2Int(5, 3), result[2]);
            Assert.AreEqual(new Vector2Int(2, 3), result[3]);
            Assert.AreEqual(new Vector2Int(2, 3), result[4]);
        }

        [Test]
        public void K5Selector_GetOccupiedGridPositions_WithRightDirection_ReturnsCorrectPositions()
        {
            K5Selector selector = new GameObject().AddComponent<K5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void K5Selector_GetOccupiedGridPositions_WithRightDirectionAndFlipped_ReturnsCorrectPositions()
        {
            K5Selector selector = new GameObject().AddComponent<K5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void K5Selector_GetOccupiedGridPositions_WithDownDirection_ReturnsCorrectPositions()
        {
            K5Selector selector = new GameObject().AddComponent<K5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void K5Selector_GetOccupiedGridPositions_WithDownDirectionAndFlipped_ReturnsCorrectPositions()
        {
            K5Selector selector = new GameObject().AddComponent<K5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void K5Selector_GetOccupiedGridPositions_WithLeftDirection_ReturnsCorrectPositions()
        {
            K5Selector selector = new GameObject().AddComponent<K5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void K5Selector_GetOccupiedGridPositions_WithLeftDirectionAndFlipped_ReturnsCorrectPositions()
        {
            K5Selector selector = new GameObject().AddComponent<K5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        // *********************************************************************
        // L5Selector Tests
        // *********************************************************************


        [Test]
        public void L5Selector_GetOccupiedGridPositions_WithUpDirection_ReturnsCorrectPositions()
        {
            L5Selector selector = new GameObject().AddComponent<L5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(2, 3), result[1]);
            Assert.AreEqual(new Vector2Int(1, 3), result[2]);
            Assert.AreEqual(new Vector2Int(4, 3), result[3]);
            Assert.AreEqual(new Vector2Int(4, 3), result[4]);
        }

        [Test]
        public void L5Selector_GetOccupiedGridPositions_WithUpDirectionAndFlipped_ReturnsCorrectPositions()
        {
            L5Selector selector = new GameObject().AddComponent<L5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Up;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(4, 3), result[1]);
            Assert.AreEqual(new Vector2Int(5, 3), result[2]);
            Assert.AreEqual(new Vector2Int(2, 3), result[3]);
            Assert.AreEqual(new Vector2Int(2, 3), result[4]);
        }

        [Test]
        public void L5Selector_GetOccupiedGridPositions_WithRightDirection_ReturnsCorrectPositions()
        {
            L5Selector selector = new GameObject().AddComponent<L5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void L5Selector_GetOccupiedGridPositions_WithRightDirectionAndFlipped_ReturnsCorrectPositions()
        {
            L5Selector selector = new GameObject().AddComponent<L5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Right;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void L5Selector_GetOccupiedGridPositions_WithDownDirection_ReturnsCorrectPositions()
        {
            L5Selector selector = new GameObject().AddComponent<L5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void L5Selector_GetOccupiedGridPositions_WithDownDirectionAndFlipped_ReturnsCorrectPositions()
        {
            L5Selector selector = new GameObject().AddComponent<L5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Down;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void L5Selector_GetOccupiedGridPositions_WithLeftDirection_ReturnsCorrectPositions()
        {
            L5Selector selector = new GameObject().AddComponent<L5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = false;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

        [Test]
        public void L5Selector_GetOccupiedGridPositions_WithLeftDirectionAndFlipped_ReturnsCorrectPositions()
        {
            L5Selector selector = new GameObject().AddComponent<L5Selector>();
            Vector2Int cellA = new Vector2Int(3, 3);
            Direction direction = Direction.Left;
            bool isFlipped = true;


            List<Vector2Int> result = selector.GetOccupiedGridPositions(cellA, direction, isFlipped);


            Assert.AreEqual(new Vector2Int(3, 3), result[0]);
            Assert.AreEqual(new Vector2Int(3, 2), result[1]);
            Assert.AreEqual(new Vector2Int(3, 1), result[2]);
            Assert.AreEqual(new Vector2Int(3, 4), result[3]);
            Assert.AreEqual(new Vector2Int(3, 4), result[4]);
        }

    }
}
