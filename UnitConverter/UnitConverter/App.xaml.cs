using Autofac;
using System.Windows;

namespace UnitConversion
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
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
            containerBuilder.RegisterType<MainWindowViewModel>();
            containerBuilder.RegisterType<ConvertersApi>();

            containerBuilder.RegisterType<MainWindow>();
            return containerBuilder.Build();
        }
    }
}
