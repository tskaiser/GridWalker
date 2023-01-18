using GridWalker.Geometry;

namespace GridWalker.Entities
{
    public class Walker : IEntity
    {
        /// <summary>
        /// The current heading of the walker.
        /// </summary>
        public Compass Heading { get; private set; }
        public Point Position { get; private set; }
        public IShape Shape { get; init; }

        /// <summary>
        /// Creates a new walker entity.
        /// </summary>
        /// <param name="startingPosition">The initial placement of the walker on the grid.</param>
        /// <param name="initialHeading">Optional initial heading of the walker, default is North.</param>
        /// <param name="shape">Optional shape of the walker, default is a 1x1 square.</param>
        public Walker(Point startingPosition, Compass initialHeading = Compass.North, IShape? shape = null)
        {
            Heading = initialHeading;

            Position = startingPosition;
            Shape = shape ?? new Rectangle(1, 1);
        }

        /// <summary>
        /// Move the walker one cell in the direction of its current heading.
        /// </summary>
        public void MoveForward() => Position += Heading.UnitDirection();

        /// <summary>
        /// Move the walker on cell in the opposite direction of its current heading ie. backwards.
        /// </summary>
        public void MoveBackward() => Position -= Heading.UnitDirection();

        /// <summary>
        /// Turn the walker right changing its heading to the next clockwise direction eg. North to East.
        /// </summary>
        public void TurnRight() => Heading = Heading.Clockwise();

        /// <summary>
        /// Turn the walker left changing its heading to the next counterclockwise direction eg. North to West.
        /// </summary>
        public void TurnLeft() => Heading = Heading.Counterclockwise();
    }
}
