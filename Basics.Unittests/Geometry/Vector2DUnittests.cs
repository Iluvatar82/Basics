using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Geometry.Tests
{
    [TestClass()]
    public class Vector2DUnittests
    {
        [TestMethod]
        public void Vector2DTest()
        {
            var vector2D = new Vector2D();

            Assert.AreEqual(vector2D.X, 0);
            Assert.AreEqual(vector2D.Y, 0);
        }

        [DataRow(0)]
        [DataRow(1)]
        [DataRow(1.414)]
        [DataRow(35.67)]
        [DataTestMethod()]
        public void Vector2DTest(double value)
        {
            var vector2D = new Vector2D(value);

            Assert.AreEqual(vector2D.X, value);
            Assert.AreEqual(vector2D.Y, value);
        }

        [DataRow(0, 0)]
        [DataRow(1, 0)]
        [DataRow(1.414, 1.414)]
        [DataRow(0, 35.67)]
        [DataTestMethod()]
        public void Vector2DTest(double x, double y)
        {
            var vector2D = new Vector2D(x, y);

            Assert.AreEqual(vector2D.X, x);
            Assert.AreEqual(vector2D.Y, y);
        }

        [DataRow(0, 0)]
        [DataRow(1, 0)]
        [DataRow(1.414, 1.414)]
        [DataRow(0, 35.67)]
        [DataTestMethod()]
        public void Vector2DTest(double x, double y, bool use = true)
        {
            var vector = new Vector2D(x, y);
            var vector2D = new Vector2D(vector);

            Assert.AreEqual(vector2D.X, vector.X);
            Assert.AreEqual(vector2D.Y, vector.Y);
        }

        [DataRow(0, 0, 0)]
        [DataRow(1, 0)]
        [DataRow(1.414, 1.414)]
        [DataRow(0, 35.67)]
        [DataTestMethod()]
        public void NormalizeTest(double x, double y, double length = 1)
        {
            var vector = new Vector2D(x, y);
            vector.Normalize();

            Assert.AreEqual(vector.Length, length, Math.Helper.E);
        }

        [DataRow(0, 0, 2)]
        [DataRow(1, 0, 3)]
        [DataRow(1.414, 1.414, 0.5)]
        [DataRow(0, 35.67, 0)]
        [DataTestMethod()]
        public void ScaleTest(double x, double y, double factor)
        {
            var vector = new Vector2D(x, y);
            vector.Scale(factor);

            Assert.AreEqual(vector.X, x * factor, Math.Helper.E);
            Assert.AreEqual(vector.Y, y * factor, Math.Helper.E);
        }

        [DataRow(1, 0, Math.Conversion.DEGREE_RADIANS_FACTOR * -90, 0, -1)]
        [DataRow(1.414, 1.414, Math.Conversion.DEGREE_RADIANS_FACTOR * 45, 0, 1)]
        [DataTestMethod()]
        public void RotateTest(double x, double y, double angle, double resultX, double resultY)
        {
            var vector = new Vector2D(x, y);
            vector.Normalize();
            vector.Rotate(angle);

            Assert.AreEqual(vector.X, resultX, Math.Helper.E);
            Assert.AreEqual(vector.Y, resultY, Math.Helper.E);
        }

        [DataRow(1, 0, -90, 0, -1)]
        [DataRow(1.414, 1.414, 45, 0, 1)]
        [DataTestMethod()]
        public void RotateDegreesTest(double x, double y, double angle, double resultX, double resultY)
        {
            var vector = new Vector2D(x, y);
            vector.Normalize();
            vector.RotateDegrees(angle);

            Assert.AreEqual(vector.X, resultX, Math.Helper.E);
            Assert.AreEqual(vector.Y, resultY, Math.Helper.E);
        }

        [DataRow(1, 0, 0, 1, 0)]
        [DataRow(1, 0, 1, 0, 1)]
        [DataRow(1.414, 1.414, -1.414, 1.414, 0)]
        [DataRow(1, 0, -1, 0, -1)]
        [DataTestMethod()]
        public void DotTest(double x1, double y1, double x2, double y2, double result)
        {
            var vector1 = new Vector2D(x1, y1);
            vector1.Normalize();
            var vector2 = new Vector2D(x2, y2);
            vector2.Normalize();
            Assert.AreEqual(result, vector1.Dot(vector2), Math.Helper.E);
        }
    }
}