using System;
using System.Collections.Generic;
using CarmaCore.Contracts;
using System.IO;
using Helpers.Contracts;
using CarmaCore.Images;
using System.Linq;

namespace CarmaCore.Pix
{
    public class PixService : IPixService
    {
        private readonly List<string> _pixDirs = new List<string>
            {
                @"DATA\PIXELMAP\",
                @"DATA\REG\PIXELMAP\",
                @"DATA\32X20X8\PIXELMAP\"
            };
        private readonly List<string> _paletteDirs = new List<string>
        {
            @"data\reg\palettes\drrender.pal",
            @"data\reg\palettes\draceflc.pal"
        };
        private readonly IDirectories _directories;
        private readonly IFilesService _filesService;
        private readonly List<string> _pixDirsFull = new List<string>();
        private readonly List<string> _paletteDirsFull = new List<string>();

        public PixService(IDirectories directories, IFilesService filesService)
        {
            if (string.IsNullOrEmpty(directories.CarmaDir))
            {
                throw new InvalidOperationException("Carma dir is empty. Check your settings.");
            }
            _directories = directories;
            _filesService = filesService;
            foreach (var pixDir in _pixDirs)
            {
                _pixDirsFull.Add(Path.Combine(_directories.CarmaDir, pixDir));
            }
            foreach (var paletteDir in _paletteDirs)
            {
                _paletteDirsFull.Add(Path.Combine(_directories.CarmaDir, paletteDir));
            }
        }

        public IList<PixDTO> GetAllPixData()
        {
            // todo refactor - use some mapping for pix directories to palettes if possible
            var palette1 = new PaletteFile(_paletteDirsFull[0]);
            var palette2 = new PaletteFile(_paletteDirsFull[1]);

            var result = new List<PixDTO>();
            var filePaths = _filesService.GetFilePaths(_pixDirs, "pix");
            foreach (var filePath in filePaths)
            {
                PixFile pixFile = new PixFile(filePath, palette1);
                result.Add(new PixDTO
                {
                    FileName = Path.GetFileName(filePath),
                    FilePath = filePath,
                    Images = pixFile.PixMaps.Select(x => x.BitmapSource).ToList()
                });

            }
            return result;
        }
    }
}
