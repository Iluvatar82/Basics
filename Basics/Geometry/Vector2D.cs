using System;

namespace Basics.Geometry
{
    public class Vector2D : ICloneable
    {
        #region Variables & Fields
        /// <summary>
        /// Should the <see cref="Length"/> Value of the <see cref="Vector2D"/> be recalculated or not?
        /// Relevant only when we set the <see cref="X"/> and <see cref="Y"/> Values.
        /// </summary>
        private bool _updateLength;

        /// <summary>
        /// Backing Field for the <see cref="X"/> Value.
        /// </summary>
        private double _x;

        /// <summary>
        /// Backing Field for the <see cref="Y"/> Value.
        /// </summary>
        private double _y;

        /// <summary>
        /// Squared <see cref="Length"/> of the Vector.
        /// </summary>
        private double _lengthSquared;

        /// <summary>
        /// Backing Field for the <see cref="Length"/> Value.
        /// </summary>
        private double _length;


        /// <summary>
        /// X Value of the <see cref="Vector2D"/>. Automatically recalculates the <see cref="Length"/> if needed.
        /// </summary>
        public double X
        {
            get => _x;
            set
            {
                _x = value;
                if (_updateLength)
                {
                    _lengthSquared = _x * _x + _y * _y;
                    _length = default;
                }
            }
        }

        /// <summary>
        /// Y Value of the <see cref="Vector2D"/>. Automatically recalculates the <see cref="Length"/> if needed.
        /// </summary>
        public double Y
        {
            get => _y;
            set
            {
                _y = value;
                if (_updateLength)
                {
                    _lengthSquared = _x * _x + _y * _y;
                    _length = default;
                }
            }
        }

        /// <summary>
        /// Length of the <see cref="Vector2D"/>. Not calculated every time, only when the <see cref="X"/> or <see cref="Y"/> Values changed since the previous Access.
        /// </summary>
        public double Length
        {
            get
            {
                if (_lengthSquared != default && _length == default)
                    _length = System.Math.Sqrt(_lengthSquared);

                return _length;
            }
        }

        /// <summary>
        /// Indicating if the <see cref="Len"/> of the <see cref="Vector2D"/> equals to 1.0.
        /// </summary>
        public bool IsNormalized => (_lengthSquared - 1.0) > -Math.Helper.E && (_lengthSquared - 1.0) < Math.Helper.E;

        /// <summary>
        /// Angle of the <see cref="Vector2D"/>.
        /// </summary>
        public double Heading
        {
            get
            {
                var normalized = this;
                if (!IsNormalized)
                {
                    normalized = (Vector2D)Clone();
                    normalized.Normalize();
                }

                return System.Math.Atan2(normalized.X, normalized.Y);
            }
        }

        /// <summary>
        /// New <see cref="Vector2D"/> Instance. <see cref="X"/> = 0.0, <see cref="Y"/> = 0.0.
        /// </summary>
        public static Vector2D Zero => new Vector2D();

        /// <summary>
        /// New <see cref="Vector2D"/> Instance. <see cref="X"/> = 1.0, <see cref="Y"/> = 1.0.
        /// </summary>
        public static Vector2D One => new Vector2D(1);

        /// <summary>
        /// New <see cref="Vector2D"/> Instance. <see cref="X"/> = 1.0, <see cref="Y"/> = 0.0.
        /// </summary>
        public static Vector2D PositiveX => new Vector2D(1, 0);

        /// <summary>
        /// New <see cref="Vector2D"/> Instance. <see cref="X"/> = -1.0, <see cref="Y"/> = 0.0.
        /// </summary>
        public static Vector2D NegativeX => new Vector2D(-1, 0);

        /// <summary>
        /// New <see cref="Vector2D"/> Instance. <see cref="X"/> = 0.0, <see cref="Y"/> = 1.0.
        /// </summary>
        public static Vector2D PositiveY => new Vector2D(0, 1);

        /// <summary>
        /// New <see cref="Vector2D"/> Instance. <see cref="X"/> = 0.0, <see cref="Y"/> = -1.0.
        /// </summary>
        public static Vector2D NegativeY => new Vector2D(0, -1);
        #endregion Variables & Fields


        #region Constructors
        /// <summary>
        /// New <see cref="Vector2D"/> Instance. <see cref="X"/> = 0, <see cref="Y"/> = 0 (same as <see cref="Zero/>).
        /// </summary>
        public Vector2D()
        {
            _x = 0;
            _y = 0;

            _updateLength = true;
            _lengthSquared = 0;
        }

