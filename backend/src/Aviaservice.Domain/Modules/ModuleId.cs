namespace Aviaservice.Domain.Module

{
    public record ModuleId
    {
        private ModuleId(Guid value)
        {
            Value = value;
        }
        public Guid Value { get;}

        public static ModuleId NewModuleId() => new(Guid.NewGuid());
        public static ModuleId Empty() => new(Guid.Empty);
    }
}
