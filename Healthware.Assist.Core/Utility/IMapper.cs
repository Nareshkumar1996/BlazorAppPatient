namespace Healthware.Assist.Core.Utility
{
    public interface IMapper<TIn, Tout>
    {
        Tout MapFrom(TIn item);
    }
}