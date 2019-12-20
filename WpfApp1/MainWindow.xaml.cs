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
using System.Configuration;
using Newtonsoft.Json;
using WpfApp1.Logic;
using WpfApp1.SDK;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IStatisticsSource repository;
        public MainWindow(IStatisticsSource repo, GetMeasuresObj mes)
        {
            InitializeComponent();
            repository = repo;
            Choose_measureCombobox.ItemsSource = mes.GetMesasures();
            LoadStatistics(repository);
        }

       
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            string from = "";
            string to = "";
            double from_value = 0;
            double to_value = 0;
            if (this.Choose_measureCombobox.SelectedItem != null)
            {
                IGetMeasures converter = (IGetMeasures)this.Choose_measureCombobox.SelectedItem;
                from = FromCombobox.SelectedItem.ToString();
                to = ToCombobox.SelectedItem.ToString();
                from_value = float.Parse(FromTextBox.Text);
                to_value = converter.Convert(from, to, from_value);
                ToTextBox.Text = Convert.ToString(to_value);

                StatisticsDTO st = new StatisticsDTO()
                {
                    Id = repository.GetStatistics().Count() + 1, //to nie będzie dobrze działac przy większycgh tabelach, no i problem z wieloma użytkownikami
                    Time = DateTime.Now,
                    From = from,
                    To = to,
                    OryginalValue = Convert.ToDecimal(from_value),
                    CalculatedValue = Convert.ToDecimal(to_value)
                };
                repository.AddStatistic(st);
            }
            
           
            LoadStatistics(repository);
        }
        private void LoadStatistics(IStatisticsSource r)
        {
            this.StatisticDataGrid.ItemsSource = r.GetStatistics();
        }

        private void Choose_measureCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            //string choosen_measure_name = ((IGetMeasures)this.Choose_measureCombobox.SelectedItem).Nam;
            FromCombobox.ItemsSource = ((IGetMeasures)this.Choose_measureCombobox.SelectedItem).Units;
            ToCombobox.ItemsSource = ((IGetMeasures)this.Choose_measureCombobox.SelectedItem).Units;
        }
    }
}
