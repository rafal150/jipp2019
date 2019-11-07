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
        private BazaNazw bn = new BazaNazw();
        private ObliczeniaTemp ot = new ObliczeniaTemp();
        private ObliczeniaMasa om = new ObliczeniaMasa();
        private ObliczeniaDlug od = new ObliczeniaDlug();

        public MainWindow(IBazyDanych repo)
        {
            InitializeComponent();

            this.repozytorium = repo;
            this.WyswietlDane.ItemsSource = repozytorium.wyswietlStatystyki();
            this.typKonwersji.ItemsSource = bn.getKategoria();          
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void typKonwersji_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {           
            this.JednostkaWejsc.ItemsSource = bn.wypelnienieJednostek(this.typKonwersji.SelectedItem.ToString());
            this.JednostkaWyjsc.ItemsSource = bn.wypelnienieJednostek(this.typKonwersji.SelectedItem.ToString());
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
            if (typKonwersji==bn.getKategoria().First())
            {              
                this.Wynik.Text = (ot.zCelcjusza(wartoscWej, jednostkaWejsc, jednostkaWyjsc)).ToString(); 
            }
            else if(typKonwersji==bn.getKategoria().ElementAt(1))
            {
                this.Wynik.Text = (od.zMilimetry(wartoscWej, jednostkaWejsc, jednostkaWyjsc)).ToString();
            }
            else if(typKonwersji==bn.getKategoria().ElementAt(2))
            {
                this.Wynik.Text = (om.zMiligramy(wartoscWej, jednostkaWejsc, jednostkaWyjsc)).ToString();
            }
            ZapisBazaPosrednik zbp = new ZapisBazaPosrednik()
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
