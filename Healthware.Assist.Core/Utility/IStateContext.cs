namespace Healthware.Assist.Core.Utility
{
    public interface IStateContext<T> where T : IState
    {
        void ChangeStateTo(T new_state);
    }
}