using Renderer;
using Viewer.Viewers;
using Xunit;

namespace ImageViewer.Viewers.Tests
{
    public class BMPViewerTests
    {
        [Fact()]
        public void LoadTest()
        {
            var renderer = new SimpleRenderer();
            var viewer = new BMPViewer(renderer);
            Assert.True(true, "This test needs an implementation");
        }
    }
}