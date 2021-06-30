using Xunit;
using CrispyViewer;

namespace CrispyViewer.Tests
{
    public class ExampleClassTests
    {
        [Fact()]
        public void Get1Test()
        {
            var exClass = new ExampleClass();
            Assert.Equal(1, exClass.Get1());
        }
    }
}