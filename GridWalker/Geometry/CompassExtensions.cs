namespace GridWalker.Geometry
{
    public static class CompassExtensions
    {
        /// <summary>
        /// Return a unit vector corrosponding to the compass value.
        /// </summary>
        /// <param name="compass">The compass value.</param>
        /// <returns>Unit vector pointing the direction of the compass.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the given compass value is unknown.</exception>
        public static Point UnitDirection(this Compass compass) => compass switch
        {
            Compass.North => new(0, -1),
            Compass.South => new(0, 1),
            Compass.West => new(-1, 0),
            Compass.East => new(1, 0),
            _ => throw new ArgumentOutOfRangeException(nameof(compass)),
        };

        /// <summary>
        /// Return the next clockwise direction of the given compass value, eg. North to East.
        /// </summary>
        /// <param name="compass">The compass value.</param>
        /// <returns>The next clockwise compass value</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the given compass value is unknown.</exception>
        public static Compass Clockwise(this Compass compass) => compass switch
        {
            Compass.North => Compass.East,
            Compass.South => Compass.West,
            Compass.West => Compass.North,
            Compass.East => Compass.South,
            _ => throw new ArgumentOutOfRangeException(nameof(compass)),
        };

        /// <summary>
        /// Return the next counterclockwise direction of the given compass value, eg. North to West.
        /// </summary>
        /// <param name="compass">The compass value.</param>
        /// <returns>The next counterclockwise compass value</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the given compass value is unknown.</exception>
        public static Compass Counterclockwise(this Compass compass) => compass switch
        {
            Compass.North => Compass.West,
            Compass.South => Compass.East,
            Compass.West => Compass.South,
            Compass.East => Compass.North,
            _ => throw new ArgumentOutOfRangeException(nameof(compass)),
        };
    }
}
