using System;
using System.Collections.Generic;
using Blokr.Core.Models;

namespace Blokr.Core.Services
{
    public interface IBoardService
    {
        bool[,] OccupiedSpaces { get; }
        List<GridPosition> InitialCells { get; }
        
        event Action<List<GridPosition>> OnPiecePlaced;
        
        bool IsValidMove(List<GridPosition> positions, PieceColor color);
        bool IsValidForFirstTurn(List<GridPosition> positions, PieceColor color);
        bool CheckPlayableAndAdjacency(List<GridPosition> positions, PieceColor color);
        void PlacePiece(List<GridPosition> positions);
        void Reset();
    }
}
