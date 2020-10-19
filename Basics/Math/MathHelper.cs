namespace Basics.Math
{
    public static class Helper
    {
        #region Constants
        /// <summary>
        /// Used for comparing two Numbers. Allowed Delta of the Values for them to be seen as "equal".
        /// </summary>
        public const double E = 0.00001;
        #endregion Constants


        #region Functions
        /// <summary>
        /// Swap two Numbers.
        /// </summary>
        /// <param name="first">First Number.</param>
        /// <param name="second">Second Number.</param>
        public static void Swap(ref double first, ref double second)
        {
            var temp = first;
            first = second;
            second = temp;
        }
        #endregion Functions
    }
}