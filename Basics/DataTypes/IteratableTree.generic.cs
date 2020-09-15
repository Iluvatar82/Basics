using Basics.Extensions;
using System.Collections.Generic;
using System.Linq;

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

    public class IteratableTreeNode<T> : TreeNode<T>, IIteratable<IteratableTreeNode<T>>
    {
        #region Variables & Fields
        public IteratableTreeNode<T> Previous { get; set; }
        public IteratableTreeNode<T> Next { get; set; }
        #endregion Variables & Fields


        #region Constructors
        public IteratableTreeNode() { }

        public IteratableTreeNode(T value)
        {
            Value = value;

            Previous = null;
            Next = null;
        }

        public IteratableTreeNode(TreeNode<T> node) :this(node.Value)
        {
            Children = node.Children;
        }

        public IteratableTreeNode(T value, IteratableTreeNode<T> parent)
            : this(value)
        {
            Parent = parent;
            if (Parent != null)
                Parent.AddChild(this);
        }
        #endregion Constructors


        #region Functions
        public override bool AddChild(TreeNode<T> node)
        {
            if (node == null)
                return false;

            var iteratableNode = (IteratableTreeNode<T>)node;
            node.Parent = this;
            if (Children == default)
                Children = new List<TreeNode<T>>();
            else
            {
                var lastIteratableNode = (IteratableTreeNode<T>)Children.Last();
                lastIteratableNode.Next = iteratableNode;
                iteratableNode.Previous = lastIteratableNode;
            }

            Children.Add(iteratableNode);
            return true;
        }

        public bool Insert(int position, IteratableTreeNode<T> iteratableNode)
        {
            if (Children == default)
                Children = new List<TreeNode<T>>();

            if (position < 0 || position > Children.Count)
            {
                AddChild(iteratableNode);
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

            Children.Add(iteratableNode);
            return true;

        }

        public override bool RemoveChild(TreeNode<T> node)
        {
            if (node == null || Children == default || !Children.Any())
                return false;

            node.Parent = null;
            var iteratableNode = (IteratableTreeNode<T>)node;
            ConnectPreviousAndNextNodes(iteratableNode?.Previous, iteratableNode?.Next);
            return Children.Remove(node);
        }

        public override long RemoveChildren(T value)
        {
            if (Children == default || !Children.Any())
                return 0;

            var nodesToRemove = Children.Where(tn => tn.Value.Equals(value)).ToList();
            foreach (var node in nodesToRemove)
            {
                node.Parent = null;
                var iteratableNode = (IteratableTreeNode<T>)node;
                ConnectPreviousAndNextNodes(iteratableNode?.Previous, iteratableNode?.Next);
            }

            Children = Children.Remove(tn => tn.Value.Equals(value)).ToList();
            return nodesToRemove.Count;
        }

        public override long RemoveChildren(IEnumerable<T> values)
        {
            if (values == null || !values.Any() || Children == default || !Children.Any())
                return 0;

            var valuesLookup = new HashSet<T>(values);
            long removedCount = 0;
            for (var i = Children.Count - 1; i >= 0; i--)
            {
                var currentChild = Children[i];
                if (valuesLookup.Contains(currentChild.Value))
                {
                    removedCount++;
                    currentChild.Parent = null;
                    var iteratableChildNode = (IteratableTreeNode<T>)currentChild;
                    ConnectPreviousAndNextNodes(iteratableChildNode?.Previous, iteratableChildNode?.Next);
                    Children.Remove(currentChild);
                }
            }

            return removedCount;
        }

        public override long RemoveChildren(IEnumerable<TreeNode<T>> nodes)
        {
            if (nodes == null || !nodes.Any() || Children == default || !Children.Any())
                return 0;

            var nodesLookup = new HashSet<TreeNode<T>>(nodes);
            long removedCount = 0;
            for (var i = Children.Count - 1; i >= 0; i--)
            {
                var currentChild = Children[i];
                if (nodesLookup.Contains(currentChild))
                {
                    removedCount++;
                    currentChild.Parent = null;
                    var iteratableChildNode = (IteratableTreeNode<T>)currentChild;
                    ConnectPreviousAndNextNodes(iteratableChildNode?.Previous, iteratableChildNode?.Next);
                    Children.Remove(currentChild);
                }
            }

            return removedCount;
        }

        private void ConnectPreviousAndNextNodes(IteratableTreeNode<T> previous, IteratableTreeNode<T> next)
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