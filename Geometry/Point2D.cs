namespace Basics.Geometry
{
    public class Point2D
    {
        #region Variables & Fields
        public double X { get; set; }

        public double Y { get; set; }
        #endregion Variables & Fields


        #region Constructors
        public Point2D()
        {
            X = 0;
            Y = 0;
        }

        public Point2D(double value)
        {
            X = value;
            Y = value;
        }

        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point2D(Point2D other)
        {
            X = other.X;
            Y = other.Y;
        }

        public Point2D(Vector2D vector)
        {
            X = vector.X;
            Y = vector.Y;
        }
        #endregion Constructors


        #region Operators
        public static Point2D operator +(Point2D point, double value)
        {
            return new Point2D(point.X + value, point.Y + value);
        }

        public static Point2D operator +(Point2D point, Vector2D translate)
        {
            return new Point2D(point.X + translate.X, point.Y + translate.Y);
        }

        public static Point2D operator -(Point2D point, double value)
        {
            return new Point2D(point.X - value, point.Y - value);
        }

        public static Point2D operator -(Point2D point, Vector2D translate)
        {
            return new Point2D(point.X - translate.X, point.Y - translate.Y);
        }

        public static explicit operator Point2D(Vector2D vector)
        {
            return new Point2D(vector);
        }
        #endregion Operators


        #region Overrides
        public override string ToString()
        {
            return $"X: {X:F2} Y: {Y:F2}";
        }
        #endregion Overrides
    }
}