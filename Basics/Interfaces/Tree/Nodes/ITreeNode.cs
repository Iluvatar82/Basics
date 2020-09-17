using System;
using System.Collections.Generic;
using System.Text;

namespace Basics.Interfaces.Tree.Nodes
{
    public interface ITreeNode<T>
    {
        T Value { get; set; }

        ITreeNode<T> Parent { get; set; }
        List<ITreeNode<T>> Children { get; set; }

        bool IsRoot { get; }
        bool IsLeaf { get; }
        long Count { get; }
        long Height { get; }

        bool AddChild(ITreeNode<T> node);
        bool AddChild(T value);

        bool RemoveChild(ITreeNode<T> node);
        bool RemoveChild(T value);
    }
}