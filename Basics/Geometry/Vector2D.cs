using Basics.MathHelper;
using System;
using System.Reflection;

namespace Basics.Geometry
{
    public class Vector2D : ICloneable
    {
        #region Variables & Fields
        private bool _updateLength;
        private double _x;
        private double _y;
        private double _lengthSquared;
        private double _length;

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

        public double Length
        {
            get
            {
                if (_lengthSquared != default && _length == default)
                    _length = Math.Sqrt(_lengthSquared);

                return _length;
            }
        }

        public bool IsNormalized => _lengthSquared == 1;

        public double Heading
        {
            get
            {
                var normalized = this;
                if (!IsNormalized)
                {
                    normalized = new Vector2D(this);
                    normalized.Normalize();
                }

                return Math.Atan2(normalized.X, normalized.Y);
            }
        }
        #endregion Variables & Fields


        #region Constructors
        public Vector2D()
        {
            _x = 0;
            _y = 0;

            _updateLength = true;
            _lengthSquared = 0;
        }

        public Vector2D(double value) : this()
        {
            _x = value;
            _y = value;

            _lengthSquared = 2 * (value * value);
        }

        public Vector2D(double x, double y) : this()
        {
            _x = x;
            _y = y;

            _lengthSquared = x * x + y * y;
        }

        public Vector2D(Vector2D other) : this()
        {
            _x = other.X;
            _y = other.Y;

            _lengthSquared = other.X * other.X + other.Y * other.Y;
        }

        public Vector2D(Point2D point) : this()
        {
            X = point.X;
            Y = point.Y;
        }
        #endregion Constructors


        #region Functions
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

        public void Scale(double factor)
        {
            _x *= factor;
            _y *= factor;

            _lengthSquared = _x * _x + _y * _y;
            _length *= factor;
        }

        public void Rotate(double angle)
        {
            var x = _x * Math.Cos(angle) - _y * Math.Sin(angle);
            var y = _x * Math.Sin(angle) + _y * Math.Cos(angle);
            _x = x;
            _y = y;
        }

        public void RotateDegrees(double angleInDegrees) => Rotate(Conversion.DegreesToRadians(angleInDegrees));

        public double Dot(Vector2D other) => X * other.X + Y * other.Y;

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

            return Math.Atan(first.Dot(second));
        }

        public void Opposite()
        {
            _updateLength = false;
            X *= -1;
            Y *= -1;
            _updateLength = true;
        }

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
        public static Vector2D operator +(Vector2D one, Vector2D two) => new Vector2D(one.X + two.X, one.Y + two.Y);

        public static Vector2D operator +(Vector2D one, double add) => new Vector2D(one.X + add, one.Y + add);

        public static Vector2D operator +(double add, Vector2D one) => new Vector2D(one.X + add, one.Y + add);

        public static Vector2D operator -(Vector2D one, Vector2D two) => new Vector2D(one.X - two.X, one.Y - two.Y);

        public static Vector2D operator -(Vector2D one, double subtract) => new Vector2D(one.X - subtract, one.Y - subtract);

        public static Vector2D operator -(double subtract, Vector2D one) => new Vector2D(one.X - subtract, one.Y - subtract);

        public static Vector2D operator *(Vector2D one, double factor) => new Vector2D(one.X * factor, one.Y * factor);

        public static Vector2D operator *(double factor, Vector2D one) => new Vector2D(one.X * factor, one.Y * factor);

        public static Vector2D operator /(Vector2D one, double divisor)
        {
            if (divisor == default)
                return new Vector2D();

            return new Vector2D(one.X / divisor, one.Y / divisor);
        }

        public static Vector2D operator /(double divisor, Vector2D one)
        {
            if (divisor == default)
                return new Vector2D();

            return new Vector2D(one.X / divisor, one.Y / divisor);
        }

        public static explicit operator Vector2D(Point2D point) => new Vector2D(point);
        #endregion Operators


        #region Overrides
        public override string ToString() => $"X: {X:F2} Y: {Y:F2}";
        #endregion Overrides


        #region ICloneable
        public object Clone() => new Vector2D(this);
        #endregion ICloneable


        #region Static
        public static double Dot(Vector2D first, Vector2D second) => (first == null || second == null) ? 0 : first.Dot(second);

        public double AngleBetween(Vector2D first, Vector2D second) => (first == null || second == null) ? 0 : first.AngleBetween(second);
        
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