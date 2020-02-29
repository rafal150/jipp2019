using Przelicznik_Jednostek.Services;
using Przelicznik_Jednostek.Model;
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

namespace Przelicznik_Jednostek
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IStatisticsRepository repository;
        public MainWindow(IStatisticsRepository repository, ConvertersService converters)
        {   
        InitializeComponent();
           this.repository = repository;
            this.Baza.ItemsSource = repository.GetStatistics();
            this.Wybor_miary.ItemsSource = converters.GetConverters();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.Wybor_miary.SelectedItem != null)
            {
                this.Wybor_jednostki.ItemsSource = ((iKonwerter)this.Wybor_miary.SelectedItem).Units;
                this.Wybor_Jednostki_Wynikowej.ItemsSource = ((iKonwerter)this.Wybor_miary.SelectedItem).Units;
            }

        }

        private void Przycisk_przeliczania_Click(object sender, RoutedEventArgs e)
        {
            if (this.Wybor_miary.SelectedItem != null)
            {
                iKonwerter converter = (iKonwerter)this.Wybor_miary.SelectedItem;
                decimal result = converter.Convert(
                    this.Wybor_jednostki.SelectedItem.ToString(),
                    this.Wybor_Jednostki_Wynikowej.SelectedItem.ToString(),
                    decimal.Parse(this.Ilosc_jednoski.Text));

                this.Wynik.Text = result.ToString();
                StatisticDTO st = new StatisticDTO()
                {
                    DateTime = DateTime.Now,
                    UnitFrom = this.Wybor_jednostki.SelectedItem.ToString(),
                    Type = this.Wybor_miary.SelectedItem.ToString(),
                    UnitTo = this.Wybor_Jednostki_Wynikowej.SelectedItem.ToString(),
                    ConvertedValue = this.Wynik.Text,
                    RawValue = this.Ilosc_jednoski.Text
                };
                this.repository.AddStatistic(st);
                this.Baza.ItemsSource = repository.GetStatistics();

            }
        }
    }
}
