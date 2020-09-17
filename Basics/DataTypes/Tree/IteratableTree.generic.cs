using Basics.DataTypes.Tree.Nodes;

namespace Basics.DataTypes
{
    public class IteratableTree<T> : Tree<T>
    {
        #region Constructors
        public IteratableTree() { }

        public IteratableTree(T rootValue)
        {
            Root = new IteratableTreeNode<T>(rootValue);
        }

        public IteratableTree(IteratableTreeNode<T> root)
        {
            Root = root;
        }
        #endregion Constructors
    }
}