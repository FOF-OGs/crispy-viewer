using Shared.Structs;
using System.Windows.Media;

namespace Renderer.Interfaces
{
    public interface IRenderer
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public void SetPixel(Point2D point, RGB color);
        public void Clear(RGB color);
        public ImageSource GetBuffer();
    }
}
