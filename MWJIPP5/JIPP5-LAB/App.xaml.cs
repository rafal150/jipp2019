using Autofac;
using JIPP5_LAB.bazydanych;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace JIPP5_LAB
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

            if (ConfigurationManager.AppSettings["StatisticsRepository"] == "AzureStorage")
            {
                containerBuilder.RegisterType<Azure>().As<IPobieranieDanych>();
            }
            else
            {
                containerBuilder.RegisterType<BazaDanych>().As<IPobieranieDanych>();
            }

            containerBuilder.RegisterType<MainWindow>();
            containerBuilder.RegisterType<ConvertersService>();
            containerBuilder.RegisterType<ConvertersApi>();

            var assembly = typeof(ConvertersService).Assembly;
            containerBuilder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Converter")).AsImplementedInterfaces();

            RegisterPlugins(containerBuilder);

            return containerBuilder.Build();
        }

        private static void RegisterPlugins(ContainerBuilder containerBuilder)
        {
            string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pluginDirectory = Path.Combine(assemblyDirectory, "plugins");
            Directory.CreateDirectory(pluginDirectory);
            var assemblies = Directory.GetFiles(pluginDirectory, "*Plugin.dll").Select(Assembly.LoadFrom).ToList();

            foreach (Assembly assembly in assemblies)
            {
                containerBuilder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Converter")).AsImplementedInterfaces();
            }
        }
    }
}