using Blokr.Core.Models;

namespace Blokr.Core.Services
{
    public interface IPieceTransformService
    {
        void RotateClockwise(Piece piece);
        void RotateCounterClockwise(Piece piece);
        void Flip(Piece piece);
    }

    public class PieceTransformService : IPieceTransformService
    {
        public void RotateClockwise(Piece piece)
        {
            int dirIndex = (int)piece.PieceDirection;
            dirIndex = dirIndex < 3 ? dirIndex + 1 : 0;
            piece.PieceDirection = (Direction)dirIndex;
        }

        public void RotateCounterClockwise(Piece piece)
        {
            int dirIndex = (int)piece.PieceDirection;
            dirIndex = dirIndex > 0 ? dirIndex - 1 : 3;
            piece.PieceDirection = (Direction)dirIndex;
        }

        public void Flip(Piece piece)
        {
            piece.IsFlipped = !piece.IsFlipped;
        }
    }
}
