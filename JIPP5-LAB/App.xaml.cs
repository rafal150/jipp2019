using JIPP5_LAB.DataProviders;
using JIPP5_LAB.Interfaces;
using JIPP5_LAB.SDK;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using Unity;

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
            IUnityContainer Container = BuildContainer();

            this.MainWindow = Container.Resolve<MainWindow>();
            this.MainWindow.Show();
        }

        private IUnityContainer BuildContainer()
        {
            var container = new UnityContainer();

            if (ConfigurationManager.AppSettings["StatisticsRepository"] == "AzureStorage")
            {
                container.RegisterType(typeof(IDataHelper), typeof(AzureHelper));
            }
            else
            {
                container.RegisterType(typeof(IDataHelper), typeof(DatabaseHelper));
            }
            RegisterTypes(Assembly.GetExecutingAssembly(), container);
            RegisterPlugins(container);
            return container;
        }

        private void RegisterPlugins(IUnityContainer container)
        {
            string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pluginDirectory = Path.Combine(assemblyDirectory, "plugins");
            Directory.CreateDirectory(pluginDirectory);
            var assemblies = Directory.GetFiles(pluginDirectory, "*Plugin.dll").Select(Assembly.LoadFrom).ToList();
            foreach (var assembly in assemblies)
            {
                RegisterTypes(assembly, container);
            }
        }

        private void RegisterTypes(Assembly assembly, IUnityContainer container)
        {
            var listOfConverters = assembly.GetTypes().Where(x => x.Name.EndsWith("ConverterHelper") && x.IsClass).ToList();
            var listOfViews = assembly.GetTypes().Where(x => x.Name.EndsWith("View") && x.IsClass).ToList();
            foreach (var item in listOfConverters)
            {
                container.RegisterType(typeof(IConverterHelper), item, item.Name);
            }
            foreach (var item in listOfViews)
            {
                container.RegisterType(typeof(IView), item, item.Name);
            }
        }
    }
}