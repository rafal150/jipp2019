using Konwerter.SDK;
using Konwerter.Services;
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
       
        double value;//, converted;

        private IRepo repository;
        public MainWindow(IRepo repo, ConvertersService konwertery)
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
            this.typeComboBox.ItemsSource = konwertery.GetConverters();
        }

        private void pokazZapisy()
        {
            statisticDataGrid.ItemsSource = repository.pobierzRekordy();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double.TryParse(valueTextBox.Text, out value);
            RekordDTO rekord = new RekordDTO();
            rekord.DateTime = DateTime.Now;
            //rekord.Type = typeComboBox.SelectedValue.ToString();
            rekord.FromUnit = fromComboBox.SelectedValue.ToString();
            rekord.ToUnit = toComboBox.SelectedValue.ToString();
            rekord.RawValue = value.ToString();

            IKonwerter konwerter = (IKonwerter)this.typeComboBox.SelectedItem;
            double wynik = konwerter.Przelicz(fromComboBox.SelectedItem.ToString(), toComboBox.SelectedItem.ToString(), double.Parse(this.valueTextBox.Text));
            resultLabel.Content = "= " + wynik.ToString();
            rekord.ConvertedValue = wynik.ToString();

            repository.dodajRekord(rekord);
            //switch (typeComboBox.SelectedIndex)
            //{
            //    case 0:
            //        double.TryParse(Temperatura.Przelicz(fromComboBox.SelectedValue.ToString(), toComboBox.SelectedValue.ToString(), value).ToString(), out converted);
            //        resultLabel.Content = "= " + converted;
            //        rekord.ConvertedValue = converted.ToString();
            //        repository.dodajRekord(rekord);
            //        break;
            //    case 1:
            //        double.TryParse(Dlugosc.Przelicz(fromComboBox.SelectedValue.ToString(), toComboBox.SelectedValue.ToString(), value).ToString(), out converted);
            //        resultLabel.Content = "= " + converted;
            //        rekord.ConvertedValue = converted.ToString();
            //        repository.dodajRekord(rekord);
            //        break;
            //    case 2:
            //        double.TryParse(MasaKonwerter.Przelicz(fromComboBox.SelectedValue.ToString(), toComboBox.SelectedValue.ToString(), value).ToString(), out converted);
            //        resultLabel.Content = "= " + converted;
            //        rekord.ConvertedValue = converted.ToString();
            //        repository.dodajRekord(rekord);
            //        break;
            //    default:
            //        break;
            //}
            pokazZapisy();
        }

        private void TypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (typeComboBox.SelectedItem !=null)
            {
                fromComboBox.ItemsSource = ((IKonwerter)this.typeComboBox.SelectedItem).Jednostki;
                toComboBox.ItemsSource = ((IKonwerter)this.typeComboBox.SelectedItem).Jednostki;
            }
            
            //switch (typeComboBox.SelectedIndex)
            //{
            //    case 0:
            //        fromComboBox.ItemsSource = temperatury;
            //        toComboBox.ItemsSource = temperatury;
            //        break;
            //    case 1:
            //        fromComboBox.ItemsSource = dlugosci;
            //        toComboBox.ItemsSource = dlugosci;
            //        break;
            //    case 2:
            //       // fromComboBox.ItemsSource = masy;
            //      //  toComboBox.ItemsSource = masy;
            //        break;
            //    default:
            //        fromComboBox.ItemsSource = null;
            //        toComboBox.ItemsSource = null;
            //        break;
            //}
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //typeComboBox.ItemsSource = typy;
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
