// using System.Collections;
// using System.Collections.Generic;
// using NUnit.Framework;
// using UnityEngine;
// using UnityEngine.TestTools;
// using Blokr;
// using Blokr.Core.Models;

// // *********************************************************************
// // A4Highlighter Tests
// // *********************************************************************
// namespace Tests
// {
//     public class A4HighlighterTests
//     {

//         [Test]
//         public void A4Highlighter_GetOccupiedGridPositions_WithUpDirection_ReturnsCorrectPositions()
//         {

//             A4Highlighter highlighter = new GameObject().AddComponent<A4Highlighter>();
//             GridPosition cellA = new GridPosition(3, 3);
//             Direction direction = Direction.Up;
//             bool isFlipped = false;

//             List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);


//             Assert.AreEqual(new GridPosition(3, 3), result[0]);
//             Assert.AreEqual(new GridPosition(4, 3), result[1]);
//             Assert.AreEqual(new GridPosition(2, 3), result[2]);
//             Assert.AreEqual(new GridPosition(5, 3), result[3]);

//             result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
//             foreach (GridPosition item in result)
//             {
//                 Debug.Log($"[x:{item.x}, y:{item.y}]");
//             }
//             Assert.AreEqual(new GridPosition(3, 4), result[0]);
//             Assert.AreEqual(new GridPosition(4, 4), result[1]);
//             Assert.AreEqual(new GridPosition(5, 4), result[2]);
//             Assert.AreEqual(new GridPosition(6, 4), result[3]);
//             Assert.AreEqual(new GridPosition(6, 3), result[4]);
//             Assert.AreEqual(new GridPosition(6, 2), result[5]);
//             Assert.AreEqual(new GridPosition(5, 2), result[6]);
//             Assert.AreEqual(new GridPosition(4, 2), result[7]);
//             Assert.AreEqual(new GridPosition(3, 2), result[8]);
//             Assert.AreEqual(new GridPosition(2, 2), result[9]);
//             Assert.AreEqual(new GridPosition(1, 2), result[10]);
//             Assert.AreEqual(new GridPosition(1, 3), result[11]);
//             Assert.AreEqual(new GridPosition(1, 4), result[12]);
//             Assert.AreEqual(new GridPosition(2, 4), result[13]);
//         }
//         [Test]
//         public void A4Highlighter_GetOccupiedGridPositions_WithUpDirectionAndFlipped_ReturnsCorrectPositions()
//         {

//             A4Highlighter highlighter = new GameObject().AddComponent<A4Highlighter>();
//             GridPosition cellA = new GridPosition(3, 3);
//             Direction direction = Direction.Up;
//             bool isFlipped = true;

//             List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);



//             Assert.AreEqual(new GridPosition(3, 3), result[0]);
//             Assert.AreEqual(new GridPosition(2, 3), result[1]);
//             Assert.AreEqual(new GridPosition(4, 3), result[2]);
//             Assert.AreEqual(new GridPosition(1, 3), result[3]);

//             result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
//             foreach (GridPosition item in result)
//             {
//                 Debug.Log($"[x:{item.x}, y:{item.y}]");
//             }
//             Assert.AreEqual(new GridPosition(3, 4), result[0]);
//             Assert.AreEqual(new GridPosition(2, 4), result[1]);
//             Assert.AreEqual(new GridPosition(1, 4), result[2]);
//             Assert.AreEqual(new GridPosition(0, 4), result[3]);
//             Assert.AreEqual(new GridPosition(0, 3), result[4]);
//             Assert.AreEqual(new GridPosition(0, 2), result[5]);
//             Assert.AreEqual(new GridPosition(1, 2), result[6]);
//             Assert.AreEqual(new GridPosition(2, 2), result[7]);
//             Assert.AreEqual(new GridPosition(3, 2), result[8]);
//             Assert.AreEqual(new GridPosition(4, 2), result[9]);
//             Assert.AreEqual(new GridPosition(5, 2), result[10]);
//             Assert.AreEqual(new GridPosition(5, 3), result[11]);
//             Assert.AreEqual(new GridPosition(5, 4), result[12]);
//             Assert.AreEqual(new GridPosition(4, 4), result[13]);
//         }

