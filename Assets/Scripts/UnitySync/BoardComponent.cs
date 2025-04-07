using UnityEngine;
using System.Collections.Generic;
using Blokr.Core.Services;
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
                        SetTileOccupied(new Vector2Int(x, y));
                    }
                }
            }

            // Highlight initial cells
            foreach (var cell in _boardService.InitialCells)
            {
                HighlightCell(cell);
            }
        }

        private void HandlePiecePlaced(List<Vector2Int> positions)
        {
            foreach (var pos in positions)
            {
                SetTileOccupied(pos);
            }
        }

        public void SetTileOccupied(Vector2Int position)
        {
            boardTilemap.SetTile(new Vector3Int(position.x, position.y, 0), occupiedTile);
        }

        public void HighlightCell(Vector2Int position)
        {
            boardTilemap.SetTile(new Vector3Int(position.x, position.y, 0), highlightTile);
        }

        public void ClearHighlight(Vector2Int position)
        {
            if (!_boardService.OccupiedSpaces[position.x, position.y])
            {
                boardTilemap.SetTile(new Vector3Int(position.x, position.y, 0), null);
            }
        }

        public void HighlightValidMoves(List<Vector2Int> positions)
        {
            foreach (var pos in positions)
            {
                if (_boardService.IsValidMove(new List<Vector2Int> { pos }, 
                    GameStateComponent.Instance.GetComponent<GameStateComponent>()._gameStateService.CurrentPlayer.Color))
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
