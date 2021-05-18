namespace Healthware.Assist.Core.Utility
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T item);
    }
}