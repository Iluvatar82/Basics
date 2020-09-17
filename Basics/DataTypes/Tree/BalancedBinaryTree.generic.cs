using Basics.Interfaces.Tree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basics.DataTypes.Tree
{
    public class BalancedBinaryTree<T> : BinaryTree<T>, IBalancedTree<T>
    {
        public int Rank { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}