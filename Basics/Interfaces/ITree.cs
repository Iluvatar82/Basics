using System;
using System.Collections.Generic;
using System.Text;

namespace Basics.Interfaces
{
    public interface ITree<T>
    {
        ITreeNode<T> Root { get; set; }
        long NodeCount { get; }
        long Height { get; }

        ITree<T> Merge(ITree<T> otherTree);
    }
}