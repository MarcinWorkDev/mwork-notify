namespace MWork.Common.Sdk.WebApi.Helpers
{
    public interface IFileManager
    {
        bool FileExists(string file);
        bool DirectoryExists(string directory);
        string ReadAllText(string file);
    }
}