namespace Healthware.Assist.Core.Utility
{
    public interface IQuery<Output>
    {
        Output Fetch();
    }

    public interface IQuery<Input, Output>
    {
        Output Fetch(Input item);
    }
}