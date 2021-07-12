using Shared.Structs;

namespace FileLoader.structs
{
    public struct BMPFile
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public RGB PixelColors { get; set; }
    }
}
