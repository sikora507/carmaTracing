using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmaBrowser.Services
{
    public interface IFilesService
    {
        string BrowseDirectory();
        List<string> GetFiles(string directory, string extension);
    }
}
