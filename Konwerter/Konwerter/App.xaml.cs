using Autofac;
//using Konwerter.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace Konwerter
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
            //if (ConfigurationManager.AppSettings["StatisticsRepository"] == "AzureStorage")
            //{
            //    containerBuilder.RegisterType<AzureStorageRepo>().As<IRepo>();
            //}
            //else
            //{
            //    containerBuilder.RegisterType<SqlRepo>().As<IRepo>();
            //}

            containerBuilder.RegisterType<MainWindow>();
            containerBuilder.RegisterType<KonwerteryAPI>();

            return containerBuilder.Build();
        }

        //private static IContainer BuildContainer()
        //{
        //    var containerBuilder = new ContainerBuilder();

        //    if (ConfigurationManager.AppSettings["StatisticsRepository"] == "AzureStorage")
        //    {
        //        containerBuilder.RegisterType<AzureStorageRepo>().As<IRepo>();
        //    }
        //    else
        //    {
        //        containerBuilder.RegisterType<SqlRepo>().As<IRepo>();
        //    }

        //    containerBuilder.RegisterType<MainWindow>();
        //    containerBuilder.RegisterType<ConvertersService>();

        //    var assembly = typeof(ConvertersService).Assembly;//var assembly = Assembly.GetExecutingAssembly();
        //    containerBuilder.RegisterAssemblyTypes(assembly)
        //        .Where(t => t.Name.EndsWith("Konwerter")).AsImplementedInterfaces();

        //    RegisterPlugins(containerBuilder);


        //    return containerBuilder.Build();
        //}
        //private static void RegisterPlugins(ContainerBuilder containerBuilder)
        //{
        //    string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //    string pluginDirectory = Path.Combine(assemblyDirectory, "plugins");

        //    var assemblies = Directory.GetFiles(pluginDirectory, "*Plugin.dll").Select(Assembly.LoadFrom).ToList();

        //    foreach (Assembly assembly in assemblies)
        //    {
        //        containerBuilder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Konwerter")).AsImplementedInterfaces();
        //    }
        //}
    }
}
