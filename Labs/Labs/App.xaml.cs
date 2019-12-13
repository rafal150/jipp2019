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
using Labs.Converters;
using Labs.Databases;
using Labs;

namespace Labs
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

        private static void SearchPlugin(ContainerBuilder containerBuilder)
        {
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pluginsDir = Path.Combine(dir, "plugins");
            var plugins = Directory.GetFiles(pluginsDir, "*Plugin.dll").Select(Assembly.LoadFrom).ToList();

            foreach (Assembly assembly in plugins)
            {
                containerBuilder.RegisterAssemblyTypes(assembly).Where(conv => conv.Name.EndsWith("Conv")).AsImplementedInterfaces();
            }
        }

        private static IContainer BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();

            
            if (ConfigurationManager.AppSettings["StatisticsRepository"] == "AzureStorage")
            {
                containerBuilder.RegisterType<AzureRepo>().As<InterfaceRepository>();
            }
            else
            {
                containerBuilder.RegisterType<SQLRepo>().As<InterfaceRepository>();
            }
            
            containerBuilder.RegisterType<MainWindow>();
            containerBuilder.RegisterType<SConverters>();

            var searchConv = typeof(SConverters).Assembly; //Assembly.GetExecutingAssembly(); <--- old 
            containerBuilder.RegisterAssemblyTypes(searchConv).Where(conv => conv.Name.EndsWith("Conv")).AsImplementedInterfaces();

            SearchPlugin(containerBuilder);

            return containerBuilder.Build();
        }
    }
}
