namespace Basics.MathHelper
{
    public static class Conversion
    {
        public const double E = 0.00001;
        public const double DEGREE_RADIANS_FACTOR = System.Math.PI / 180d;
        public const double RADIANS_DEGREES_FACTOR = 1d / DEGREE_RADIANS_FACTOR;


        public static double DegreesToRadians(double angle) => DEGREE_RADIANS_FACTOR * angle;
        public static double RadiansToDegrees(double angle) => RADIANS_DEGREES_FACTOR * angle;
    }
}