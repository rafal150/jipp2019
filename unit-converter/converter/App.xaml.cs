using Autofac;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace converter
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            var container = BuildContainer();

            MainWindow = container.Resolve<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);

        }

        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            if (ConfigurationManager.AppSettings["TelemetriesRepository"] == "Azure")
            {
                builder.RegisterType<TelemetryAzureRepository>().As<ITelemetryRepository>();
            }
            else
            {
                builder.RegisterType<TelemetrySqlRepository>().As<ITelemetryRepository>();
            }

            builder.RegisterType<MainWindow>();
            builder.RegisterType<ConvertersService>();
            
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Converter")).AsImplementedInterfaces();

            RegisterPlugins(builder);

            return builder.Build();
        }

        private static void RegisterPlugins(ContainerBuilder builder)
        {
            string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pluginDirectory = Path.Combine(assemblyDirectory, "plugins");            
            var assemblies = Directory.GetFiles(pluginDirectory, "*Plugin.dll").Select(Assembly.LoadFrom).ToList();            
            foreach (Assembly assembly in assemblies)
            {
                builder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Converter")).AsImplementedInterfaces();
            }        }
    }
}
