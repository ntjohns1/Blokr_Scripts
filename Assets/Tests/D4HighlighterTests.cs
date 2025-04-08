// using System.Collections;
// using System.Collections.Generic;
// using NUnit.Framework;
// using UnityEngine;
// using UnityEngine.TestTools;
// using Blokr;

// namespace Tests
// {

//     public class D4SElectorTests
//     {
//         // *********************************************************************
//         // D4Highlighter Tests
//         // *********************************************************************

//         [Test]
//         public void D4Highlighter_GetOccupiedGridPositions_WithUpDirection_ReturnsCorrectPositions()
//         {
//             D4Highlighter highlighter = new GameObject().AddComponent<D4Highlighter>();
//             GridPosition cellA = new GridPosition(3, 3);
//             Direction direction = Direction.Up;
//             bool isFlipped = false;


//             List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);


//             Assert.AreEqual(new GridPosition(3, 3), result[0]);
//             Assert.AreEqual(new GridPosition(4, 3), result[1]);
//             Assert.AreEqual(new GridPosition(3, 4), result[2]);
//             Assert.AreEqual(new GridPosition(4, 4), result[3]);


//             result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
//             foreach (GridPosition item in result)
//             {
//                 Debug.Log($"[x:{item.x}, y:{item.y}]");
//             }
//         }

//         [Test]
//         public void D4Highlighter_GetOccupiedGridPositions_WithUpDirectionAndFlipped_ReturnsCorrectPositions()
//         {
//             D4Highlighter highlighter = new GameObject().AddComponent<D4Highlighter>();
//             GridPosition cellA = new GridPosition(3, 3);
//             Direction direction = Direction.Up;
//             bool isFlipped = true;


//             List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);


//             Assert.AreEqual(new GridPosition(3, 3), result[0]);
//             Assert.AreEqual(new GridPosition(4, 3), result[1]);
//             Assert.AreEqual(new GridPosition(3, 2), result[2]);
//             Assert.AreEqual(new GridPosition(4, 2), result[3]);

//             result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
//             foreach (GridPosition item in result)
//             {
//                 Debug.Log($"[x:{item.x}, y:{item.y}]");
//             }
//         }

//         [Test]
//         public void D4Highlighter_GetOccupiedGridPositions_WithRightDirection_ReturnsCorrectPositions()
//         {
//             D4Highlighter highlighter = new GameObject().AddComponent<D4Highlighter>();
//             GridPosition cellA = new GridPosition(3, 3);
//             Direction direction = Direction.Right;
//             bool isFlipped = false;


//             List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);


//             Assert.AreEqual(new GridPosition(3, 3), result[0]);
//             Assert.AreEqual(new GridPosition(3, 2), result[1]);
//             Assert.AreEqual(new GridPosition(4, 3), result[2]);
//             Assert.AreEqual(new GridPosition(4, 2), result[3]);

//             result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
//             foreach (GridPosition item in result)
//             {
//                 Debug.Log($"[x:{item.x}, y:{item.y}]");
//             }
//         }

//         [Test]
//         public void D4Highlighter_GetOccupiedGridPositions_WithRightDirectionAndFlipped_ReturnsCorrectPositions()
//         {
//             D4Highlighter highlighter = new GameObject().AddComponent<D4Highlighter>();
//             GridPosition cellA = new GridPosition(3, 3);
//             Direction direction = Direction.Right;
//             bool isFlipped = true;


//             List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);


//             Assert.AreEqual(new GridPosition(3, 3), result[0]);
//             Assert.AreEqual(new GridPosition(3, 2), result[1]);
//             Assert.AreEqual(new GridPosition(2, 3), result[2]);
//             Assert.AreEqual(new GridPosition(2, 2), result[3]);

//             result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
//             foreach (GridPosition item in result)
//             {
//                 Debug.Log($"[x:{item.x}, y:{item.y}]");
//             }
//         }

//         [Test]
//         public void D4Highlighter_GetOccupiedGridPositions_WithDownDirection_ReturnsCorrectPositions()
//         {
//             D4Highlighter highlighter = new GameObject().AddComponent<D4Highlighter>();
//             GridPosition cellA = new GridPosition(3, 3);
//             Direction direction = Direction.Down;
//             bool isFlipped = false;


//             List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);


//             Assert.AreEqual(new GridPosition(3, 3), result[0]);
//             Assert.AreEqual(new GridPosition(2, 3), result[1]);
//             Assert.AreEqual(new GridPosition(3, 2), result[2]);
//             Assert.AreEqual(new GridPosition(2, 2), result[3]);

//             result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
//             foreach (GridPosition item in result)
//             {
//                 Debug.Log($"[x:{item.x}, y:{item.y}]");
//             }
//         }

//         [Test]
//         public void D4Highlighter_GetOccupiedGridPositions_WithDownDirectionAndFlipped_ReturnsCorrectPositions()
//         {
//             D4Highlighter highlighter = new GameObject().AddComponent<D4Highlighter>();
//             GridPosition cellA = new GridPosition(3, 3);
//             Direction direction = Direction.Down;
//             bool isFlipped = true;


//             List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);


//             Assert.AreEqual(new GridPosition(3, 3), result[0]);
//             Assert.AreEqual(new GridPosition(2, 3), result[1]);
//             Assert.AreEqual(new GridPosition(3, 4), result[2]);
//             Assert.AreEqual(new GridPosition(2, 4), result[3]);

//             result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
//             foreach (GridPosition item in result)
//             {
//                 Debug.Log($"[x:{item.x}, y:{item.y}]");
//             }
//         }

//         [Test]
//         public void D4Highlighter_GetOccupiedGridPositions_WithLeftDirection_ReturnsCorrectPositions()
//         {
//             D4Highlighter highlighter = new GameObject().AddComponent<D4Highlighter>();
//             GridPosition cellA = new GridPosition(3, 3);
//             Direction direction = Direction.Left;
//             bool isFlipped = false;


//             List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);


//             Assert.AreEqual(new GridPosition(3, 3), result[0]);
//             Assert.AreEqual(new GridPosition(3, 4), result[1]);
//             Assert.AreEqual(new GridPosition(2, 3), result[2]);
//             Assert.AreEqual(new GridPosition(2, 4), result[3]);

//             result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
//             foreach (GridPosition item in result)
//             {
//                 Debug.Log($"[x:{item.x}, y:{item.y}]");
//             }
//         }

//         [Test]
//         public void D4Highlighter_GetOccupiedGridPositions_WithLeftDirectionAndFlipped_ReturnsCorrectPositions()
//         {
//             D4Highlighter highlighter = new GameObject().AddComponent<D4Highlighter>();
//             GridPosition cellA = new GridPosition(3, 3);
//             Direction direction = Direction.Left;
//             bool isFlipped = true;


//             List<GridPosition> result = highlighter.GetOccupiedGridPositions(cellA, direction, isFlipped);


//             Assert.AreEqual(new GridPosition(3, 3), result[0]);
//             Assert.AreEqual(new GridPosition(3, 4), result[1]);
//             Assert.AreEqual(new GridPosition(4, 3), result[2]);
//             Assert.AreEqual(new GridPosition(4, 4), result[3]);

//             result = highlighter.CalculateAdjacentPositions(cellA, direction, isFlipped);
//             foreach (GridPosition item in result)
//             {
//                 Debug.Log($"[x:{item.x}, y:{item.y}]");
//             }
//         }

//     }
// }