//         [Test]
//         public void A4Highlighter_GetOccupiedGridPositions_WithRightDirection_ReturnsCorrectPositions()
//         {
//             A4Highlighter highlighter = new GameObject().AddComponent<A4Highlighter>();
//             GridPosition cellA = new GridPosition(3, 3);
//             Direction direction = Direction.Right;
//             bool isFlipped = false;

//             List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);



//             Assert.AreEqual(new GridPosition(3, 3), result[0]);
//             Assert.AreEqual(new GridPosition(3, 2), result[1]);
//             Assert.AreEqual(new GridPosition(3, 4), result[2]);
//             Assert.AreEqual(new GridPosition(3, 1), result[3]);


//             result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
//             foreach (GridPosition item in result)
//             {
//                 Debug.Log($"[x:{item.x}, y:{item.y}]");
//             }
//             Assert.AreEqual(new GridPosition(4, 3), result[0]);
//             Assert.AreEqual(new GridPosition(4, 2), result[1]);
//             Assert.AreEqual(new GridPosition(4, 1), result[2]);
//             Assert.AreEqual(new GridPosition(4, 0), result[3]);
//             Assert.AreEqual(new GridPosition(3, 0), result[4]);
//             Assert.AreEqual(new GridPosition(2, 0), result[5]);
//             Assert.AreEqual(new GridPosition(2, 1), result[6]);
//             Assert.AreEqual(new GridPosition(2, 2), result[7]);
//             Assert.AreEqual(new GridPosition(2, 3), result[8]);
//             Assert.AreEqual(new GridPosition(2, 4), result[9]);
//             Assert.AreEqual(new GridPosition(2, 5), result[10]);
//             Assert.AreEqual(new GridPosition(3, 5), result[11]);
//             Assert.AreEqual(new GridPosition(4, 5), result[12]);
//             Assert.AreEqual(new GridPosition(4, 4), result[13]);
//         }

//         [Test]
//         public void A4Highlighter_GetOccupiedGridPositions_WithRightDirectionAndFlipped_ReturnsCorrectPositions()
//         {

//             A4Highlighter highlighter = new GameObject().AddComponent<A4Highlighter>();
//             GridPosition cellA = new GridPosition(3, 3);
//             Direction direction = Direction.Right;
//             bool isFlipped = true;

//             List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);



//             Assert.AreEqual(new GridPosition(3, 3), result[0]);
//             Assert.AreEqual(new GridPosition(3, 4), result[1]);
//             Assert.AreEqual(new GridPosition(3, 2), result[2]);
//             Assert.AreEqual(new GridPosition(3, 5), result[3]);

//             result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
//             foreach (GridPosition item in result)
//             {
//                 Debug.Log($"[x:{item.x}, y:{item.y}]");
//             }
//             Assert.AreEqual(new GridPosition(4, 3), result[0]);
//             Assert.AreEqual(new GridPosition(4, 4), result[1]);
//             Assert.AreEqual(new GridPosition(4, 5), result[2]);
//             Assert.AreEqual(new GridPosition(4, 6), result[3]);
//             Assert.AreEqual(new GridPosition(3, 6), result[4]);
//             Assert.AreEqual(new GridPosition(2, 6), result[5]);
//             Assert.AreEqual(new GridPosition(2, 5), result[6]);
//             Assert.AreEqual(new GridPosition(2, 4), result[7]);
//             Assert.AreEqual(new GridPosition(2, 3), result[8]);
//             Assert.AreEqual(new GridPosition(2, 2), result[9]);
//             Assert.AreEqual(new GridPosition(2, 1), result[10]);
//             Assert.AreEqual(new GridPosition(3, 1), result[11]);
//             Assert.AreEqual(new GridPosition(4, 1), result[12]);
//             Assert.AreEqual(new GridPosition(4, 2), result[13]);
//         }

