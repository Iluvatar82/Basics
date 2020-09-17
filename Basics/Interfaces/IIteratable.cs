namespace Basics.DataTypes
{
    public interface IIteratable<T>
    {
        IIteratable<T> Previous { get; set; }
        IIteratable<T> Next { get; set; }
    }
}