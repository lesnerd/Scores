using System.Threading.Tasks;

namespace Model
{
    public interface IFileProcessor
    {
        Task<string> GetFileContent(string path);
        Task<string[]> GetFilesListFromLocation(string path);
    }
}