//         [Test]
//         public void A4Highlighter_GetOccupiedGridPositions_WithDownDirection_ReturnsCorrectPositions()
//         {
//             A4Highlighter highlighter = new GameObject().AddComponent<A4Highlighter>();
//             GridPosition cellA = new GridPosition(3, 3);
//             Direction direction = Direction.Down;
//             bool isFlipped = false;

//             List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);


//             Assert.AreEqual(new GridPosition(3, 3), result[0]);
//             Assert.AreEqual(new GridPosition(2, 3), result[1]);
//             Assert.AreEqual(new GridPosition(4, 3), result[2]);
//             Assert.AreEqual(new GridPosition(1, 3), result[3]);

//             result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
//             foreach (GridPosition item in result)
//             {
//                 Debug.Log($"[x:{item.x}, y:{item.y}]");
//             }
//             Assert.AreEqual(new GridPosition(3, 2), result[0]);
//             Assert.AreEqual(new GridPosition(2, 2), result[1]);
//             Assert.AreEqual(new GridPosition(1, 2), result[2]);
//             Assert.AreEqual(new GridPosition(0, 2), result[3]);
//             Assert.AreEqual(new GridPosition(0, 3), result[4]);
//             Assert.AreEqual(new GridPosition(0, 4), result[5]);
//             Assert.AreEqual(new GridPosition(1, 4), result[6]);
//             Assert.AreEqual(new GridPosition(2, 4), result[7]);
//             Assert.AreEqual(new GridPosition(3, 4), result[8]);
//             Assert.AreEqual(new GridPosition(4, 4), result[9]);
//             Assert.AreEqual(new GridPosition(5, 4), result[10]);
//             Assert.AreEqual(new GridPosition(5, 3), result[11]);
//             Assert.AreEqual(new GridPosition(5, 2), result[12]);
//             Assert.AreEqual(new GridPosition(4, 2), result[13]);
//         }

//         [Test]
//         public void A4Highlighter_GetOccupiedGridPositions_WithDownDirectionAndFlipped_ReturnsCorrectPositions()
//         {
//             A4Highlighter highlighter = new GameObject().AddComponent<A4Highlighter>();
//             GridPosition cellA = new GridPosition(3, 3);
//             Direction direction = Direction.Down;
//             bool isFlipped = true;

//             List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);


//             Assert.AreEqual(new GridPosition(3, 3), result[0]);
//             Assert.AreEqual(new GridPosition(4, 3), result[1]);
//             Assert.AreEqual(new GridPosition(2, 3), result[2]);
//             Assert.AreEqual(new GridPosition(5, 3), result[3]);

//             result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
//             foreach (GridPosition item in result)
//             {
//                 Debug.Log($"[x:{item.x}, y:{item.y}]");
//             }
//             Assert.AreEqual(new GridPosition(3, 2), result[0]);
//             Assert.AreEqual(new GridPosition(4, 2), result[1]);
//             Assert.AreEqual(new GridPosition(5, 2), result[2]);
//             Assert.AreEqual(new GridPosition(6, 2), result[3]);
//             Assert.AreEqual(new GridPosition(6, 3), result[4]);
//             Assert.AreEqual(new GridPosition(6, 4), result[5]);
//             Assert.AreEqual(new GridPosition(5, 4), result[6]);
//             Assert.AreEqual(new GridPosition(4, 4), result[7]);
//             Assert.AreEqual(new GridPosition(3, 4), result[8]);
//             Assert.AreEqual(new GridPosition(2, 4), result[9]);
//             Assert.AreEqual(new GridPosition(1, 4), result[10]);
//             Assert.AreEqual(new GridPosition(1, 3), result[11]);
//             Assert.AreEqual(new GridPosition(1, 2), result[12]);
//             Assert.AreEqual(new GridPosition(2, 2), result[13]);
//         }

