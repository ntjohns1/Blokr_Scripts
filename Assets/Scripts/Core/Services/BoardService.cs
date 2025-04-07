using System;
using System.Collections.Generic;
using System.Linq;

namespace Blokr.Core.Services
{
    public class BoardService : IBoardService
    {
        private readonly bool[,] _occupiedSpaces;
        private readonly List<Vector2Int> _initialCells;
        private readonly IGameStateService _gameStateService;

        public bool[,] OccupiedSpaces => _occupiedSpaces;
        public List<Vector2Int> InitialCells => _initialCells;

        public event Action<List<Vector2Int>> OnPiecePlaced;

        public BoardService(IGameStateService gameStateService)
        {
            _gameStateService = gameStateService;
            _occupiedSpaces = new bool[20, 20];
            _initialCells = new List<Vector2Int>
            {
                new(19, 0),  // Red
                new(0, 0),   // Green
                new(0, 19),  // Blue
                new(19, 19)  // Yellow
            };
        }

        public bool IsValidMove(List<Vector2Int> positions, PieceColor color)
        {
            if (_gameStateService.CurrentState.IsFirstTurn)
            {
                return IsValidForFirstTurn(positions, color);
            }

            return positions.All(pos => IsValidPosition(pos)) &&
                   CheckPlayableAndAdjacency(positions, color);
        }

        private bool IsValidPosition(Vector2Int pos)
        {
            return pos.x >= 0 && pos.x < 20 && 
                   pos.y >= 0 && pos.y < 20 && 
                   !_occupiedSpaces[pos.x, pos.y];
        }

        public bool IsValidForFirstTurn(List<Vector2Int> positions, PieceColor color)
        {
            var initialCell = _initialCells[(int)color];
            return positions.Contains(initialCell);
        }

        public bool CheckPlayableAndAdjacency(List<Vector2Int> positions, PieceColor color)
        {
            var player = _gameStateService.GetPlayer(color);
            if (player == null) return false;

            bool hasPlayableCell = false;
            bool allNonAdjacentOrNotPlayable = true;

            foreach (var pos in positions)
            {
                if (player.PlayablePositions[pos.x, pos.y])
                {
                    hasPlayableCell = true;
                }

                if (player.AdjacentPositions[pos.x, pos.y] && !player.PlayablePositions[pos.x, pos.y])
                {
                    allNonAdjacentOrNotPlayable = false;
                    break;
                }
            }

            return hasPlayableCell && allNonAdjacentOrNotPlayable;
        }

        public void PlacePiece(List<Vector2Int> positions)
        {
            foreach (var pos in positions)
            {
                _occupiedSpaces[pos.x, pos.y] = true;
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
