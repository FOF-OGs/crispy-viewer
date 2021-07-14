
using System;

namespace FileLoader.Interfaces
{
    public interface IImage
    {
        public UInt16 Width { get; set; }
        public UInt16 Height { get; set; }
        public UInt32 Size { get; set; }
    }
}
