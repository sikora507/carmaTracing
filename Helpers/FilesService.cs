using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System;
using Helpers.Contracts;

namespace Helpers
{
    public class FilesService : IFilesService
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

        public List<string> GetFilePaths(string directory, string extension = "")
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

        public List<string> GetFilePaths(List<string> directories, string extension)
        {
            var results = new List<string>();
            foreach (var directory in directories)
            {
                var directoryFiles = GetFilePaths(directory, extension);
                results.AddRange(directoryFiles);
            }
            return results;
        }
    }
}
