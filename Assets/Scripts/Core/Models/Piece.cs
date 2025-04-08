namespace Blokr.Core.Models
{
    public class Piece
    {
        public PieceType PieceType { get; set; }
        public PieceColor PieceColor { get; set; }
        public Direction PieceDirection { get; set; }
        public bool IsFlipped { get; set; }

        public Piece()
        {
            PieceDirection = Direction.Up;
            IsFlipped = false;
        }
    }
}
