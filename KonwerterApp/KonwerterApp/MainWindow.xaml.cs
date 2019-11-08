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

namespace KonwerterApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private IStatisticsRepository repository;

        ObliczarkaMasy KonwerterMasy = new ObliczarkaMasy();
        ObliczarkaTemperatury KonwerterTemperatury = new ObliczarkaTemperatury();
        ObliczarkaDlugosci KonwerterDlugosci = new ObliczarkaDlugosci();
        Model1 BazaDanych = new Model1();

        //Określam zawartość listy rozwijalnej kategorii jednostek
        string Temperatura = ObliczarkaTemperatury.Temperatura;
        string Dlugosc = ObliczarkaDlugosci.Dlugosc;
        string Masa = ObliczarkaMasy.Masa;
        public MainWindow(IStatisticsRepository repozytorium)
        {
            InitializeComponent();
            //Podaje zawartość listy rozwijalnej Kategoria
            string[] Kategorie = { Temperatura, Dlugosc, Masa};
            ComboBox_Kategoria.ItemsSource=Kategorie;

            DataGridWynikowy.ItemsSource = BazaDanych.TabelaKonwerteras.ToList();

            this.repository = repozytorium;
            this.DataGridWynikowy.ItemsSource = repository.GetStatistic();
        }



        private void ComboBox_Kategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Jeśli wybrano kategorię Temperatura
            if (ComboBox_Kategoria.SelectedItem.ToString()==Temperatura)
            {
                string[] Temperatura = { "Celcjusz", "Farenheit", "Kelvin","Rankine"};
                ComboBox_Jednostka.ItemsSource = Temperatura;
                ComboBox_JednostkaDocelowa.ItemsSource = Temperatura;
            }
            //Jeśli wybrano kategorię Długość
            else if (ComboBox_Kategoria.SelectedItem.ToString() == Dlugosc)
            {
                //Miary metryczne (mm, cm, dcm, m km)
                //Anglosaskie(cal, stop, jard, mila)
                //morskie(kabel, mila morska)
                string[] Metryczne = { "Milimetry", "Centymetry", "Decymetry", "Metry","Kilometry"};
                string[] Anglosaskie = { "Cale", "Stopy", "Jardy", "Mile"};
                string[] Morskie = { "Kable", "Mile morskie"};
                ComboBox_Jednostka.ItemsSource = Metryczne.Concat(Anglosaskie).Concat(Morskie);
                ComboBox_JednostkaDocelowa.ItemsSource= Metryczne.Concat(Anglosaskie).Concat(Morskie);
            }
            //Jeśli wybrano kategorię Masa
            else if (ComboBox_Kategoria.SelectedItem.ToString() == Masa)
            {
                //metryczny (mg, g, dkg, kg, T)
                //miary anglosaskie(uncja, funt)
                //inne(karat, kwintal)
                //zawartosc listy rozwijalnej
                string[] Metryczne = { "Miligramy", "Gramy", "Dekagramy", "Kilogramy", "Tony" };
                string[] Anglosaskie = { "Uncje", "Funty"};
                string[] Inne = { "Karaty", "Kwintale" };
                ComboBox_Jednostka.ItemsSource = Metryczne.Concat(Anglosaskie).Concat(Inne);
                ComboBox_JednostkaDocelowa.ItemsSource = Metryczne.Concat(Anglosaskie).Concat(Inne);
            }
        }

        private void Button_Zamien_Click(object sender, RoutedEventArgs e)
        {
            TextBlock_WartoscPrzedKonwersjaWynik.Text = TextBox_WartoscDoKonwersji.Text;
           float.TryParse(TextBox_WartoscDoKonwersji.Text, out float WartoscDoKonwersji);
           

            string WybranaKategoria = ComboBox_Kategoria.SelectedItem.ToString();
            string JednostkaPocz = ComboBox_Jednostka.SelectedItem.ToString();
            string JednostkaDocelowa = ComboBox_JednostkaDocelowa.SelectedItem.ToString();
            float WartoscPoKonwersji=0;
            /*Przerobic tak, zeby z automatu wiedzial ktora klase uzyc do konwersji */
            if (WybranaKategoria == Temperatura)
            {
                WartoscPoKonwersji= KonwerterTemperatury.KonwertujTemperature(JednostkaPocz, JednostkaDocelowa, WartoscDoKonwersji);

            }
            else if (WybranaKategoria == Dlugosc)
            {
                WartoscPoKonwersji = KonwerterDlugosci.KonwertujDlugosc(JednostkaPocz, JednostkaDocelowa, WartoscDoKonwersji);
            }
            else if (WybranaKategoria == Masa)
            {
                WartoscPoKonwersji = KonwerterMasy.KonwertujMase(JednostkaPocz, JednostkaDocelowa, WartoscDoKonwersji);
            }

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
