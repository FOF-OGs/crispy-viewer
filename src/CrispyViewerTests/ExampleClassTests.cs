using Xunit;

namespace CrispyViewer.Tests
{
    public class ExampleClassTests
    {
        [Fact()]
        public void Get1Test()
        {
            var exClass = new ExampleClass();
            Assert.Equal(2, exClass.Get1());
        }
    }
}