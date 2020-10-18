using Basics.Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Extensions.Tests
{
    [TestClass]
    public class NumberExtensionsUnittests
    {

        [DataRow(1, 0)]
        [DataRow(1.1, 0.1)]
        [DataRow(-3.456, -0.456)]
        [DataRow(2.9999, 0.9999)]
        [DataTestMethod()]
        public void DecimalValue(double value, double result)
        {
            Assert.AreEqual(value.DecimalValue(), result, Math.Helper.E);
        }

        [DataRow(1.1, 0.1)]
        [DataTestMethod()]
        public void Swap(double first, double second)
        {
            var one = second;
            var two = first;
            Math.Helper.Swap(ref first, ref second);
            Assert.AreEqual(one, first, Math.Helper.E);
            Assert.AreEqual(two, second, Math.Helper.E);
        }

        [DataRow(0.54, 0, 1, 0.54)]
        [DataRow(0.0, 0, 1, 0)]
        [DataRow(0, 1, 3, 1)]
        [DataRow(4.32, 0, 2.76, 2.76)]
        [DataRow(4.32, 2.76, 0, 2.76)]
        [DataRow(-4.45, -3.99, 1, -3.99)]
        [DataRow(-0.54, -2.34, -1, -1)]
        [DataTestMethod()]
        public void Constrain(double value, double minimum, double maximum, double result)
        {
            Assert.AreEqual(value.Constrain(minimum, maximum), result, Math.Helper.E);
        }

        [DataRow(0, 0, 1, 0)]
        [DataRow(0, -1, 0, 1)]
        [DataRow(0, -1, 1, 0.5)]
        [DataRow(1, -1, 5, 0.33333)]
        [DataRow(-4.5, -4.8, -4.4, 0.75)]
        [DataRow(0.15, 0.05, 0.25, 0.5)]
        [DataRow(3.3, 1.1, 2.2, 2)]
        [DataRow(4, 8, 6, 2)]
        [DataRow(3, 6, 8, -1.5)]
        [DataTestMethod()]
        public void Fraction(double value, double from, double to, double result)
        {
            Assert.AreEqual(value.Fraction(from, to), result, Math.Helper.E);
        }

        [DataRow(0, 0, 1, 10, 11, 10)]
        [DataRow(0.5, 0, 2, 10, 14, 11)]
        [DataRow(0, 0, 0, 0, 0, 0)]
        [DataRow(0, 0, 1, -1, -1, -1)]
        [DataRow(18, 10, 20, -34, -33, -33.2)]
        [DataRow(-1, -1, 1, 0, 100, 0)]
        [DataRow(0.75, -1, 1, 80, 160, 150)]
        [DataRow(256, 0, 640, 0, 2560, 1024)]
        [DataTestMethod()]
        public void Map(double value, double from, double to, double fromNew, double toNew, double result)
        {
            Assert.AreEqual(value.Map(from, to, fromNew, toNew), result, Math.Helper.E);
        }

        [DataRow(0, 0, 1, 10, 11, 10)]
        [DataRow(0.5, 0, 2, 10, 14, 11)]
        [DataRow(0, 0, 0, 0, 0, 0)]
        [DataRow(0, 0, 1, -1, -1, -1)]
        [DataRow(18, 10, 20, -34, -33, -33.2)]
        [DataRow(-1, -1, 1, 0, 100, 0)]
        [DataRow(0.75, -1, 1, 80, 160, 150)]
        [DataRow(256, 0, 640, 0, 2560, 1024)]
        [DataTestMethod()]
        public void Interpolate(double position, double fromPosition, double toPosition, double valueFrom, double valueTo, double result)
        {
            Assert.AreEqual(position.Interpolate(fromPosition, toPosition, valueFrom, valueTo), result, Math.Helper.E);
        }

        [DataRow(0, 0, 0, 1, 0, 1, 0)]
        [DataRow(0, 1, 0, 1, 0, 1, 0)]
        [DataRow(0.5, 0, 0, 1, 0, 1, 0.5)]
        [DataRow(0.5, 1, 0, 1, 0, 1, 0.5)]
        [DataRow(1, 0, 0, 1, 0, 1, 1)]
        [DataRow(1, 1, 0, 1, 0, 1, 1)]
        [DataRow(0.5, .5, 0, 0, 1, 1, 0.5)]
        [DataRow(0, 0, 0, 0, 1, 1, 0)]
        [DataRow(1, 0, 0, 0, 1, 1, 0)]
        [DataRow(0, 0.5, 0, 0, 1, 1, 0.5)]
        [DataRow(1, 0.5, 0, 0, 1, 1, 0.5)]
        [DataRow(0, 1, 0, 0, 1, 1, 1)]
        [DataRow(1, 1, 0, 0, 1, 1, 1)]
        [DataRow(0.5, 0.5, 0, 0, 1, 1, 0.5)]
        [DataRow(1, 0, 0, 1, 1, 2, 1)]
        [DataTestMethod()]
        public void InterpolatePoint(double pointX, double pointY, double valueLowerLeft, double valueLowerRight, double valueUpperLeft, double valueUpperRight, double result)
        {
            var point = new Point2D(pointX, pointY);
            Assert.AreEqual(point.Interpolate(valueLowerLeft, valueLowerRight, valueUpperLeft, valueUpperRight), result, Math.Helper.E);
        }
    }
}