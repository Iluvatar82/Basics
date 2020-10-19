using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Basics.Extensions.Tests
{
    [TestClass]
    public class LinqExtensionsUnittests
    {
        [TestMethod]
        public void Remove()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            var filter = new Func<int, bool>(i => i % 2 == 0);
            var resultCount = 3;

            Assert.AreEqual(resultCount, list.Remove(filter).ToList().Count);
        }
    }
}