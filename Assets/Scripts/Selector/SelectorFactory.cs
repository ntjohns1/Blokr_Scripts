using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blokr
{
    public static class SelectorFactory
    {
        public static GameObject CreateSelector(PieceType pieceType)
        {
            List<GameObject> selectors  = GameManager.Instance.HighlightPrefabs;
            return pieceType switch
            {
                PieceType.A1 => selectors[0],
                PieceType.A2 => selectors[1],
                PieceType.A3 => selectors[2],
                PieceType.A4 => selectors[3],
                PieceType.A5 => selectors[4],
                PieceType.B3 => selectors[5],
                PieceType.B4 => selectors[6],
                PieceType.B5 => selectors[7],
                PieceType.C4 => selectors[8],
                PieceType.C5 => selectors[9],
                PieceType.D4 => selectors[10],
                PieceType.D5 => selectors[11],
                PieceType.E4 => selectors[12],
                PieceType.E5 => selectors[13],
                PieceType.F5 => selectors[14],
                PieceType.G5 => selectors[15],
                PieceType.H5 => selectors[16],
                PieceType.I5 => selectors[17],
                PieceType.J5 => selectors[18],
                PieceType.K5 => selectors[19],
                PieceType.L5 => selectors[20],
                _ => selectors[0],
                // _ => throw new ArgumentException("Invalid selector type", nameof(selectorType)),
            };
        }
    }

}
