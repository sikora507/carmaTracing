using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarmaBrowser.Services
{
    class FilesService : IFilesService
    {
        public string BrowseDirectory()
        {
            var dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                return dialog.SelectedPath;
            }
            else
            {
                return string.Empty;
            }
        }
        public List<string> GetFiles(string directory, string extension = "")
        {
            if (!Directory.Exists(directory))
            {
                return new List<string>();
            }
            string[] filePaths;
            if (string.IsNullOrEmpty(extension))
            {
                filePaths = Directory.GetFiles(directory);
            }
            else
            {
                filePaths = Directory.GetFiles(directory, "*." + extension);
            }
            return filePaths.ToList();
        }
    }
}
