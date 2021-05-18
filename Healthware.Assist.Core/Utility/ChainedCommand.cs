namespace Healthware.Assist.Core.Utility
{
    internal class ChainedCommand : ICommand
    {
        readonly ICommand left;
        readonly ICommand right;

        public ChainedCommand(ICommand left, ICommand right)
        {
            this.left = left;
            this.right = right;
        }

        public void Execute()
        {
            left.Execute();
            right.Execute();
        }
    }
}