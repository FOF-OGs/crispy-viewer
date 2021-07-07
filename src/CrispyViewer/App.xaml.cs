using Autofac;
using Autofac.Core;
using Renderer;
using Renderer.Interfaces;
using System.Windows;
using Viewer.Interfaces;
using Viewer.Viewers;

namespace CrispyViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainRenderer>().As<IRenderer>().WithParameter("width", 800).WithParameter("height", 600);

            builder.RegisterType<MainWindow>().AsSelf();

            var container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                var window = scope.Resolve<MainWindow>();
                window.Show();
            }
        }
    }
}
