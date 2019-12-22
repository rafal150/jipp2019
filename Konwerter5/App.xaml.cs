using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using System.IO;
using System.Reflection;
using Konwerter5.Uslugi;
using Konwerter5.Logic;



namespace Konwerter5
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IContainer kontener = TworzKontener();

            MainWindow = kontener.Resolve<MainWindow>();
            MainWindow.Show();
        }
        static IContainer TworzKontener()
        {
            var containerBuilder = new ContainerBuilder();

            if (ConfigurationManager.AppSettings["RepozytoriumStatystyk"] == "AzureStorage")
            {
                containerBuilder.RegisterType<StatystykiUzyciaRepozytoriumAzureStorageTable>().As<IRepozytoriumStatystykUzycia>();
            }
            else
            {
                containerBuilder.RegisterType<StatystykiUzyciaRepozytoriumSQL>().As<IRepozytoriumStatystykUzycia>();
            }

            containerBuilder.RegisterType<MainWindow>();
            containerBuilder.RegisterType<Konwerter5Usluga>();

            var assembly = Assembly.GetExecutingAssembly();
            containerBuilder.RegisterAssemblyTypes(assembly)
                .Where
                (
                    t => t.Name.StartsWith("Konwerter5", StringComparison.Ordinal)
                ).AsImplementedInterfaces();

            RejestrujPluginy(containerBuilder);

            return containerBuilder.Build();
        }

        static void RejestrujPluginy(ContainerBuilder containerBuilder)
        {
            string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pluginDirectory = Path.Combine(assemblyDirectory, "plugins");

            var assemblies = Directory.GetFiles(pluginDirectory, "*Plugin.dll").Select
                (
                    Assembly.LoadFrom
                ).ToList();

            foreach (Assembly assembly in assemblies)
            {
                containerBuilder.RegisterAssemblyTypes(assembly).Where
                    (
                        t => t.Name.StartsWith("Konwerter5", StringComparison.Ordinal)
                    ).AsImplementedInterfaces();
            }
        }
    }
}
