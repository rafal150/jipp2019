using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using Konwerter_Azure.Services;
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
            
            IContainer container = BuildContainer();

            this.MainWindow = container.Resolve<MainWindow>();
            this.MainWindow.Show();
        }

        private static IContainer BuildContainer()
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
            myContainerBuilder.RegisterType<ConvertersService>();

            var assembly = Assembly.GetExecutingAssembly();
            myContainerBuilder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Konwerter")).AsImplementedInterfaces();//rejestracja

            RejestrowaniePluginow(myContainerBuilder);

            return myContainerBuilder.Build();
        }

        private static void RejestrowaniePluginow(ContainerBuilder containerBuilder)
        {
            string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);// sciezka do exe
            string pluginDirectory = Path.Combine(assemblyDirectory, "plugins");// dodaje podfolder plugins

            var assemblies = Directory.GetFiles(pluginDirectory, "*Plugin.dll").Select(Assembly.LoadFrom).ToList(); // szukaj plikowkonczoncych sie na Plugin.dll

            foreach (Assembly assembly in assemblies)// na kazdym pliku wywoluje load from- to pobiera te biblioteki
            {
                containerBuilder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Konwerter")).AsImplementedInterfaces();
            }
        }
    }
}