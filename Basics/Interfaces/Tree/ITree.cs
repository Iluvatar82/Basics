using Basics.Interfaces.Tree.Nodes;

namespace Basics.Interfaces.Tree
{
    public interface ITree<T>
    {
        ITreeNode<T> Root { get; set; }
        long NodeCount { get; }
        long Height { get; }

        ITree<T> Merge(ITree<T> otherTree);
    }
}