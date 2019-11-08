using JIPP5_LAB.Helpers;
using JIPP5_LAB.Interfaces;
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

namespace JIPP5_LAB.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ConversionHistoryView.xaml
    /// </summary>
    public partial class ConversionHistoryView : UserControl, IConversionHistoryView
    {
        IDataHelper DataHelper { get; }
        IUnityContainer Container { get; }
        public ConversionHistoryView(IDataHelper dataHelper, IUnityContainer unityContainer)
        {
            InitializeComponent();
            DataHelper = dataHelper;
            Container = unityContainer;
            this.StatisticsDataGrid.ItemsSource = DataHelper.GetRecords();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.StatisticsDataGrid.ItemsSource = DataHelper.GetRecords();
        }
    }
}
