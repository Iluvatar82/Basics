namespace Basics.Interfaces.Tree
{
    public interface IBalancedTree<T>
    {
        int Rank { get; }

        void ReBalance();
    }
}