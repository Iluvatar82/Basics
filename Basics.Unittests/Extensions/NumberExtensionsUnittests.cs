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
            Assert.AreEqual(value.DecimalValue(), result, Math.MathHelper.E);
        }

        [DataRow(1.1, 0.1)]
        [DataTestMethod()]
        public void Swap(double first, double second)
        {
            var one = second;
            var two = first;
            Math.MathHelper.Swap(ref first, ref second);
            Assert.AreEqual(one, first, Math.MathHelper.E);
            Assert.AreEqual(two, second, Math.MathHelper.E);
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
            Assert.AreEqual(value.Constrain(minimum, maximum), result, Math.MathHelper.E);
        }

        [TestMethod]
        public void Map(double value, double from, double to, double fromNew, double toNew, double result)
        {
            
        }

        [TestMethod]
        public void Fraction(double value, double from, double to, double result)
        {
            
        }

        [TestMethod]
        public void Interpolate(double position, double fromPosition, double toPosition, double valueFrom, double valueTo, double result)
        {

        }

        [TestMethod]
        public void Interpolate(Point2D point, double valueLowerLeft, double valueLowerRight, double valueUpperLeft, double valueUpperRight, double result)
        {

        }
    }
}