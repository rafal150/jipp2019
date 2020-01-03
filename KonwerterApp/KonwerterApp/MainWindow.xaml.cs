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
using KonwerterApp.Services;

namespace KonwerterApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private IStatisticsRepository repository;
        
        Model1 BazaDanych = new Model1();
        
        public MainWindow(IStatisticsRepository repozytorium, ConvertersService converters)
        {
            InitializeComponent();
            ComboBox_Kategoria.ItemsSource=converters.GetConverters();

            DataGridWynikowy.ItemsSource = BazaDanych.TabelaKonwerteras.ToList();

            this.repository = repozytorium;
            this.DataGridWynikowy.ItemsSource = repository.GetStatistic();
        }

        private void ComboBox_Kategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.ComboBox_Kategoria.SelectedItem != null)
            {
                this.ComboBox_Jednostka.ItemsSource = ((IConverter)this.ComboBox_Kategoria.SelectedItem).Jednostki;
                this.ComboBox_JednostkaDocelowa.ItemsSource = ((IConverter)this.ComboBox_Kategoria.SelectedItem).Jednostki;
            }
        }

        private void Button_Zamien_Click(object sender, RoutedEventArgs e)
        {

            IConverter converter = (IConverter)this.ComboBox_Kategoria.SelectedItem;

            TextBlock_WartoscPrzedKonwersjaWynik.Text = TextBox_WartoscDoKonwersji.Text;
            float.TryParse(TextBox_WartoscDoKonwersji.Text, out float WartoscDoKonwersji);


            string WybranaKategoria = converter.Nazwa;
            string JednostkaPocz = ComboBox_Jednostka.SelectedItem.ToString();
            string JednostkaDocelowa = ComboBox_JednostkaDocelowa.SelectedItem.ToString();
            float WartoscPoKonwersji=0;
            WartoscPoKonwersji = converter.Konwertuj(JednostkaPocz, JednostkaDocelowa, WartoscDoKonwersji);

            TextBlock_WartoscPoKonwersji_Wynik.Text = WartoscPoKonwersji.ToString();

           StatisticDTO log = new StatisticDTO
            {
                DateTime = DateTime.Now,
                Type = WybranaKategoria,
                FromUnit = JednostkaPocz,
                ToUnit = JednostkaDocelowa,
                RawValue = WartoscDoKonwersji,
                Converted = WartoscPoKonwersji
            };
            repository.DodajStatystyke(log);
            
            DataGridWynikowy.ItemsSource = repository.GetStatistic();
        }
    }
}
