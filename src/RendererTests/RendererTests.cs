using Xunit;
namespace Renderer.Tests
{
    public class RendererTests
    {
        [Fact()]
        public void RenderTest()
        {
            var renderer = new MainRenderer(100, 100);
            Assert.True(true, "This test needs an implementation");
        }
    }
}