using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UnitConversion;

namespace UnitConversion
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

            this.MainWindow = container.Resolve<MainWindow>();
            this.MainWindow.Show();
        }

        private static IContainer BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();

            if(ConfigurationManager.AppSettings["ServiceRepository"] == "AzureStorage")
            {
                containerBuilder.RegisterType<AzureServiceRepository>().As<IServiceRepository>();
            }
            else if(ConfigurationManager.AppSettings["ServiceRepository"] == "SQL")
            {
                containerBuilder.RegisterType<SqlServiceRepository>().As<IServiceRepository>();
            }
            containerBuilder.RegisterType<MainWindow>();
            return containerBuilder.Build();
        }
    }
}
