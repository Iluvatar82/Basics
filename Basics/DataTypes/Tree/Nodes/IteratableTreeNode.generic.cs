using Basics.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Basics.DataTypes.Tree.Nodes
{
    public class IteratableTreeNode<T> : TreeNode<T>, IIteratable<IteratableTreeNode<T>>
    {
        #region Variables & Fields
        public IIteratable<IteratableTreeNode<T>> Previous { get; set; }
        public IIteratable<IteratableTreeNode<T>> Next { get; set; }
        #endregion Variables & Fields


        #region Constructors
        public IteratableTreeNode() { }

        public IteratableTreeNode(T value)
        {
            Value = value;

            Previous = null;
            Next = null;
        }
        #endregion Constructors


        #region Functions
        public override bool AddChild(ITreeNode<T> node)
        {
            if (node == null)
                return false;

            var iteratableNode = (IteratableTreeNode<T>)node;
            node.Parent = this;
            if (Children == default)
                Children = new List<ITreeNode<T>>();
            else
            {
                var lastIteratableNode = (IteratableTreeNode<T>)Children.Last();
                lastIteratableNode.Next = iteratableNode;
                iteratableNode.Previous = lastIteratableNode;
            }

            Children.Add(iteratableNode);
            return true;
        }

        public bool Insert(int position, IIteratable<IteratableTreeNode<T>> iteratableNode)
        {
            if (Children == default)
                Children = new List<ITreeNode<T>>();

            if (position < 0 || position > Children.Count)
            {
                AddChild((ITreeNode<T>)iteratableNode);
                return true;
            }

            var previous = position > 0 ? (IteratableTreeNode<T>)Children[position - 1] : null;
            var next = position < Children.Count ? (IteratableTreeNode<T>)Children[position] : null;

            if (previous != null)
                previous.Next = iteratableNode;

            if (next != null)
                next.Previous = iteratableNode;

            iteratableNode.Previous = previous;
            iteratableNode.Next = next;

            Children.Add((ITreeNode<T>)iteratableNode);
            return true;

        }

        public override bool RemoveChild(ITreeNode<T> node)
        {
            if (node == null || Children == default || !Children.Any())
                return false;

            node.Parent = null;
            var iteratableNode = (IteratableTreeNode<T>)node;
            ConnectPreviousAndNextNodes(iteratableNode?.Previous, iteratableNode?.Next);
            return Children.Remove(node);
        }

        private void ConnectPreviousAndNextNodes(IIteratable<IteratableTreeNode<T>> previous, IIteratable<IteratableTreeNode<T>> next)
        {
            if (previous != null)
                previous.Next = next;

            if (next != null)
                next.Previous = previous;
        }
        #endregion Functions


        #region Operators
        public static implicit operator IteratableTreeNode<T>(T value) => new IteratableTreeNode<T>(value);

        public static implicit operator T(IteratableTreeNode<T> node) => node.Value;
        #endregion Operators


        #region Overrides
        public override string ToString()
        {
            return $"Value: {Value}, H: {Height}, C: {Count}";
        }
        #endregion Overrides
    }
}