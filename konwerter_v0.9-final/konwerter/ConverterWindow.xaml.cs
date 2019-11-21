using konwerter.services;
using System;
using System.Windows;
using System.Windows.Controls;

namespace konwerter
{
    public partial class ConverterWindow : Window
    {
        private IUsageStatisticsRepo repository;
        public ConverterWindow(IUsageStatisticsRepo repo, ConvertersService converters)
        {
            InitializeComponent();

            this.repository = repo;
            this.selectedConverterComboBox.ItemsSource = converters.GetConverters();
        }

        private void ConvertTemperatureButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.selectedConverterComboBox.SelectedItem != null)
            {
                IConverter converter = (IConverter)this.selectedConverterComboBox.SelectedItem;
                decimal result = converter.Convert(
                    this.inputUnitComboBox.SelectedItem.ToString(),
                    this.outputUnitComboBox.SelectedItem.ToString(),
                    decimal.Parse(this.inputTextBox.Text));

                this.outputTextBlock.Text = result.ToString();

                StatisticDTO st = new StatisticDTO()
                {
                    DateTime = DateTime.Now,
                    UnitType = this.selectedConverterComboBox.ToString(),
                    InputUnit = inputUnitComboBox.Text,
                    OutputUnit = outputUnitComboBox.Text,
                    Value = decimal.Parse(this.inputTextBox.Text)
                };

                this.repository.AddStatistic(st);
            }
        }
        private void SelectedConverterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.selectedConverterComboBox.SelectedItem != null)
            {
                this.inputUnitComboBox.ItemsSource = ((IConverter)this.selectedConverterComboBox.SelectedItem).Units;
                this.outputUnitComboBox.ItemsSource = ((IConverter)this.selectedConverterComboBox.SelectedItem).Units;
            }
        }
    }
}
