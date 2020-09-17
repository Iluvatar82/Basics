using System;
using System.Collections.Generic;
using System.Text;

namespace Basics.Interfaces.Tree
{
    public interface IBalancedTree<T>
    {
        int Rank { get; }

        void ReBalance();
    }
}