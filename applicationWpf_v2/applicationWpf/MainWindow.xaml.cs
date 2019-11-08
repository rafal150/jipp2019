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

namespace applicationWpf
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static IStatisticsRepository repo;
        public MainWindow(IStatisticsRepository rep)
        {
            InitializeComponent();
            repo = rep;
        }

        private void TemperatureUnitConvert(object sender, RoutedEventArgs e)
        {
            bool bValidTemp = double.TryParse(tempboxfrom.Text, out double value);
            if (!bValidTemp)
                return;
            TemperatureConverter tc = new TemperatureConverter(value, templistfrom.SelectedIndex, templistto.SelectedIndex); 
            tc.Convert();
            string resultString = tc.GetConvertedString();
            tempboxto.Text = resultString;
        }


        private void DistanceUnitConvert(object sender, RoutedEventArgs e)
        {
            bool bValidTemp = double.TryParse(distboxfrom.Text, out double value);
            if (!bValidTemp)
                return;
            DistanceConverter tc = new DistanceConverter(value, distlistfrom.SelectedIndex, distlistto.SelectedIndex);
            tc.Convert();
            string resultString = tc.GetConvertedString();
            distboxto.Text = resultString;
        }


        private void MassUnitConvert(object sender, RoutedEventArgs e)
        {
            bool bValidTemp = double.TryParse(massboxfrom.Text, out double value);
            if (!bValidTemp)
                return;
            MassConverter tc = new MassConverter(value, masslistfrom.SelectedIndex, masslistto.SelectedIndex);
            tc.Convert();
            string resultString = tc.GetConvertedString();
            massboxto.Text = resultString;
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
    }
}
