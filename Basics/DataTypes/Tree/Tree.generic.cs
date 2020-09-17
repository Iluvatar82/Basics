using Basics.Interfaces.Tree;
using Basics.Interfaces.Tree.Nodes;
using System;
using System.Linq;

namespace Basics.DataTypes
{
    public class Tree<T> : ITree<T>
    {
        #region Variables & Fields
        public ITreeNode<T> Root { get; set; }
        public long NodeCount => Root.Count;
        public long Height => Root.Height;
        #endregion Variables & Fields


        #region Constructors
        public Tree() { }

        public Tree(T rootValue)
        {
            Root = (ITreeNode<T>)rootValue;
        }

        public Tree(ITreeNode<T> root)
        {
            Root = root;
        }
        #endregion Constructors


        #region Functions
        public virtual ITree<T> Merge(ITree<T> otherTree)
        {
            throw new NotSupportedException();
        }
        #endregion


        #region Overrides
        public override string ToString()
        {
            return $"Root: {Root}, Height: {Height}, Count: {NodeCount}";
        }
        #endregion Overrides
    }
}