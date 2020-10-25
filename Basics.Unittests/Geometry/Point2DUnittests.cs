using Basics.Math;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Geometry.Tests
{
    [TestClass()]
    public class Point2DUnittests
    {
        [TestMethod()]
        public void Point2DTest()
        {
            var point = new Point2D();

            Assert.AreEqual(0, point.X, Helper.E);
            Assert.AreEqual(0, point.Y, Helper.E);
        }

        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(2.425)]
        [DataRow(-7.91)]
        [DataTestMethod()]
        public void Point2DValueTest(double value)
        {
            var point = new Point2D(value);

            Assert.AreEqual(value, point.X, Helper.E);
            Assert.AreEqual(value, point.Y, Helper.E);
        }

        [DataRow(0, -1)]
        [DataRow(1, 0)]
        [DataRow(0.414, -1.717)]
        [DataRow(35.67, -4.29)]
        [DataTestMethod()]
        public void Point2DXYTest(double x, double y)
        {
            var point = new Point2D(x, y);

            Assert.AreEqual(x, point.X, Helper.E);
            Assert.AreEqual(y, point.Y, Helper.E);
        }

        [DataRow(0, 0)]
        [DataRow(-1, 0)]
        [DataRow(-1.414, 1.414)]
        [DataRow(0, 5.67)]
        [DataTestMethod()]
        public void Point2DCopyTest(double x, double y)
        {
            var point = new Point2D(x, y);
            var copiedPoint = new Point2D(point);

            Assert.AreEqual(point.X, copiedPoint.X, Helper.E);
            Assert.AreEqual(point.Y, copiedPoint.Y, Helper.E);
        }

        [TestMethod()]
        public void Point2DFromVectorTest()
        {
            var x = 3.44;
            var y = 4.26;
            var vector = new Vector2D(x, y);
            var point = new Point2D(vector);

            Assert.AreEqual(x, point.X, Helper.E);
            Assert.AreEqual(y, point.Y, Helper.E);
        }

        [DataRow(0, 0, 0, 0, 0, 0)]
        [DataRow(0, 0, -1, 1, -1, 1)]
        [DataRow(-2.33, 4.29, 3.17, -1.34, 0.84, 2.95)]
        [DataTestMethod()]
        public void TranslateTest(double pointX, double pointY, double translateX, double translateY, double resultX, double resultY)
        {
            var point = new Point2D(pointX, pointY);
            var translationVector = new Vector2D(translateX, translateY);
            point.Translate(translationVector);

            Assert.AreEqual(resultX, point.X, Helper.E);
            Assert.AreEqual(resultY, point.Y, Helper.E);
        }

        [DataRow(0, 0, 2.5, 0, 2.5)]
        [DataRow(-3, -3, 5, 5, 11.31370849)]
        [DataRow(3.45, -0.29, -1.38, 3.21, 5.96480511)]
        [DataTestMethod()]
        public void DistanceToPointTest(double pointX, double pointY, double secondPointX, double secondPointY, double result)
        {
            var point = new Point2D(pointX, pointY);
            var secondPoint = new Point2D(secondPointX, secondPointY);

            var distance = point.Distance(secondPoint);
            Assert.AreEqual(result, distance, Helper.E);
        }

        [DataRow(0, 0, 0, 0, 0, 0, 0)]
        [DataTestMethod()]
        public void DistanceToRayTest(double pointX, double pointY, double rayOriginX, double rayOriginY, double rayDirectionX, double rayDirectionY, double result)
        {
            var point = new Point2D(pointX, pointY);
            var ray = new Ray2D(new Point2D(rayOriginX, rayOriginY), new Vector2D(rayDirectionX, rayDirectionY));

            var distance = point.Distance(ray);
            Assert.AreEqual(result, distance, Helper.E);
        }

        [DataRow(1, 0, 90, 0, 1)]
        [DataRow(0.70710678, 0.70710678, -45, 1, 0)]
        [DataRow(0.70710678, 0.70710678, 135, -1, 0)]
        [DataRow(-1.41421356, 1.41421356, 90, -1.41421356, -1.41421356)]
        [DataRow(0.70710678, 0.70710678, 360, 0.70710678, 0.70710678)]
        [DataTestMethod()]
        public void RotateNoOriginTest(double pointX, double pointY, double angleInDegrees, double resultX, double resultY)
        {
            var point = new Point2D(pointX, pointY);
            point.Rotate(Conversion.DegreesToRadians(angleInDegrees));

            Assert.AreEqual(resultX, point.X, Helper.E);
            Assert.AreEqual(resultY, point.Y, Helper.E);
        }

        [DataRow(1, 0, 90, 0, 0, 0, 1)]
        [DataRow(0.70710678, 0.70710678, -45, 0.70710678, 0.70710678, 0.70710678, 0.70710678)]
        [DataRow(0.70710678, -0.70710678, -135, 1.41421356, 0, 1.41421356, 1)]
        [DataRow(2, -1, 90, -1, -2, -2, 1)]
        [DataTestMethod()]
        public void RotateWithOriginTest(double pointX, double pointY, double angleInDegrees, double originX, double originY, double resultX, double resultY)
        {
            var point = new Point2D(pointX, pointY);
            var origin = new Point2D(originX, originY);
            point.Rotate(Conversion.DegreesToRadians(angleInDegrees), origin);

            Assert.AreEqual(resultX, point.X, Helper.E);
            Assert.AreEqual(resultY, point.Y, Helper.E);
        }

        [DataRow(1, 0, 0, 1, -1, 0)]
        [DataRow(0, 2.5, -0.70710678, -0.70710678, 2.5, 0)]
        [DataRow(0.70710678, 0.70710678, 0, 2, -0.70710678, 0.70710678)]
        [DataRow(10, 1, 0, 0, 10, 1)]
        [DataTestMethod()]
        public void ReflectWithVectorTest(double pointX, double pointY, double vectorX, double vectorY, double resultX, double resultY)
        {
            var point = new Point2D(pointX, pointY);
            var vector = new Vector2D(vectorX, vectorY);

            point.Reflect(vector);
            Assert.AreEqual(resultX, point.X, Helper.E);
            Assert.AreEqual(resultY, point.Y, Helper.E);
        }

        [DataRow(1, 0, 1, 1, 1, 0, 1, 2)]
        [DataRow(1, 2, -1, 1, -1, 1, -2, -1)]
        [DataTestMethod()]
        public void ReflectWithRayTest(double pointX, double pointY, double rayOriginX, double rayOriginY, double rayDirectionX, double rayDirectionY, double resultX, double resultY)
        {
            var point = new Point2D(pointX, pointY);
            var ray = new Ray2D(new Point2D(rayOriginX, rayOriginY), new Vector2D(rayDirectionX, rayDirectionY));

            point.Reflect(ray);

            Assert.AreEqual(resultX, point.X, Helper.E);
            Assert.AreEqual(resultY, point.Y, Helper.E);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var point = new Point2D(-2.323, -0.5);
            Assert.AreEqual("X: -2,32 Y: -0,50", point.ToString());
        }

        [TestMethod()]
        public void CloneTestSame()
        {
            var point = new Point2D(6.21, -3.63);
            var clonedPoint = (Point2D)point.Clone();

            Assert.AreEqual(point.X, clonedPoint.X);
            Assert.AreEqual(point.Y, clonedPoint.Y);
        }

        [TestMethod()]
        public void CloneTestDifferent()
        {
            var point = new Point2D(6.21, -3.63);
            var clonedPoint = (Point2D)point.Clone();
            clonedPoint.Y *= -2;

            Assert.AreEqual(point.X, clonedPoint.X);
            Assert.AreNotEqual(point.Y, clonedPoint.Y);
        }

        [DataRow(0, 0, 2.5, 0, 2.5)]
        [DataRow(-3, -3, 5, 5, 11.31370849)]
        [DataRow(3.45, -0.29, -1.38, 3.21, 5.96480511)]
        [DataTestMethod()]
        public void StaticDistanceTest(double pointX, double pointY, double secondPointX, double secondPointY, double result)
        {
            var point = new Point2D(pointX, pointY);
            var secondPoint = new Point2D(secondPointX, secondPointY);

            var distance = Point2D.Distance(point, secondPoint);
            Assert.AreEqual(result, distance, Helper.E);
        }

        [DataRow(1, 0, 90, 0, 1)]
        [DataRow(0.70710678, 0.70710678, -45, 1, 0)]
        [DataRow(0.70710678, 0.70710678, 135, -1, 0)]
        [DataRow(-1.41421356, 1.41421356, 90, -1.41421356, -1.41421356)]
        [DataRow(0.70710678, 0.70710678, 360, 0.70710678, 0.70710678)]
        [DataTestMethod()]
        public void StaticRotateNoOriginTest(double pointX, double pointY, double angleInDegrees, double resultX, double resultY)
        {
            var point = new Point2D(pointX, pointY);
            var rotatedPoint = Point2D.Rotate(point, Conversion.DegreesToRadians(angleInDegrees));

            Assert.AreEqual(resultX, rotatedPoint.X, Helper.E);
            Assert.AreEqual(resultY, rotatedPoint.Y, Helper.E);
        }

        [DataRow(1, 0, 90, 0, 0, 0, 1)]
        [DataRow(0.70710678, 0.70710678, -45, 0.70710678, 0.70710678, 0.70710678, 0.70710678)]
        [DataRow(0.70710678, -0.70710678, -135, 1.41421356, 0, 1.41421356, 1)]
        [DataRow(2, -1, 90, -1, -2, -2, 1)]
        [DataTestMethod()]
        public void StaticRotateWithOriginTest(double pointX, double pointY, double angleInDegrees, double originX, double originY, double resultX, double resultY)
        {
            var point = new Point2D(pointX, pointY);
            var origin = new Point2D(originX, originY);
            var rotatedPoint = Point2D.Rotate(point, Conversion.DegreesToRadians(angleInDegrees), origin);

            Assert.AreEqual(resultX, rotatedPoint.X, Helper.E);
            Assert.AreEqual(resultY, rotatedPoint.Y, Helper.E);
        }

        [DataRow(1, 0, 0, 1, -1, 0)]
        [DataRow(0, 2.5, -0.70710678, -0.70710678, 2.5, 0)]
        [DataRow(0.70710678, 0.70710678, 0, 2, -0.70710678, 0.70710678)]
        [DataRow(10, 1, 0, 0, 10, 1)]
        [DataTestMethod()]
        public void StaticReflectWithVectorTest(double pointX, double pointY, double vectorX, double vectorY, double resultX, double resultY)
        {
            var point = new Point2D(pointX, pointY);
            var vector = new Vector2D(vectorX, vectorY);

            var reflectedPoint = Point2D.Reflect(point, vector);
            Assert.AreEqual(resultX, reflectedPoint.X, Helper.E);
            Assert.AreEqual(resultY, reflectedPoint.Y, Helper.E);
        }

        [DataRow(1, 0, 1, 1, 1, 0, 1, 2)]
        [DataRow(1, 2, -1, 1, -1, 1, -2, -1)]
        [DataTestMethod()]
        public void StaticReflectWithRayTest(double pointX, double pointY, double rayOriginX, double rayOriginY, double rayDirectionX, double rayDirectionY, double resultX, double resultY)
        {
            var point = new Point2D(pointX, pointY);
            var ray = new Ray2D(new Point2D(rayOriginX, rayOriginY), new Vector2D(rayDirectionX, rayDirectionY));

            var reflectedPoint = Point2D.Reflect(point, ray);

            Assert.AreEqual(resultX, reflectedPoint.X, Helper.E);
            Assert.AreEqual(resultY, reflectedPoint.Y, Helper.E);
        }
    }
}