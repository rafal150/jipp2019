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
using UnitConversion;

namespace UnitConversion
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

            if(ConfigurationManager.AppSettings["ServiceRepository"] == "AzureStorage")
            {
                containerBuilder.RegisterType<AzureServiceRepository>().As<IServiceRepository>();
            }
            else if(ConfigurationManager.AppSettings["ServiceRepository"] == "SQL")
            {
                containerBuilder.RegisterType<SqlServiceRepository>().As<IServiceRepository>();
            }

            containerBuilder.RegisterType<MainWindowViewModel>();
            containerBuilder.RegisterType<ConverterService>();

            containerBuilder.RegisterType<MainWindow>();

            var assembly = Assembly.GetExecutingAssembly();
            containerBuilder.RegisterAssemblyTypes(assembly).Where(x => typeof(UnitConverter).IsAssignableFrom(x)).As<UnitConverter>();

            RegisterPlugins(containerBuilder);

            return containerBuilder.Build();
        }

        private static void RegisterPlugins(ContainerBuilder container)
        {
            string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pluginDirectory = Path.Combine(directory, "plugins");
            var assemblies = Directory.GetFiles(pluginDirectory, "*Plugin.dll").Select(Assembly.LoadFrom).ToList();

            foreach(Assembly assembly in assemblies)
            {
                container.RegisterAssemblyTypes(assembly).Where(x => typeof(UnitConverter).IsAssignableFrom(x)).As<UnitConverter>();
            }
        }
    }
}
