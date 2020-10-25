using Basics.Extensions;
using Basics.Math;
using System;

namespace Basics.Geometry
{
    public class Ray2D : ICloneable
    {
        #region Variables & Fields
        /// <summary>
        /// The Origin of the <see cref="Ray2D"/>.
        /// </summary>
        public Point2D Origin { get; set; }

        /// <summary>
        /// The Direction of the <see cref="Ray2D"/>.
        /// </summary>
        public Vector2D Direction { get; set; }
        #endregion Variables & Fields


        #region Constructors
        /// <summary>
        /// New <see cref="Ray2D"/> Instance. <see cref="Origin"/> and <see cref="Direction"/> with Default values (<see cref="Point2D.Zero"/> and <see cref="Vector2D.Zero"/>).
        /// </summary>
        public Ray2D()
        {
            Origin = Point2D.Zero;
            Direction = Vector2D.Zero;
        }

        /// <summary>
        /// New <see cref="Ray2D"/> Instance. <see cref="Direction"/> with Default values (<see cref="Vector2D.Zero"/>).
        /// </summary>
        /// <param name="origin">The <see cref="Ray2D"/> <see cref="Origin"/>.</param>
        public Ray2D(Point2D origin)
        {
            Origin = origin;
            Direction = Vector2D.Zero;
        }

        /// <summary>
        /// New <see cref="Ray2D"/> Instance. <see cref="Origin"/> with Default values (<see cref="Point2D.Zero"/>).
        /// </summary>
        /// <param name="direction">The <see cref="Ray2D"/> <see cref="Direction"/>.</param>
        public Ray2D(Vector2D direction)
        {
            Origin = Point2D.Zero;
            Direction = (Vector2D)direction.Clone();
        }

        /// <summary>
        /// New <see cref="Ray2D"/> Instance.
        /// </summary>
        /// <param name="origin">The <see cref="Ray2D"/> <see cref="Origin"/>.</param>
        /// <param name="direction">The <see cref="Ray2D"/> <see cref="Direction"/>.</param>
        public Ray2D(Point2D origin, Vector2D direction)
        {
            Origin = (Point2D)origin.Clone();
            Direction = (Vector2D)direction.Clone();
        }

        /// <summary>
        /// New <see cref="Ray2D"/> Instance with Values from another <see cref="Ray2D"/> to set <see cref="Origin"/> and <see cref="Direction"/>.
        /// </summary>
        /// <param name="other">Existing <see cref="Ray2D"/>.</param>
        public Ray2D(Ray2D other)
        {
            Origin = (Point2D)other.Origin.Clone();
            Direction = (Vector2D)other.Direction.Clone();
        }
        #endregion Constructors


        #region Functions
        /// <summary>
        /// Calculate the closest <see cref="Point2D"/> on the <see cref="Ray2D"/> with the minumum Distance to the <see cref="Point2D"/>.
        /// </summary>
        /// <param name="point">The <see cref="Point2D"/>.</param>
        /// <returns>Closest <see cref="Point2D"/> on the <see cref="Ray2D"/>.</returns>
        public Point2D ClosestPointOnRay(Point2D point)
        {
            if (point == null)
                return null;

            var normalizedDirection = (Vector2D)Direction.Clone();
            if (!normalizedDirection.IsNormalized)
                normalizedDirection.Normalize();

            var originToPoint = (Vector2D)point - (Vector2D)Origin;
            var projectedLength = originToPoint.Dot(normalizedDirection);
            return Origin + normalizedDirection * projectedLength;
        }

        /// <summary>
        /// Calculate the Distance to the <see cref="Point2D"/>.
        /// </summary>
        /// <param name="point">The <see cref="Point2D"/>.</param>
        /// <returns>Distance to the <see cref="Point2D"/>.</returns>
        public double Distance(Point2D point)
        {
            if (point == null)
                return 0;

            var closestPoint = ClosestPointOnRay(point);
            return point.Distance(closestPoint);
        }

        /// <summary>
        /// Calculate the Intersection-<see cref="Point2D"/> with another <see cref="Ray2D"/>.
        /// </summary>
        /// <param name="other">The second <see cref="Ray2D"/>.</param>
        /// <returns>Intersection <see cref="Point2D"/>.</returns>
        public Point2D Intersection(Ray2D other)
        {
            if (other == null || other.Direction == null || other.Direction.Length == 0)
                return null;

            if (System.Math.Abs(Direction.Heading.NormalizeAngle() - other.Direction.Heading.NormalizeAngle()) < Helper.E ||
                System.Math.Abs(Direction.Heading.NormalizeAngle() - (other.Direction.Heading + Helper.PI).NormalizeAngle()) < Helper.E)
                return null;

            var originVector = new Vector2D(Origin - new Vector2D(other.Origin));
            var parameter = (other.Direction.Y * originVector.X - other.Direction.X * originVector.Y) / (other.Direction.X * Direction.Y - other.Direction.Y * Direction.X);
            return Origin + Direction * parameter;
        }
        #endregion Functions


        #region Overrides
        /// <summary>
        /// String Representation of the <see cref="Ray2D"/>.
        /// </summary>
        /// <returns>String Value.</returns>
        public override string ToString() => $"Origin: [{Origin}], Direction: [{Direction}]";
        #endregion Overrides


        #region ICloneable
        /// <summary>
        /// Clone the Values of the <see cref="Ray2D"/> to a new <see cref="Ray2D"/>.
        /// </summary>
        /// <returns>Clone of the <see cref="Ray2D"/>.</returns>
        public object Clone() => new Ray2D(this);
        #endregion ICloneable


        #region Static
        /// <summary>
        /// Calculates the clostst <see cref="Point2D"/> on the <see cref="Ray2D"/> with the minumum Distance to the <see cref="Point2D"/>.
        /// </summary>
        /// <param name="ray">The <see cref="Ray2D"/>.</param>
        /// <param name="point">The <see cref="Point2D"/>.</param>
        /// <returns>Closest <see cref="Point2D"/> on the <see cref="Ray2D"/>.</returns>
        public static Point2D ClosestPointOnRay(Ray2D ray, Point2D point)
        {
            if (ray == null || point == null)
                return null;

            return ray.ClosestPointOnRay(point);
        }

        /// <summary>
        /// Calculates the Distance between the <see cref="Point2D"/> and the <see cref="Ray2D"/>.
        /// </summary>
        /// <param name="ray">The <see cref="Ray2D"/>.</param>
        /// <param name="point">The <see cref="Point2D"/>.</param>
        /// <returns>Closest <see cref="Point2D"/> on the <see cref="Ray2D"/>.</returns>
        public static double Distance(Ray2D ray, Point2D point)
        {
            if (point == null)
                return 0;

            var closestPoint = ClosestPointOnRay(ray, point);
            return point.Distance(closestPoint);
        }

        /// <summary>
        /// Calculate the Intersection-<see cref="Point2D"/> of two <see cref="Ray2D"/>s.
        /// </summary>
        /// <param name="first">The first <see cref="Ray2D"/>.</param>
        /// <param name="second">The second <see cref="Ray2D"/>.</param>
        /// <returns>Intersection <see cref="Point2D"/>.</returns>
        public static Point2D Intersection(Ray2D first, Ray2D second)
        {
            if (first == null || second == null || first.Direction == null || first.Direction.Length == 0 || second.Direction == null || second.Direction.Length == 0)
                return null;

            return first.Intersection(second);
        }
        #endregion Static
    }
}