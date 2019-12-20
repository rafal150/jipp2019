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
using WpfApp1.Logic;
//using Autofac.Integration.Mvc;

namespace WpfApp1
{
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

            if (ConfigurationManager.AppSettings["StatisticsRepository"] == "SQL")
            {
                containerBuilder.RegisterType<StatisticsSqlRepository>().As<IStatisticsSource>();
            }
            else
            {
                containerBuilder.RegisterType<StatisticsAzureStorageRepository>().As<IStatisticsSource>();
            }

            containerBuilder.RegisterType<MainWindow>();
            containerBuilder.RegisterType<GetMeasuresObj>();
           var assembly = typeof(GetMeasuresObj).Assembly; //Assembly.GetExecutingAssembly();
           //var assembly = Assembly.GetExecutingAssembly();
            containerBuilder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Measure")).AsImplementedInterfaces();
            //containerBuilder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Unit")).AsImplementedInterfaces();

            RegisterPlugins(containerBuilder);

            return containerBuilder.Build();
        }

        private static void RegisterPlugins(ContainerBuilder containerBuilder)
        {
            string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pluginDirectory = Path.Combine(assemblyDirectory, "plugins");

            var assemblies = Directory.GetFiles(pluginDirectory, "*.dll").Select(Assembly.LoadFrom).ToList();

            foreach (Assembly assembly in assemblies)
            {
                containerBuilder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Measure")).AsImplementedInterfaces();
                //containerBuilder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Unit")).AsImplementedInterfaces();
            }
        }
    }
}