        /// <summary>
        /// New <see cref="Vector2D"/> Instance. <see cref="X"/> = <paramref name="value"/>, <see cref="Y"/> = <paramref name="value"/>.
        /// </summary>
        /// <param name="value">Value for <see cref="X"/> and <see cref="Y"/>.</param>
        public Vector2D(double value) : this()
        {
            _x = value;
            _y = value;

            _lengthSquared = 2 * (value * value);
        }

        /// <summary>
        /// New <see cref="Vector2D"/> Instance. <see cref="X"/> = <paramref name="x"/>, <see cref="Y"/> = <paramref name="x"/>.
        /// </summary>
        /// <param name="x"><see cref="X"/> Value.</param>
        /// <param name="y"><see cref="Y"/> Value.</param>
        public Vector2D(double x, double y) : this()
        {
            _x = x;
            _y = y;

            _lengthSquared = x * x + y * y;
        }

        /// <summary>
        /// New <see cref="Vector2D"/> Instance with Values from another <see cref="Point2D"/> to set <see cref="X"/> and <see cref="Y"/>.
        /// </summary>
        /// <param name="other">Existing <see cref="Point2D"/>.</param>
        public Vector2D(Vector2D other) : this()
        {
            _x = other.X;
            _y = other.Y;

            _lengthSquared = other.X * other.X + other.Y * other.Y;
        }

        /// <summary>
        /// New <see cref="Vector2D"/> Instance with Values from a <see cref="Point2D"/> to set <see cref="X"/> and <see cref="Y"/>.
        /// </summary>
        /// <param name="point">Existing <see cref="Point2D"/>.</param>
        public Vector2D(Point2D point) : this()
        {
            X = point.X;
            Y = point.Y;
        }
        #endregion Constructors


        #region Functions
        /// <summary>
        /// Normalize the <see cref="Vector2D"/> (i.e. <see cref="Scale(double)"/> the <see cref="Vector2D"/> to a <see cref="Length"/> of 1.0).
        /// </summary>
        public void Normalize()
        {
            if (IsNormalized)
                return;

            if (_lengthSquared == default)
                return;

            var length = Length;
            _x /= length;
            _y /= length;

            _lengthSquared = 1;
            _length = 1;
        }

        /// <summary>
        /// Scale the <see cref="Vector2D"/> with the provided <paramref name="factor"/>.
        /// </summary>
        /// <param name="factor">Factor of the <see cref="Length"/> of the <see cref="Vector2D"/>.</param>
        public void Scale(double factor)
        {
            _x *= factor;
            _y *= factor;

            _lengthSquared = _x * _x + _y * _y;
            _length *= factor;
        }

