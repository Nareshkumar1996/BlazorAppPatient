namespace Healthware.Shared
{
    public class JournalEntry: BaseEntity
    {        
        public string Status { get; set; }
        public long EntityId { get; set; }
        public string EntityName { get; set; }
        public string EntityProperty { get; set; }
        public string CurrentValue { get; set; }
        public string PreviousValue { get; set; }

    }
}
