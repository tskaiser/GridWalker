using GridWalker.Geometry;

namespace GridWalker.Entities
{
    public interface IEntity
    {
        /// <summary>
        /// The position of the entity.
        /// </summary>
        public Point Position { get; }

        /// <summary>
        /// The shape of the entity.
        /// </summary>
        public IShape Shape { get; }
    }
}
