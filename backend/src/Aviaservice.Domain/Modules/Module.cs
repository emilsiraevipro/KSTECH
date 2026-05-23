
using KSTECH.Domain.Shared;
//using System.Reflection;
//using static System.Net.WebRequestMethods;

namespace KSTECH.Domain.Modules

{
    public sealed class Module: Shared.Entity<ModuleId>
    {  
        private readonly List<Issue> _issues = [];
        //ef core
        public Module() : base(ModuleId.Empty())
        {
            
        }
        //private Module(ModuleId moduleId) : base(moduleId) {}
        private Module(ModuleId moduleId, string title, string description) : base(moduleId)
        {
            Title = title;
            Description = description;
        }

        public string Title { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public IReadOnlyList<Issue> Issues => _issues;
        public int NumberOfIssues => Issues.Count();

        public void AddIssue(Issue issue)
        {
            //проверки, валидация
            _issues.Add(issue);
        }

        // (Module? Module, string? Error)
        public static Result<Module> Create(ModuleId moduleId, string title, string description)
        {
            if (string.IsNullOrWhiteSpace(title))
                return Result<Module>.Failure<Module>("Title can not be empty");

            if (string.IsNullOrWhiteSpace(description))
                return Result<Module>.Failure<Module>("Description can not be empty");

            var module = new Module(moduleId, title, description);

            return Result<Module>.Success(module);
        }

    }
}
