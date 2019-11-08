using JIPP5_LAB.Constants;
using JIPP5_LAB.Interfaces;
using JIPP5_LAB.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Unity;

namespace JIPP5_LAB
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IUnityContainer Container { get; }
        public MainWindow(IUnityContainer unityContainer)
        {
            InitializeComponent();
            Container = unityContainer;

            TabControl.Items.Add(CreateTab(Container.Resolve<ILengthConverterView>(), UIElements.LengthConverter));
            TabControl.Items.Add(CreateTab(Container.Resolve<IWeightConverterView>(), UIElements.WeightConverter));
            TabControl.Items.Add(CreateTab(Container.Resolve<ITemperatureConverterView>(), UIElements.TemperatureConverter));
            TabControl.Items.Add(CreateTab(Container.Resolve<IConversionHistoryView>(), UIElements.ConversionHistory));
        }

        private TabItem CreateTab(IView view, string header)
        {
            return new TabItem()
            {
                Content = view,
                Header = header
            };
        }
    }
}
