using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Konwenter
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IContainer kontener = BuildContainer();
            this.MainWindow = kontener.Resolve<MainWindow>();
            this.MainWindow.Show();
        }

        private static IContainer BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();
            if (ConfigurationManager.AppSettings["RepozytoriumStatystyk"] == "AzureStorage")
            {
                containerBuilder.RegisterType<ZapisBazaAzureStorage>().As<IBazyDanych>();
            }
            else
            {
                containerBuilder.RegisterType<ZapisBazaSQL>().As<IBazyDanych>();
            }
            containerBuilder.RegisterType<MainWindow>();
            return containerBuilder.Build();
        }
    }
}
