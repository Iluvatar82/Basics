﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Math.Tests
{
    [TestClass()]
    public class ConversionUnittests
    {
        [DataRow(0, 0)]
        [DataRow(90, System.Math.PI / 2)]
        [DataRow(240, System.Math.PI * 4 / 3)]
        [DataRow(-45, -System.Math.PI / 4)]
        [DataTestMethod()]
        public void DegreesToRadiansTest(double degrees, double radians)
        {
            var result = Conversion.DegreesToRadians(degrees);

            Assert.AreEqual(result, radians, Helper.E);
        }

        [DataRow(0, 0)]
        [DataRow(System.Math.PI / 2, 90)]
        [DataRow(System.Math.PI * 4 / 3, 240)]
        [DataRow(-System.Math.PI / 4, -45)]
        [DataTestMethod()]
        public void RadiansToDegreesTest(double radians, double degrees)
        {
            var result = Conversion.RadiansToDegrees(radians);

            Assert.AreEqual(result, degrees, Helper.E);
        }
    }
}