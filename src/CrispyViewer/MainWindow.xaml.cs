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

        public MainWindow(IRenderer renderer)
        {
            InitializeComponent();
            _renderer = renderer;
            _viewer = new BMPViewer(renderer);
            Load();
            ShowImage();
        }

        private void Load()
        {
            //var loader = new BMPLoader();
            //var file = loader.Load(string.Empty);
            //_viewer.Load(file);
        }

        private void ShowImage()
        {
            _viewer.Prepare();
            ViewImage.Source = _renderer.GetImageSource();
        }

    }
}
