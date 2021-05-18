namespace Healthware.Assist.Core.Utility
{
    public interface ICallback<T>
    {
        void Send(T item);
    }
}