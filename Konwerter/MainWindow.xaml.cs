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

namespace Konwerter
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string fromUnit = "";
        public static string toUnit = "";
        private InterfaceStatisticsRepository repository;
        public MainWindow(InterfaceStatisticsRepository repo)
        {
            InitializeComponent();

            this.repository = repo;
            this.dbGrid.ItemsSource = repository.GetStatistics();

            this.convenrsionTypeCombo.ItemsSource =
                new List<string>(new[] { "Temperature", "Length", "Weight" });
        }

        private void ConvenrsionTypeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (convenrsionTypeCombo.SelectedItem.ToString())
            {
                case "Temperature":
                    {
                        List<string> convertionUnits = new List<string> { "Celsius", "Fahrenheit", "Kelvin", "Rankine" };
                        this.fromCombo.ItemsSource = convertionUnits;
                        this.toCombo.ItemsSource = convertionUnits;
                        break;
                    }
                case "Length":
                    {
                        List<string> convertionUnits = new List<string> { "mm", "cm", "dm", "m", "km", "cal", "stopa", "jard", "mila", "kabel", "mila morska" };
                        this.fromCombo.ItemsSource = convertionUnits;
                        this.toCombo.ItemsSource = convertionUnits;
                        break;
                    }
                case "Weight":
                    {
                        List<string> convertionUnits = new List<string> { "mg", "g", "dkg", "kg", "T", "uncja", "funt", "karat", "kwintal" };
                        this.fromCombo.ItemsSource = convertionUnits;
                        this.toCombo.ItemsSource = convertionUnits;
                        break;
                    }
            }
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (convenrsionTypeCombo.SelectedItem.ToString())
                {
                    case "Temperature":
                        {
                            this.convertedValue.Text =
                                TemperatureConversion.Convert(Convert.ToDouble(this.valueToConvert.Text)).ToString();
                            break;
                        }
                    case "Length":
                        {
                            this.convertedValue.Text =
                                LengthConversion.Convert(Convert.ToDouble(this.valueToConvert.Text)).ToString();
                            break;
                        }
                    case "Weight":
                        {
                            this.convertedValue.Text =
                                WeightConversion.Convert(Convert.ToDouble(this.valueToConvert.Text)).ToString();
                            break;
                        }
                }
            }
            catch
            {
                this.convertedValue.Text = "Invalid input value";
            }

            DbLoad();
        }

        private void FromCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                fromUnit = fromCombo.SelectedItem.ToString();
            }
            catch
            {
                fromUnit = "";
            }
        }

        private void ToCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                toUnit = toCombo.SelectedItem.ToString();
            }
            catch
            {
                toUnit = "";
            }
        }

        private void DbLoad()
        {
            try
            {
                StatisticsDTO stats = new StatisticsDTO()
                {
                    conversionType = convenrsionTypeCombo.SelectedItem.ToString(),
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
