using Microsoft.VisualStudio.TestTools.UnitTesting;
using Basics.DataTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basics.DataTypes.Tests
{
    [TestClass()]
    public class TreeUnittests
    {
        [TestMethod()]
        public void TreeTest()
        {
            var tree = new Tree<int>(5);

            Assert.AreEqual(tree.Root.IsRoot, true);
            Assert.AreEqual(tree.Root.IsLeaf, true);
            Assert.AreEqual(tree.Root.Value, 5);
            Assert.AreEqual(tree.Height, 1);
            Assert.AreEqual(tree.NodeCount, 1);
            Assert.AreEqual(tree.Root.Height, 1);
            Assert.AreEqual(tree.Root.Count, 1);
        }

        [TestMethod()]
        public void TreeTestWithNode()
        {
            var tree = new Tree<int>(new TreeNode<int>(8));

            Assert.AreEqual(tree.Root.Value, 8);
            Assert.AreEqual(tree.Height, 1);
            Assert.AreEqual(tree.NodeCount, 1);
            Assert.AreEqual(tree.Root.Height, 1);
            Assert.AreEqual(tree.Root.Count, 1);
        }

        [TestMethod()]
        public void TreeNodeTest()
        {
            var treeNode = new TreeNode<string>("abc");

            Assert.AreEqual(treeNode.Height, 1);
            Assert.AreEqual(treeNode.Count, 1);
        }

        [TestMethod()]
        public void TreeNodeTestWithParent()
        {
            var baseNode = new TreeNode<string>("root");
            var leafNode = new TreeNode<string>("leaf", baseNode);

            Assert.AreEqual(baseNode.IsRoot, true);
            Assert.AreEqual(baseNode.IsLeaf, false);
            Assert.AreEqual(baseNode.Height, 2);
            Assert.AreEqual(baseNode.Count, 2);
            Assert.AreEqual(leafNode.IsRoot, false);
            Assert.AreEqual(leafNode.IsLeaf, true);
            Assert.AreEqual(leafNode.Height, 1);
            Assert.AreEqual(leafNode.Count, 1);
        }

        [TestMethod()]
        public void AddChildTestWithNodes()
        {
            var baseNode = new TreeNode<string>("root");
            var intermediateNode = new TreeNode<string>("intermediate");
            var leafNode = new TreeNode<string>("leaf");

            Assert.AreEqual(baseNode.AddChild(intermediateNode), true);
            Assert.AreEqual(intermediateNode.AddChild(leafNode), true);

            Assert.AreEqual(baseNode.Height, 3);
            Assert.AreEqual(baseNode.Count, 3);
            Assert.AreEqual(intermediateNode.Height, 2);
            Assert.AreEqual(intermediateNode.Count, 2);
            Assert.AreEqual(leafNode.Height, 1);
            Assert.AreEqual(leafNode.Count, 1);
        }

        [TestMethod()]
        public void AddChildTestWithValues1()
        {
            var baseNode = new TreeNode<string>("root");
            baseNode.AddChild("leaf");
            baseNode.AddChild("leaf2");

            Assert.AreEqual(baseNode.Height, 2);
            Assert.AreEqual(baseNode.Count, 3);
        }

        [TestMethod()]
        public void AddChildTestWithValues2()
        {
            var baseNode = new TreeNode<string>("root");
            var intermediateNode = baseNode.AddChild("intermediate");
            intermediateNode.AddChild("leaf2");

            Assert.AreEqual(baseNode.Height, 3);
            Assert.AreEqual(baseNode.Count, 3);
            Assert.AreEqual(intermediateNode.Height, 2);
            Assert.AreEqual(intermediateNode.Count, 2);
        }

        [TestMethod()]
        public void AddChildrenMidexTest()
        {
            var baseNode = new TreeNode<string>("root");
            var intermediateNode = new TreeNode<string>("intermediate");
            var intermediateNode2 = new TreeNode<string>("intermediate2");

            baseNode.AddChild("leaf");
            baseNode.AddChild(intermediateNode);
            intermediateNode.AddChild(intermediateNode2);
            intermediateNode2.AddChild("leaf2");

            Assert.AreEqual(baseNode.Height, 4);
            Assert.AreEqual(baseNode.Count, 5);
            Assert.AreEqual(intermediateNode.Height, 3);
            Assert.AreEqual(intermediateNode.Count, 3);
            Assert.AreEqual(intermediateNode2.Height, 2);
            Assert.AreEqual(intermediateNode2.Count, 2);
        }

        [TestMethod()]
        public void RemoveSingleChildTest()
        {
            var baseNode = new TreeNode<string>("root");
            var nodeToDelete = baseNode.AddChild("leaf");
            baseNode.AddChild("leaf2");

            Assert.AreEqual(baseNode.RemoveChild(nodeToDelete), true);
            Assert.AreEqual(nodeToDelete.Parent, null);
            Assert.AreEqual(baseNode.Children.Count, 1);
            Assert.AreEqual(baseNode.Height, 2);
            Assert.AreEqual(baseNode.Count, 2);
        }

        [TestMethod()]
        public void RemoveChildrenByValueTest()
        {
            var baseNode = new TreeNode<int>(8);
            baseNode.AddChild(4);
            baseNode.AddChild(3);
            baseNode.AddChild(5);
            baseNode.AddChild(4);
            baseNode.AddChild(7);

            Assert.AreEqual(baseNode.RemoveChildren(4), 2);
            Assert.AreEqual(baseNode.Children.Count, 3);
            Assert.AreEqual(baseNode.Height, 2);
            Assert.AreEqual(baseNode.Count, 4);
        }

        [TestMethod()]
        public void RemoveChildrenByMultipleValuesTest()
        {
            var baseNode = new TreeNode<int>(8);
            var subNode = baseNode.AddChild(4);
            subNode.AddChild(3);
            baseNode.AddChild(5);
            baseNode.AddChild(4);
            baseNode.AddChild(7);

            Assert.AreEqual(baseNode.Height, 3);
            Assert.AreEqual(baseNode.Children.Count, 4);
            Assert.AreEqual(baseNode.Count, 6);

            Assert.AreEqual(baseNode.RemoveChildren(4), 2);
            Assert.AreEqual(baseNode.Children.Count, 2);
            Assert.AreEqual(baseNode.Height, 2);
            Assert.AreEqual(baseNode.Count, 3);
        }

        [TestMethod()]
        public void RemoveChildrenByNodesTest()
        {
            var baseNode = new TreeNode<int>(8);
            var subNode = baseNode.AddChild(4);
            subNode.AddChild(3);
            baseNode.AddChild(5);
            baseNode.AddChild(4);
            var leafNode = baseNode.AddChild(7);

            Assert.AreEqual(baseNode.Height, 3);
            Assert.AreEqual(baseNode.Children.Count, 4);
            Assert.AreEqual(baseNode.Count, 6);

            Assert.AreEqual(baseNode.RemoveChildren(new List<TreeNode<int>>{ subNode, leafNode }), 2);
            Assert.AreEqual(baseNode.Children.Count, 2);
            Assert.AreEqual(baseNode.Height, 2);
            Assert.AreEqual(baseNode.Count, 3);
        }
    }
}