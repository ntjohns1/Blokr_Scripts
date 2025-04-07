namespace Blokr.Core.Models
{
    /// <summary>
    /// Represents the different types of pieces in the Blokr game.
    /// The naming convention follows a letter (shape family) and a number (size).
    /// </summary>
    public enum PieceType
    {
        // A Series - Basic straight pieces (1-5 cells)
        A1, // Single cell
        A2, // Two cells in a line
        A3, // Three cells in a line
        A4, // Four cells in a line
        A5, // Five cells in a line

        // B Series - L-shaped pieces (3-5 cells)
        B3, // Three cells in an L shape
        B4, // Four cells in an L shape
        B5, // Five cells in an L shape

        // C Series - Zigzag pieces (4-5 cells)
        C4, // Four cells in a zigzag
        C5, // Five cells in a zigzag

        // D Series - T-shaped pieces (4-5 cells)
        D4, // Four cells in a T shape
        D5, // Five cells in a T shape

        // E Series - Cross-like pieces (4-5 cells)
        E4, // Four cells in a cross-like shape
        E5, // Five cells in a cross-like shape

        // F-L Series - Complex 5-cell pieces
        F5, // Five cells in F configuration
        G5, // Five cells in G configuration
        H5, // Five cells in H configuration
        I5, // Five cells in I configuration
        J5, // Five cells in J configuration
        K5, // Five cells in K configuration
        L5  // Five cells in L configuration
    }

    /// <summary>
    /// Extension methods for PieceType enum
    /// </summary>
    public static class PieceTypeExtensions
    {
        /// <summary>
        /// Gets the size (number of cells) of a piece type
        /// </summary>
        public static int GetSize(this PieceType pieceType)
        {
            return pieceType.ToString()[1] - '0';
        }

        /// <summary>
        /// Gets the shape family (A-L) of a piece type
        /// </summary>
        public static char GetFamily(this PieceType pieceType)
        {
            return pieceType.ToString()[0];
        }
    }
}
