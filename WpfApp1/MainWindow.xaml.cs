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

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IStatisticsSource repository;
        public MainWindow()
        {
            InitializeComponent();
            if (ConfigurationManager.AppSettings["StatisticsRepository"] == "SQL")
            {
                repository = new StatisticsSqlRepository();
            }
            else
            {
                repository = new StatisticsAzureStorageRepository();
            }
            menu.Populate();
            LoadStatistics(repository);
        }

        private readonly MainMenu menu = new MainMenu();
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            int choosen_from_unit_index = FromCombobox.SelectedIndex;
            int choosen_to_unit_index = ToCombobox.SelectedIndex;
            double from_value;
            try
            {
                from_value = Convert.ToDouble(FromTextBox.Text);
            }
            catch (FormatException)
            {
                _ = MessageBox.Show(string.Format(
                    "\"From Value\"" + Environment.NewLine + "{0}" + Environment.NewLine + "is in wrong format", arg0: FromTextBox.Text), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            double to_value=0.0;
            try
            {
                double intermediate_base_value = menu.Units_of_choice[choosen_from_unit_index].Con_to_base(from_value);
                if (intermediate_base_value<0)
                {
                    _ = MessageBox.Show(string.Format("From value {0}" + Environment.NewLine + "has no physical meaning", arg0: FromTextBox.Text), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                to_value = menu.Units_of_choice[choosen_to_unit_index].Con_from_base(intermediate_base_value);
            }

            catch (ArgumentOutOfRangeException)
            {
                _ = MessageBox.Show("\"Choose measure type\", \"From unit\" or \"To unit\" not set", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
               return; 
            }


            this.ToTextBox.Text = Convert.ToString(to_value);

            StatisticsDTO st = new StatisticsDTO()
            {
                Id = repository.GetStatistics().Count() + 1, //to nie będzie dobrze działac przy większycgh tabelach, no i problem z wieloma użytkownikami
                Time = DateTime.Now,
                From = menu.Units_of_choice[choosen_from_unit_index].Nam,
                To = menu.Units_of_choice[choosen_to_unit_index].Nam,
                OryginalValue = Convert.ToDecimal(from_value),
                CalculatedValue = Convert.ToDecimal(to_value)
            };
                    
                    
            repository.AddStatistic(st);
           
            LoadStatistics(repository);
        }
        private void LoadStatistics(IStatisticsSource r)
        {
            this.StatisticDataGrid.ItemsSource = r.GetStatistics();
        }

        private void Choose_measureCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int choosen_measure_index = Choose_measureCombobox.SelectedIndex;
            switch (choosen_measure_index)
            {
                case 0:
                    menu.Units_of_choice = menu.Units_of_temp;
                        break;
                case 1:
                    menu.Units_of_choice = menu.Units_of_lenght;
                    break;
                case 2:
                    menu.Units_of_choice = menu.Unints_of_weight;
                    break;
            }
            FromCombobox.ItemsSource = menu.Units_of_choice;
            ToCombobox.ItemsSource = menu.Units_of_choice;
        }
    }
}
