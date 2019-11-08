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

namespace WpfAppJIPP
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
    private IStatisticsRepository repository;

        public MainWindow(IStatisticsRepository repo)
        {
            InitializeComponent();

          this.repository = repo;
          this.StatisticDataGrid.ItemsSource = repository.GetStatistics();
        }
  
        private Mainlist lista = new Mainlist();

        private void TypCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int wybrany_typ = Wybor_typuCombobox.SelectedIndex;
            lista.kolekcja();
            switch (wybrany_typ)
            {
                case 0:
                    lista.Wybor_miary = lista.Jedn_temp;
                    break;
                case 1:
                    lista.Wybor_miary = lista.Jedn_masy;
                    break;
                case 2:
                    lista.Wybor_miary = lista.Jedn_dlugosci;
                    break;
            }
            ZCombobox.ItemsSource = lista.Wybor_miary;
            NACombobox.ItemsSource = lista.Wybor_miary;
          
        }

        private void CalcButton_click(object sender, RoutedEventArgs e)
        {
            int wybrany_typ = Wybor_typuCombobox.SelectedIndex;
            int z_wybor = ZCombobox.SelectedIndex;
            int na_wybor = NACombobox.SelectedIndex;
            double wartosc_z = Convert.ToDouble(this.ZTextBox.Text);
            double wartosc_na = lista.Wybor_miary[na_wybor].Konwersja_z_bazowej(lista.Wybor_miary[z_wybor].Konwersja_na_bazowa(wartosc_z));
            this.NATextBox.Text = Convert.ToString(wartosc_na);
            using (Converter context = new Converter())
            {


                StatisticDTO st = new StatisticDTO()
                {
                    Id = repository.GetStatistics().Count() + 1,
                    Czas = DateTime.Now,
                    Typ = lista.Wybor_miary[wybrany_typ].Typmiary,
                    Konwersja_z = lista.Wybor_miary[z_wybor].Nazwa,
                    Konwersja_na = lista.Wybor_miary[na_wybor].Nazwa,
                    Wartosc_wprowadzona = Convert.ToDecimal(wartosc_z),
                    Wynik = Convert.ToDecimal(wartosc_na)
                };
                 this.repository.AddStatistic(st);
                this.StatisticDataGrid.ItemsSource = repository.GetStatistics();
            }
      
        }


    }
}

