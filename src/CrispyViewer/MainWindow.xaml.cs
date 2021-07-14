using FileLoader.ImageLoaders;
using Renderer;
using Renderer.Interfaces;
using System.Windows;
using Viewer.Interfaces;
using Viewer.Viewers;

namespace CrispyViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private IRenderer _renderer;
        private IViewer _viewer;

        public MainWindow()
        {
            InitializeComponent();
            _renderer = new MainRenderer(ViewImage.Width, ViewImage.Height);
            _viewer = new BMPViewer(_renderer);
            Load();
            ShowImage();
        }

        private void Load()
        {
            var loader = new BMPLoader();
            var file = loader.Load(@"C:\Users\szymon\Desktop\bmp2.bmp");
            //_viewer.Load(file);
        }

        private void ShowImage()
        {
            _viewer.Prepare();
            ViewImage.Source = _renderer.GetImageSource();
        }

    }
}
