using System;

namespace Basics.Geometry
{
    public class Point2D : ICloneable
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


        #region Functions
        public void Translate(Vector2D translationVector)
        {
            if (translationVector == null)
                return;

            X += translationVector.X;
            Y += translationVector.Y;
        }

        public double Distance(Point2D other) => new Vector2D(this - new Vector2D(other)).Length;

        public void Rotate(double angle, Point2D origin = null)
        {
            if (origin == null)
                origin = new Point2D();

            var vectorToPoint = new Vector2D(this - new Vector2D(origin));
            vectorToPoint.Rotate(angle);

            X = origin.X + vectorToPoint.X;
            Y = origin.Y + vectorToPoint.Y;
        }

        public void Reflect(Vector2D reflector)
        {
            if (reflector == null)
                return;

            var vector = (Vector2D)this;
            vector.Reflect(reflector);
            X = vector.X;
            Y = vector.Y;
        }

        public void Reflect(Ray2D ray)
        {
            if (ray == null)
                return;

            var reflectedPoint = (Point2D)Clone();
            reflectedPoint.Translate((Vector2D)ray.Origin * -1);
            reflectedPoint.Reflect(ray.Direction);
            reflectedPoint.Translate((Vector2D)ray.Origin);

            X = reflectedPoint.X;
            Y = reflectedPoint.Y;
        }
        #endregion Functions


        #region Operators
        public static Point2D operator +(Point2D point, double value) => new Point2D(point.X + value, point.Y + value);

        public static Point2D operator +(Point2D point, Vector2D translate) => new Point2D(point.X + translate.X, point.Y + translate.Y);

        public static Point2D operator -(Point2D point, double value) => new Point2D(point.X - value, point.Y - value);

        public static Point2D operator -(Point2D point, Vector2D translate) => new Point2D(point.X - translate.X, point.Y - translate.Y);

        public static explicit operator Point2D(Vector2D vector) => new Point2D(vector);
        #endregion Operators


        #region Overrides
        public override string ToString() => $"X: {X:F2} Y: {Y:F2}";
        #endregion Overrides


        #region ICloneable
        public object Clone() => new Point2D(this);
        #endregion ICloneable


        #region Static
        public static double Distance(Point2D first, Point2D second) => first.Distance(second);

        public static Point2D Rotate(Point2D point, double angle, Point2D origin = null)
        {
            var rotatedPoint = (Point2D)point.Clone();
            rotatedPoint.Rotate(angle, origin);
            return rotatedPoint;
        }

        public static Point2D Reflect(Point2D point, Vector2D reflector)
        {
            if (point == null || reflector == null)
                return null;

            var reflectionPoint = (Point2D)point.Clone();
            reflectionPoint.Reflect(reflector);
            return reflectionPoint;
        }

        public static Point2D Reflect(Point2D point, Ray2D ray)
        {
            if (point == null || ray == null)
                return null;

            var reflectionPoint = (Point2D)point.Clone();
            reflectionPoint.Reflect(ray);
            return reflectionPoint;
        }
        #endregion Static
    }
}