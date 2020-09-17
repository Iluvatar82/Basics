namespace Basics.Interfaces.Tree
{
    public interface IIteratable<T>
    {
        IIteratable<T> Previous { get; set; }
        IIteratable<T> Next { get; set; }
    }
}