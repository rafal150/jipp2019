using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using Autofac;
using Converter.Calculator;
using Microsoft.Extensions.DependencyInjection;

namespace Converter
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

        private static IContainer BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<MainWindow>();

            if (ConfigurationManager.AppSettings["ResultsRepository"] == "AzureStorage")
            {
                containerBuilder.RegisterType<AzureRepository>().As<ICalcRepository>();
            }
            else
            {
                containerBuilder.RegisterType<SQLRepository>().As<ICalcRepository>();
            }

            containerBuilder.RegisterType<CalculatorService>();

            var assembly = Assembly.GetExecutingAssembly();
            containerBuilder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Calculator")).AsImplementedInterfaces();

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
                containerBuilder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Calculator")).AsImplementedInterfaces();
            }
        }

        public void ConfigureServices(IServiceCollection services)
        {

        }
    }
}
