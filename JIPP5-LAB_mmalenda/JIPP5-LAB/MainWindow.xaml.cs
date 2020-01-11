using JIPP5.SDK;
using JIPP5_LAB.Data;
using JIPP5_LAB.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace JIPP5_LAB
{
    
    public partial class MainWindow : Window
    {
        private IGetData repository;

        public MainWindow(IGetData repo, ConvertersService converters)
        {
            InitializeComponent();
            this.repository = repo;
            

            this.catergoriesCombobox.ItemsSource = converters.GetConverters();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.catergoriesCombobox.SelectedItem != null)
            {
                decimal.TryParse(this.inputTextBox.Text, out decimal decimalowe);

                IConverter converter = (IConverter)this.catergoriesCombobox.SelectedItem;
                decimal result = converter.Converter(
                    this.unitsFromCombobox.SelectedItem.ToString(),
                    decimalowe,
                    this.unitsToCombobox.SelectedItem.ToString());

                this.outputTextBlock.Text = result.ToString();

                StatisticDTO st = new StatisticDTO()
                {
                    DateTime = DateTime.Now,
                    Type = this.unitsFromCombobox.SelectedItem.ToString(),
                    ConvertedValue = result,
                    RawValue = decimalowe,
                };

                this.repository.AddStatistic(st);
                this.statisticsDataGrid.ItemsSource = repository.GetStatistics();
            }
        }

        private void catergoriesCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.catergoriesCombobox.SelectedItem != null)
            {
                this.unitsFromCombobox.ItemsSource = ((IConverter)this.catergoriesCombobox.SelectedItem).Units;
                this.unitsToCombobox.ItemsSource = ((IConverter)this.catergoriesCombobox.SelectedItem).Units;
            }
        }
    }
}