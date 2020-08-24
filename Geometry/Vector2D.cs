using Basics.MathHelper;
using System;

namespace Basics.Geometry
{
    public class Vector2D
    {
        #region Variables & Fields
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

                _lengthSquared = _x * _x + _y * _y;
                _length = default;
            }
        }

        public double Y
        {
            get => _y;
            set
            {
                _y = value;

                _lengthSquared = _x * _x + _y * _y;
                _length = default;
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
        #endregion Variables & Fields


        #region Constructors
        public Vector2D()
        {
            _x = 0;
            _y = 0;

            _lengthSquared = 0;
        }

        public Vector2D(double value)
        {
            _x = value;
            _y = value;

            _lengthSquared = 2 * (value * value);
        }

        public Vector2D(double x, double y)
        {
            _x = x;
            _y = y;

            _lengthSquared = x * x + y * y;
        }

        public Vector2D(Vector2D other)
        {
            _x = other.X;
            _y = other.Y;

            _lengthSquared = other.X * other.X + other.Y * other.Y;
        }

        public Vector2D(Point2D point)
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

            if (Length == 0)
                return;

            var length = Length;
            _x /= length;
            _y /= length;

            _lengthSquared = _x * _x + _y * _y;
            _length = 1;
        }

        public void Scale(double x, double y)
        {
            _x *= x;
            _y *= y;

            _lengthSquared = _x * _x + _y * _y;
            _length = 1;
        }

        public void Rotate(double angle)
        {
            var x = _x * Math.Cos(angle) - _y * Math.Sin(angle);
            var y = _x * Math.Sin(angle) + _y * Math.Cos(angle);
            _x = x;
            _y = y;
        }

        public void RotateDegrees(double angleInDegrees)
        {
            Rotate(Conversion.DegreesToRadians(angleInDegrees));
        }

        public double DistanceTo(Point2D point)
        {
            var vectorToPoint = new Vector2D(point);
            var vectorLength = vectorToPoint.Length;
            vectorToPoint.Normalize();
            var normalized = new Vector2D(this);
            normalized.Normalize();

            var vectorBase = new Vector2D(normalized) * (normalized.Dot(vectorToPoint) * vectorLength);
            return new Vector2D(point - vectorBase).Length;
        }

        public double Dot(Vector2D other)
        {
            return X * other.X + Y * other.Y;
        }

        public static void DistanceTo(Vector2D vector, Point2D point) => vector.DistanceTo(point);

        public static double Dot(Vector2D one, Vector2D two) => one.Dot(two);
        #endregion Functions


        #region Operators
        public static Vector2D operator +(Vector2D one, Vector2D two)
        {
            return new Vector2D(one.X + two.X, one.Y + two.Y);
        }

        public static Vector2D operator +(Vector2D one, double add)
        {
            return new Vector2D(one.X + add, one.Y + add);
        }

        public static Vector2D operator +(double add, Vector2D one)
        {
            return new Vector2D(one.X + add, one.Y + add);
        }

        public static Vector2D operator -(Vector2D one, Vector2D two)
        {
            return new Vector2D(one.X - two.X, one.Y - two.Y);
        }

        public static Vector2D operator -(Vector2D one, Point2D point)
        {
            return new Vector2D(one.X - point.X, one.Y - point.Y);
        }

        public static Vector2D operator -(Vector2D one, double subtract)
        {
            return new Vector2D(one.X - subtract, one.Y - subtract);
        }

        public static Vector2D operator -(double subtract, Vector2D one)
        {
            return new Vector2D(one.X - subtract, one.Y - subtract);
        }

        public static Vector2D operator *(Vector2D one, double factor)
        {
            return new Vector2D(one.X * factor, one.Y * factor);
        }

        public static Vector2D operator *(double factor, Vector2D one)
        {
            return new Vector2D(one.X * factor, one.Y * factor);
        }

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

        public static explicit operator Vector2D(Point2D point)
        {
            return new Vector2D(point);
        }
        #endregion Operstors


        #region Overrides
        public override string ToString()
        {
            return $"X: {X:F2} Y: {Y:F2}";
        }
        #endregion Overrides
    }
}