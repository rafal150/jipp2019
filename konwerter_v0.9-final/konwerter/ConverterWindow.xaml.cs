using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Shapes;

namespace konwerter
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class ConverterWindow : Window
    {
        private IUsageStatisticsRepo repository;
        public ConverterWindow(IUsageStatisticsRepo repo)
        {
            InitializeComponent();

            this.repository = repo;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            using (Model1 context = new Model1())
            {
                // Temperature ComboBoxes Items Load
                this.InputTemperatureComboBox.ItemsSource = context.TempUnits.ToList();
                this.InputTemperatureComboBox.SelectedValuePath = "ID";
                this.InputTemperatureComboBox.DisplayMemberPath = "UnitName";
                this.InputTemperatureComboBox.SelectedIndex = 0;

                this.OutputTemperatureComboBox.ItemsSource = context.TempUnits.ToList();
                this.OutputTemperatureComboBox.SelectedValuePath = "ID";
                this.OutputTemperatureComboBox.DisplayMemberPath = "UnitName";
                this.OutputTemperatureComboBox.SelectedIndex = 1;

                // Lenght ComboBoxes Items Load
                this.InputLenghtComboBox.ItemsSource = context.LenghtUnits.ToList();
                this.InputLenghtComboBox.SelectedValuePath = "ID";
                this.InputLenghtComboBox.DisplayMemberPath = "UnitName";
                this.InputLenghtComboBox.SelectedIndex = 0;

                this.OutputLenghtComboBox.ItemsSource = context.LenghtUnits.ToList();
                this.OutputLenghtComboBox.SelectedValuePath = "ID";
                this.OutputLenghtComboBox.DisplayMemberPath = "UnitName";
                this.OutputLenghtComboBox.SelectedIndex = 1;

                // Weight ComboBoxes Items Load
                this.InputWeightComboBox.ItemsSource = context.WieghtUnits.ToList(); // Wieght literowka
                this.InputWeightComboBox.SelectedValuePath = "ID";
                this.InputWeightComboBox.DisplayMemberPath = "UnitName";
                this.InputWeightComboBox.SelectedIndex = 0;

                this.OutputWeightComboBox.ItemsSource = context.WieghtUnits.ToList(); // Wieght literowka
                this.OutputWeightComboBox.SelectedValuePath = "ID";
                this.OutputWeightComboBox.DisplayMemberPath = "UnitName";
                this.OutputWeightComboBox.SelectedIndex = 1;
            }
        }

        //===================== Temperature Convert Button ==========================
        // INFO: Converts to kelvin then to desired unit
        private void ConvertTemperatureButton_Click(object sender, RoutedEventArgs e)
        {
            decimal temperatureConversionResult;
            decimal.TryParse(InputTemperatureTextBox.Text, out decimal inputUnitValue);

            using (Model1 context = new Model1())
            {
                // Convert input unit to kelvin
                switch (InputTemperatureComboBox.Text)
                {
                    case "Rankine":
                        TempUnits TempUnitsRow = context.TempUnits.Single(a => a.UnitName == "Rankine");
                        decimal.TryParse((TempUnitsRow.UnitBaseValue.ToString()), out decimal UnitBaseValueTmp);
                        temperatureConversionResult = decimal.Multiply(inputUnitValue, UnitBaseValueTmp);
                        break;

                    case "kelvin":
                        decimal.TryParse(InputTemperatureTextBox.Text, out inputUnitValue);
                        temperatureConversionResult = inputUnitValue;
                        break;

                    case "Fahrenheit":
                        decimal FahrenheitTmp = decimal.Divide(5, 9);
                        temperatureConversionResult = decimal.Add(inputUnitValue, 459.67M);
                        temperatureConversionResult = decimal.Multiply(temperatureConversionResult, FahrenheitTmp);
                        break;

                    default:
                        TempUnitsRow = context.TempUnits.Single(a => a.UnitName == InputTemperatureComboBox.Text);
                        decimal.TryParse((TempUnitsRow.UnitBaseValue.ToString()), out UnitBaseValueTmp);
                        temperatureConversionResult = decimal.Add(inputUnitValue, UnitBaseValueTmp);
                        break;
                }

                // Convert temperature from kelvin to desired unit
                if (OutputTemperatureComboBox.Text == "Rankine")
                {
                    // Output Rankine
                    const decimal kelvinInRankines = 1.8M;
                    temperatureConversionResult = decimal.Multiply(temperatureConversionResult, kelvinInRankines);
                    OutputTemperatureTextBlock.Text = temperatureConversionResult.ToString();
                }
                else if (OutputTemperatureComboBox.Text == "Celsius")
                {
                    // Convert from Kelvin to Celsius
                    TempUnits TempUnitsRow = context.TempUnits.Single(a => a.UnitName == OutputTemperatureComboBox.Text);

                    decimal.TryParse((TempUnitsRow.UnitBaseValue.ToString()), out decimal UnitBaseValueTmp);

                    temperatureConversionResult = decimal.Subtract(temperatureConversionResult, UnitBaseValueTmp);

                    // Output Celsius
                    OutputTemperatureTextBlock.Text = temperatureConversionResult.ToString();
                }
                else if (OutputTemperatureComboBox.Text == "Fahrenheit")
                {
                    // Convert from Kelvin to Fahrenheit
                    decimal FahrenheitTmp = 1.8M;
                    temperatureConversionResult = decimal.Multiply(temperatureConversionResult, FahrenheitTmp);
                    temperatureConversionResult = decimal.Subtract(temperatureConversionResult, 459.67M);

                    // Output Fahrenheit
                    OutputTemperatureTextBlock.Text = temperatureConversionResult.ToString();
                }
                else if (OutputTemperatureComboBox.Text == "kelvin")
                {
                    OutputTemperatureTextBlock.Text = temperatureConversionResult.ToString();
                }

                // Save to database
                StatisticDTO usageStatisticsEntry = new StatisticDTO
                {
                    DateTime = DateTime.Now,
                    UnitType = "Temperature",
                    InputUnit = InputTemperatureComboBox.Text,
                    OutputUnit = OutputTemperatureComboBox.Text,
                    Value = inputUnitValue
                };

                this.repository.AddStatistic(usageStatisticsEntry);
            }
        }

        //================== Lenght Convert Button ==================================
        // INFO: Converts to meters then to desired unit
        private void ConvertLenghtButton_Click(object sender, RoutedEventArgs e)
        {
            // Parse input text do decimal datatype
            decimal.TryParse(InputLenghtTextBox.Text, out decimal inputUnitValue);

            using (Model1 context = new Model1())
            {

                // Convert to meters
                LenghtUnits lenghtUnitsRecord = context.LenghtUnits.Single(a => a.UnitName == InputLenghtComboBox.Text);

                decimal.TryParse((lenghtUnitsRecord.UnitBaseValue.ToString()), out decimal UnitBaseValueTmp);

                decimal lenghtConversionResult = decimal.Multiply(inputUnitValue, UnitBaseValueTmp);

                // Convert from meters to selected unit
                switch (OutputLenghtComboBox.Text)
                {
                    case "mile":
                        decimal meterInMiles = 0.0006213712M;
                        lenghtConversionResult = decimal.Multiply(lenghtConversionResult, meterInMiles);
                        break;

                    case "yard":
                        decimal meterInYards = 1.0936132983M;
                        lenghtConversionResult = decimal.Multiply(lenghtConversionResult, meterInYards);
                        break;

                    case "foot":
                        decimal meterInFoots = 3.280839895M;
                        lenghtConversionResult = decimal.Multiply(lenghtConversionResult, meterInFoots);
                        break;

                    case "inch":
                        decimal meterInInches = 39.37007874M;
                        lenghtConversionResult = decimal.Multiply(lenghtConversionResult, meterInInches);
                        break;

                    case "nautical mile":
                        decimal meterInNauticalMiles = 0.000539956803M;
                        lenghtConversionResult = decimal.Multiply(lenghtConversionResult, meterInNauticalMiles);
                        break;

                    case "cable lenght":
                        decimal meterInCableLenghts = 0.004556722076M;
                        lenghtConversionResult = decimal.Multiply(lenghtConversionResult, meterInCableLenghts);
                        break;

                    default:
                        lenghtUnitsRecord = context.LenghtUnits.Single(a => a.UnitName == OutputLenghtComboBox.Text);
                        decimal.TryParse((lenghtUnitsRecord.UnitBaseValue.ToString()), out UnitBaseValueTmp);
                        lenghtConversionResult = decimal.Divide(lenghtConversionResult, UnitBaseValueTmp);
                        break;
                }

                // Output result
                OutputLenghtTextBlock.Text = lenghtConversionResult.ToString();

                // Save to database
                StatisticDTO usageStatisticsEntry = new StatisticDTO
                {
                    DateTime = DateTime.Now,
                    UnitType = "Lenght",
                    InputUnit = InputLenghtComboBox.Text,
                    OutputUnit = OutputLenghtComboBox.Text,
                    Value = inputUnitValue
                };

                this.repository.AddStatistic(usageStatisticsEntry);
            }
        }

        //====================== Weight Convert Button ====================
        // INFO: Converts to kilograms then to desired unit
        private void ConvertWeightButton_Click(object sender, RoutedEventArgs e)
        {
            // Parse input text do decimal datatype
            decimal.TryParse(InputWeightTextBox.Text, out decimal inputUnitValue);

            using (Model1 context = new Model1())
            {

                // Convert to kilograms
                WieghtUnits weightUnitsRow = context.WieghtUnits.Single(a => a.UnitName == InputWeightComboBox.Text);

                decimal.TryParse((weightUnitsRow.UnitBaseValue.ToString()), out decimal UnitBaseValueTmp);

                decimal weightConversionResult = decimal.Multiply(inputUnitValue, UnitBaseValueTmp);

                // Convert from kilograms to selected unit
                weightUnitsRow = context.WieghtUnits.Single(a => a.UnitName == OutputWeightComboBox.Text);

                switch (OutputWeightComboBox.Text)
                {
                    case "ounce":
                        decimal kilogramInOunces = 35.27396195M;
                        weightConversionResult = decimal.Multiply(weightConversionResult, kilogramInOunces);
                        break;

                    case "pound":
                        decimal kilogramInPounds = 2.2046226218M;
                        weightConversionResult = decimal.Multiply(weightConversionResult, kilogramInPounds);
                        break;

                    case "carat":
                        decimal kilogramInCarats = 5000;
                        weightConversionResult = decimal.Multiply(weightConversionResult, kilogramInCarats);
                        break;

                    default:
                        decimal.TryParse((weightUnitsRow.UnitBaseValue.ToString()), out UnitBaseValueTmp);
                        weightConversionResult = decimal.Divide(weightConversionResult, UnitBaseValueTmp);
                        break;
                }

                // Output result
                OutputWeightTextBlock.Text = weightConversionResult.ToString();

                // Save to database
                StatisticDTO usageStatisticsEntry = new StatisticDTO
                {
                    DateTime = DateTime.Now,
                    UnitType = "Weight",
                    InputUnit = InputWeightComboBox.Text,
                    OutputUnit = OutputWeightComboBox.Text,
                    Value = inputUnitValue
                };
                this.repository.AddStatistic(usageStatisticsEntry);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (Owner != null)
            {
                Owner.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}