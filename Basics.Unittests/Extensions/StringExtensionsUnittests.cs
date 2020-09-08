using Basics.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Extensions.Tests
{
    [TestClass]
    public class StringExtensionsUnittests
    {
        [DataRow(null, null, null)]
        [DataRow(null, "test", null)]
        [DataRow("test", null, "test")]
        [DataRow("TestMethod", "Test", "Method")]
        [DataRow("TestTestMethod", "Test", "Method")]
        [DataRow("TestTesMethod", "Test", "TesMethod")]
        [DataRow("TTTTTMethod", "T", "Method")]
        [DataTestMethod]
        public void TrimStartTest(string baseString, string stringToTrim, string resultString)
        {
            Assert.AreEqual(baseString?.TrimStart(stringToTrim), resultString);
        }

        [DataRow(null, null, null)]
        [DataRow(null, "test", null)]
        [DataRow("test", null, "test")]
        [DataRow("MethodTest", "Test", "Method")]
        [DataRow("MethodTestTest", "Test", "Method")]
        [DataRow("MethodTesTest", "Test", "MethodTes")]
        [DataRow("MethodTTTTT", "T", "Method")]
        [DataTestMethod]
        public void TrimEndTest(string baseString, string stringToTrim, string resultString)
        {
            Assert.AreEqual(baseString?.TrimEnd(stringToTrim), resultString);
        }

        [DataRow(null, null, null)]
        [DataRow(null, "test", null)]
        [DataRow("test", null, "test")]
        [DataRow("TestMethodTest", "Test", "Method")]
        [DataRow("TestMethodTestTest", "Test", "Method")]
        [DataRow("TTMethodTTTTT", "T", "Method")]
        [DataRow("  Method         ", " ", "Method")]
        [DataTestMethod]
        public void TrimTest(string baseString, string stringToTrim, string resultString)
        {
            Assert.AreEqual(baseString?.Trim(stringToTrim), resultString);
        }

        [DataRow(null, null)]
        [DataRow("test", "Test")]
        [DataRow("teSt", "TeSt")]
        [DataRow("this is  a test", "This Is  A Test")]
        [DataTestMethod]
        public void CapitalizeFirstCharacterTest(string baseString, string resultString)
        {
            Assert.AreEqual(baseString?.CapitalizeFirstCharacter(), resultString);
        }

        [DataRow("test", null, "\0test\0")]
        [DataRow("test", ' ', " test ")]
        [DataRow("test", '_', "_test_")]
        [DataTestMethod]
        public void DecorateStartEndTest(string toDecorate, char decorator, string resultString)
        {
            Assert.AreEqual(toDecorate?.DecorateStartEnd(decorator), resultString);
        }

        [DataRow("test", null, "test")]
        [DataRow("test", "", "test")]
        [DataRow("test", "__", "__test__")]
        [DataRow("", "__", "____")]
        [DataRow("b", "aba", "abababa")]
        [DataTestMethod]
        public void DecorateStartEndTest(string toDecorate, string decorator, string resultString)
        {
            Assert.AreEqual(toDecorate?.DecorateStartEnd(decorator), resultString);
        }

        [DataRow(null, null)]
        [DataRow("", "\'\'")]
        [DataRow("\'", "\'\'\'")]
        [DataRow("SQL", "\'SQL\'")]
        [DataRow("0001", "\'0001\'")]
        [DataRow("EntityFramework", "\'EntityFramework\'")]
        [DataTestMethod]
        public void SQLStringifyTest(string toDecorate, string resultString)
        {
            Assert.AreEqual(toDecorate?.SQLStringify(), resultString);
        }
    }
}