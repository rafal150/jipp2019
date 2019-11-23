using JIPP5_LAB.Database;
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

namespace JIPP5_LAB
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var przeliczanie = new Doprzeliczenia();
            FromUnitD.ItemsSource = przeliczanie.Dlugosci;
            FromUnitT.ItemsSource = przeliczanie.Temperatury;
            FromUnitW.ItemsSource = przeliczanie.Wagi;
            ToUnitD.ItemsSource = przeliczanie.Dlugosci;
            ToUnitT.ItemsSource = przeliczanie.Temperatury;
            ToUnitW.ItemsSource = przeliczanie.Wagi;
        }

        public Konwerter konwerter = new Konwerter();

        private void Temp_click(object sender, RoutedEventArgs e)
        {
            var from = (Jednostka)FromUnitT.SelectedItem;
            var to = (Jednostka)ToUnitT.SelectedItem;
            decimal.TryParse(FromInputT.Text, out decimal wartosc);
            var przeliczone = konwerter.Convert(from, wartosc, to);
            zapisz_wynik(wartosc, przeliczone, from.Typ, to.Typ);
            ResultT.Text = $"{przeliczone.ToString()} {to.Jednostkaa}";
        }

        private void Length_click(object sender, RoutedEventArgs e)
        {
            var from = (Jednostka)FromUnitD.SelectedItem;
            var to = (Jednostka)ToUnitD.SelectedItem;
            decimal.TryParse(FromInputD.Text, out decimal wartosc);
            var przeliczone = konwerter.Convert(from, wartosc, to);
            zapisz_wynik(wartosc, przeliczone, from.Typ, to.Typ);
            ResultD.Text = $"{przeliczone.ToString()} {to.Jednostkaa}";
        }

        private void Weight_click(object sender, RoutedEventArgs e)
        {
            var from = (Jednostka)FromUnitW.SelectedItem;
            var to = (Jednostka)ToUnitW.SelectedItem;
            decimal.TryParse(FromInputW.Text, out decimal wartosc);
            var przeliczone = konwerter.Convert(from, wartosc, to);
            zapisz_wynik(wartosc, przeliczone, from.Typ, to.Typ);
            ResultW.Text = $"{przeliczone.ToString()} {to.Jednostkaa}";
        }

        private void zapisz_wynik(decimal wartosc, decimal przeliczone, Jednostki from, Jednostki to)
        {
            var stats = new StatisticModel()
            {
                Converted = przeliczone,
                Date = DateTime.Now,
                FromUnit = from.ToString(),
                ToUnit = to.ToString(),
                RawData = wartosc
            };
            using (var db = new StatisticsContext())
            {
                db.Statistics.Add(stats);
                db.SaveChanges();
            }
        }

        private void Refresh_click(object sender, RoutedEventArgs e)
        {
            using (var db = new StatisticsContext())
            {
                datagird.ItemsSource = db.Statistics.ToList();
            }
        }
    }
}
