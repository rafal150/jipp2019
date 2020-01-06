using Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
//using IContainer = System.ComponentModel.IContainer;
//using IContainer = Autofac.IContainer;

namespace Konwerter_Azure
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Autofac.IContainer container = BuildContainer();

            this.MainWindow = container.Resolve<MainWindow>();
            this.MainWindow.Show();
        }

        private static Autofac.IContainer BuildContainer()
        {
            var myContainerBuilder = new ContainerBuilder();

            if (ConfigurationManager.AppSettings["StatisticsRepository"] == "AzureStorage")
            {
                myContainerBuilder.RegisterType<StatisticsAzureStorageRepository>().As<IStatisticsRepository>();
            }
            else
            {
                myContainerBuilder.RegisterType<StatisticsSqlRepository>().As<IStatisticsRepository>();
            }

            myContainerBuilder.RegisterType<MainWindow>();

            return myContainerBuilder.Build();
        }
    }
}
// 