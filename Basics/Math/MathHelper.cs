namespace Basics.Math
{
    public static class Helper
    {
        public const double E = 0.00001;

        public static void Swap(ref double first, ref double second)
        {
            var temp = first;
            first = second;
            second = temp;
        }
    }
}