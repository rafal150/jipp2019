using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace Konwenter
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IContainer kontener = BuildContainer();
            this.MainWindow = kontener.Resolve<MainWindow>();
            this.MainWindow.Show();
        }

        private static IContainer BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();
            if (ConfigurationManager.AppSettings["RepozytoriumStatystyk"] == "AzureStorage")
            {
                containerBuilder.RegisterType<ZapisBazaAzureStorage>().As<IBazyDanych>();
            }
            else
            {
                containerBuilder.RegisterType<ZapisBazaSQL>().As<IBazyDanych>();
            }
            containerBuilder.RegisterType<MainWindow>();
            containerBuilder.RegisterType<ListaTypowKonwersji>();

            var assembly = Assembly.GetExecutingAssembly();
            containerBuilder.RegisterAssemblyTypes(assembly)
                .Where(x => x.Name.EndsWith("Konwersja")).AsImplementedInterfaces();

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
                containerBuilder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Konwersja")).AsImplementedInterfaces();
            }
        }
    }
}
