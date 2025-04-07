namespace Blokr.Core.Models
{
    /// <summary>
    /// Represents the four cardinal directions on the game board.
    /// Used for piece orientation and movement calculations.
    /// </summary>
    public enum Direction 
    { 
        Up = 0,     // Represents movement in +Y direction
        Right = 1,  // Represents movement in +X direction
        Down = 2,   // Represents movement in -Y direction
        Left = 3    // Represents movement in -X direction
    }

    /// <summary>
    /// Extension methods for Direction enum to help with common operations
    /// </summary>
    public static class DirectionExtensions
    {
        /// <summary>
        /// Rotates a direction by the specified number of 90-degree turns clockwise
        /// </summary>
        /// <param name="direction">The base direction</param>
        /// <param name="rotations">Number of 90-degree clockwise rotations</param>
        /// <returns>The resulting direction after rotation</returns>
        public static Direction Rotate(this Direction direction, int rotations)
        {
            return (Direction)(((int)direction + rotations) % 4);
        }

        /// <summary>
        /// Gets the opposite direction (180-degree rotation)
        /// </summary>
        /// <param name="direction">The base direction</param>
        /// <returns>The opposite direction</returns>
        public static Direction Opposite(this Direction direction)
        {
            return (Direction)(((int)direction + 2) % 4);
        }
    }
}
