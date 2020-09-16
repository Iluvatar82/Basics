using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basics.DataTypes
{
    public class BinaryTree<T> : Tree<T>
    {
        #region Constructors
        public BinaryTree() { }

        public BinaryTree(T rootValue)
        {
            Root = new BinaryTreeNode<T>(rootValue);
        }

        public BinaryTree(BinaryTreeNode<T> root)
        {
            Root = root;
        }
        #endregion Constructors
    }
    public class BinaryTreeNode<T> : TreeNode<T>
    {
        #region Variables & Fields
        public override List<TreeNode<T>> Children
        {
            get { return new List<TreeNode<T>> { LeftChild, RightChild }; }
            set {
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
            :this()
        {
            Value = value;
        }

        public BinaryTreeNode(T value, TreeNode<T> parent)
            :this(value)
        {
            Parent = parent;
            if (Parent != null)
                Parent.AddChild(this);
        }
        #endregion Constructors


        #region Functions
        public override bool AddChild(TreeNode<T> node)
        {
            if (node == null || Children.Count >= 2)
                return false;

            return base.AddChild(node);
        }

        public override bool RemoveChild(TreeNode<T> node)
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

        public override long RemoveChildren(T value)
        {
            if (value == null || Children == default || !Children.Any())
                return 0;

            var removedCount = 0;
            if (LeftChild.Value.Equals(value))
            {
                LeftChild.Parent = null;
                LeftChild = null;
                removedCount++;
            }

            if (RightChild.Value.Equals(value))
            {
                RightChild.Parent = null;
                RightChild = null;
                removedCount++;
            }

            return removedCount;
        }

        public override long RemoveChildren(IEnumerable<T> values)
        {
            if (values == null || !values.Any() || Children == default || !Children.Any())
                return 0;

            var valuesLookup = new HashSet<T>(values);
            var removedCount = 0;
            if (valuesLookup.Contains(LeftChild.Value))
            {
                LeftChild.Parent = null;
                LeftChild = null;
                removedCount++;
            }

            if (valuesLookup.Contains(RightChild.Value))
            {
                RightChild.Parent = null;
                RightChild = null;
                removedCount++;
            }

            return removedCount;
        }

        public override long RemoveChildren(IEnumerable<TreeNode<T>> nodes)
        {
            if (nodes == null || !nodes.Any() || Children == default || !Children.Any())
                return 0;

            var removedCount = 0;
            if (nodes.Contains(LeftChild))
            {
                LeftChild.Parent = null;
                LeftChild = null;
                removedCount++;
            }

            if (nodes.Contains(RightChild))
            {
                RightChild.Parent = null;
                RightChild = null;
                removedCount++;
            }

            return removedCount;
        }
        #endregion Functions


        #region Operators
        public static implicit operator BinaryTreeNode<T>(T value) => new BinaryTreeNode<T>(value);

        public static implicit operator T(BinaryTreeNode<T> node) => node.Value;
        #endregion Operators
    }
}