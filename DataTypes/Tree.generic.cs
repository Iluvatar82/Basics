using Basics.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Basics.DataTypes
{
    public class Tree<T>
    {
        public TreeNode<T> Root { get; set; }
        public long NodeCount => Root.Count;
        public long Height => Root.Height;

        public Tree(T rootValue)
        {
            Root = new TreeNode<T>(rootValue);
        }

        public Tree(TreeNode<T> root)
        {
            Root = root;
        }
    }

    public class TreeNode<T>
    {
        #region Variables & Fields
        public T Value { get; set; }
        public TreeNode<T> Parent { get; set; }
        public List<TreeNode<T>> Children { get; set; }

        public bool IsRoot => Parent == default;
        public bool IsLeaf => Children == default || Children.Count == 0;
        public long Count => Children?.Sum(c => c.Count) + 1 ?? 1;
        public long Height => Children?.Max(c => c.Height) + 1 ?? 1;
        #endregion Variables & Fields


        #region Constructors
        public TreeNode(T value)
        {
            Value = value;
        }

        public TreeNode(T value, TreeNode<T> parent)
            :this(value)
        {
            Parent = parent;
            if (Parent.Children == default)
                Parent.Children = new List<TreeNode<T>> { this };
            else
                Parent.Children.Add(this);
        }
        #endregion Constructors


        #region Functions
        public TreeNode<T> AddChild(T value)
        {
            var newNode = new TreeNode<T>(value);
            AddChild(newNode);
            return newNode;
        }

        public bool AddChild(TreeNode<T> node)
        {
            if (node == null)
                return false;

            node.Parent = this;
            if (Children == default)
                Children = new List<TreeNode<T>>();

            Children.Add(node);
            return true;
        }

        public bool RemoveChild(TreeNode<T> node)
        {
            if (node == null || Children == default || !Children.Any())
                return false;

            node.Parent = null;
            return Children.Remove(node);
        }

        public long RemoveChildren(T value)
        {
            if (Children == default || !Children.Any())
                return 0;

            var nodesToRemove = Children.Where(tn => tn.Value.Equals(value)).ToList();
            foreach (var node in nodesToRemove)
                node.Parent = null;

            Children = Children.Remove(tn => tn.Value.Equals(value)).ToList();
            return nodesToRemove.Count;
        }

        public long RemoveChildren(IEnumerable<T> values)
        {
            if (values == null || !values.Any() || Children == default || !Children.Any())
                return 0;

            var valuesLookup = new HashSet<T> (values);
            long removedCount = 0;
            for(var i = Children.Count - 1; i >= 0; i--)
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

        public long RemoveChildren(IEnumerable<TreeNode<T>> nodes)
        {
            if (nodes == null || !nodes.Any() || Children == default || !Children.Any())
                return 0;

            var nodesLookup = new HashSet<TreeNode<T>> (nodes);
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
    }
}