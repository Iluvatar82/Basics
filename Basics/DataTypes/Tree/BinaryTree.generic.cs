using Basics.DataTypes.Tree.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Basics.DataTypes
{
    public class BinaryTree<T> : Tree<T>
    {
        #region Constructors
        public BinaryTree() { }

        public BinaryTree(T rootValue)
        {
            Root = new BinaryTreeNode<T>(rootValue);
        }

        public BinaryTree(BinaryTreeNode<T> root)
        {
            Root = root;
        }
        #endregion Constructors
    }
}