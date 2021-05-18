namespace Healthware.Assist.Core.Utility
{
    public interface IVisitable<T>
    {
        void Accept(IVisitor<T> visitor);
    }
}