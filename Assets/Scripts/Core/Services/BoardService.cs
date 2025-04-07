using System;
using System.Collections.Generic;
using System.Linq;
using Blokr.Core.Models;

namespace Blokr.Core.Services
{
    public class BoardService : IBoardService
    {
        private readonly bool[,] _occupiedSpaces;
        private readonly List<GridPosition> _initialCells;
        private readonly IGameStateService _gameStateService;

        public bool[,] OccupiedSpaces => _occupiedSpaces;
        public List<GridPosition> InitialCells => _initialCells;

        public event Action<List<GridPosition>> OnPiecePlaced;

        public BoardService(IGameStateService gameStateService)
        {
            _gameStateService = gameStateService;
            _occupiedSpaces = new bool[20, 20];
            _initialCells = new List<GridPosition>
            {
                new GridPosition(19, 0),  // Red
                new GridPosition(0, 0),   // Green
                new GridPosition(0, 19),  // Blue
                new GridPosition(19, 19)  // Yellow
            };
        }

        public bool IsValidMove(List<GridPosition> positions, PieceColor color)
        {
            if (_gameStateService.CurrentState.IsFirstTurn)
            {
                return IsValidForFirstTurn(positions, color);
            }

            return positions.All(pos => IsValidPosition(pos)) &&
                   CheckPlayableAndAdjacency(positions, color);
        }

        private bool IsValidPosition(GridPosition pos)
        {
            return pos.X >= 0 && pos.X < 20 && 
                   pos.Y >= 0 && pos.Y < 20 && 
                   !_occupiedSpaces[pos.X, pos.Y];
        }

        public bool IsValidForFirstTurn(List<GridPosition> positions, PieceColor color)
        {
            var initialCell = _initialCells[(int)color];
            return positions.Contains(initialCell);
        }

        public bool CheckPlayableAndAdjacency(List<GridPosition> positions, PieceColor color)
        {
            var player = _gameStateService.GetPlayer(color);
            if (player == null) return false;

            bool hasPlayableCell = false;
            bool allNonAdjacentOrNotPlayable = true;

            foreach (var pos in positions)
            {
                if (player.PlayablePositions[pos.X, pos.Y])
                {
                    hasPlayableCell = true;
                }

                if (player.AdjacentPositions[pos.X, pos.Y] && !player.PlayablePositions[pos.X, pos.Y])
                {
                    allNonAdjacentOrNotPlayable = false;
                    break;
                }
            }

            return hasPlayableCell && allNonAdjacentOrNotPlayable;
        }

        public void PlacePiece(List<GridPosition> positions)
        {
            foreach (var pos in positions)
            {
                _occupiedSpaces[pos.X, pos.Y] = true;
            }
            
            OnPiecePlaced?.Invoke(positions);
        }

        public void Reset()
        {
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    _occupiedSpaces[x, y] = false;
                }
            }
        }
    }
}
