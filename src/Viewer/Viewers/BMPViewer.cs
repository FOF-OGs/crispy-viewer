using FileLoader.Interfaces;
using Viewer.Interfaces;
using Renderer.Interfaces;
using System;

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
            throw new NotImplementedException();
        }

    }
}
