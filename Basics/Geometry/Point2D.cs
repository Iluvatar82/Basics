using System;

namespace Basics.Geometry
{
    public class Point2D : ICloneable
    {
        #region Variables & Fields
        /// <summary>
        /// X-Value of the <see cref="Point2D"/>.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Y-Value of the <see cref="Point2D"/>.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// <see cref="Point2D"/> Object with Values <see cref="X"/> = 0, <see cref="Y"/> = 0.
        /// </summary>
        public static Point2D Zero => new Point2D();
        #endregion Variables & Fields


        #region Constructors
        /// <summary>
        /// Create a default <see cref="Point2D"/> with Values <see cref="X"/> = 0, <see cref="Y"/> = 0 (same as <see cref="Zero/>).
        /// </summary>
        public Point2D()
        {
            X = 0;
            Y = 0;
        }

        /// <summary>
        /// Create a default <see cref="Point2D"/> with Values <see cref="X"/> = <paramref name="value"/>, <see cref="Y"/> = <paramref name="value"/>.
        /// </summary>
        /// <param name="value">Value for <see cref="X"/> and <see cref="Y"/>.</param>
        public Point2D(double value)
        {
            X = value;
            Y = value;
        }

        /// <summary>
        /// Create a default <see cref="Point2D"/> with Values <see cref="X"/> = <paramref name="x"/>, <see cref="Y"/> = <paramref name="x"/>.
        /// </summary>
        /// <param name="x"><see cref="X"/> Value.</param>
        /// <param name="y"><see cref="Y"/> Value.</param>
        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Copy Constructor that takes the Values from another <see cref="Point2D"/> to set <see cref="X"/> and <see cref="Y"/>.
        /// </summary>
        /// <param name="other">Existing <see cref="Point2D"/>.</param>
        public Point2D(Point2D other)
        {
            X = other.X;
            Y = other.Y;
        }

        /// <summary>
        /// Copy Constructor that takes the Values from a <see cref="Vector2D"/> to set <see cref="X"/> and <see cref="Y"/>.
        /// </summary>
        /// <param name="vector">Existing <see cref="Vector2D"/>.</param>
        public Point2D(Vector2D vector)
        {
            X = vector.X;
            Y = vector.Y;
        }
        #endregion Constructors


        #region Functions
        /// <summary>
        /// Translate the <see cref="Point2D"/> with the provided <see cref="Vector2D"/> <paramref name="translationVector"/>.
        /// </summary>
        /// <param name="translationVector">Translation <see cref="Vector2D"/>.</param>
        public void Translate(Vector2D translationVector)
        {
            if (translationVector == null)
                return;

            X += translationVector.X;
            Y += translationVector.Y;
        }

        /// <summary>
        /// Calculates the Distance to another <see cref="Point2D"/>.
        /// </summary>
        /// <param name="other">The <see cref="Point2D"/> to calculate the Distance to.</param>
        /// <returns>Distance from the <see cref="Point2D"/> to the <paramref name="other"/> <see cref="Point2D"/>.</returns>
        public double Distance(Point2D other) => new Vector2D(this - new Vector2D(other)).Length;

        /// <summary>
        /// Rotates the <see cref="Point2D"/> around the <paramref name="origin"/>.
        /// </summary>
        /// <param name="angle">Angle of the Rotation (in Radians).</param>
        /// <param name="origin">The Rotation Origin.</param>
        public void Rotate(double angle, Point2D origin = null)
        {
            if (origin == null)
                origin = new Point2D();

            var vectorToPoint = new Vector2D(this - new Vector2D(origin));
            vectorToPoint.Rotate(angle);

            X = origin.X + vectorToPoint.X;
            Y = origin.Y + vectorToPoint.Y;
        }

        /// <summary>
        /// Reflect the <see cref="Point2D"/> with the provided <see cref="Vector2D"/> <paramref name="reflector"/>.
        /// </summary>
        /// <param name="reflector">The Reflection <see cref="Vector2D"/>.</param>
        /// <returns>New reflected <see cref="Point2D"/>.</returns>
        public Point2D Reflect(Vector2D reflector)
        {
            if (reflector == null)
                return (Point2D)Clone();

            var vector = (Vector2D)this;
            vector.Reflect(reflector);
            return (Point2D)vector;
        }

        /// <summary>
        /// Reflect the <see cref="Point2D"/> with the provided <see cref="Ray2D"/> <paramref name="ray"/>.
        /// </summary>
        /// <param name="ray">The Reflection <see cref="Ray2D"/>.</param>
        /// <returns>New reflected <see cref="Point2D"/>.</returns>
        public Point2D Reflect(Ray2D ray)
        {
            if (ray == null)
                return (Point2D)Clone();

            var reflectedPoint = (Point2D)Clone();
            reflectedPoint.Translate((Vector2D)ray.Origin * -1);
            reflectedPoint.Reflect(ray.Direction);
            reflectedPoint.Translate((Vector2D)ray.Origin);

            return reflectedPoint;
        }
        #endregion Functions


