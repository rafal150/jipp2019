using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using Konwerter8000.Konwersje;
using System.IO;
using System.Reflection;



namespace Konwerter8000
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IContainer k = TworzKontener();

            MainWindow = k.Resolve<MainWindow>();
            MainWindow.Show();
        }
        static IContainer TworzKontener()
        {
            var containerBuilder = new ContainerBuilder();

            if (ConfigurationManager.AppSettings["Log"] == "AzureStorage")
            {
                containerBuilder.RegisterType<LogDoAzure>().As<ILog>();
            }
            else
            {
                containerBuilder.RegisterType<LogDoSQL>().As<ILog>();
            }

            containerBuilder.RegisterType<MainWindow>();
            containerBuilder.RegisterType<Konwerter8000Konwersja>();

            var assembly = Assembly.GetExecutingAssembly();
            containerBuilder.RegisterAssemblyTypes(assembly)
                .Where
                (
                    t => t.Name.StartsWith("Konwerter8000", StringComparison.Ordinal)
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
                        t => t.Name.StartsWith("Konwerter8000", StringComparison.Ordinal)
                    ).AsImplementedInterfaces();
            }
        }


    }
}
