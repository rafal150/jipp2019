using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WPFConverterv2
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            

            IContainer container = BuildContainer();

            this.MainWindow = container.Resolve<MainWindow>();
            this.MainWindow.Show();
            base.OnStartup(e);
        }

        private static IContainer BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();

            if (ConfigurationManager.AppSettings["StatisticsRepository"] == "AzureStorage")
            {
                containerBuilder.RegisterType<StatisticsAzureStorage>().As<IStatisticsRepository>();
            }
            else
            {
                containerBuilder.RegisterType<StatisticsSqlRepository>().As<IStatisticsRepository>();
            }

            containerBuilder.RegisterType<MainWindow>();

            return containerBuilder.Build();
        }
    }
}
