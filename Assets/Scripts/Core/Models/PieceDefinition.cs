using System.Collections.Generic;

namespace Blokr.Core.Models
{
    /// <summary>
    /// Represents a single cell position in a piece's shape, along with its rotation relative to the piece's base direction
    /// </summary>
    public readonly struct CellDefinition
    {
        /// <summary>
        /// The position offset from the piece's origin
        /// </summary>
        public readonly GridPosition Offset { get; }

        /// <summary>
        /// The number of 90-degree clockwise rotations relative to the piece's base direction
        /// </summary>
        public readonly int RelativeRotation { get; }

        public CellDefinition(GridPosition offset, int relativeRotation)
        {
            Offset = offset;
            RelativeRotation = relativeRotation;
        }
    }

    /// <summary>
    /// Defines the complete shape and behavior of a game piece
    /// </summary>
    public class PieceDefinition
    {
        /// <summary>
        /// The type of the piece
        /// </summary>
        public PieceType Type { get; }

        /// <summary>
        /// The number of cells in the piece
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// Ordered list of cell definitions that make up the piece's shape
        /// The first cell is always at (0,0) and is not included in this list
        /// </summary>
        public IReadOnlyList<CellDefinition> Cells { get; }

        /// <summary>
        /// Indices into the adjacent positions list that represent valid placement points
        /// These are the corners where the piece can be placed on the board
        /// </summary>
        public IReadOnlyList<int> PlayablePositionIndices { get; }

        public PieceDefinition(
            PieceType type,
            int size,
            IReadOnlyList<CellDefinition> cells,
            IReadOnlyList<int> playablePositionIndices)
        {
            Type = type;
            Size = size;
            Cells = cells;
            PlayablePositionIndices = playablePositionIndices;
        }

        /// <summary>
        /// Creates a straight line piece of specified length
        /// </summary>
        public static PieceDefinition CreateStraightPiece(PieceType type, int length)
        {
            var cells = new List<CellDefinition>();
            var playableIndices = new List<int>();

            // Add cells in a straight line going up
            for (int i = 1; i < length; i++)
            {
                cells.Add(new CellDefinition(new GridPosition(0, i), 0));
            }

            // Playable positions are at the ends of the line
            playableIndices.Add(0); // Bottom
            playableIndices.Add(length); // Top

            return new PieceDefinition(type, length, cells, playableIndices);
        }

        /// <summary>
        /// Creates an L-shaped piece with specified vertical and horizontal lengths
        /// </summary>
        public static PieceDefinition CreateLPiece(PieceType type, int verticalLength, int horizontalLength)
        {
            var cells = new List<CellDefinition>();
            var playableIndices = new List<int>();

            // Add vertical cells
            for (int i = 1; i < verticalLength; i++)
            {
                cells.Add(new CellDefinition(new GridPosition(0, i), 0));
            }

            // Add horizontal cells with 90-degree rotation
            for (int i = 1; i < horizontalLength; i++)
            {
                cells.Add(new CellDefinition(new GridPosition(i, verticalLength - 1), 1));
            }

            // Playable positions are at the three corners
            playableIndices.Add(0); // Bottom of vertical
            playableIndices.Add(verticalLength); // Top corner
            playableIndices.Add(verticalLength + horizontalLength - 1); // End of horizontal

            return new PieceDefinition(type, verticalLength + horizontalLength - 1, cells, playableIndices);
        }

        /// <summary>
        /// Creates a T-shaped piece (like D4)
        /// </summary>
        public static PieceDefinition CreateTPiece(PieceType type, int verticalLength, int horizontalLength)
        {
            var cells = new List<CellDefinition>();
            var playableIndices = new List<int>();

            // Add vertical stem
            for (int i = 1; i < verticalLength; i++)
            {
                cells.Add(new CellDefinition(new GridPosition(0, i), 0));
            }

            // Add horizontal crossbar
            int crossbarY = verticalLength - 1;
            cells.Add(new CellDefinition(new GridPosition(-1, crossbarY), 1));
            cells.Add(new CellDefinition(new GridPosition(1, crossbarY), 1));

            // Playable positions are at the four corners
            playableIndices.Add(0);  // Bottom of stem
            playableIndices.Add(verticalLength);  // Left end
            playableIndices.Add(verticalLength + 1);  // Top of stem
            playableIndices.Add(verticalLength + 2);  // Right end

            return new PieceDefinition(type, verticalLength + 2, cells, playableIndices);
        }
    }
}
