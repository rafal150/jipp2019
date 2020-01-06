using Autofac;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace UnitConverter.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IContainer container = BuildContainer();

            this.MainWindow = container.Resolve<MainWindow>();
            this.MainWindow.Show();
        }

        private static IContainer BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<MainWindow>();
            containerBuilder.RegisterType<UnitConverterApi>();

            return containerBuilder.Build();
        }
    }
}
