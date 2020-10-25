using Basics.Geometry;
using Basics.Math;

namespace Basics.Extensions
{
    public static class NumberExtensions
    {
        /// <summary>
        /// Calculates the Decimal Value of the Input. Value-Range ]-1, 1[
        /// </summary>
        /// <param name="value">Any Number.</param>
        /// <returns>Decimal Part of the provided Parameter <paramref name="value"/>.</returns>
        public static double DecimalValue(this double value) => value - (int)value;

        /// <summary>
        /// Constrain the Input Value to a specified Range.
        /// </summary>
        /// <param name="value">Any Number.</param>
        /// <param name="minimum">Minimum of the Range.</param>
        /// <param name="maximum">Maximum of the Range.</param>
        /// <returns>Input Value, if it is between the <paramref name="minimum"/> and the <paramref name="maximum"/>, the closest Value of the Range, if the <paramref name="value"/> is not in the Range.</returns>
        public static double Constrain(this double value, double minimum, double maximum)
        {
            if (minimum > maximum)
                Helper.Swap(ref minimum, ref maximum);

            return value < minimum ? minimum : (value > maximum ? maximum : value);
        }

        /// <summary>
        /// Calculates the Fraction of the provided <paramref name="value"/> in the Range between <paramref name="from"/> to <paramref name="to"/>.
        /// Value-Range [0,1] if the Value is in the provided Range, < 0 if the <paramref name="value"/> is lower than the <paramref name="from"/> Value, > 1 if the <paramref name="value"/> is bigger than the <paramref name="to"/> Value.
        /// </summary>
        /// <param name="value">Any Number.</param>
        /// <param name="from">The first Value defining the Range.</param>
        /// <param name="to">The second Value defining the Range.</param>
        /// <returns>Fraction of the Value relative to the values of the Range. </returns>
        public static double Fraction(this double value, double from, double to)
        {
            var range = to - from;
            if (range == 0)
                return value;

            return (value - from) / range;
        }

        /// <summary>
        /// Maps a <paramref name="value"/> in the Range <paramref name="from"/> - <paramref name="to"/> to a new Range <paramref name="fromNew"/> - <paramref name="toNew"/>.
        /// </summary>
        /// <param name="value">Any Number.</param>
        /// <param name="from">The first Value defining the original Range.</param>
        /// <param name="to">The second Value defining the original Range.</param>
        /// <param name="fromNew">The first Value defining the new Range.</param>
        /// <param name="toNew">The second Value defining the new Range.</param>
        /// <returns>Mapped Value from the original Range to the new Range.</returns>
        public static double Map(this double value, double from, double to, double fromNew, double toNew)
        {
            var range = to - from;
            if (range == 0)
                return value;

            return (toNew - fromNew) * value.Fraction(from, to) + fromNew;
        }

        /// <summary>
        /// Interpolate two Values at a given Position.
        /// </summary>
        /// <param name="position">The Position (between) the <paramref name="fromPosition"/> and <paramref name="toPosition"/> Values.</param>
        /// <param name="fromPosition">Fist Position Value.</param>
        /// <param name="toPosition">Second Position Value.</param>
        /// <param name="valueFrom">Value at the Positoin <paramref name="fromPosition"/>.</param>
        /// <param name="valueTo">Value at the Positoin <paramref name="toPosition"/>.</param>
        /// <returns>Interpolated Value at the specified Position.</returns>
        public static double Interpolate(this double position, double fromPosition, double toPosition, double valueFrom, double valueTo) => position.Map(fromPosition, toPosition, valueFrom, valueTo);

        /// <summary>
        /// 2D-Interpolation of four Values at a given Position.
        /// </summary>
        /// <param name="point">The Position of the Point with normalized Coordinates (in the Range X: [0,1] Y: [0,1]).</param>
        /// <param name="valueLowerLeft">The Value at normalized Position X: 0 Y: 0.</param>
        /// <param name="valueLowerRight">The Value at normalized Position X: 1 Y: 0.</param>
        /// <param name="valueUpperLeft">The Value at normalized Position X: 0 Y: 1.</param>
        /// <param name="valueUpperRight">The Value at normalized Position X: 1 Y: 1.</param>
        /// <returns></returns>
        public static double Interpolate(this Point2D point, double valueLowerLeft, double valueLowerRight, double valueUpperLeft, double valueUpperRight)
        {
            var x = point.X.Constrain(0, 1);
            var y = point.Y.Constrain(0, 1);

            var lowerValueInterpolation = x.Interpolate(0, 1, valueLowerLeft, valueLowerRight);
            var upperValueInterpolation = x.Interpolate(0, 1, valueUpperLeft, valueUpperRight);
            return y.Interpolate(0, 1, lowerValueInterpolation, upperValueInterpolation);
        }

        /// <summary>
        /// Brings an Angle (in Radians) to the normalized Range [0, TwoPI].
        /// </summary>
        /// <param name="angleInRadians">The Angle in Radians.</param>
        /// <returns>The angle in the Range [0, TwoPI].</returns>
        public static double NormalizeAngle(this double angleInRadians)
        {
            var result = angleInRadians % Helper.TwoPI;
            if (result < 0)
                result += Helper.TwoPI;

            return result;
        }
    }
}