using Microsoft.VisualStudio.TestTools.UnitTesting;
using Basics.Math;

namespace Basics.Geometry.Tests
{
    [TestClass()]
    public class Ray2DUnittests
    {

        [TestMethod()]
        public void Ray2DTest()
        {
            var ray = new Ray2D();

            Assert.AreEqual(0, ray.Origin.X, Helper.E);
            Assert.AreEqual(0, ray.Origin.Y, Helper.E);
            Assert.AreEqual(0, ray.Direction.X, Helper.E);
            Assert.AreEqual(0, ray.Direction.Y, Helper.E);
        }


        [DataRow(0, -1)]
        [DataRow(1, 0)]
        [DataRow(0.414, -1.717)]
        [DataRow(35.67, -4.29)]
        [DataTestMethod()]
        public void Ray2DOriginTest(double originX, double originY)
        {
            var origin = new Point2D(originX, originY);
            var ray = new Ray2D(origin);

            Assert.AreEqual(originX, ray.Origin.X, Helper.E);
            Assert.AreEqual(originY, ray.Origin.Y, Helper.E);
            Assert.AreEqual(0, ray.Direction.X, Helper.E);
            Assert.AreEqual(0, ray.Direction.Y, Helper.E);
        }

        [DataRow(0, -1)]
        [DataRow(1, 0)]
        [DataRow(0.414, -1.717)]
        [DataRow(35.67, -4.29)]
        [DataTestMethod()]
        public void Ray2DDirectionTest(double directionX, double directionY)
        {
            var direction = new Vector2D(directionX, directionY);
            var ray = new Ray2D(direction);

            Assert.AreEqual(0, ray.Origin.X, Helper.E);
            Assert.AreEqual(0, ray.Origin.Y, Helper.E);
            Assert.AreEqual(directionX, ray.Direction.X, Helper.E);
            Assert.AreEqual(directionY, ray.Direction.Y, Helper.E);
        }

        [DataRow(0, -1, 2, 3)]
        [DataRow(-2.33, 1.45, 1, -1)]
        [DataTestMethod()]
        public void Ray2DOriginDirectionTest(double originX, double originY, double directionX, double directionY)
        {
            var origin = new Point2D(originX, originY);
            var direction = new Vector2D(directionX, directionY);
            var ray = new Ray2D(origin, direction);

            Assert.AreEqual(originX, ray.Origin.X, Helper.E);
            Assert.AreEqual(originY, ray.Origin.Y, Helper.E);
            Assert.AreEqual(directionX, ray.Direction.X, Helper.E);
            Assert.AreEqual(directionY, ray.Direction.Y, Helper.E);
        }

        [DataRow(0, -1, 2, 3)]
        [DataRow(-2.33, 1.45, 1, -1)]
        [DataTestMethod()]
        public void Ray2DCopyTest(double originX, double originY, double directionX, double directionY)
        {
            var origin = new Point2D(originX, originY);
            var direction = new Vector2D(directionX, directionY);
            var existingRay = new Ray2D(origin, direction);
            var newRay = new Ray2D(existingRay);

            Assert.AreEqual(originX, newRay.Origin.X, Helper.E);
            Assert.AreEqual(originY, newRay.Origin.Y, Helper.E);
            Assert.AreEqual(directionX, newRay.Direction.X, Helper.E);
            Assert.AreEqual(directionY, newRay.Direction.Y, Helper.E);
        }

        [DataRow(0, 0, 0, 0, 0, 0, 0, 0)]
        [DataRow(9.5, 5.5, 5, -3, 0, 1, 5, 5.5)]
        [DataRow(9.5, 5.5, 5, -3, 0, 4.5, 5, 5.5)]
        [DataRow(9.5, 5.5, 0, 5, 1, 1, 5, 10)]
        [DataTestMethod()]
        public void ClosestPointOnRayTest(double pointX, double pointY, double rayOriginX, double rayOriginY, double rayDirectionX, double rayDirectionY, double nearestPointX, double nearestPointY)
        {
            var point = new Point2D(pointX, pointY);
            var ray = new Ray2D(new Point2D(rayOriginX, rayOriginY), new Vector2D(rayDirectionX, rayDirectionY));

            var closestPoint = ray.ClosestPointOnRay(point);
            Assert.AreEqual(nearestPointX, closestPoint.X, Helper.E);
            Assert.AreEqual(nearestPointY, closestPoint.Y, Helper.E);
        }

