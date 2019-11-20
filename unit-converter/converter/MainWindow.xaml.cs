using System;
using System.Windows;
using System.Windows.Controls;
    using System.Linq;
using System.Collections.Generic;

namespace converter
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
        List<IConverter> converters;
        ITelemetryRepository repository;

        public double From { set; get; }
        public double To { set; get; }


        public MainWindow(ITelemetryRepository repository, ConvertersService convertersService)
        {
            InitializeComponent();
            DataContext = this;

            this.repository = repository;
            this.converters = convertersService.GetConverters();

            UnitsTypeComboBox.ItemsSource = this.converters;

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
            var unitList = ((IConverter)UnitsTypeComboBox.SelectedItem).Units;
            FromUnitComboBox.ItemsSource = unitList;
            ToUnitComboBox.ItemsSource = unitList;
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            To = ((IConverter)UnitsTypeComboBox.SelectedItem).Convert(
                FromUnitComboBox.SelectedItem.ToString(),
                ToUnitComboBox.SelectedItem.ToString(),
                From
            );
            Result.Text = To.ToString();
            
            var telemetry = new TelemetryDTO()
            {
                Date = DateTime.Now,
                Type = ((IConverter)UnitsTypeComboBox.SelectedItem).Name,
                UnitFrom = FromUnitComboBox.SelectedItem.ToString(),
                UnitTo = ToUnitComboBox.SelectedItem.ToString(),
                ValueFrom = From,
                ValueTo = To
            };
            repository.AddTelemetry(telemetry);
            TelemetryGrid.ItemsSource = repository.GetTelemetries();
        }
    }
}
