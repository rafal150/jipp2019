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
using UnitConverter4.UnitConverters;

namespace UnitConverter4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IStatisticsRepository repository;
        private Dictionary<string, List<IUnitConverter>> unitConvertersPerType;

        public MainWindow(
            IStatisticsRepository repository,
            IEnumerable<IUnitConverter> unitConverters)
        {
            InitializeComponent();

            this.repository = repository;
            this.unitConvertersPerType = unitConverters.GroupBy(c => c.Type).ToDictionary(g => g.Key, g => g.ToList());

            this.TypeCombobox.ItemsSource = unitConvertersPerType.Keys;
            this.TypeCombobox.SelectedIndex = 0;

            this.statisticsDataGrid.ItemsSource = repository.GetStatistics();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var fromConverter = FromCombobox.SelectedItem as IUnitConverter;
            var toConverter = ToCombobox.SelectedItem as IUnitConverter;
            var fromValue = ParseDecimal(this.InputTextBox.Text);
            var toValue = toConverter.ConvertFromSI(fromConverter.ConvertToSI(fromValue));

            this.ResultTextBlock.Text = toValue.ToString();

            StatisticDTO st = new StatisticDTO()
            {
                DateTime = DateTime.Now,
                UnitFrom = fromConverter.Unit,
                UnitTo = toConverter.Unit,
                Type = fromConverter.Type,
                RawValue = fromValue,
                ConvertedValue = toValue
            };

            this.repository.AddStatistic(st);
            this.statisticsDataGrid.ItemsSource = repository.GetStatistics();
        }

        private decimal ParseDecimal(string value)
        {
            if(decimal.TryParse(value, out decimal result))
            {
                return result;
            }

            return 0m;
        }

        private void TypeCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var units = unitConvertersPerType[e.AddedItems[0].ToString()];

            this.FromCombobox.ItemsSource = units;
            this.FromCombobox.SelectedIndex = 0;

            this.ToCombobox.ItemsSource = units;
            this.ToCombobox.SelectedIndex = 0;
        }
    }
}