        /// <summary>
        /// Rotate the <see cref="Vector2D"/> with the provided <paramref name="angle"/>.
        /// </summary>
        /// <param name="angle">The Rotation Angle.</param>
        public void Rotate(double angle)
        {
            var x = _x * System.Math.Cos(angle) - _y * System.Math.Sin(angle);
            var y = _x * System.Math.Sin(angle) + _y * System.Math.Cos(angle);
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Rotate the <see cref="Vector2D"/> with the provided <paramref name="angleInDegrees"/> using Degrees.
        /// </summary>
        /// <param name="angleInDegrees">The Rotation Angle in Degrees.</param>
        public void RotateDegrees(double angleInDegrees) => Rotate(Math.Conversion.DegreesToRadians(angleInDegrees));

        /// <summary>
        /// Calculate the Dot Product of the <see cref="Vector2D"/> and the <paramref name="other"/> <see cref="Vector2D"/>.
        /// </summary>
        /// <param name="other">The second <see cref="Vector2D"/>.</param>
        /// <returns>Dot Product for the two <see cref="Vector2D"/>.</returns>
        public double Dot(Vector2D other) => X * other.X + Y * other.Y;

        /// <summary>
        /// Calculate the Angle between the <see cref="Vector2D"/> and the <paramref name="other"/> <see cref="Vector2D"/>.
        /// </summary>
        /// <param name="other">The second <see cref="Vector2D"/>.</param>
        /// <returns>Angle between the two <see cref="Vector2D"/> (in Radians).</returns>
        public double AngleBetween(Vector2D other)
        {
            if (this == null || other == null)
                return 0;

            var first = (Vector2D)Clone();
            first.Normalize();
            var second = (Vector2D)other.Clone();
            second.Normalize();

            if (!IsNormalized || !other.IsNormalized)
                return 0;

            return System.Math.Atan(first.Dot(second));
        }

        /// <summary>
        /// Reverts the <see cref="Vector2D"/>.
        /// </summary>
        public void Opposite()
        {
            _updateLength = false;
            X *= -1;
            Y *= -1;
            _updateLength = true;
        }

        /// <summary>
        /// Reflect the <see cref="Vector2D"/> with the <paramref name="other"/> <see cref="Vector2D"/>.
        /// </summary>
        /// <param name="other">The second <see cref="Vector2D"/>.</param>
        public void Reflect(Vector2D other)
        {
            if (other == null)
                return;

            var reflector = (Vector2D)other.Clone();
            reflector.Normalize();
            if (!other.IsNormalized)
                return;

            var projectedLength = Dot(reflector);
            var reflectionPoint = new Point2D(reflector * projectedLength);
            var endToReflectionPoint = new Vector2D(reflectionPoint - this);

            var newX = X + 2 * endToReflectionPoint.X;
            var newY = Y + 2 * endToReflectionPoint.Y;

            _updateLength = false;
            X = newX;
            Y = newY;
            _updateLength = true;
        }
        #endregion Functions


        #region Operators
        /// <summary>
        /// Adds the <see cref="Vector2D"/>'s Values to the <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The Value.</param>
        /// <param name="vector">The <see cref="Vector2D"/> to add.</param>
        /// <returns><see cref="Vector2D"/> with new <see cref="X"/> and <see cref="Y"/> Values.</returns>
        public static Vector2D operator +(double value, Vector2D vector) => new Vector2D(vector.X + value, vector.Y + value);

        /// <summary>
        /// Adds the <paramref name="value"/> to the <see cref="Vector2D"/>'s <see cref="X"/> and <see cref="Y"/> Values.
        /// </summary>
        /// <param name="vector">The <see cref="Vector2D"/>.</param>
        /// <param name="value">The Value to add to the <paramref name="vector"/>'s  <see cref="X"/> and <see cref="Y"/> Values.</param>
        /// <returns><see cref="Vector2D"/> with new <see cref="X"/> and <see cref="Y"/> Values.</returns>
        /// <returns></returns>
        public static Vector2D operator +(Vector2D vector, double value) => new Vector2D(vector.X + value, vector.Y + value);

        /// <summary>
        /// Adds the Values of the <see cref="Vector2D"/> to the <see cref="Vector2D"/>'s <see cref="X"/> and <see cref="Y"/> Values.
        /// </summary>
        /// <param name="first">The first <see cref="Vector2D"/>.</param>
        /// <param name="second"> The second <see cref="Vector2D"/>.</param>
        /// <returns><see cref="Vector2D"/> with new <see cref="X"/> and <see cref="Y"/> Values.</returns>
        public static Vector2D operator +(Vector2D first, Vector2D second) => new Vector2D(first.X + second.X, first.Y + second.Y);

        /// <summary>
        /// Subtracts the <see cref="Vector2D"/>'s Values from the <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The Value.</param>
        /// <param name="vector">The <see cref="Vector2D"/> to subtract.</param>
        /// <returns><see cref="Vector2D"/> with new <see cref="X"/> and <see cref="Y"/> Values.</returns>
        public static Vector2D operator -(double value, Vector2D vector) => new Vector2D(vector.X - value, vector.Y - value);

        /// <summary>
        /// Subtracts the <see cref="value"/> from the <see cref="Vector2D"/>'s Values.
        /// </summary>
        /// <param name="vector">The <see cref="Vector2D"/>.</param>
        /// <param name="value">The Value to subtract.</param>
        /// <returns><see cref="Vector2D"/> with new <see cref="X"/> and <see cref="Y"/> Values.</returns>
        public static Vector2D operator -(Vector2D vector, double value) => new Vector2D(vector.X - value, vector.Y - value);

        /// <summary>
        /// Subtracts the Values of the <paramref name="second"/> <see cref="Vector2D"/> from the <paramref name="first"/> <see cref="Vector2D"/>'s <see cref="X"/> and <see cref="Y"/> Values.
        /// </summary>
        /// <param name="first">The first <see cref="Vector2D"/>.</param>
        /// <param name="second"> The second <see cref="Vector2D"/>.</param>
        /// <returns><see cref="Vector2D"/> with new <see cref="X"/> and <see cref="Y"/> Values.</returns>
        public static Vector2D operator -(Vector2D first, Vector2D second) => new Vector2D(first.X - second.X, first.Y - second.Y);

        /// <summary>
        /// Multiplies the <see cref="Vector2D"/>'s Values with the <paramref name="factor"/>.
        /// </summary>
        /// <param name="factor">The Factor.</param>
        /// <param name="vector">The <see cref="Vector2D"/> to multiply.</param>
        /// <returns><see cref="Vector2D"/> with new <see cref="X"/> and <see cref="Y"/> Values.</returns>
        public static Vector2D operator *(double factor, Vector2D vector) => new Vector2D(vector.X * factor, vector.Y * factor);

        /// <summary>
        /// Multiplies the <see cref="Vector2D"/>'s Values with the <paramref name="factor"/>.
        /// </summary>
        /// <param name="factor">The Factor.</param>
        /// <param name="vector">The <see cref="Vector2D"/> to multiply.</param>
        /// <returns><see cref="Vector2D"/> with new <see cref="X"/> and <see cref="Y"/> Values.</returns>
        public static Vector2D operator *(Vector2D vector, double factor) => new Vector2D(vector.X * factor, vector.Y * factor);

        /// <summary>
        /// Divides the <see cref="Vector2D"/>'s Values with the <paramref name="divisor"/>.
        /// </summary>
        /// <param name="divisor">The Divisor.</param>
        /// <param name="vector">The <see cref="Vector2D"/> to divide.</param>
        /// <returns><see cref="Vector2D"/> with new <see cref="X"/> and <see cref="Y"/> Values.</returns>
        public static Vector2D operator /(Vector2D vector, double divisor)
        {
            if (divisor == default)
                return new Vector2D();

            return new Vector2D(vector.X / divisor, vector.Y / divisor);
        }

        /// <summary>
        /// Conversion from a <see cref="Point2D"/> to a new <see cref="Vector2D"/>.
        /// </summary>
        /// <param name="point">The existing <see cref="Point2D"/>.</param>
        public static explicit operator Vector2D(Point2D point) => new Vector2D(point);
        #endregion Operators


        #region Overrides
        /// <summary>
        /// String Representation of the <see cref="Vector2D"/>.
        /// </summary>
        /// <returns>String Value.</returns>
        public override string ToString() => $"X: {X:F2} Y: {Y:F2}";
        #endregion Overrides


        #region ICloneable
        /// <summary>
        /// Clone the Values of the <see cref="Vector2D"/> to a new <see cref="Vector2D"/>.
        /// </summary>
        /// <returns>Clone of the <see cref="Vector2D"/>.</returns>
        public object Clone() => new Vector2D(this);
        #endregion ICloneable


        #region Static
        /// <summary>
        /// Calculates the Dot Product for the two <see cref="Vector2D"/>'s <paramref name="first"/> and <paramref name="second"/>.
        /// </summary>
        /// <param name="first">The first <see cref="Vector2D"/>.</param>
        /// <param name="second">The second <see cref="Vector2D"/>.</param>
        /// <returns>Dot Product for the two <see cref="Vector2D"/>'s.</returns>
        public static double Dot(Vector2D first, Vector2D second) => (first == null || second == null) ? 0 : first.Dot(second);

        /// <summary>
        /// Calculates the Angle between the two <see cref="Vector2D"/>'s <paramref name="first"/> and <paramref name="second"/>.
        /// </summary>
        /// <param name="first">The first <see cref="Vector2D"/>.</param>
        /// <param name="second">The second <see cref="Vector2D"/>.</param>
        /// <returns>Angle between the two <see cref="Vector2D"/>'s (in Radians).</returns>
        public double AngleBetween(Vector2D first, Vector2D second) => (first == null || second == null) ? 0 : first.AngleBetween(second);

        /// <summary>
        /// Reflect the <paramref name="vector"/> <see cref="Vector2D"/> with the <paramref name="reflector"/> <see cref="Vector2D"/>.
        /// </summary>
        /// <param name="vector">The <see cref="Vector2D"/> to be reflected.</param>
        /// <param name="reflector">The <see cref="Vector2D"/> to reflect.</param>
        /// <returns><see cref="Vector2D"/> the is reflected.</returns>
        public Vector2D Reflect(Vector2D vector, Vector2D reflector)
        {
            if (vector == null || reflector == null)
                return null;

            var reflectedVector = (Vector2D)vector.Clone();
            reflectedVector.Reflect(reflector);
            return reflectedVector;
        }
        #endregion Static
    }
}