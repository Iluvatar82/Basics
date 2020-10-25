using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Extensions.Tests
{
    [TestClass()]
    public class CharacterExtensionsUnittests
    {
        [DataRow('a', 3, "aaa")]
        [DataRow('r', 7, "rrrrrrr")]
        [DataTestMethod()]
        public void RepeatTest(char character, int times, string resultingString)
        {
            var repeatedString = character.Repeat(times);
            Assert.AreEqual(resultingString, repeatedString);
        }
    }
}