using Basics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Basics.DataTypes.Tree.Nodes
{
    public class BinaryTreeNode<T> : TreeNode<T>
    {
        #region Variables & Fields
        public override List<ITreeNode<T>> Children
        {
            get { return new List<ITreeNode<T>> { LeftChild, RightChild }; }
            set
            {
                if (value == null || !value.Any())
                {
                    LeftChild = null;
                    RightChild = null;
                }

                if (value.Count > 0)
                    LeftChild = value[0].Value;

                if (value.Count > 1)
                    RightChild = value[1].Value;

                if (value.Count > 2)
                    throw new NotSupportedException($"Adding more than 2 Children is not supported on Binary Trees");
            }
        }

        public BinaryTreeNode<T> LeftChild { get; set; }
        public BinaryTreeNode<T> RightChild { get; set; }
        #endregion Variables & Fields


        #region Constructors
        public BinaryTreeNode()
        {
            LeftChild = null;
            RightChild = null;
        }
        public BinaryTreeNode(T value)
            : this()
        {
            Value = value;
        }

        public BinaryTreeNode(T value, TreeNode<T> parent)
            : this(value)
        {
            Parent = parent;
            if (Parent != null)
                Parent.AddChild((ITreeNode<T>)this);
        }
        #endregion Constructors


        #region Functions
        public override bool AddChild(ITreeNode<T> node)
        {
            if (node == null || Children.Count >= 2)
                return false;

            return base.AddChild(node);
        }

        public override bool RemoveChild(ITreeNode<T> node)
        {
            if (node == null || Children == default || !Children.Any())
                return false;

            node.Parent = null;
            if (node == LeftChild)
                LeftChild = null;

            if (node == RightChild)
                RightChild = null;

            return true;
        }
        #endregion Functions


        #region Operators
        public static implicit operator BinaryTreeNode<T>(T value) => new BinaryTreeNode<T>(value);

        public static implicit operator T(BinaryTreeNode<T> node) => node.Value;
        #endregion Operators
    }
}