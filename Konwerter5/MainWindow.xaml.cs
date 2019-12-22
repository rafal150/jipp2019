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
using Konwerter5.Uslugi;
using Konwerter5.Logic;



namespace Konwerter5
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IRepozytoriumStatystykUzycia repozytorium;
        public MainWindow(IRepozytoriumStatystykUzycia rep, Konwerter5Usluga konwertery)
        {
            InitializeComponent();
            repozytorium = rep;
            catergoriesCombobox.ItemsSource = konwertery.PobierzKonwertery();
            statisticsDataGrid.ItemsSource = repozytorium.PobierzStatystykiUzycia();

        }
        void Button_Click(object sender, RoutedEventArgs e)
        {
            if (catergoriesCombobox.SelectedIndex != -1)
            {
                IKonwerter5 konwerter = (IKonwerter5)catergoriesCombobox.SelectedItem;
                double wynik = konwerter.Konwertuj(
                    unitsFromCombobox.SelectedItem.ToString(),
                        unitsToCombobox.SelectedItem.ToString(),
                            double.Parse(inputTextBox.Text)
                    );
                outputTextBlock.Text = wynik.ToString();
                StatystykiUzyciaDTO statystyki = new StatystykiUzyciaDTO()
                {
                    Id = 5,
                    Data = DateTime.Now,
                    DoJednostki = unitsToCombobox.SelectedItem.ToString(),
                    ZJednostki = unitsFromCombobox.SelectedItem.ToString(),
                    WartoscDoPrzeliczen = double.Parse(inputTextBox.Text),
                    WartoscPrzeliczona = wynik,
                    TypKonwersji = "Dobra Konwersja"
                };
                repozytorium.DodajStatystykiUzycia(statystyki);
                statisticsDataGrid.ItemsSource = repozytorium.PobierzStatystykiUzycia();
            }
        }
        void catergoriesCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(catergoriesCombobox.SelectedItem != null)
            {
                unitsFromCombobox.ItemsSource =
                    (
                        (IKonwerter5)catergoriesCombobox.SelectedItem
                    
                    ).Jednostki;
                unitsToCombobox.ItemsSource =
                    (
                        (IKonwerter5)catergoriesCombobox.SelectedItem
                    ).Jednostki;
            }
        }

    }
}
