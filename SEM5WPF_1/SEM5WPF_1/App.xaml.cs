using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Autofac;


namespace SEM5WPF_1
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IContainer container = BulidContainer();
            this.MainWindow = container.Resolve<MainWindow>();
            this.MainWindow.Show();
        }

        private static IContainer BulidContainer()
        {
            var containerBulider = new ContainerBuilder();

            if(ConfigurationManager.AppSettings["StatisticsRepository"] == "AzureStorage")
            {
                containerBulider.RegisterType<StatystykiAzureRepozytorium>().As<IStatystykiRepozytorium>();
            }
            else
            {
                containerBulider.RegisterType<StatystykiSqlRepozytorium>().As<IStatystykiRepozytorium>();
            }

            containerBulider.RegisterType<MainWindow>();

            return containerBulider.Build();
        
        }
    }
}