        [DataRow(0, 0, 0, 0, 0, 0, 0)]
        [DataRow(9.5, 5.5, 0, 5, 1, 1, 6.36396103)]
        [DataRow(9.5, 10, -5, -5, 0, -3, 14.5)]
        [DataTestMethod()]
        public void DistanceTest(double pointX, double pointY, double rayOriginX, double rayOriginY, double rayDirectionX, double rayDirectionY, double result)
        {
            var point = new Point2D(pointX, pointY);
            var ray = new Ray2D(new Point2D(rayOriginX, rayOriginY), new Vector2D(rayDirectionX, rayDirectionY));

            var distance = ray.Distance(point);
            Assert.AreEqual(result, distance, Helper.E);
        }

        [DataRow(0, 0, 1, 0, 5, -5, 0, 1, 5, 0)]
        [DataRow(0, 0, 10, 0, 5, -5, 0, 1, 5, 0)]
        [DataRow(0, 0, 2, 2, 5, -5, 0, 1, 5, 5)]
        [DataRow(0, 0, 1, 0, 8, 1, -1, -1, 7, 0)]
        [DataRow(0, 0, 2, 2, 8, 3, -1, -1, double.PositiveInfinity, double.PositiveInfinity)]
        [DataTestMethod()]
        public void IntersectionTest(double firstOriginX, double firstOriginY, double firstDirectionX, double firstDirectionY,
                                     double secondOriginX, double secondOriginY, double secondDirectionX, double secondDirectionY, double resultX, double resultY)
        {
            var firstRay = new Ray2D(new Point2D(firstOriginX, firstOriginY), new Vector2D(firstDirectionX, firstDirectionY));
            var secondRay = new Ray2D(new Point2D(secondOriginX, secondOriginY), new Vector2D(secondDirectionX, secondDirectionY));

            var intersectionPoint = firstRay.Intersection(secondRay);
            if (resultX == double.PositiveInfinity || resultY == double.PositiveInfinity)
                Assert.AreEqual(null, intersectionPoint);
            else
            {
                Assert.AreEqual(resultX, intersectionPoint.X, Helper.E);
                Assert.AreEqual(resultY, intersectionPoint.Y, Helper.E);
            }
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var ray = new Ray2D(new Point2D(3.45, -23.45653), new Vector2D(4.3482, -1209.23829));
            var result = $"Origin: [X: 3,45 Y: -23,46], Direction: [X: 4,35 Y: -1209,24]";

            Assert.AreEqual(result, ray.ToString());
        }

        [TestMethod()]
        public void CloneEqualValuesTest()
        {
            var ray = new Ray2D(new Point2D(0, 0), new Vector2D(1, 0));
            var clonedRay = (Ray2D)ray.Clone();

            Assert.AreEqual(ray.Origin.X, clonedRay.Origin.X, Helper.E);
            Assert.AreEqual(ray.Origin.Y, clonedRay.Origin.Y, Helper.E);
            Assert.AreEqual(ray.Direction.X, clonedRay.Direction.X, Helper.E);
            Assert.AreEqual(ray.Direction.Y, clonedRay.Direction.Y, Helper.E);
        }

        [TestMethod()]
        public void CloneNotEqualValuesTest()
        {
            var ray = new Ray2D(new Point2D(0, 0), new Vector2D(1, 0));
            var clonedRay = (Ray2D)ray.Clone();
            clonedRay.Origin.Translate(Vector2D.One);
            clonedRay.Direction.RotateDegrees(45);

            Assert.AreNotEqual(ray.Origin.X, clonedRay.Origin.X, Helper.E);
            Assert.AreNotEqual(ray.Origin.Y, clonedRay.Origin.Y, Helper.E);
            Assert.AreNotEqual(ray.Direction.X, clonedRay.Direction.X, Helper.E);
            Assert.AreNotEqual(ray.Direction.Y, clonedRay.Direction.Y, Helper.E);
        }

