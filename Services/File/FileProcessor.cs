using System;
using System.Collections.Specialized;
using System.IO;
using System.Threading.Tasks;
using Model;

namespace Services.File
{
    public class FileProcessor : IFileProcessor
    {
        public async Task<string> GetFileContent(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("Path is null");

            try
            {
                using (var sr = new StreamReader(path))
                {
                    return await sr.ReadToEndAsync();
                }
            }
            catch (IOException e)
            {
                throw new IOException($"The file could not be read: {e.Message}");
            }
        }

        public Task<string[]> GetFilesListFromLocation(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("Path is empty");
            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException($"No such location as: {path}");
            var listOfFiles = Directory.GetFiles(path);
            return Task.FromResult(listOfFiles);
        }
    }
}
