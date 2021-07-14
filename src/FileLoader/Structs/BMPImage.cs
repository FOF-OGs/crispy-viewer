using Shared.Structs;
using FileLoader.Interfaces;
using System;

namespace FileLoader.Structs
{
    public struct BMPImage : IImage
    {
        public UInt16 Width { get; set; }
        public UInt16 Height { get; set; }
        public UInt32 Size { get; set; }
        public RGB[][] PixelColors { get; set; }
    }
}
