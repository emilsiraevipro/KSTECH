namespace KSTECH.Domain.Modules
{
    public record IssueId
    {
        public IssueId()
        {
            
        }
        public IssueId(Guid value)
        {
            Value = value;
        }
        public Guid Value { get; private set; }
        public static IssueId NewGuid() => new (Guid.NewGuid());
        public static IssueId EmptyGuid() => new(Guid.Empty);
        public static IssueId Create(Guid id) => new(id);
    }
}