//         [Test]
//         public void A4Highlighter_GetOccupiedGridPositions_WithLeftDirection_ReturnsCorrectPositions()
//         {
//             A4Highlighter highlighter = new GameObject().AddComponent<A4Highlighter>();
//             GridPosition cellA = new GridPosition(3, 3);
//             Direction direction = Direction.Left;
//             bool isFlipped = false;

//             List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);



//             Assert.AreEqual(new GridPosition(3, 3), result[0]);
//             Assert.AreEqual(new GridPosition(3, 4), result[1]);
//             Assert.AreEqual(new GridPosition(3, 2), result[2]);
//             Assert.AreEqual(new GridPosition(3, 5), result[3]);

//             result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
//             foreach (GridPosition item in result)
//             {
//                 Debug.Log($"[x:{item.x}, y:{item.y}]");
//             }
//             Assert.AreEqual(new GridPosition(2, 3), result[0]);
//             Assert.AreEqual(new GridPosition(2, 4), result[1]);
//             Assert.AreEqual(new GridPosition(2, 5), result[2]);
//             Assert.AreEqual(new GridPosition(2, 6), result[3]);
//             Assert.AreEqual(new GridPosition(3, 6), result[4]);
//             Assert.AreEqual(new GridPosition(4, 6), result[5]);
//             Assert.AreEqual(new GridPosition(4, 5), result[6]);
//             Assert.AreEqual(new GridPosition(4, 4), result[7]);
//             Assert.AreEqual(new GridPosition(4, 3), result[8]);
//             Assert.AreEqual(new GridPosition(4, 2), result[9]);
//             Assert.AreEqual(new GridPosition(4, 1), result[10]);
//             Assert.AreEqual(new GridPosition(3, 1), result[11]);
//             Assert.AreEqual(new GridPosition(2, 1), result[12]);
//             Assert.AreEqual(new GridPosition(2, 2), result[13]);
//         }

//         [Test]
//         public void A4Highlighter_GetOccupiedGridPositions_WithLeftDirectionAndFlipped_ReturnsCorrectPositions()
//         {
//             A4Highlighter highlighter = new GameObject().AddComponent<A4Highlighter>();
//             GridPosition cellA = new GridPosition(3, 3);
//             Direction direction = Direction.Left;
//             bool isFlipped = true;

//             List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);



//             Assert.AreEqual(new GridPosition(3, 3), result[0]);
//             Assert.AreEqual(new GridPosition(3, 2), result[1]);
//             Assert.AreEqual(new GridPosition(3, 4), result[2]);
//             Assert.AreEqual(new GridPosition(3, 1), result[3]);

//             result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
//             foreach (GridPosition item in result)
//             {
//                 Debug.Log($"[x:{item.x}, y:{item.y}]");
//             }
//             Assert.AreEqual(new GridPosition(2, 3), result[0]);
//             Assert.AreEqual(new GridPosition(2, 2), result[1]);
//             Assert.AreEqual(new GridPosition(2, 1), result[2]);
//             Assert.AreEqual(new GridPosition(2, 0), result[3]);
//             Assert.AreEqual(new GridPosition(3, 0), result[4]);
//             Assert.AreEqual(new GridPosition(4, 0), result[5]);
//             Assert.AreEqual(new GridPosition(4, 1), result[6]);
//             Assert.AreEqual(new GridPosition(4, 2), result[7]);
//             Assert.AreEqual(new GridPosition(4, 3), result[8]);
//             Assert.AreEqual(new GridPosition(4, 4), result[9]);
//             Assert.AreEqual(new GridPosition(4, 5), result[10]);
//             Assert.AreEqual(new GridPosition(3, 5), result[11]);
//             Assert.AreEqual(new GridPosition(2, 5), result[12]);
//             Assert.AreEqual(new GridPosition(2, 4), result[13]);
//         }
//     }
// }
