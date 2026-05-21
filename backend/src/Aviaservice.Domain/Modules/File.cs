
using CSharpFunctionalExtensions;

namespace Aviaservice.Domain.Module

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
                return Result.Failure<File>("Путь не может быть пустым");
            var file = new File(pathToStorage);
            return Result.Success<File>(file);
        }
    }
}
