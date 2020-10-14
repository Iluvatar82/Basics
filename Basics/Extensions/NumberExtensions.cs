using Basics.Geometry;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basics.Mathhelper
{
    public static class NumberExtensions
    {
        public static double DecimalValue(this double value) => value - (int)value;

        public static double Constrain(this double value, double minimum, double maximum) => value < minimum ? minimum : (value > maximum ? maximum : value);

        public static double Map(this double value, double from, double to, double fromNew, double toNew)
        {
            var range = to - from;
            if (range == 0)
                return value;

            return (toNew - fromNew) * value.Fraction(from, to) + fromNew;
        }

        public static double Fraction(this double value, double from, double to)
        {
            var range = to - from;
            if (range == 0)
                return value;

            return (value - from) / range;
        }

        public static double Interpolate(this double position, double fromPosition, double toPosition, double valueFrom, double valueTo) => position.Map(fromPosition, toPosition, valueFrom, valueTo);
        
        public static double Interpolate(this Point2D point, double valueLowerLeft, double valueLowerRight, double valueUpperLeft, double valueUpperRight)
        {
            var lowerValueInterpolation = point.X.DecimalValue().Interpolate(0, 1, valueLowerLeft, valueLowerRight);
            var upperValueInterpolation = point.X.DecimalValue().Interpolate(0, 1, valueUpperLeft, valueUpperRight);
            return point.Y.DecimalValue().Interpolate(0, 1, lowerValueInterpolation, upperValueInterpolation);
        }
    }
}