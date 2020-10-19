using Basics.Geometry;
using Basics.Math;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.InteropServices.ComTypes;

namespace Basics.Geometry.Tests
{
    [TestClass()]
    public class Vector2DUnittests
    {
        [TestMethod]
        public void Vector2DTest()
        {
            var vector2D = new Vector2D();

            Assert.AreEqual(0, vector2D.X, Helper.E);
            Assert.AreEqual(0, vector2D.Y, Helper.E);
        }

        [DataRow(0)]
        [DataRow(1)]
        [DataRow(1.414)]
        [DataRow(35.67)]
        [DataTestMethod()]
        public void Vector2DValueTest(double value)
        {
            var vector2D = new Vector2D(value);

            Assert.AreEqual(value, vector2D.X, Helper.E);
            Assert.AreEqual(value, vector2D.Y, Helper.E);
        }

        [DataRow(0, 0)]
        [DataRow(1, 0)]
        [DataRow(1.414, 1.414)]
        [DataRow(0, 35.67)]
        [DataTestMethod()]
        public void Vector2DXYTest(double x, double y)
        {
            var vector2D = new Vector2D(x, y);

            Assert.AreEqual(x, vector2D.X, Helper.E);
            Assert.AreEqual(y, vector2D.Y, Helper.E);
        }

        [DataRow(0, 0)]
        [DataRow(1, 0)]
        [DataRow(1.414, 1.414)]
        [DataRow(0, 35.67)]
        [DataTestMethod()]
        public void Vector2DCopyTest(double x, double y)
        {
            var vector = new Vector2D(x, y);
            var vector2D = new Vector2D(vector);

            Assert.AreEqual(vector.X, vector2D.X, Helper.E);
            Assert.AreEqual(vector.Y, vector2D.Y, Helper.E);
        }

        [TestMethod]
        public void Vector2DFromPointTest()
        {
            var x = 3.44;
            var y = 4.26;
            var point = new Point2D(x, y);
            var vector = new Vector2D(point);

            Assert.AreEqual(x, vector.X, Helper.E);
            Assert.AreEqual(y, vector.Y, Helper.E);
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

            Assert.AreEqual(length, vector.Length, Helper.E);
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

            Assert.AreEqual(x * factor, vector.X, Helper.E);
            Assert.AreEqual(y * factor, vector.Y, Helper.E);
        }

        [DataRow(1, 0, Math.Conversion.DEGREE_RADIANS_FACTOR * -90, 0, -1)]
        [DataRow(1.414, 1.414, Math.Conversion.DEGREE_RADIANS_FACTOR * 45, 0, 1)]
        [DataTestMethod()]
        public void RotateTest(double x, double y, double angle, double resultX, double resultY)
        {
            var vector = new Vector2D(x, y);
            vector.Normalize();
            vector.Rotate(angle);

            Assert.AreEqual(resultX, vector.X, Helper.E);
            Assert.AreEqual(resultY, vector.Y, Helper.E);
        }

        [DataRow(1, 0, -90, 0, -1)]
        [DataRow(1.414, 1.414, 45, 0, 1)]
        [DataTestMethod()]
        public void RotateDegreesTest(double x, double y, double angle, double resultX, double resultY)
        {
            var vector = new Vector2D(x, y);
            vector.Normalize();
            vector.RotateDegrees(angle);

            Assert.AreEqual(resultX, vector.X, Helper.E);
            Assert.AreEqual(resultY, vector.Y, Helper.E);
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

        [DataRow(1, 0, true)]
        [DataRow(1, 1, false)]
        [DataRow(0, 0, false)]
        [DataTestMethod()]
        public void IsNormalizedTest(double x, double y, bool normalized)
        {
            var vector = new Vector2D(x, y);
            Assert.AreEqual(normalized, vector.IsNormalized);
        }

        [DataRow(1, 0, 1, 1, 45)]
        [DataRow(1, 1, 1, 0, 45)]
        [DataRow(1, 0, 0, 1, 90)]
        [DataRow(1, 0, -1, 0, 180)]
        [DataRow(1, 0, -1, 1, 135)]
        [DataRow(1, 0, 0.5, 0.86602540, 60)]
        [DataTestMethod()]
        public void AngleBetweenTest(double x1, double y1, double x2, double y2, double expectedAngleInDegrees)
        {
            var vector1 = new Vector2D(x1, y1);
            var vector2 = new Vector2D(x2, y2);

            var angle = vector1.AngleBetween(vector2);
            Assert.AreEqual(Conversion.DegreesToRadians(expectedAngleInDegrees), angle, Helper.E);
        }

        [TestMethod()]
        public void OppositeTest()
        {
            var x = 0.5;
            var y = 0.86602540;
            var vector = new Vector2D(x, y);
            vector.Opposite();
            Assert.AreEqual(-x, vector.X, Helper.E);
            Assert.AreEqual(-y, vector.Y, Helper.E);
        }

        [DataRow(1, 0, 1, 1, 1, 0)]
        [DataRow(1, 0, 0.92387953, 0.38268343, 0.70710678, 0.70710678)]
        [DataTestMethod()]
        public void ReflectTest(double x1, double y1, double x2, double y2, double reflectX, double reflectY)
        {
            var vector1 = new Vector2D(x1, y1);
            var vector2 = new Vector2D(x2, y2);

            vector1.Reflect(vector2);
            Assert.AreEqual(reflectX, vector1.X, Helper.E);
            Assert.AreEqual(reflectY, vector1.Y, Helper.E);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CloneTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void StaticDotTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void StaticAngleBetweenTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void StaticReflectTest()
        {
            Assert.Fail();
        }
    }
}