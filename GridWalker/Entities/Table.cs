using GridWalker.Geometry;

namespace GridWalker.Entities
{
    public class Table : IEntity
    {
        public Point Position { get; init; }
        public IShape Shape { get; init; }

        /// <summary>
        /// Creates a new table.
        /// </summary>
        /// <param name="height">The height of the table, must be greater than zero.</param>
        /// <param name="width">The width of the table, must be greater than zero.</param>
        /// <param name="position">Optional placement of the table on the grid, the default is at origo (0,0).</param>
        public Table(int height, int width, Point? position = null)
        {
            Position = position ?? new Point(0, 0);
            Shape = new Rectangle(height, width);
        }

        /// <summary>
        /// Checks if the provided entity is on the table.
        /// </summary>
        /// <param name="entity">The entity to check if it is on the table.</param>
        /// <returns>True if the entity is on the table, false otherwise.</returns>
        public bool IsOnTable(IEntity entity) => entity.Shape
            /* I assume that to be on a table all parts of the entity must be within the extants of that table
            * 
            * This could technically be trivialized with the given specification,
            * since a walker is representable as just its position and the table has a trivial shape,
            * but I wanted the idea to be extensible to both non-standard shapes for walkers and tables.
            */
            .GetPointsGlobal(entity.Position)
            .All(point => Shape.ContainsPointGlobal(Position, point));
    }
}
