namespace Healthware.Assist.Core.Utility
{
    public interface IConfiguration<T>
    {
        void Configure(T item);
    }
}