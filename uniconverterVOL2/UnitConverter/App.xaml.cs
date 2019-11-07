using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Autofac;

namespace UnitConverter
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

            if (ConfigurationManager.AppSettings["StatisticsRepository"] == "AzureStorage")
            {
                containerBuilder.RegisterType<StatisticAzureStorageRepository>().As<IRepository>();
            }
            else if (ConfigurationManager.AppSettings["StatisticsRepository"] == "SQL")
            {
                containerBuilder.RegisterType<StatisticSQLRepository>().As<IRepository>();
            }
            else
            {
                MessageBox.Show("Błędny odczyt bazy danych");
            }

            containerBuilder.RegisterType<MainWindow>();

            return containerBuilder.Build();
        }
    }
}

