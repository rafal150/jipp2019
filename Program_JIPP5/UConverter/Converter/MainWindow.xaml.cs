using Converter;

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Converter
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


            this.statisticsDataGrid.ItemsSource = repository.GetStatistics();
            this.catergoriesCombobox.ItemsSource = converters.GetConverters();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.catergoriesCombobox.SelectedItem != null)
            {


                IConverter converter = (IConverter)this.catergoriesCombobox.SelectedItem;
                decimal result = converter.Convert(
                    this.FromCombobox.SelectedItem.ToString(),
                    this.ToCombobox.SelectedItem.ToString(),
                    decimal.Parse(this.input.Text));

                this.output.Text = result.ToString();

                StatDTO st = new StatDTO()
                {
                    DateTime = DateTime.Now,
                    UnitFrom = this.FromCombobox.SelectedItem.ToString(),
                    UnitTo = this.ToCombobox.SelectedItem.ToString(),
                    




            };

                this.repository.AddStatistic(st);
                this.statisticsDataGrid.ItemsSource = repository.GetStatistics();
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.catergoriesCombobox.SelectedItem != null)
            {
                this.FromCombobox.ItemsSource = ((IConverter)this.catergoriesCombobox.SelectedItem).Units;
                this.ToCombobox.ItemsSource = ((IConverter)this.catergoriesCombobox.SelectedItem).Units;
            }
        }
    }
}