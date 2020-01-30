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
using UnitCoverterPart2.Services;

namespace UnitCoverterPart2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IStatisticsRepository repository;

        public MainWindow(IStatisticsRepository repo, ConvertersService converters)
        {
            InitializeComponent();

            this.repository = repo;
            this.statisticsDataGrid.ItemsSource = repository.GetStatistics();
            
            this.TypeBox.ItemsSource = converters.GetConverters(); //new ConvertersService().GetConverters()
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.TypeBox.SelectedItem != null)
            {
                IConverter converter = (IConverter)this.TypeBox.SelectedItem;
                double result = converter.Convert(
                    this.UnitFromBox.SelectedItem.ToString(), 
                    this.UnitToBox.SelectedItem.ToString(),
                    double.Parse(this.RawValueBox.Text));

                this.OutputBox.Text = result.ToString();

               

                StatisticDTO st = new StatisticDTO()
                {
                    DateTime = DateTime.Now,
                    ConvertedValue = Convert.ToDouble(this.OutputBox.Text),
                    RawValue = Convert.ToDouble(this.RawValueBox.Text),
                    UnitFrom = UnitFromBox.Text,
                    UnitTo = UnitToBox.Text,
                    Type = TypeBox.Text
                    
                };

                this.repository.AddStatistic(st);
                this.statisticsDataGrid.ItemsSource = repository.GetStatistics();
            }
        }

        

        private void TypeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.TypeBox.SelectedItem != null)
            {
                this.UnitFromBox.ItemsSource = ((IConverter)this.TypeBox.SelectedItem).Units;
                this.UnitToBox.ItemsSource = ((IConverter)this.TypeBox.SelectedItem).Units;
            }
        }
    }
}
