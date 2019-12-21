using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
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
using WPFKonwerter.Model;
using WPFKonwerter.Services;

namespace WPFKonwerter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Statistics statistics;

        IStatisticsRepo repo;

        public MainWindow(IStatisticsRepo statRepo, KonwerterService converter)
        {
            InitializeComponent();
            repo = statRepo;  
            cbCategory.ItemsSource = converter.GetConverters();
            cbCategory.SelectedIndex = 0;
            //dgStatistics.ItemsSource = uce.Statistics_AC.ToList();
            dgStatistics.ItemsSource = statRepo.GetStats();

        }

        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbCategory.SelectedItem != null)
            {
                cbLeft.ItemsSource = cbRight.ItemsSource = (cbCategory.SelectedItem as ConverterSDK.IConvertible).Units;
                cbLeft.SelectedIndex = 0;
                cbRight.SelectedIndex = 1;
            }
        }
        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            string result = "";
            double valueToConvert;
            if (tbLeft.Text == "") return;
      
            if (!Double.TryParse(tbLeft.Text, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out valueToConvert))
            {
                lblErr.Visibility = Visibility.Visible;
                return;
            }
            valueToConvert = Math.Round(valueToConvert, 2);

            result = (cbCategory.SelectedItem as ConverterSDK.IConvertible).Convert(cbLeft.SelectedIndex, cbRight.SelectedIndex, valueToConvert);
            tbRight.Text = result;
            
            

            statistics = new Statistics()
            {
                CategoryType = cbCategory.SelectedValue.ToString(),
                ConversionDT = DateTime.Now,
                UnitFrom = cbLeft.SelectedValue.ToString(),
                ValueFrom = tbLeft.Text,
                UnitTo = cbRight.SelectedValue.ToString(),
                ValueTo = tbRight.Text
            };

            //zapis do bazki
            //if (Properties.Settings.Default.SaveToSQL)
            //    stats2SQL.SaveStats(statistics);
            //else
            //    stats2Azure.SaveStats(statistics);

            //nowy zapis
            repo.SaveStats(statistics);

            #region OLD save2sql -> przeniesione do oddzielnej klasy
            //uce.Statistics_AC.Add(new Statistics_AC()
            //{
            //    CategoryType = cbCategory.SelectedValue.ToString(),
            //    ConversionDT = DateTime.Now,
            //    UnitFrom = cbLeft.SelectedValue.ToString(),
            //    ValueFrom = tbLeft.Text,
            //    UnitTo = cbRight.SelectedValue.ToString(),
            //    ValueTo = tbRight.Text
            //}
            //);
            #endregion

            lblErr.Visibility = Visibility.Collapsed;
            
            dgStatistics.ItemsSource = null;
            dgStatistics.ItemsSource = repo.GetStats();
            //dgStatistics.ItemsSource=uce.Statistics_AC.ToList();

        }
    }
}
