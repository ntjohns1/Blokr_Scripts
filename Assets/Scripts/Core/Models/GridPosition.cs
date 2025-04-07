namespace Blokr.Core.Models
{
    /// <summary>
    /// Represents a position on a 2D grid using integer coordinates
    /// </summary>
    public readonly struct GridPosition
    {
        /// <summary>
        /// The X coordinate
        /// </summary>
        public readonly int X { get; }

        /// <summary>
        /// The Y coordinate
        /// </summary>
        public readonly int Y { get; }

        public GridPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static GridPosition operator +(GridPosition a, GridPosition b)
            => new(a.X + b.X, a.Y + b.Y);

        public static GridPosition operator -(GridPosition a, GridPosition b)
            => new(a.X - b.X, a.Y - b.Y);

        public override bool Equals(object obj)
            => obj is GridPosition other && X == other.X && Y == other.Y;

        public override int GetHashCode()
            => X.GetHashCode() ^ (Y.GetHashCode() << 2);

        public override string ToString()
            => $"({X}, {Y})";
    }
}
