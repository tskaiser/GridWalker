namespace GridWalker.Geometry
{
    /// <summary>
    /// A rectangle shape.
    /// </summary>
    public class Rectangle : IShape
    {
        /// <summary>
        /// The height of the rectangle.
        /// </summary>
        public int Height { get; init;}

        /// <summary>
        /// The width of the rectangle.
        /// </summary>
        public int Width { get; init;}

        /// <summary>
        /// Creates a new rectangle.
        /// </summary>
        /// <param name="height">The width of the rectangle, which must be greater than zero.</param>
        /// <param name="width">The height of the rectangle, which must be greater than zero.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the height or width is less than one.</exception>
        public Rectangle(int height, int width)
        {
            if (height < 1)
                throw new ArgumentOutOfRangeException(nameof(height),
                    "Rectangles must have non-zero and positive height");

            if (width < 1)
                throw new ArgumentOutOfRangeException(nameof(width),
                    "Rectangles must have non-zero and positive width");

            Height = height;
            Width = width;
        }

        public bool ContainsPointGlobal(Point offset, Point point) =>
            ContainsPointLocal(point + offset);

        public bool ContainsPointLocal(Point point) =>
            0 <= point.X && point.X <= Width &&
            0 <= point.Y && point.Y <= Height;


        public Point[] GetPointsGlobal(Point offset) =>
            GetPointsLocal()
            .Select(point => point + offset)
            .ToArray();
        

        public Point[] GetPointsLocal()
        {
            // this could be memoized :)
            Point[] result = new Point[(Height + 1) * (Width + 1)];

            for (var x = 0; x <= Width; x++)
                for (var y = 0; y <= Height; y++)
                    result[x + y] = new(x, y);

            return result;
        }
    }
}
