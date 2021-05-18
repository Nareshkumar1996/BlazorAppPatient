namespace Healthware.Assist.Core.Utility
{
    public interface IValueReturningVisitor<TypeToVisit, TypeToReturn> : IVisitor<TypeToVisit>
    {
        void Reset();
        TypeToReturn Result { get; }
    }
}