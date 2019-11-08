using Autofac;
using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            //this.Visibility = System.Windows.Visibility.Hidden;

            //ConverterWindow NewConverterWindow = new ConverterWindow();
            //NewConverterWindow.ShowDialog();

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

            return containerBuilder.Build();
        }
    }
}