        [DataRow(0, 0, 0, 0, 0, 0, 0, 0)]
        [DataRow(9.5, 5.5, 5, -3, 0, 1, 5, 5.5)]
        [DataRow(9.5, 5.5, 5, -3, 0, 4.5, 5, 5.5)]
        [DataRow(9.5, 5.5, 0, 5, 1, 1, 5, 10)]
        [DataTestMethod()]
        public void StaticClosestPointOnRayTest(double pointX, double pointY, double rayOriginX, double rayOriginY, double rayDirectionX, double rayDirectionY, double nearestPointX, double nearestPointY)
        {
            var point = new Point2D(pointX, pointY);
            var ray = new Ray2D(new Point2D(rayOriginX, rayOriginY), new Vector2D(rayDirectionX, rayDirectionY));

            var closestPoint = Ray2D.ClosestPointOnRay(ray, point);
            Assert.AreEqual(nearestPointX, closestPoint.X, Helper.E);
            Assert.AreEqual(nearestPointY, closestPoint.Y, Helper.E);
        }

        [DataRow(0, 0, 0, 0, 0, 0, 0)]
        [DataRow(9.5, 5.5, 0, 5, 1, 1, 6.36396103)]
        [DataRow(9.5, 10, -5, -5, 0, -3, 14.5)]
        [DataTestMethod()]
        public void StaticDistanceTest(double pointX, double pointY, double rayOriginX, double rayOriginY, double rayDirectionX, double rayDirectionY, double result)
        {
            var point = new Point2D(pointX, pointY);
            var ray = new Ray2D(new Point2D(rayOriginX, rayOriginY), new Vector2D(rayDirectionX, rayDirectionY));

            var distance = Ray2D.Distance(ray, point);
            Assert.AreEqual(result, distance, Helper.E);
        }

        [DataRow(0, 0, 1, 0, 5, -5, 0, 1, 5, 0)]
        [DataRow(0, 0, 10, 0, 5, -5, 0, 1, 5, 0)]
        [DataRow(0, 0, 2, 2, 5, -5, 0, 1, 5, 5)]
        [DataRow(0, 0, 1, 0, 8, 1, -1, -1, 7, 0)]
        [DataRow(0, 0, 2, 2, 8, 3, -1, -1, double.PositiveInfinity, double.PositiveInfinity)]
        [DataTestMethod()]
        public void StaticIntersectionTest(double firstOriginX, double firstOriginY, double firstDirectionX, double firstDirectionY,
                                     double secondOriginX, double secondOriginY, double secondDirectionX, double secondDirectionY, double resultX, double resultY)
        {
            var firstRay = new Ray2D(new Point2D(firstOriginX, firstOriginY), new Vector2D(firstDirectionX, firstDirectionY));
            var secondRay = new Ray2D(new Point2D(secondOriginX, secondOriginY), new Vector2D(secondDirectionX, secondDirectionY));

            var intersectionPoint = Ray2D.Intersection(firstRay, secondRay);
            if (resultX == double.PositiveInfinity || resultY == double.PositiveInfinity)
                Assert.AreEqual(null, intersectionPoint);
            else
            {
                Assert.AreEqual(resultX, intersectionPoint.X, Helper.E);
                Assert.AreEqual(resultY, intersectionPoint.Y, Helper.E);
            }

            var intersectionPoint2 = Ray2D.Intersection(secondRay, firstRay);
            if (resultX == double.PositiveInfinity || resultY == double.PositiveInfinity)
                Assert.AreEqual(null, intersectionPoint2);
            else
            {
                Assert.AreEqual(resultX, intersectionPoint2.X, Helper.E);
                Assert.AreEqual(resultY, intersectionPoint2.Y, Helper.E);
            }
        }
    }
}