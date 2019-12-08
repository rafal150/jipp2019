using Autofac;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using UnitConverter.Logic;
using UnitConverter.Logic.UnitConverters;
using UnitConverter.SDK;

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

            if (ConfigurationManager.AppSettings["StatisticsRepository"] == "AzureStorage")
            {
                containerBuilder.RegisterType<StatisticsAzureStorageRepository>().As<IStatisticsRepository>();
            }
            else
            {
                containerBuilder.RegisterType<StatisticsSqlRepository>().As<IStatisticsRepository>();
            }

            containerBuilder.RegisterType<MainWindow>();
            containerBuilder.RegisterType<ConvertersService>();

            var assembly = typeof(ConvertersService).Assembly;
            containerBuilder.RegisterAssemblyTypes(assembly)
               .Where(t => t.IsAssignableTo<IUnitConverter>())
               .As<IUnitConverter>();

            RegisterPlugins(containerBuilder);

            return containerBuilder.Build();
        }

        private static void RegisterPlugins(ContainerBuilder containerBuilder)
        {
            string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pluginDirectory = Path.Combine(assemblyDirectory, "plugins");

            var assemblies = Directory.GetFiles(pluginDirectory, "*Plugin.dll").Select(Assembly.LoadFrom).ToList();

            foreach (Assembly assembly in assemblies)
            {
                containerBuilder.RegisterAssemblyTypes(assembly)
                   .Where(t => t.IsAssignableTo<IUnitConverter>())
                   .As<IUnitConverter>();
            }
        }
    }
}
