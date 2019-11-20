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
using Converter.SDK;
using Konwerter.Services;

namespace Konwerter
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IStatisticsRepository repository;
        public MainWindow(IStatisticsRepository repo, ConvertersService converters)
        {
            InitializeComponent();

            this.repository = repo;
            this.dbGrid.ItemsSource = repository.GetStatistics();

            this.convenrsionTypeCombo.ItemsSource = converters.GetConverters();
        }

        private void ConvenrsionTypeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.convenrsionTypeCombo.SelectedItem != null)
            {
                this.fromCombo.ItemsSource = ((IConverter)this.convenrsionTypeCombo.SelectedItem).Units;
                this.toCombo.ItemsSource = ((IConverter)this.convenrsionTypeCombo.SelectedItem).Units;
            }
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IConverter converter = (IConverter)this.convenrsionTypeCombo.SelectedItem;
                double result = converter.Convert(fromCombo.SelectedItem.ToString(), toCombo.SelectedItem.ToString(),  Convert.ToDouble(this.valueToConvert.Text));

                this.convertedValue.Text = result.ToString();
            }
            catch
            {
                this.convertedValue.Text = "Invalid input value";
            }

            DbLoad();
        }

        private void DbLoad()
        {
            try
            {
                IConverter converter = (IConverter)this.convenrsionTypeCombo.SelectedItem;
                StatisticsDTO stats = new StatisticsDTO()
                {
                    conversionType = converter.Name,
                    fromUnit = fromCombo.SelectedItem.ToString(),
                    valueToConvert = valueToConvert.Text,
                    toUnit = toCombo.SelectedItem.ToString(),
                    convertedValue = convertedValue.Text,
                    dateTime = DateTime.Now,
                };

                this.repository.AddStatistics(stats);
                this.dbGrid.ItemsSource = repository.GetStatistics();
            }
            catch
            {
                this.convertedValue.Text = "What?";
            }
        }
    }
}
