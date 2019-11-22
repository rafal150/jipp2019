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
using UnitConverter.Services;

namespace UnitConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IRepository repository;

        public MainWindow(IRepository repo, ConverterService converters)
        {
            InitializeComponent();

            this.repository = repo;
            this.statisticsDataGrid.ItemsSource = repository.GetStatistics();

            this.TypeComboBox.ItemsSource = converters.GetConverters();
        }
     


        private void TypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.TypeComboBox.SelectedItem != null)
            {
                this.FromComboBox.ItemsSource = ((IConverter)this.TypeComboBox.SelectedItem).Units;
                this.ToComboBox.ItemsSource = ((IConverter)this.TypeComboBox.SelectedItem).Units;
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.TypeComboBox.SelectedItem != null)
            {

                IConverter converter = (IConverter)this.TypeComboBox.SelectedItem;
                decimal result = converter.Convert(
                   // this.FromComboBox.SelectedItem.ToString(),
                    this.ToComboBox.SelectedItem.ToString(),
                    float.Parse(this.InputTextBox.Text));

                this.ResultTextBlock.Text = result.ToString();


                StatisticJZDTO st = new StatisticJZDTO()
                {
                    DateTime = DateTime.Now,
                    UnitFrom = this.FromComboBox.SelectedItem.ToString(),
                    UnitTo = this.ToComboBox.SelectedItem.ToString(),
                    Type = this.TypeComboBox.SelectedItem.ToString(),
                    RawValue = double.Parse(this.InputTextBox.Text),
                    ConvertedValue = double.Parse(this.ResultTextBlock.Text)
                };
                this.repository.AddStatistic(st);
                this.statisticsDataGrid.ItemsSource = repository.GetStatistics();
            }


        }
       

    }
} 

