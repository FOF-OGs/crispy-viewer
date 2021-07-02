using FileLoader.ImageLoaders;
using Viewer.Interfaces;
using Renderer;
using Renderer.Interfaces;
using Viewer.Viewers;

namespace CrispyViewer
{
    public class CrispyView
    {

        private IRenderer _renderer;
        private IViewer _viewer;

        public void Init()
        {
            _renderer = new SimpleRenderer();
            _viewer = new BMPViewer(_renderer);
        }

        public void Load()
        {
            var loader = new BMPLoader();
            var file = loader.Load(string.Empty);
            _viewer.Load(file);
        }

        public void Show()
        {
            _viewer.Prepare();
            //_img.Source = _renderer.GetBuffer();
        }

    }
}
