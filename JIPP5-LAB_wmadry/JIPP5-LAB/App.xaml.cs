using Autofac;
using JIPP5_LAB.Data;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace JIPP5_LAB
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

            if (ConfigurationManager.AppSettings["StatisticsRepository"] == "AzureStorage")
            {
                containerBuilder.RegisterType<AzureData>().As<IGetData>();
            }
            else
            {
                containerBuilder.RegisterType<Database>().As<IGetData>();
            }

            containerBuilder.RegisterType<MainWindow>();
            containerBuilder.RegisterType<ConvertersService>();

            var assembly = typeof(ConvertersService).Assembly;
            containerBuilder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Converter")).AsImplementedInterfaces();

            RegisterPlugins(containerBuilder);

            return containerBuilder.Build();
        }

        private static void RegisterPlugins(ContainerBuilder containerBuilder)
        {
            string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pluginDirectory = Path.Combine(assemblyDirectory, "plugins");
            Directory.CreateDirectory(pluginDirectory);

            foreach (Assembly assembly in Directory.GetFiles(pluginDirectory, "*Plugin.dll").Select(Assembly.LoadFrom).ToList())
            {
                containerBuilder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Converter")).AsImplementedInterfaces();
            }
        }
    }
}