using Basics.DataTypes.Tree.Nodes;
using Basics.Interfaces.Tree;
using System;

namespace Basics.DataTypes.Tree
{
    public class SortedTree<T> : BinaryTree<T>, ISortedTree<T>
    {
        #region Constructors
        public SortedTree() { }

        public SortedTree(T rootValue)
        {
            Root = new BinaryTreeNode<T>(rootValue);
        }

        public SortedTree(BinaryTreeNode<T> root)
        {
            Root = root;
        }
        #endregion Constructors


        #region Functions
        public void Sort()
        {
            throw new NotImplementedException();
        }
        #endregion Functions
    }
}