namespace Healthware.Assist.Core.Utility
{
    public interface IParameterizedCommand<Input>
    {
        void Execute(Input item);
    }
}