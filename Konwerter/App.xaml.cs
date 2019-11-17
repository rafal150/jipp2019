using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using Konwerter.Services;

namespace Konwerter
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IContainer container = BuildContainer();

            MainWindow = container.Resolve<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        private static IContainer BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();

            if (ConfigurationManager.AppSettings["StatisticsRepository"] == "AzureStorage")
            {
                containerBuilder.RegisterType<StatisticsAzureStorageRepository>().As<IStatisticRepository>();
            }
            else
            {
                containerBuilder.RegisterType<StatisticsSqlRepository>().As<IStatisticRepository>();
            }

            containerBuilder.RegisterType<MainWindow>();
            containerBuilder.RegisterType<ConvertersService>();

            var assembly = Assembly.GetExecutingAssembly();
            containerBuilder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.StartsWith("Converter")).AsImplementedInterfaces();

            RegisterPlugins(containerBuilder);

            return containerBuilder.Build();
        }

        private static void RegisterPlugins(ContainerBuilder builder)
        {
            string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pluginDirectory = Path.Combine(assemblyDirectory, "plugins");

            var assemblies = Directory.GetFiles(pluginDirectory, "*Plugin.dll").Select(Assembly.LoadFrom).ToList();

            foreach (Assembly assembly in assemblies)
            {
                builder.RegisterAssemblyTypes(assembly).Where(t => t.Name.StartsWith("Converter")).AsImplementedInterfaces();
            }
        }
    }

}
