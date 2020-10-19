namespace Basics.Math
{
    public static class Conversion
    {
        #region Constants
        /// <summary>
        /// Used to convert Degrees to Radians.
        /// </summary>
        public const double DEGREE_RADIANS_FACTOR = System.Math.PI / 180d;
        /// <summary>
        /// Used to convert Radians to Degrees.
        /// </summary>
        public const double RADIANS_DEGREES_FACTOR = 1d / DEGREE_RADIANS_FACTOR;
        #endregion Constants


        #region Functions
        /// <summary>
        /// Converts an <paramref name="angle"/> from Degrees to an Angle in Radians.
        /// </summary>
        /// <param name="angle">The Angle in Degrees.</param>
        /// <returns>The Angle in Radians.</returns>
        public static double DegreesToRadians(double angle) => DEGREE_RADIANS_FACTOR * angle;

        /// <summary>
        /// Converts an <paramref name="angle"/> from Radians to an Angle in Degrees.
        /// </summary>
        /// <param name="angle">The Angle in Radians.</param>
        /// <returns>The Angle in Degrees.</returns>
        public static double RadiansToDegrees(double angle) => RADIANS_DEGREES_FACTOR * angle;
        #endregion Functions
    }
}