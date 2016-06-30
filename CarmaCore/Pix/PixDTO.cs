using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace CarmaCore.Pix
{
    public class PixDTO
    {
        public string FileName { get; internal set; }
        public string FilePath { get; internal set; }
        public List<BitmapSource> Images { get; internal set; }
    }
}
