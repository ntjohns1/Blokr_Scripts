using System;
using System.Collections.Generic;

namespace Blokr.Core.Services
{
    public interface IBoardService
    {
        bool[,] OccupiedSpaces { get; }
        List<Vector2Int> InitialCells { get; }
        
        event Action<List<Vector2Int>> OnPiecePlaced;
        
        bool IsValidMove(List<Vector2Int> positions, PieceColor color);
        bool IsValidForFirstTurn(List<Vector2Int> positions, PieceColor color);
        bool CheckPlayableAndAdjacency(List<Vector2Int> positions, PieceColor color);
        void PlacePiece(List<Vector2Int> positions);
        void Reset();
    }
}
