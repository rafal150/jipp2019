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

namespace Unitconverter
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
            
            if (ConfigurationManager.AppSettings["StatRepo"] == "Azure")
            {
                containerBuilder.RegisterType<StatisticsAzureRepo>().As<IStatisticsRepository>();
            }
            else
            {
            
                containerBuilder.RegisterType<StatisticsSQLRepo>().As<IStatisticsRepository>();
                
            }
            
            containerBuilder.RegisterType<MainWindow>();

            containerBuilder.RegisterType<ConverterAPIservice>();
            /*
            containerBuilder.RegisterType<Unitconverter.Services.ConvServices>();

            var assembly = typeof(Services.ConvServices).Assembly; //System.Reflection.Assembly.GetExecutingAssembly();
            containerBuilder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Konwerter")).AsImplementedInterfaces();
            */
            //RegisterPlugin(containerBuilder);
            
            return containerBuilder.Build();

        }

        //private static void RegisterPlugin(ContainerBuilder containerbuilder)
        //{
        //    string assemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //    string pluginDir = Path.Combine(assemblyDir, "Plugins");
        //    var assemblies = Directory.GetFiles(pluginDir, "*Plugin.dll").Select(Assembly.LoadFrom).ToList();

        //    foreach(Assembly assembly in assemblies)
        //    {
        //        containerbuilder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Konwerter")).AsImplementedInterfaces();
        //    }
        //}
    }
}
