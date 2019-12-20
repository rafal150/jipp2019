using Autofac;
using konwerter.services;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace konwerter
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class Owner : Window
    {
        private IUsageStatisticsRepo repository;
        public Owner(IUsageStatisticsRepo repo)
        {
            InitializeComponent();

            this.repository = repo;
            this.conversionsNumberTextBlock.Text = repository.GetStatistics();
        }

        private void ToConverterButton_Click(object sender, RoutedEventArgs e)
        {
            IContainer container = BuildContainer();

            ConverterWindow NewConverterWindow = container.Resolve<ConverterWindow>();
            NewConverterWindow.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private static IContainer BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();

            if (ConfigurationManager.AppSettings["StatisticsRepositorySwitch"] == "AzureStorage")
            {
                containerBuilder.RegisterType<UsageStatisticsAzureRepo>().As<IUsageStatisticsRepo>();
            }
            else
            {
                containerBuilder.RegisterType<UsageStatisticsSqlRepo>().As<IUsageStatisticsRepo>();
            }

            containerBuilder.RegisterType<ConverterWindow>();
            containerBuilder.RegisterType<ConvertersService>();

            var assembly = typeof(ConvertersService).Assembly;
            //var assembly = Assembly.GetExecutingAssembly();
            containerBuilder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Converter")).AsImplementedInterfaces();

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
                containerBuilder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Converter")).AsImplementedInterfaces();
            }
        }
    }
}
