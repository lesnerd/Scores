using System.IO;
using System.Threading.Tasks;
using Services.File;
using Xunit;

namespace Services.Test
{
    public class FileProcessorTest
    {
        [Fact]
        public async Task GetFileContent_Should()
        {
            FileProcessor fileProcessor = new FileProcessor();
            string[] paths = { Directory.GetCurrentDirectory(), "PhysicalFiles" };
            var files = await fileProcessor.GetFilesListFromLocation(Path.Combine(paths));
            foreach (var file in files)
            {
                await fileProcessor.GetFileContent(file);
            }
        }

        [Fact]
        public async Task GetFileLocations_Should()
        {
            FileProcessor fileProcessor = new FileProcessor();
            string[] paths = { Directory.GetCurrentDirectory(), "PhysicalFiles"};
            await fileProcessor.GetFilesListFromLocation(Path.Combine(paths));
        }
    }
}
