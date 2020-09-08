using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Basics.MathHelper.Tests
{
    [TestClass()]
    public class ConversionUnittests
    {
        [DataRow(0, 0)]
        [DataRow(90, Math.PI / 2)]
        [DataRow(240, Math.PI * 4 / 3)]
        [DataRow(-45, -Math.PI / 4)]
        [DataTestMethod()]
        public void DegreesToRadiansTest(double degrees, double radians)
        {
            var result = Conversion.DegreesToRadians(degrees);

            Assert.AreEqual(result, radians, Conversion.E);
        }

        [DataRow(0, 0)]
        [DataRow(Math.PI / 2, 90)]
        [DataRow(Math.PI * 4 / 3, 240)]
        [DataRow(-Math.PI / 4, -45)]
        [DataTestMethod()]
        public void RadiansToDegreesTest(double radians, double degrees)
        {
            var result = Conversion.RadiansToDegrees(radians);

            Assert.AreEqual(result, degrees, Conversion.E);
        }
    }
}