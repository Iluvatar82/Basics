using Basics.DataTypes.Tree.Nodes;
using Basics.Interfaces.Tree;
using System;

namespace Basics.DataTypes.Tree
{
    public class BalancedTree<T> : SortedTree<T>, IBalancedTree<T>
    {
        #region Variables & Fields
        public int Rank { get; }
        #endregion Variables & Fields


        #region Constructors
        public BalancedTree(int rank)
            : base()
        {
            Rank = rank;
        }

        public BalancedTree(int rank, T rootValue)
            : this(rank)
        {
            Root = new BinaryTreeNode<T>(rootValue);
        }

        public BalancedTree(int rank, BinaryTreeNode<T> root)
            : this(rank)
        {
            Root = root;
        }
        #endregion Constructors


        #region Functions
        public void ReBalance()
        {
            throw new NotImplementedException();
        }
        #endregion Functions
    }
}