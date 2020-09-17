using Basics.Interfaces.Tree;

namespace Basics.DataTypes.Tree
{
    public class BalancedTree<T> : SortedTree<T>, IBalancedTree<T>
    {
        public int Rank { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}