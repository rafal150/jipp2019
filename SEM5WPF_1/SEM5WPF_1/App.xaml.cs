using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Autofac;
using SEM5WPF_1.Services;
using System.Reflection;
using System.IO;
using SEM5WPF_1;

namespace SEM5WPF_1
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IContainer container = BulidContainer();
            this.MainWindow = container.Resolve<MainWindow>(); 
            this.MainWindow.Show();
        }

        private static IContainer BulidContainer()
        {
            var containerBulider = new ContainerBuilder();

            if(ConfigurationManager.AppSettings["StatisticsRepository"] == "AzureStorage")
            {
                containerBulider.RegisterType<StatystykiAzureRepozytorium>().As<IStatystykiRepozytorium>();
            }
            else
            {
                containerBulider.RegisterType<StatystykiSqlRepozytorium>().As<IStatystykiRepozytorium>();
            }

            containerBulider.RegisterType<MainWindow>();
            containerBulider.RegisterType<KonwerterServices>();

            var assembly = Assembly.GetExecutingAssembly();
            containerBulider.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Konwerter")).AsImplementedInterfaces();

            RegisterPlugins(containerBulider);

            return containerBulider.Build();
        
        }

        private static void RegisterPlugins(ContainerBuilder containerBuilder)
        {
            string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pluginDirectory = Path.Combine(assemblyDirectory, "plugins");

            var assmbiles = Directory.GetFiles(pluginDirectory, "*Plugin.dll").Select(Assembly.LoadFrom).ToList();
            
            foreach(Assembly assembly in assmbiles)
            {
                containerBuilder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Plugin")).AsImplementedInterfaces();
            }
        }
    }
}
