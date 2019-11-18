using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Linq;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Konwerter.SDK;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Windows.Shapes;
using SEM5WPF_1.Services;

namespace SEM5WPF_1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IStatystykiRepozytorium repozytorium;
        public MainWindow(IStatystykiRepozytorium repo, KonwerterServices konwerter)
        {

            InitializeComponent();
            this.repozytorium = repo;
            this.DataGrid1.ItemsSource = repozytorium.GetStatystykis();

            this.CboxListMiary.ItemsSource = konwerter.GetKonwerters();

             
        }
        // DO WERSJI 2

        private void CboxListMiary_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(this.CboxListMiary.SelectedItem != null)
            {
                this.CboxListJednowstkaA.ItemsSource = ((IKonwerter)this.CboxListMiary.SelectedItem).Units;
                this.CboxListJednostkaB.ItemsSource = ((IKonwerter)this.CboxListMiary.SelectedItem).Units;
            }
        }

        private void Bkonwertuj_Click(object sender, RoutedEventArgs e)
        {
            if (this.CboxListMiary.SelectedItem != null)
            {
                IKonwerter konwerter = (IKonwerter)this.CboxListMiary.SelectedItem;
                decimal wynik = konwerter.Konwerter(
                    this.CboxListJednowstkaA.SelectedItem.ToString(),
                    this.CboxListJednostkaB.SelectedItem.ToString(),
                    decimal.Parse(this.TboxDokonwersji.Text));

                this.TboxWynik.Text = wynik.ToString();


                StatystykiDTO sDTO = new StatystykiDTO()
                {
                    WartoscPodstawowa = double.Parse(TboxDokonwersji.Text),
                    WartoscPoKonwersji = double.Parse(TboxWynik.Text),
                    WartoscA = CboxListMiary.Text,
                    WartoscB = CboxListMiary.Text,
                    JednostkaA = CboxListJednowstkaA.Text,
                    JednostkaB = CboxListJednostkaB.Text,
                    Data = DateTime.Now
                };
                this.repozytorium.DodajStatystyki(sDTO);
                this.DataGrid1.ItemsSource = repozytorium.GetStatystykis();
            }
        }
    }
}
