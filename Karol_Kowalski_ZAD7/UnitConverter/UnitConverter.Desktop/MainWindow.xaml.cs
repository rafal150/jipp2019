using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace UnitConverter.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UnitConverterApi unitConverters;

        public MainWindow(UnitConverterApi unitConverters)
        {
            InitializeComponent();

            this.unitConverters = unitConverters;

            this.TypeCombobox.ItemsSource = unitConverters.GetConverters();
            this.TypeCombobox.SelectedIndex = 0;

            this.statisticsDataGrid.ItemsSource = unitConverters.GetStatistics();
            this.historyDataGrid.ItemsSource = unitConverters.GetHistory();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.TypeCombobox.SelectedItem is Converter converter)
            {
                var result = unitConverters.Convert(
                    FromCombobox.SelectedItem.ToString(),
                    ToCombobox.SelectedItem.ToString(),
                    this.InputTextBox.Text,
                    converter.Type);

                this.ResultTextBlock.Text = result.ToString();
            }

            this.statisticsDataGrid.ItemsSource = unitConverters.GetStatistics();
            this.historyDataGrid.ItemsSource = unitConverters.GetHistory();
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
            var units = (TypeCombobox.SelectedItem as Converter)?.Units;

            this.FromCombobox.ItemsSource = units;
            this.FromCombobox.SelectedIndex = 0;

            this.ToCombobox.ItemsSource = units;
            this.ToCombobox.SelectedIndex = 0;
        }
    }
}
