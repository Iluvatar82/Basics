using Basics.Interfaces.Tree;
using System;

namespace Basics.DataTypes.Tree
{
    public class BalancedBinaryTree<T> : BinaryTree<T>, IBalancedTree<T>
    {
        public int Rank { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void ReBalance()
        {
            throw new NotImplementedException();
        }
    }
}