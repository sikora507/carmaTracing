using System.Collections.Generic;

namespace Helpers.Contracts
{
    public interface IFilesService
    {
        string BrowseDirectory();
        List<string> GetFilePaths(string directory, string extension);
        List<string> GetFilePaths(List<string> directories, string extension);
    }
}
