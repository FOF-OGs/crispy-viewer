using Renderer.Interfaces;
using Shared.Structs;
using System;
using System.Windows.Media;

namespace Renderer
{
    public class SimpleRenderer : IRenderer
    {
        public int Width { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Height { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Clear(RGB color)
        {
            throw new NotImplementedException();
        }

        public ImageSource GetBuffer()
        {
            throw new NotImplementedException();
        }

        public ImageSource GetWritableBitmap()
        {
            throw new NotImplementedException();
        }

        public void SetPixel(Point2D point, RGB color)
        {
            throw new NotImplementedException();
        }
    }
}
