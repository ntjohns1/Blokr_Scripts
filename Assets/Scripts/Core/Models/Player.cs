using System.Collections.Generic;

namespace Blokr.Core.Models
{
    public class Player
    {
        public string Name { get; set; }
        public PieceColor Color { get; set; }
        public Dictionary<PieceType, bool> AvailablePieces { get; private set; }
        public bool[,] AdjacentPositions { get; private set; }
        public bool[,] PlayablePositions { get; private set; }

        public Player(string name, PieceColor color)
        {
            Name = name;
            Color = color;
            AvailablePieces = new Dictionary<PieceType, bool>();
            AdjacentPositions = new bool[20, 20];
            PlayablePositions = new bool[20, 20];
            InitializePieces();
        }

        private void InitializePieces()
        {
            foreach (PieceType type in System.Enum.GetValues(typeof(PieceType)))
            {
                AvailablePieces[type] = true;
            }
        }

        public void UpdatePlayableArea(bool[,] adjacent, bool[,] playable)
        {
            AdjacentPositions = adjacent;
            PlayablePositions = playable;
        }

        public void UsePiece(PieceType type)
        {
            if (AvailablePieces.ContainsKey(type))
            {
                AvailablePieces[type] = false;
            }
        }

        public bool IsPieceAvailable(PieceType type)
        {
            return AvailablePieces.ContainsKey(type) && AvailablePieces[type];
        }
    }
}
