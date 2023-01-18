namespace GridWalker.Geometry
{
    public readonly record struct Point(int X, int Y)
    {
        public static Point operator +(Point a, Point b) => new()
        {
            X = a.X + b.X,
            Y = a.Y + b.Y
        };

        public static Point operator -(Point a, Point b) => new()
        {
            X = a.X - b.X,
            Y = a.Y - b.Y
        };
    };
}
