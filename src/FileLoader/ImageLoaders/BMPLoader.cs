using FileLoader.Interfaces;
using System.IO;
using System;
using Shared.Structs;
using FileLoader.Structs;
using FileLoader.Exceptions;
using Microsoft.Extensions.Logging;

namespace FileLoader.ImageLoaders
{
    public class BMPLoader : IImageLoader
    {
        private readonly ILogger _logger;

        public BMPLoader() { }
        public BMPLoader(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Opens BMP file in given path and from it's bytes fils interface IImage
        /// </summary>
        /// <param name="path">Path to file</param>
        public IImage Load(string path)
        {
            var bmpImage = new BMPImage();

            try
            {
                var bmpBytes = File.ReadAllBytes(path);

                (UInt16 width, UInt16 height) resolutions = GetBMPResolutions(bmpBytes);
                bmpImage.Width = resolutions.width;
                bmpImage.Height = resolutions.height;
                bmpImage.Size = GetFileSize(bmpBytes);

                return bmpImage;
            }
            catch (BMPFileLoadingException ex)
            {
                if (_logger != null)
                    _logger.LogError(ex.Message);

                throw new BMPFileLoadingException(ex);
            }
        }

        /// <summary>
        /// From given bytes of BMP file calculates and returns 
        /// it's resolution (width, height)
        /// </summary>
        /// <param name="BMPBytes">Array of BMP file bytes</param>
        public (UInt16, UInt16) GetBMPResolutions(byte[] BMPBytes)
        {
            var widthBytes = new byte[4];
            var heightBytes = new byte[4];
            Array.Copy(BMPBytes, 18, widthBytes, 0, 4);
            Array.Copy(BMPBytes, 22, heightBytes, 0, 4);

            return (BitConverter.ToUInt16(widthBytes, 0),
                BitConverter.ToUInt16(heightBytes, 0));

        }
        /// <summary>
        /// From given bytes of BMP file calculates and returns 
        /// it's size in bits
        /// </summary>
        /// <param name="BMPBytes">Array of BMP file bytes</param>
        /// 
        public UInt32 GetFileSize(byte[] BMPBytes)
        {
            (UInt16 width, UInt16 height) resolutions = GetBMPResolutions(BMPBytes);
            var bitCountTable = new byte[2];
            Array.Copy(BMPBytes, 28, bitCountTable, 0, 2);
            var colorDepth = BitConverter.ToUInt16(bitCountTable, 0);

            return (UInt32)(resolutions.width * resolutions.height * colorDepth);
        }

        /// <summary>
        /// From given bytes of BMP file calculates and returns 
        /// it's colors
        /// </summary>
        /// <param name="BMPBytes">Array of BMP file bytes</param>
        /// <param name="size">Size of bmp file in bits</param>
        public RGB[] GetBMPColors(byte[] BMPBytes, UInt16 size)
        {
            var result = new RGB[size];

            return result;
        }

    }
}
