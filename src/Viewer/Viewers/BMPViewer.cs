using FileLoader.Interfaces;
using Viewer.Interfaces;
using Renderer.Interfaces;
using System;
using System.Windows;
using Shared.Structs;

namespace Viewer.Viewers
{
    public class BMPViewer : IViewer
    {

        private readonly IRenderer _renderer;

        public BMPViewer(IRenderer renderer)
        {
            _renderer = renderer;
        }

        public void Load(IImage image)
        {
            throw new NotImplementedException();
        }

        public void Prepare()
        {
            // TODO

            // Example (slow)
            var rect = new Int32Rect { X = 30, Y = 30, Width = 30, Height = 30 };
            var color = new RGB { R = 24, G = 64, B = 128 };
            _renderer.SetRectangle(rect, color);
            // Please use
            // -- SetRectangle(Int32Rect rect, int stride, byte[] buffer);
            // Which is more efficient way to draw
        }

    }
}
