namespace GridWalker.Geometry
{
    /// <summary>
    /// A shape is defined on its own grid along with its own origo.
    /// 
    /// Alone a shape does not have a position, but exists purely as a representation.
    /// A global position is needed as an offset to translate the shape into a given position on the grid.
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// Get all the points of the edge and the inside of the shape in local coordinates.
        /// </summary>
        /// <returns>An array of the points contained inside and on the edge of the shape.</returns>
        public Point[] GetPointsLocal();

        /// <summary>
        /// Get all the points of the edge and the inside of the shape in global coordinates.
        /// </summary>
        /// <param name="offset">The offset of the shape in global coordinates.</param>
        /// <returns>An array of the points contained inside and on the edge of the shape.</returns>
        public Point[] GetPointsGlobal(Point offset);

        /// <summary>
        /// Checks whether a given point is part of the edge or the inside of the shape in local coordinates.
        /// </summary>
        /// <param name="point">The point in local coordinates.</param>
        /// <returns>True if the point is part of the edge or the inside of the shape, false otherwise.</returns>
        public bool ContainsPointLocal(Point point);

        /// <summary>
        /// Checks whether a given point is part of the edge or the inside of the shape in local coordinates.
        /// </summary>
        /// <param name="offset">The offset of the shape in global coordinates.</param>
        /// <param name="point">The point in global coordinates.</param>
        /// <returns>True if the point is part of the edge or the inside of the shape, false otherwise.</returns>
        public bool ContainsPointGlobal(Point offset, Point point);
    }
}
