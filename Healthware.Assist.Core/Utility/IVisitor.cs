namespace Healthware.Assist.Core.Utility
{
    public interface IVisitor<T>
    {
        void Visit(T item_to_visit);
    }
}