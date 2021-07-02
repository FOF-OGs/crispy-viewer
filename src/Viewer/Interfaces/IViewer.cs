using FileLoader.Interfaces;

namespace Viewer.Interfaces
{
    public interface IViewer
    {
        public void Load(IImage image);
        public void Prepare();
    }
}
