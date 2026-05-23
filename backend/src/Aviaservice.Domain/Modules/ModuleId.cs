namespace KSTECH.Domain.Modules

{
    public record ModuleId
    {
        //ef core
        //public ModuleId()
        //{
            
        //}
        private ModuleId(Guid value)
        {
            Value = value;
        }
        public Guid Value { get; }

        public static ModuleId NewModuleId()
        {
            return new ModuleId(Guid.NewGuid());
        }
        public static ModuleId Empty() 
        {
             return new ModuleId(Guid.Empty);
        }
        public static ModuleId Create(Guid id)
        {
            return new ModuleId(id);
        }
    }
}
