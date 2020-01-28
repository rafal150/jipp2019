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

namespace UnitCoverterPart2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private IStatisticsRepository repository;
        private ConvertersApi converters;

        public MainWindow(ConvertersApi converters)
        {
            InitializeComponent();

            this.converters = converters;
            //this.repository = repo;
            //this.statisticsDataGrid.ItemsSource = repository.GetStatistics();
            
            this.catergoriesCombobox.ItemsSource = converters.GetConverters(); //new ConvertersService().GetConverters()
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string repo = "Azure";
            if (this.catergoriesCombobox.SelectedItem != null)
            {
                Converter converter = (Converter)this.catergoriesCombobox.SelectedItem;
                decimal result = converters.Convert(
                    this.unitsFromCombobox.SelectedItem.ToString(),
                    this.unitsToCombobox.SelectedItem.ToString(),
                    this.inputTextBox.Text,
                    converter.Name,
                    repo);

                this.outputTextBlock.Text = result.ToString();
                statisticsDataGrid.ItemsSource = converters.getRecords(repo);
                //converters.Clean();
                //StatisticDTO st = new StatisticDTO()
                //{
                //    DateTime = DateTime.Now,
                //    Type = "Masa"
                //};

                //this.repository.AddStatistic(st);
                //this.statisticsDataGrid.ItemsSource = repository.GetStatistics();
            }

        }

        private void catergoriesCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(this.catergoriesCombobox.SelectedItem != null)
            {
                this.unitsFromCombobox.ItemsSource = ((Converter)this.catergoriesCombobox.SelectedItem).Units;
                this.unitsToCombobox.ItemsSource = ((Converter)this.catergoriesCombobox.SelectedItem).Units;
            }
        }
    }
}
