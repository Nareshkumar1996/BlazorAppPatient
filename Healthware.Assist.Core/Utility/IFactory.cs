namespace Healthware.Assist.Core.Utility
{
    public interface IFactory<TypeToCreate>
    {
        TypeToCreate Create();
    }
}