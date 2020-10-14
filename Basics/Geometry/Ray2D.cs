using System;
using System.Collections.Generic;
using System.Text;

namespace Basics.Geometry
{
    public class Ray2D : ICloneable
    {
        #region Variables & Fields
        public Point2D Origin { get; set; }
        public Vector2D Direction { get; set; }
        #endregion Variables & Fields


        #region Constructors
        public Ray2D()
        {
            Origin = new Point2D();
            Direction = new Vector2D();
        }

        public Ray2D(Vector2D direction)
        {
            Origin = new Point2D();
            Direction = (Vector2D)direction.Clone();
        }

        public Ray2D(Point2D origin, Vector2D direction)
        {
            Origin = (Point2D)origin.Clone();
            Direction = (Vector2D)direction.Clone();
        }

        public Ray2D(Ray2D other)
        {
            Origin = (Point2D)other.Origin.Clone();
            Direction = (Vector2D)other.Direction.Clone();
        }
        #endregion Constructors


        #region Functions
        public Point2D ClosestPoint(Point2D point)
        {
            if (point == null)
                return null;

            var originToPoint = (Vector2D)point - (Vector2D)Origin;
            var projectedLength = originToPoint.Dot(Direction);
            return Origin + Direction * projectedLength;
        }

        public Point2D Intersection(Ray2D other)
        {
            if (other == null)
                return null;

            if (Direction.Heading == other.Direction.Heading || Direction.Heading == other.Direction.Heading * -1)
                return null;

            var originVector = new Vector2D(Origin - new Vector2D(other.Origin));
            var parameter = (other.Direction.Y * originVector.X - other.Direction.X * originVector.Y) / (other.Direction.X * Direction.Y - other.Direction.Y * Direction.X);
            return Origin + Direction * parameter;
        }
        #endregion Functions


        #region Operators
        public static explicit operator Ray2D(Vector2D vector) => new Ray2D(vector);
        #endregion Operators


        #region Overrides
        public override string ToString() => $"Origin: [{Origin}], Direction: [{Direction}]";
        #endregion Overrides


        #region ICloneable
        public object Clone() => new Ray2D(this);
        #endregion ICloneable


        #region Static
        public static Point2D ClosestPoint(Ray2D ray, Point2D point)
        {
            if (ray == null || point == null)
                return null;

            return ray.ClosestPoint(point);
        }
        #endregion Static
    }
}