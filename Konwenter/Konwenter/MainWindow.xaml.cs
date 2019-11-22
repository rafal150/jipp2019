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

namespace Konwenter
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IBazyDanych repozytorium;
        private ListaTypowKonwersji konwersja;

        public MainWindow(IBazyDanych repo, ListaTypowKonwersji konw)
        {
            InitializeComponent();

            this.repozytorium = repo;
            this.konwersja = konw;
            this.WyswietlDane.ItemsSource = repozytorium.wyswietlStatystyki();
            this.typKonwersji.ItemsSource = konwersja.DajKonwenter();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void typKonwersji_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {           
            if(this.typKonwersji != null)
            {
                this.JednostkaWejsc.ItemsSource = ((IKonwersja)this.typKonwersji.SelectedItem).jednostki;
                this.JednostkaWyjsc.ItemsSource = ((IKonwersja)this.typKonwersji.SelectedItem).jednostki;
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Przelicznik_Click(object sender, RoutedEventArgs e)
        {
            string typKonwersji = this.typKonwersji.SelectedItem.ToString();
            int jednostkaWejsc = this.JednostkaWejsc.SelectedIndex;
            int jednostkaWyjsc = this.JednostkaWyjsc.SelectedIndex;
            double wartoscWej = double.Parse(this.wartoscWej.Text);
            if(this.typKonwersji.SelectedItem != null)
            {
                IKonwersja wybranyKonwenter = (IKonwersja)this.typKonwersji.SelectedItem;
                this.Wynik.Text = (wybranyKonwenter.obliczenia(double.Parse(this.wartoscWej.Text), this.JednostkaWejsc.SelectedIndex, this.JednostkaWyjsc.SelectedIndex)).ToString();
            }
            ZapisBazaDTO zbp = new ZapisBazaDTO()
            {
                dataZapisu = DateTime.Now,
                typKonwersji = this.typKonwersji.SelectedItem.ToString(),
                zJednostki = this.JednostkaWejsc.SelectedItem.ToString(),
                naJednostke = this.JednostkaWyjsc.SelectedItem.ToString(),
                daneWejsc = decimal.Parse(this.wartoscWej.Text),
                daneWyjsc = decimal.Parse(this.Wynik.Text)
            };        
            repozytorium.zapisDoBazy(zbp);
            this.WyswietlDane.ItemsSource = repozytorium.wyswietlStatystyki();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void WyswietlDane_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
