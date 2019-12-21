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
using WPFKonwerter.Model;
using WPFKonwerter.Model.DTO;

namespace WPFKonwerter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IContainer IocContainer = BuildContainer();
            MainWindow = IocContainer.Resolve<MainWindow>();
            MainWindow.Show();
        }

        private static IContainer BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();

            if (ConfigurationManager.AppSettings["StatisticsRepositorySource"] == "Azure")
                containerBuilder.RegisterType<Statistics2Azure>().As<IStatisticsRepo>();
            else
                containerBuilder.RegisterType<Statistic2SQL>().As<IStatisticsRepo>();

            containerBuilder.RegisterType<MainWindow>();
            containerBuilder.RegisterType<Services.KonwerterService>();

            var assembly = Assembly.GetExecutingAssembly();
            containerBuilder.RegisterAssemblyTypes(assembly)
                .Where(x => x.Name.EndsWith("Converter")).AsImplementedInterfaces();

            RegisterPlugins(containerBuilder);
            return containerBuilder.Build();
        }
        private static void RegisterPlugins(ContainerBuilder containerBuilder)
        {
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pluginDir = Path.Combine(dir, "plugins");

            var assemblies = Directory.GetFiles(pluginDir, "*Plugin.dll")
                                      .Select(Assembly.LoadFrom)
                                      .ToList();

            foreach (Assembly assmb in assemblies)
                containerBuilder.RegisterAssemblyTypes(assmb)
                    .Where(x => x.Name.EndsWith("Converter")).AsImplementedInterfaces();
        }
    }
}
