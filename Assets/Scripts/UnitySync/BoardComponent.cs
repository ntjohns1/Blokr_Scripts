using UnityEngine;
using System.Collections.Generic;
using Blokr.Core.Services;
using Blokr.Core.Models;
using UnityEngine.Tilemaps;

namespace Blokr.UnitySync
{
    public class BoardComponent : MonoBehaviour
    {
        [SerializeField] private Tilemap boardTilemap;
        [SerializeField] private Tile occupiedTile;
        [SerializeField] private Tile highlightTile;
        
        private IBoardService _boardService;

        private void Start()
        {
            // Get reference to the board service from GameStateComponent
            _boardService = GameStateComponent.Instance.BoardService;
            
            if (_boardService != null)
            {
                _boardService.OnPiecePlaced += HandlePiecePlaced;
                InitializeBoard();
            }
        }

        private void InitializeBoard()
        {
            // Clear the board
            boardTilemap.ClearAllTiles();
            
            // Set up initial visual state
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    if (_boardService.OccupiedSpaces[x, y])
                    {
                        SetTileOccupied(new GridPosition(x, y));
                    }
                }
            }

            // Highlight initial cells
            foreach (var cell in _boardService.InitialCells)
            {
                HighlightCell(cell);
            }
        }

        private void HandlePiecePlaced(List<GridPosition> positions)
        {
            foreach (var pos in positions)
            {
                SetTileOccupied(pos);
            }
        }

        public void SetTileOccupied(GridPosition position)
        {
            boardTilemap.SetTile(position.ToVector3Int(), occupiedTile);
        }

        public void HighlightCell(GridPosition position)
        {
            boardTilemap.SetTile(position.ToVector3Int(), highlightTile);
        }

        public void ClearHighlight(GridPosition position)
        {
            if (!_boardService.OccupiedSpaces[position.X, position.Y])
            {
                boardTilemap.SetTile(position.ToVector3Int(), null);
            }
        }

        public void HighlightValidMoves(List<GridPosition> positions)
        {
            foreach (var pos in positions)
            {
                if (_boardService.IsValidMove(new List<GridPosition> { pos }, 
                    GameStateComponent.Instance.GameStateService.CurrentPlayer.Color))
                {
                    HighlightCell(pos);
                }
            }
        }

        private void OnDestroy()
        {
            if (_boardService != null)
            {
                _boardService.OnPiecePlaced -= HandlePiecePlaced;
            }
        }
    }
}
