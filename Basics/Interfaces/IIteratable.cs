namespace Basics.DataTypes
{
    public interface IIteratable<T>
    {
        T Previous { get; set; }
        T Next { get; set; }

        bool Insert(int position, T iteratableNode);
    }
}