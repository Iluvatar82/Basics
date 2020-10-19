using Basics.DataTypes.Tree.Nodes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.DataTypes.Tests
{
    [TestClass()]
    public class TreeUnittests
    {
        [TestMethod()]
        public void TreeTest()
        {
            var tree = new Tree<int>(5);

            Assert.AreEqual(true, tree.Root.IsRoot);
            Assert.AreEqual(true, tree.Root.IsLeaf);
            Assert.AreEqual(5, tree.Root.Value);
            Assert.AreEqual(1, tree.Height);
            Assert.AreEqual(1, tree.NodeCount);
            Assert.AreEqual(1, tree.Root.Height);
            Assert.AreEqual(1, tree.Root.Count);
        }

        [TestMethod()]
        public void TreeTestWithNode()
        {
            var tree = new Tree<int>(8);

            Assert.AreEqual(8, tree.Root.Value);
            Assert.AreEqual(1, tree.Height);
            Assert.AreEqual(1, tree.NodeCount);
            Assert.AreEqual(1, tree.Root.Height);
            Assert.AreEqual(1, tree.Root.Count);
        }

        [TestMethod()]
        public void TreeNodeTest()
        {
            var treeNode = new TreeNode<string>("abc");

            Assert.AreEqual(1, treeNode.Height);
            Assert.AreEqual(1, treeNode.Count);
        }

        [TestMethod()]
        public void TreeNodeTestWithParent()
        {
            var baseNode = new TreeNode<string>("root");
            var leafNode = new TreeNode<string>("leaf", baseNode);

            Assert.AreEqual(true, baseNode.IsRoot);
            Assert.AreEqual(false, baseNode.IsLeaf);
            Assert.AreEqual(2, baseNode.Height);
            Assert.AreEqual(2, baseNode.Count);
            Assert.AreEqual(false, leafNode.IsRoot);
            Assert.AreEqual(true, leafNode.IsLeaf);
            Assert.AreEqual(1, leafNode.Height);
            Assert.AreEqual(1, leafNode.Count);
        }

        [TestMethod()]
        public void AddChildTestWithNodes()
        {
            var baseNode = new TreeNode<string>("root");
            var intermediateNode = new TreeNode<string>("intermediate");
            var leafNode = new TreeNode<string>("leaf");

            Assert.AreEqual(baseNode.AddChild(intermediateNode), true);
            Assert.AreEqual(intermediateNode.AddChild(leafNode), true);

            Assert.AreEqual(3, baseNode.Height);
            Assert.AreEqual(3, baseNode.Count);
            Assert.AreEqual(2, intermediateNode.Height);
            Assert.AreEqual(2, intermediateNode.Count);
            Assert.AreEqual(1, leafNode.Height);
            Assert.AreEqual(1, leafNode.Count);
        }

        [TestMethod()]
        public void AddChildTestWithValues1()
        {
            var baseNode = new TreeNode<string>("root");
            baseNode.AddChild("leaf");
            baseNode.AddChild("leaf2");

            Assert.AreEqual(2, baseNode.Height);
            Assert.AreEqual(3, baseNode.Count);
        }

        [TestMethod()]
        public void AddChildTestWithValues2()
        {
            var baseNode = new TreeNode<string>("root");
            TreeNode<string> intermediateNode = "intermediate";
            baseNode.AddChild(intermediateNode);
            intermediateNode.AddChild("leaf2");

            Assert.AreEqual(3, baseNode.Height);
            Assert.AreEqual(3, baseNode.Count);
            Assert.AreEqual(2, intermediateNode.Height);
            Assert.AreEqual(2, intermediateNode.Count);
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

            Assert.AreEqual(4, baseNode.Height);
            Assert.AreEqual(5, baseNode.Count);
            Assert.AreEqual(3, intermediateNode.Height);
            Assert.AreEqual(3, intermediateNode.Count);
            Assert.AreEqual(2, intermediateNode2.Height);
            Assert.AreEqual(2, intermediateNode2.Count);
        }

        [TestMethod()]
        public void RemoveSingleChildTest()
        {
            var baseNode = new TreeNode<string>("root");
            var nodeToDelete = new TreeNode<string>("leaf");
            baseNode.AddChild(nodeToDelete);
            baseNode.AddChild("leaf2");

            Assert.AreEqual(true, baseNode.RemoveChild(nodeToDelete));
            Assert.AreEqual(null, nodeToDelete.Parent);
            Assert.AreEqual(1, baseNode.Children.Count);
            Assert.AreEqual(2, baseNode.Height);
            Assert.AreEqual(2, baseNode.Count);
        }
    }
}