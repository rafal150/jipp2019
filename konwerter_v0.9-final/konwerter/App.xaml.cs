using Autofac;
using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace konwerter
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

            this.MainWindow = container.Resolve<Owner>();
            this.MainWindow.Show();
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

            containerBuilder.RegisterType<Owner>();

            return containerBuilder.Build();
        }
    }
}