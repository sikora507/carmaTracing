﻿using CarmaCore.Endianness;
using CarmaCore.Images.Enums;
using System.IO;
using System.Windows.Media;

namespace CarmaCore.Images
{
    class PaletteFile : IPalette
    {
        byte[] _paletteData;

        public PaletteFile(byte[] paletteData)
        {
            _paletteData = paletteData;
        }

        public PaletteFile(string filename)
        {
            EndianBinaryReader reader = new EndianBinaryReader(EndianBitConverter.Big, File.Open(filename, FileMode.Open));

            while (true)
            {
                int blockLength = 0;
                PaletteBlockType blockType = (PaletteBlockType)reader.ReadInt32();
                blockLength = reader.ReadInt32();

                switch (blockType)
                {
                    case PaletteBlockType.Attributes:

                        //contains name of palette and some attributes                        
                        //we dont care about this
                        reader.Seek(blockLength, SeekOrigin.Current);
                        break;

                    case PaletteBlockType.PixelData:
                        int entryCount = reader.ReadInt32();
                        int bytesPerEntry = reader.ReadInt32();
                        _paletteData = reader.ReadBytes(entryCount * bytesPerEntry);

                        break;

                    case PaletteBlockType.Null:
                        break;

                    default:
                        reader.Seek(blockLength, SeekOrigin.Current);
                        break;
                }
                if (reader.BaseStream.Position == reader.BaseStream.Length)
                    break;
            }

            reader.Close();
        }

        public byte[] GetRGBBytesForPixel(int pixel)
        {
            byte[] rgb = new byte[3];
            rgb[0] = _paletteData[pixel * 4 + 1];
            rgb[1] = _paletteData[pixel * 4 + 2];
            rgb[2] = _paletteData[pixel * 4 + 3];
            return rgb;
        }

        public Color GetRGBColorForPixel(int pixel)
        {
            byte[] rgb = new byte[3];
            rgb[0] = _paletteData[pixel * 4 + 1];
            rgb[1] = _paletteData[pixel * 4 + 2];
            rgb[2] = _paletteData[pixel * 4 + 3];
            return Color.FromArgb(255, rgb[0], rgb[1], rgb[2]);
        }
    }
}
