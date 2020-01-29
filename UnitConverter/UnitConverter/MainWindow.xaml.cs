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
using System.Configuration;
using UnitConverter.Converters;

namespace UnitConverter {
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private IStatisticsRepository statisticsRepository;

        public MainWindow(IStatisticsRepository statisticsRepository, Converters.Converters converters) {
            InitializeComponent();

            // set statistics repository
            this.statisticsRepository = statisticsRepository;
            // load statistics to data grid
            StatisticsDataGrid.ItemsSource = this.statisticsRepository.GetStatistics();

            // set conversion type combobox items
            ConversionType.ItemsSource = converters.GetConverters();
            // select first item
            ConversionType.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            try {
                // unit from and unit to have to be selected and unit from value has to be fulfilled
                UnitFromError.Content = (UnitFrom.SelectedIndex == 0) ? "Select unit" : ((ValueFrom.Text == "") ? "Enter value" : "");
                UnitToError.Content = (UnitTo.SelectedIndex == 0) ? "Select unit" : "";
                if (UnitFrom.SelectedIndex != 0 && UnitTo.SelectedIndex != 0 && ValueFrom.Text != "") {
                    // try to parse string to double
                    if (!double.TryParse(ValueFrom.Text.Replace(".", ","), out double valueFrom)) {
                        UnitFromError.Content = "Enter numeric value";
                    } else {
                        double valueTo = ((IConverter) ConversionType.SelectedItem).Convert(UnitFrom.Text, UnitTo.Text, valueFrom);
                        // parse double to string and assign to TextBox
                        ValueTo.Text = valueTo.ToString();
                        // save to statistics to database
                        StatisticDTO statistic = new StatisticDTO() {
                            DateTime = DateTime.Now,
                            ConversionType = ((IConverter) ConversionType.SelectedItem).Name,
                            UnitFrom = UnitFrom.Text,
                            UnitTo = UnitTo.Text,
                            ValueFrom = valueFrom,
                            ValueTo = valueTo
                        };
                        statisticsRepository.AddStatistic(statistic);
                        // load statistics to data grid
                        StatisticsDataGrid.ItemsSource = statisticsRepository.GetStatistics();
                    }
                }
            } catch (Exception ex) {
                ButtonError.Content = ex.Message;
            }
        }

        private void ConversionType_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            // set unit from and unit to comboboxes items
            UnitFrom.ItemsSource = UnitTo.ItemsSource = new List<string> { "select" }.Concat(((IConverter) ConversionType.SelectedItem).Units);
            // select first item
            UnitFrom.SelectedIndex = UnitTo.SelectedIndex = 0;
        }

        private void UnitFrom_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            /*
            if (UnitFromError != null) {
                UnitFromError.Content = (UnitFrom.SelectedIndex == 0) ? "Select unit" : "";
            }
            */
        }

        private void UnitTo_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            /*
            if (UnitToError != null) {
                UnitToError.Content = (UnitTo.SelectedIndex == 0) ? "Select unit" : "";
            }
            */
        }
    }
}
