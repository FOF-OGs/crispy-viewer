using FileLoader.Interfaces;
using System.IO;
using System;
using Shared.Structs;
using FileLoader.structs;

namespace FileLoader.ImageLoaders
{
    public class BMPLoader : IImageLoader
    {
        public IImage Load(string path)
        {            
            try
            {
                var bmpBytes = File.ReadAllBytes(path);
                var bmpFile = new BMPFile();

                var resolutions = GetBMPResolutions(bmpBytes);
                bmpFile.Width = resolutions.Item1;
                bmpFile.Height = resolutions.Item2;
                bmpFile.Size = GetFileSize(bmpBytes);
            }
            catch
            {
                throw new NotImplementedException();
            }
            return null;
        }

        public (int, int) GetBMPResolutions(byte[] BMPBytes)
        {
            var widthBytes = new byte[4];
            var heightBytes = new byte[4];
            Array.Copy(BMPBytes,18,widthBytes,0, 4);
            Array.Copy(BMPBytes,22, heightBytes,0, 4);

            return (BitConverter.ToInt32(widthBytes, 0),
                BitConverter.ToInt32(heightBytes, 0));
                       
        }

        public int GetFileSize(byte[] BMPBytes)
        {
            var resolutions = GetBMPResolutions(BMPBytes);
            var bitCountTable = new byte[2]; 
            Array.Copy(BMPBytes, 28, bitCountTable,0,2);
            var colorDepth = BitConverter.ToInt16(bitCountTable, 0);
            return resolutions.Item1 * resolutions.Item2 * colorDepth;
                
        }

        public RGB[] GetBMPColors(byte[] BMPBytes, int size)
        {
            var result = new RGB[size];

            return result;
        }

    }
}
