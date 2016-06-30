using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CarmaCore.Pix
{
    class PixMap
    {
        public string Name { get; set; }
        public int Width, Height;
        //public Texture2D Texture { get; set; }

        public BitmapSource BitmapSource { get; set; }
    }
}
