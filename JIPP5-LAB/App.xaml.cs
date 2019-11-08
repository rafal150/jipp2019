using JIPP5_LAB.Helpers;
using JIPP5_LAB.Interfaces;
using JIPP5_LAB.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;

namespace JIPP5_LAB
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IUnityContainer Container = new UnityContainer();

            if (ConfigurationManager.AppSettings["StatisticsRepository"] == "AzureStorage")
            {
                Container.RegisterType(typeof(IDataHelper), typeof(AzureHelper));
            }
            else
            {
                Container.RegisterType(typeof(IDataHelper), typeof(DatabaseHelper));
            }
            Container.RegisterType<IConversionHistoryView, ConversionHistoryView>();
            Container.RegisterType<ITemperatureConverterView, TemperatureConverterView>();
            Container.RegisterType<IWeightConverterView, WeightConverterView>();
            Container.RegisterType<ILengthConverterView, LengthConverterView>();
            Container.RegisterType<IConverterHelper, ConverterHelper>();
            this.MainWindow = Container.Resolve<MainWindow>();
            this.MainWindow.Show();
        }
    }
}
