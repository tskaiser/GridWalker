using GridWalker.Geometry;

namespace GridWalker.Input
{
    /// <summary>
    /// The header for the simulation.
    /// </summary>
    /// <param name="TableWidth">The width of the table.</param>
    /// <param name="TableHeight">The height of the table.</param>
    /// <param name="StartingPosition">The starting position of the walker.</param>
    public readonly record struct Header(int TableWidth, int TableHeight, Point StartingPosition);
}