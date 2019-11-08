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
//using Konwerter_Azure;

namespace Konwerter_Azure
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IStatisticsRepository repository;

        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(IStatisticsRepository repo)
        {
            InitializeComponent();

            FillGrupy();

            this.repository = repo;
            this.DataGrid_Statystyki.ItemsSource = repository.GetStatistics();
        }

        void FillGrupy()
        {
            this.ComboBoxRodzajMiary.ItemsSource = new List<string>(new[] { "T", "M", "O" });
        }

        private void ComboBoxRodzajMiary_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //int idGrupy = Convert.ToInt32(ComboBoxRodzajMiary.SelectedValue);

            //JIPPEntities1 obj = new JIPPEntities1();
            //List<Jednostki> listaGrup = obj.Jednostki.Where(x => x.idGrupy == idGrupy).ToList();
            //ComboBoxZCzego.ItemsSource = listaGrup;
            //ComboBoxNaCo.ItemsSource = listaGrup;

            if (Convert.ToString(ComboBoxRodzajMiary.SelectedValue)=="T")
            {
                ComboBoxZCzego.ItemsSource = new List<string>(new[] { "C", "K", "F", "R" });
                ComboBoxNaCo.ItemsSource = new List<string>(new[] { "C", "K", "F", "R" });
            }

        }





        private void ButtonOblicz_Click(object sender, RoutedEventArgs e)
        {
            string idZ = Convert.ToString(ComboBoxZCzego.SelectedValue);
            string idNa = Convert.ToString(ComboBoxNaCo.SelectedValue);
            double input = double.Parse(TextBoxPodajWartosc.Text);

            if (Convert.ToString(ComboBoxRodzajMiary.SelectedValue) == "T")// temperatura
            {
                PrzeliczTemperature pt = new PrzeliczTemperature();
                TextBlockWynik.Text = pt.ObliczTemperature(idZ, idNa, input);
            }

            //if (ComboBoxRodzajMiary.SelectedIndex == 1)// Masa
            //{
            //    PrzeliczMase pm = new PrzeliczMase();
            //    TextBlockWynik.Text = pm.ObliczMase(idZ, idNa, input);
            //}

            //if (ComboBoxRodzajMiary.SelectedIndex == 2)// Odleglosc
            //{
            //    PrzeliczOdleglosc po = new PrzeliczOdleglosc();
            //    TextBlockWynik.Text = po.ObliczOdleglosc(idZ, idNa, input);
            //}





            StatisticDTO st = new StatisticDTO()
            {
                czas = DateTime.Now,
                grupa = ComboBoxRodzajMiary.SelectedItem.ToString(),
                przeliczZ = ComboBoxZCzego.SelectedItem.ToString(),
                dane = decimal.Parse(TextBoxPodajWartosc.Text),
                przeliczNa = ComboBoxNaCo.SelectedItem.ToString(),
                wynik = decimal.Parse(TextBlockWynik.Text)
            };

            this.repository.AddStatistic(st);
            this.DataGrid_Statystyki.ItemsSource = repository.GetStatistics();
        }
    }
}
