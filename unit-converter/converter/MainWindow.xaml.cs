using System;
using System.Windows;
using System.Windows.Controls;
    using System.Linq;

namespace converter
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
        UnitConverter converter = new UnitConverter();
        ITelemetryRepository repository;

        public float From { set; get; }
        public float To { set; get; }


        public MainWindow(ITelemetryRepository repository)
        {
            InitializeComponent();
            DataContext = this;

            this.repository = repository;

            UnitsTypeComboBox.ItemsSource = Enum.GetNames(typeof(UnitsType));
            UnitsTypeComboBox.SelectedItem = converter.unitsType.ToString();

            LoadTelemetry();
        }

        private void LoadTelemetry()
        {
            using (var ctx = new ConverterCtx())
            {
                TelemetryGrid.ItemsSource = repository.GetTelemetries();
            }
        }

        private void UnitsTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            converter.unitsType = (UnitsType)Enum.Parse(typeof(UnitsType), UnitsTypeComboBox.SelectedItem.ToString());
            var unitList = converter.GetUnits();
            FromUnitComboBox.ItemsSource = unitList;
            ToUnitComboBox.ItemsSource = unitList;
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
                To = converter.Convert(From);
                Result.Text = To.ToString();


                var telemetry = new TelemetryDTO()
                {
                    Date = DateTime.Now,
                    Type = converter.unitsType.ToString(),
                    UnitFrom = converter.fromUnit,
                    UnitTo = converter.toUnit,
                    ValueFrom = From,
                    ValueTo = To
                };
                repository.AddTelemetry(telemetry);
                TelemetryGrid.ItemsSource = repository.GetTelemetries();
        }

        private void FromUnitComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                converter.fromUnit = FromUnitComboBox.SelectedItem.ToString();
            }
            catch
            {
                converter.fromUnit = "";
            }
        }

        private void ToUnitComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                converter.toUnit = ToUnitComboBox.SelectedItem.ToString();
            }
            catch
            {
                converter.toUnit = "";
            }
        }
    }
}
