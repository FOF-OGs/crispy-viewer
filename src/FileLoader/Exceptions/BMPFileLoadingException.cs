using System;


namespace FileLoader.Exceptions
{
    /// <summary>
    /// Exception for not loaded BMP file
    /// </summary>

    class BMPFileLoadingException : Exception
    {
        public BMPFileLoadingException(Exception ex) : base(ex.Message, ex) { }
    }
}
