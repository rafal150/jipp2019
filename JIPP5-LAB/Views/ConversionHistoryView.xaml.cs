using JIPP5_LAB.Constants;
using JIPP5_LAB.Interfaces;
using System.Windows;
using System.Windows.Controls;
using Unity;

namespace JIPP5_LAB.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ConversionHistoryView.xaml
    /// </summary>
    public partial class ConversionHistoryView : UserControl, IView
    {
        private IDataHelper DataHelper { get; }
        private IUnityContainer Container { get; }

        public string Header => UIElements.ConversionHistory;

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