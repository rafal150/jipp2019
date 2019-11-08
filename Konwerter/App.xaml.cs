using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Autofac;

namespace Konwerter
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IContainer container = BuildContainer();

            MainWindow = container.Resolve<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        private static IContainer BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();

            if (ConfigurationManager.AppSettings["StatisticsRepository"] == "AzureStorage")
            {
                containerBuilder.RegisterType<StatisticsAzureStorageRepository>().As<IStatisticRepository>();
            }
            else
            {
                containerBuilder.RegisterType<StatisticsSqlRepository>().As<IStatisticRepository>();
            }

            containerBuilder.RegisterType<MainWindow>();

            return containerBuilder.Build();
        }
    }

}
