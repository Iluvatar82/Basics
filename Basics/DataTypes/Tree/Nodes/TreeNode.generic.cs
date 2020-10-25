using Basics.Interfaces.Tree.Nodes;
using Basics.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Basics.DataTypes.Tree.Nodes
{
    public class TreeNode<T> : ITreeNode<T>
    {
        #region Variables & Fields
        public T Value { get; set; }

        public ITreeNode<T> Parent { get; set; }
        public virtual List<ITreeNode<T>> Children { get; set; }

        public bool IsRoot => Parent == default;
        public bool IsLeaf => Children == default || Children.Count == 0;
        public long Count => Children?.Sum(c => c.Count) + 1 ?? 1;
        public long Height => Children?.Max(c => c.Height) + 1 ?? 1;
        #endregion Variables & Fields


        #region Constructors
        public TreeNode() { }

        public TreeNode(T value)
        {
            Value = value;
        }

        public TreeNode(T value, TreeNode<T> parent)
            : this(value)
        {
            Parent = parent;
            if (Parent != null)
                Parent.AddChild(this);
        }
        #endregion Constructors


        #region Functions
        public virtual bool AddChild(ITreeNode<T> node)
        {
            if (node == null)
                return false;

            node.Parent = this;
            if (Children == default)
                Children = new List<ITreeNode<T>>();

            Children.Add(node);
            return true;
        }

        public virtual bool AddChild(T value) => AddChild((TreeNode<T>)value);

        public virtual bool RemoveChild(ITreeNode<T> node)
        {
            if (node == null || Children == default || !Children.Any())
                return false;

            node.Parent = null;
            return Children.Remove(node);
        }

        public virtual bool RemoveChild(T value)
        {
            if (Children == default || !Children.Any())
                return false;

            return Children.RemoveAll(i => i.Value.Equals(value)) > 0;
        }
        #endregion Functions


        #region Operators
        public static implicit operator TreeNode<T>(T value) => new TreeNode<T>(value);

        public static explicit operator T(TreeNode<T> node) => node.Value;
        #endregion Operators
    }
}