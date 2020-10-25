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

        [TestMethod()]
        public void ItemToEnumerableTest()
        {
            var item = 4783;
            var enumerableItem = item.ItemToEnumerable();
            Assert.AreEqual(1, enumerableItem.Count());
            Assert.AreEqual(item, enumerableItem.ElementAt(0));
        }

        [TestMethod()]
        public void ItemToListTest()
        {
            var item = 4783;
            var listItem = item.ItemToList();
            Assert.AreEqual(1, listItem.Count);
            Assert.AreEqual(item, listItem[0]);
        }

        [TestMethod()]
        public void RepeatTest()
        {
            var item = new { Message = "SingleItem" };
            var repeatedItem = item.Repeat(4);
            Assert.AreEqual(4, repeatedItem.Count());
            Assert.AreEqual(item, repeatedItem.ElementAt(2));
            Assert.AreEqual(item, repeatedItem.ElementAt(3));
        }
    }
}