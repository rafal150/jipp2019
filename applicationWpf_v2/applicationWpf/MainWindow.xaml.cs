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
using System.Net;
using Newtonsoft.Json;

namespace applicationWpf
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static IStatisticsRepository repo;
        ConverterService pluginConverters;

        public MainWindow(IStatisticsRepository rep, ConverterService converters)
        {
            InitializeComponent();
            pluginConverters = converters;
            unitSelect.ItemsSource = converters.GetConverters();
            repo = rep;
        }

        private void ConvertUnit(object sender, RoutedEventArgs e)
        {
           bool bValidTemp = double.TryParse(tempboxfrom.Text, out double value);
            if (!bValidTemp)
                return;

            ConverterService.Converter selectedConverter = unitSelect.SelectedItem as ConverterService.Converter;
            string unitFrom = selectedConverter.suffix[templistfrom.SelectedIndex];
            string unitTo = selectedConverter.suffix[templistto.SelectedIndex];
            string convName = selectedConverter.converterName;

            double convertedValue = pluginConverters.Convert(unitFrom, unitTo, tempboxfrom.Text, convName);
            ConvSupply.pairData(selectedConverter.suffix.ToArray(), templistfrom.SelectedIndex, templistto.SelectedIndex, value, convertedValue, convName);
            string resultString = ConvSupply.GetConvertedString();
            tempboxto.Text = resultString;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = @"https://localhost:44320/api/converters/getstatistics";
            string valueString;
            using (WebClient client = new WebClient())
            {;
                client.Encoding = Encoding.UTF8;
                valueString = client.DownloadString(url);
            }
            StatisticsDTO[] statisticsDeserialized = JsonConvert.DeserializeObject<StatisticsDTO[]>(valueString, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Ignore });

            statisticgrid.Items.Clear();
            var stats = statisticsDeserialized;

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
            var dupa = (unitSelect.SelectedItem as ConverterService.Converter);
            templistfrom.ItemsSource = dupa.indexes;
            templistto.ItemsSource = dupa.indexes;
            templistfrom.SelectedIndex = 0;
            templistto.SelectedIndex = 1;
        }
    }
}
