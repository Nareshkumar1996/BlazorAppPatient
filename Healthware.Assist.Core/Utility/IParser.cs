namespace Healthware.Assist.Core.Utility
{
    public interface IParser<TypeToProduce>
    {
        TypeToProduce Parse();
    }
}