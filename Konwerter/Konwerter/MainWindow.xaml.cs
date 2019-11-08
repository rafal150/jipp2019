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

namespace Konwerter
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] repo = new string[] { "Azure", "SQL" };
        string[] typy = new string[] { "konwerter temperatury", "konwerter długości", "konwerter masy" };
        string[] temperatury = new string[] { "C", "F", "K", "R" };
        string[] dlugosci = new string[] { "mm", "cm", "dcm", "m", "km", "cal", "stopa", "jard", "mila", "kabel", "mila morska" };
        string[] masy = new string[] { "mg", "g", "dkg", "kg", "t", "uncja", "funt", "karat", "kwintal" };

        private IRepo repository;
        public MainWindow(IRepo repo)
        {
            InitializeComponent();
            if (ConfigurationManager.AppSettings["StatisticsRepository"] == "AzureStorage")
            {
                //repository = new AzureStorageRepo();
                repositoryComboBox.SelectedIndex = 0;
            }
            else
            {
                //repository = new SqlRepo();
                repositoryComboBox.SelectedIndex = 1;
            }
            this.repository = repo;
        }

        private void pokazZapisy()
        {
            statisticDataGrid.ItemsSource = repository.pobierzRekordy();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double.TryParse(valueTextBox.Text, out double value);
            RekordDTO rekord = new RekordDTO();
            rekord.DateTime = DateTime.Now;
            rekord.Type = typeComboBox.SelectedValue.ToString();
            rekord.FromUnit = fromComboBox.SelectedValue.ToString();
            rekord.ToUnit = toComboBox.SelectedValue.ToString();
            rekord.RawValue = value.ToString();

            switch (typeComboBox.SelectedIndex)
            {
                case 0:
                    double.TryParse(Temperatura.przelicz(fromComboBox.SelectedValue.ToString(), toComboBox.SelectedValue.ToString(), value).ToString(), out double convertedt);
                    resultLabel.Content = "= " + convertedt;
                    rekord.ConvertedValue = convertedt.ToString();
                    repository.dodajRekord(rekord);
                    break;
                case 1:
                    double.TryParse(Dlugosc.przelicz(fromComboBox.SelectedValue.ToString(), toComboBox.SelectedValue.ToString(), value).ToString(), out double convertedd);
                    resultLabel.Content = "= " + convertedd;
                    rekord.ConvertedValue = convertedd.ToString();
                    repository.dodajRekord(rekord);
                    break;
                case 2:
                    double.TryParse(Masa.przelicz(fromComboBox.SelectedValue.ToString(), toComboBox.SelectedValue.ToString(), value).ToString(), out double convertedm);
                    resultLabel.Content = "= " + convertedm;
                    rekord.ConvertedValue = convertedm.ToString();
                    repository.dodajRekord(rekord);
                    break;
                default:
                    break;
            }
            pokazZapisy();
        }

        private void TypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (typeComboBox.SelectedIndex)
            {
                case 0:
                    fromComboBox.ItemsSource = temperatury;
                    toComboBox.ItemsSource = temperatury;
                    break;
                case 1:
                    fromComboBox.ItemsSource = dlugosci;
                    toComboBox.ItemsSource = dlugosci;
                    break;
                case 2:
                    fromComboBox.ItemsSource = masy;
                    toComboBox.ItemsSource = masy;
                    break;
                default:
                    fromComboBox.ItemsSource = null;
                    toComboBox.ItemsSource = null;
                    break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            typeComboBox.ItemsSource = typy;
            repositoryComboBox.ItemsSource = repo;
            pokazZapisy();
        }

        private void RepositoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (repositoryComboBox.SelectedValue)
            {
                case "Azure":
                    repository = new AzureStorageRepo();
                    break;
                case "SQL":
                    repository = new SqlRepo();
                    break;
                default:
                    break;
            }
            pokazZapisy();
        }
    }
}
