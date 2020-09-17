using System;
using System.Collections.Generic;
using System.Text;

namespace Basics.Interfaces.Tree
{
    public interface IBalancedTree<T>
    {
        public int Rank {get; set;}
    }
}