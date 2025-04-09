using UnityEngine;
using System.Collections.Generic;
using Blokr.Core.Models;
using Blokr.Core.Services;

namespace Blokr.UnitySync
{
    public class GameStateComponent : MonoBehaviour
    {
        private static GameStateComponent instance;
        public static GameStateComponent Instance => instance;

        [SerializeField] private GameObject moveConfirmUI;
        [SerializeField] private GameObject[] playerPrefabs;

        private IGameStateService _gameStateService;
        private IBoardService _boardService;
        private IPieceTransformService _pieceTransformService;
        private IPieceCalculationService _pieceCalculationService;
        private Dictionary<PieceColor, GameObject> _playerObjects;

        // Public accessors for services
        public IBoardService BoardService => _boardService;
        public IGameStateService GameStateService => _gameStateService;
        public IPieceTransformService PieceTransformService => _pieceTransformService;
        public IPieceCalculationService PieceCalculationService => _pieceCalculationService;

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;

            InitializeServices();
            DontDestroyOnLoad(gameObject);
        }

        private void InitializeServices()
        {
            _gameStateService = new GameStateService();
            _boardService = new BoardService(_gameStateService);
            _pieceTransformService = new PieceTransformService();
            _pieceCalculationService = new PieceCalculationService();
            _playerObjects = new Dictionary<PieceColor, GameObject>();

            // Subscribe to events
            _gameStateService.OnTurnStarted += HandleTurnStarted;
            _gameStateService.OnTurnCompleted += HandleTurnCompleted;
            _gameStateService.OnPlayerChanged += HandlePlayerChanged;
            _gameStateService.OnGameOver += HandleGameOver;
        }

        private void Start()
        {
            InitializePlayers();
            _gameStateService.StartGame();
        }

        private void InitializePlayers()
        {
            for (int i = 0; i < playerPrefabs.Length; i++)
            {
                var color = (PieceColor)i;
                var playerObj = Instantiate(playerPrefabs[i]);
                _playerObjects[color] = playerObj;
                
                // Set up the Unity player component with the core player data
                var unityPlayer = playerObj.GetComponent<PlayerComponent>();
                if (unityPlayer != null)
                {
                    unityPlayer.Initialize(_gameStateService.GetPlayer(color));
                }
            }
        }

        private void HandleTurnStarted(Turn turn)
        {
            // Update UI and player state for new turn
            moveConfirmUI.SetActive(false);
            var currentPlayerObj = _playerObjects[turn.CurrentPlayer.Color];
            currentPlayerObj.GetComponent<PlayerComponent>()?.OnTurnStarted();
        }

        private void HandleTurnCompleted(Turn turn)
        {
            var playerObj = _playerObjects[turn.CurrentPlayer.Color];
            playerObj.GetComponent<PlayerComponent>()?.OnTurnCompleted();
        }

        private void HandlePlayerChanged(Player newPlayer)
        {
            foreach (var playerObj in _playerObjects.Values)
            {
                playerObj.GetComponent<PlayerComponent>()?.UpdateActiveState(
                    playerObj == _playerObjects[newPlayer.Color]);
            }
        }

        private void HandleGameOver(bool isOver)
        {
            // Handle game over state (show UI, disable input, etc.)
            Debug.Log("Game Over!");
        }

        // Public methods for Unity components to interact with the services
        public void SelectPiece(PieceType pieceType)
        {
            _gameStateService.SelectPiece(pieceType);
        }

        public void PlacePiece(List<Vector2Int> positions)
        {
            if (_boardService.IsValidMove(positions.ToGridPosition(), _gameStateService.CurrentPlayer.Color))
            {
                _gameStateService.PlacePiece(positions.ToGridPosition());
                _boardService.PlacePiece(positions.ToGridPosition());
                moveConfirmUI.SetActive(true);
            }
        }

        public void ConfirmMove()
        {
            _gameStateService.ConfirmMove();
        }

        public void CancelMove()
        {
            _gameStateService.CancelMove();
            moveConfirmUI.SetActive(false);
        }

        private void OnDestroy()
        {
            if (_gameStateService != null)
            {
                _gameStateService.OnTurnStarted -= HandleTurnStarted;
                _gameStateService.OnTurnCompleted -= HandleTurnCompleted;
                _gameStateService.OnPlayerChanged -= HandlePlayerChanged;
                _gameStateService.OnGameOver -= HandleGameOver;
            }
        }
    }
}