        #region Operators
        /// <summary>
        /// Adds the <paramref name="value"/> to the Point's <see cref="X"/> and <see cref="Y"/> Values.
        /// </summary>
        /// <param name="point">The <see cref="Point2D"/>.</param>
        /// <param name="value">The Value to add to the <paramref name="point"/>'s  <see cref="X"/> and <see cref="Y"/> Values.</param>
        /// <returns>New Point with new <see cref="X"/> and <see cref="Y"/> Values.</returns>
        public static Point2D operator +(Point2D point, double value) => new Point2D(point.X + value, point.Y + value);

        /// <summary>
        /// Adds the <paramref name="translationVector"/>'s Values to the Point's <see cref="X"/> and <see cref="Y"/> Values.
        /// </summary>
        /// <param name="point">The <see cref="Point2D"/>.</param>
        /// <param name="translationVector"> The Translation <see cref="Vector2D"/>.</param>
        /// <returns>New Point with new <see cref="X"/> and <see cref="Y"/> Values.</returns>
        public static Point2D operator +(Point2D point, Vector2D translationVector) => new Point2D(point.X + translationVector.X, point.Y + translationVector.Y);

        /// <summary>
        /// Subtracts the <paramref name="value"/> from the Point's <see cref="X"/> and <see cref="Y"/> Values.
        /// </summary>
        /// <param name="point">The <see cref="Point2D"/>.</param>
        /// <param name="value">The Value to subtract from the <paramref name="point"/>'s  <see cref="X"/> and <see cref="Y"/> Values.</param>
        /// <returns>New Point with new <see cref="X"/> and <see cref="Y"/> Values.</returns>
        public static Point2D operator -(Point2D point, double value) => new Point2D(point.X - value, point.Y - value);

        /// <summary>
        /// Subtracts the <paramref name="translationVector"/>'s Values from the Point's <see cref="X"/> and <see cref="Y"/> Values.
        /// </summary>
        /// <param name="point">The <see cref="Point2D"/>.</param>
        /// <param name="translationVector"> The Translation <see cref="Vector2D"/>.</param>
        /// <returns>New Point with new <see cref="X"/> and <see cref="Y"/> Values.</returns>
        public static Point2D operator -(Point2D point, Vector2D translationVector) => new Point2D(point.X - translationVector.X, point.Y - translationVector.Y);

        /// <summary>
        /// COnversion from a <see cref="Vector2D"/> to a new <see cref="Point2D"/>.
        /// </summary>
        /// <param name="vector">The existing <see cref="Vector2D"/>.</param>
        public static explicit operator Point2D(Vector2D vector) => new Point2D(vector);
        #endregion Operators


        #region Overrides
        /// <summary>
        /// String Representation of the <see cref="Point2D"/>.
        /// </summary>
        /// <returns>String Value.</returns>
        public override string ToString() => $"X: {X:F2} Y: {Y:F2}";
        #endregion Overrides


        #region ICloneable
        /// <summary>
        /// Clone the Values of the <see cref="Point2D"/> to a new <see cref="Point2D"/>.
        /// </summary>
        /// <returns></returns>
        public object Clone() => new Point2D(this);
        #endregion ICloneable


        #region Static
        /// <summary>
        /// Calculates the Distance from the <see cref="Point2D"/> <paramref name="first"/> to the <see cref="Point2D"/> <paramref name="second"/>.
        /// </summary>
        /// <param name="first">Any <see cref="Point2D"/>.</param>
        /// <param name="second">Any <see cref="Point2D"/>.</param>
        /// <returns>Distance from <paramref name="first"/> to <paramref name="second"/>.</returns>
        public static double Distance(Point2D first, Point2D second) => first.Distance(second);

        /// <summary>
        /// Rotates the <see cref="Point2D"/> around the <paramref name="origin"/>.
        /// </summary>
        /// <param name="point">The <see cref="Point2D"/> to be rotated.</param>
        /// <param name="angle">Angle of the Rotation (in Radians).</param>
        /// <param name="origin">The Rotation Origin.</param>
        /// <returns>Rotated Point.</returns>
        public static Point2D Rotate(Point2D point, double angle, Point2D origin = null)
        {
            var rotatedPoint = (Point2D)point.Clone();
            rotatedPoint.Rotate(angle, origin);
            return rotatedPoint;
        }

        /// <summary>
        /// Reflect the <paramref name="point"/> with the provided <see cref="Vector2D"/> <paramref name="reflector"/>.
        /// </summary>
        /// <param name="point">The Point to be Reflected.</param>
        /// <param name="reflector">The Reflection <see cref="Vector2D"/>.</param>
        /// <returns>New reflected <see cref="Point2D"/>.</returns>
        public static Point2D Reflect(Point2D point, Vector2D reflector)
        {
            if (point == null || reflector == null)
                return null;

            return point.Reflect(reflector);
        }

        /// <summary>
        /// Reflect the <paramref name="point"/> with the provided <see cref="Ray2D"/> <paramref name="ray"/>.
        /// </summary>
        /// <param name="point">The Point to be Reflected.</param>
        /// <param name="ray">The Reflection <see cref="Ray2D"/>.</param>
        /// <returns>New reflected <see cref="Point2D"/>.</returns>
        public static Point2D Reflect(Point2D point, Ray2D ray)
        {
            if (point == null || ray == null)
                return null;

            return point.Reflect(ray);
        }
        #endregion Static
    }
}