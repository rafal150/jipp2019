using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using System.Reflection;
using System.IO;

namespace UnitConverter {
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);

            IContainer container = BuildContainer();
            // IStatisticsRepository repository = container.Resolve<IStatisticsRepository>();
            MainWindow = container.Resolve<MainWindow>();
            MainWindow.Show();
        }
        private static IContainer BuildContainer() {
            var containerBuilder = new ContainerBuilder();

            // set statistics repository class using app config
            string statisticsRepositoryConfig = ConfigurationManager.AppSettings["StatisticsRepository"].ToLower();
            if (statisticsRepositoryConfig == "sql") {
                containerBuilder.RegisterType<StatisticsSqlRepository>().As<IStatisticsRepository>();
            } else if (statisticsRepositoryConfig == "azurestorage") {
                containerBuilder.RegisterType<StatisticsAzureStorageRepository>().As<IStatisticsRepository>();
            } else {
                throw new Exception("Błędna konfiguracja StatisticsRepository");
            }

            containerBuilder.RegisterType<MainWindow>();

            containerBuilder.RegisterType<Converters.Converters>();

            // register all converters in this project (UnitConverter/Converters/*.cs)
            RegisterConverters(containerBuilder);

            // register all converters in plugins folder (UnitConverter/bin/Debug/plugins/*.dll)
            RegisterPlugins(containerBuilder);

            return containerBuilder.Build();
        }
        private static void RegisterConverters(ContainerBuilder containerBuilder) {
            var assembly = Assembly.GetExecutingAssembly();
            // register all classes...
            containerBuilder.RegisterAssemblyTypes(assembly)
                // ... that implement Converters.IConverter
                .Where(t => typeof(Converters.IConverter).IsAssignableFrom(t))
                .AsImplementedInterfaces();
        }
        private static void RegisterPlugins(ContainerBuilder containerBuilder) {
            // exe file directory
            string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            // plugins folder
            string pluginDirectory = Path.Combine(assemblyDirectory, "plugins");
            // .dll's list
            var assemblies = Directory.GetFiles(pluginDirectory, "*Plugin.dll").Select(Assembly.LoadFrom).ToList();

            foreach (Assembly assembly in assemblies) {
                containerBuilder.RegisterAssemblyTypes(assembly)
                    .Where(t => typeof(Converters.IConverter).IsAssignableFrom(t))
                    .AsImplementedInterfaces();
            }
        }
    }
}
