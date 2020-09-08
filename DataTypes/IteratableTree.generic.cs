using System;
using System.Collections.Generic;
using System.Linq;
using Basics.Extensions;

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

    public class IteratableTreeNode<T> : TreeNode<T>
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
        public override TreeNode<T> AddChild(T value)
        {
            var newNode = new TreeNode<T>(value);
            AddChild(newNode);
            return newNode;
        }

        public override bool AddChild(TreeNode<T> node)
        {
            if (node == null)
                return false;

            node.Parent = this;
            if (Children == default)
                Children = new List<TreeNode<T>>();

            Children.Add(node);
            return true;
        }

        public override bool RemoveChild(TreeNode<T> node)
        {
            if (node == null || Children == default || !Children.Any())
                return false;

            node.Parent = null;
            return Children.Remove(node);
        }

        public override long RemoveChildren(T value)
        {
            if (Children == default || !Children.Any())
                return 0;

            var nodesToRemove = Children.Where(tn => tn.Value.Equals(value)).ToList();
            foreach (var node in nodesToRemove)
                node.Parent = null;

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
                    Children.Remove(currentChild);
                }
            }

            return removedCount;
        }
        #endregion Functions


        #region Overrides
        public override string ToString()
        {
            return $"Value: {Value}, H: {Height}, C: {Count}";
        }
        #endregion Overrides
    }
}