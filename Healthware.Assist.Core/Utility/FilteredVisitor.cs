namespace Healthware.Assist.Core.Utility
{
    public class FilteredVisitor<T> : IVisitor<T>
    {
        readonly ISpecification<T> condition;
        readonly IVisitor<T> visitor;

        public FilteredVisitor(ISpecification<T> condition, IVisitor<T> visitor)
        {
            this.condition = condition;
            this.visitor = visitor;
        }

        public void Visit(T item_to_visit)
        {
            if (condition.IsSatisfiedBy(item_to_visit)) visitor.Visit(item_to_visit);
        }
    }
}