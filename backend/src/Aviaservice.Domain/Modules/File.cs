

using KSTECH.Domain.Shared;

namespace KSTECH.Domain.Modules

{
    public record File
    {
        private File(string pathToStorage)
        {
            PathToStorage = pathToStorage;
        }            
        public string PathToStorage { get; }
        public static Result<File> Create(string pathToStorage)
        {
            if (string.IsNullOrWhiteSpace(pathToStorage))
                return Result<File>.Failure("Путь не может быть пустым");
            var file = new File(pathToStorage);
            return Result<File>.Success(file); //либо так, либо как в Module, потому что есть перегрузка(implicit)
        }
    }
}
