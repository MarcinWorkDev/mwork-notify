using System.IO;

namespace MWork.Common.WebApi.Helpers
{
    public class FileManager : IFileManager
    {
        private static IFileManager _instance;

        public static IFileManager GetInstance => _instance ??= new FileManager();

        private FileManager() { }
        
        public bool FileExists(string file)
        {
            return File.Exists(file);
        }

        public bool DirectoryExists(string directory)
        {
            return Directory.Exists(directory);
        }

        public string ReadAllText(string file)
        {
            return File.ReadAllText(file);
        }
    }
}