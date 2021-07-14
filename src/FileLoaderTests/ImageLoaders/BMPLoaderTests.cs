using FileLoader.ImageLoaders;
using System;
using Xunit;

public class BMPLoaderTests
{
    [Fact()]
    public void LoadSizeTest()
    {
        var loader = new BMPLoader();
        var bmpImage = loader.Load("Resources/dummy.bmp");
        Assert.Equal((UInt32)3317760, bmpImage.Size);
    }

    [Fact()]
    public void LoadHeightTest()
    {
        var loader = new BMPLoader();
        var bmpImage = loader.Load("Resources/dummy.bmp");
        Assert.Equal(720, bmpImage.Height);
    }

    [Fact()]
    public void LoadWidthTest()
    {
        var loader = new BMPLoader();
        var bmpImage = loader.Load("Resources/dummy.bmp");
        Assert.Equal(1152, bmpImage.Width);
    }
}