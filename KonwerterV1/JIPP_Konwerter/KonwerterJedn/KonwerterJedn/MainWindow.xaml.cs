using KonwerterJedn.Services;
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

namespace KonwerterJedn
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IStatisticsRepository repository;

        public MainWindow(IStatisticsRepository repo, KonwerterJednostek konwertery)
        {
            InitializeComponent();

            this.repository = repo;
            this.StatsSQL.ItemsSource = repository.GetStatistics();

            this.ChooseUnitKind.ItemsSource = konwertery.GetConverters();
        }

        private void catergoriesCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.ChooseUnitKind.SelectedItem != null)
            {
                this.ChosenUnitsFrom.ItemsSource = ((IConverter)this.ChooseUnitKind.SelectedItem).Jednostki;
                this.ChosenUnitsTo.ItemsSource = ((IConverter)this.ChooseUnitKind.SelectedItem).Jednostki;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            IConverter converter = (IConverter)this.ChooseUnitKind.SelectedItem;
            double result = converter.Convert(
                this.ChosenUnitsFrom.SelectedItem.ToString(),
                this.ChosenUnitsTo.SelectedItem.ToString(),
                double.Parse(this.InputUnit.Text));

            this.OutputUnit.Text = result.ToString();

            StatisticDTO St = new StatisticDTO()
            {
                UnitFrom = this.ChosenUnitsFrom.Text,
                UnitTo = this.ChosenUnitsTo.Text,
                ValueFrom = this.InputUnit.Text,
                ValueTo = this.OutputUnit.Text,
                Type = this.Name,
                DateTime = DateTime.Now
            };
            this.repository.AddStatistic(St);
            this.StatsSQL.ItemsSource = repository.GetStatistics();
        }
    }
    
}


