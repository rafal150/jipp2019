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
using Konwerter_Azure.Services;
//using Konwerter_Azure;

namespace Konwerter_Azure
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IStatisticsRepository repository;

        
        public MainWindow(IStatisticsRepository repo, ConvertersService converters)
        {
            InitializeComponent();

            this.repository = repo;
            this.DataGrid_Statystyki.ItemsSource = repository.GetStatistics();

            this.ComboBoxRodzajMiary.ItemsSource = converters.GetConverters(); //new ConvertersService().GetConverters()
        }



        private void ComboBoxRodzajMiary_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.ComboBoxRodzajMiary.SelectedItem != null)
            {
                this.ComboBoxZCzego.ItemsSource = ((IConverter)this.ComboBoxRodzajMiary.SelectedItem).Jednostki; //rzutowanie
                this.ComboBoxNaCo.ItemsSource = ((IConverter)this.ComboBoxRodzajMiary.SelectedItem).Jednostki;
            }
        }


        private void ButtonOblicz_Click(object sender, RoutedEventArgs e)
        {
            //string idZ = Convert.ToString(ComboBoxZCzego.SelectedValue);
            //string idNa = Convert.ToString(ComboBoxNaCo.SelectedValue);
            //decimal input = decimal.Parse(TextBoxPodajWartosc.Text);

            if (ComboBoxRodzajMiary.SelectedItem != null)
            {
                IConverter konwerter = (IConverter)this.ComboBoxRodzajMiary.SelectedItem;

                decimal wynikObliczen = konwerter.Przelicz
                    (
                        this.ComboBoxZCzego.SelectedItem.ToString(),
                        this.ComboBoxNaCo.SelectedItem.ToString(),
                        decimal.Parse(this.TextBoxPodajWartosc.Text)
                    );

                this.TextBlockWynik.Text = wynikObliczen.ToString(); // przypisanie wyniku obliczen do okienka z wynikiem

                StatisticDTO st = new StatisticDTO() // zapis do bazy
                {
                    //czas = DateTime.Now,
                    //grupa = ComboBoxRodzajMiary.SelectedItem.ToString(),
                    ////grupa = ConvertersService.GetConverters(),
                    //przeliczZ = ComboBoxZCzego.SelectedItem.ToString(),
                    ////dane = decimal.Parse(TextBoxPodajWartosc.Text), stare
                    //dane = decimal.Parse((TextBoxPodajWartosc.Text).ToString()),//  to bylo
                    //przeliczNa = ComboBoxNaCo.SelectedItem.ToString(),
                    //wynik = decimal.Parse(TextBlockWynik.Text)
                    ////wynik = (TextBlockWynik.Text)
                    ///
                    czas = DateTime.Now,
                    grupa = ComboBoxRodzajMiary.SelectedItem.ToString(),
                    przeliczZ = ComboBoxZCzego.SelectedItem.ToString(),
                    //dane = int.Parse(TextBoxPodajWartosc.Text),
                    //dane = decimal.Parse(TextBoxPodajWartosc.Text),
                    dane = decimal.Parse((TextBoxPodajWartosc.Text).ToString()),
                    przeliczNa = ComboBoxNaCo.SelectedItem.ToString(),
                    //wynik = int.Parse(TextBlockWynik.Text)
                    wynik = decimal.Parse(TextBlockWynik.Text)
                    //wynik = (TextBlockWynik.Text)
                };

                this.repository.AddStatistic(st);
                this.DataGrid_Statystyki.ItemsSource = repository.GetStatistics();
            }
        }
    }
}
