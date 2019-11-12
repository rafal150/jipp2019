using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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
using System.Reflection;

namespace applicationWpf
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static IStatisticsRepository repo;
        List<ConverterBase> pluginConverters;

        public MainWindow(IStatisticsRepository rep, ConverterService converters)
        {
            InitializeComponent();
            pluginConverters = converters.GetConverters();
            unitSelect.ItemsSource = pluginConverters;
            repo = rep;
        }

        private void ConvertUnit(object sender, RoutedEventArgs e)
        {
           bool bValidTemp = double.TryParse(tempboxfrom.Text, out double value);
            if (!bValidTemp)
                return;
            ConverterBase tc = (unitSelect.SelectedItem as ConverterBase);
            int fromIndex = templistfrom.SelectedIndex;
            int toIndex = templistto.SelectedIndex;
            double convertedValue = tc.Convert(value, fromIndex, toIndex);
            ConvSupply.pairData(tc.suffix, fromIndex, toIndex, value, convertedValue, tc.converterName);
            string resultString = ConvSupply.GetConvertedString();
            if (convertedValue != double.NaN)
                ConvSupply.AddDbEntry();
            tempboxto.Text = resultString;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            statisticgrid.Items.Clear();
            var stats = repo.GetStatistics();

            entrieslabel.Content = $"Total entries: {stats.Count()}"; 
            var tempCount = stats.Where(x => x.Type == "temperature").Count(); 
            var distCount = stats.Where(x => x.Type == "distance").Count();
            var massCount = stats.Where(x => x.Type == "mass").Count();

            totaltemplabel.Content = $"Total temperature conversions: {tempCount}";
            totaldistlabel.Content = $"Total distance conversions: {distCount}";
            totalmasslabel.Content = $"Total mass conversions: {massCount}";

            foreach (var statisticEntity in stats)
                statisticgrid.Items.Add(statisticEntity);
        }

        private void unitSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dupa = (unitSelect.SelectedItem as ConverterBase);
            templistfrom.ItemsSource = dupa.indexes;
            templistto.ItemsSource = dupa.indexes;
            templistfrom.SelectedIndex = 0;
            templistto.SelectedIndex = 1;
        }
    }
}
