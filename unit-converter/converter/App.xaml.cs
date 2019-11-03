using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace converter
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            var container = BuildContainer();

            MainWindow = container.Resolve<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);

        }

        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            if (ConfigurationManager.AppSettings["TelemetriesRepository"] == "Azure")
            {
                builder.RegisterType<TelemetryAzureRepository>().As<ITelemetryRepository>();
            }
            else
            {
                builder.RegisterType<TelemetrySqlRepository>().As<ITelemetryRepository>();
            }

            builder.RegisterType<MainWindow>();

            return builder.Build();
        }
    }
}
