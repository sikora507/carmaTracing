﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmaCore.Images
{
    interface IPalette
    {
        byte[] GetRGBBytesForPixel(int pixel);
    }
}
