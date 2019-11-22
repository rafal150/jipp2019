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
using Konwerter8000.Konwersje;

namespace Konwerter8000
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ILog l;
        public MainWindow(ILog log, Konwerter8000Konwersja konwersja)
        {
            InitializeComponent();
            l = log;
            KategorieCombo.ItemsSource = konwersja.PobierzKonwertery();
            LogDataGrid.ItemsSource = l.PobierzLog();

        }

        private void KategorieCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (KategorieCombo.SelectedItem != null)
            {
                ZJednostkiComboBox.ItemsSource =
                    (
                        (IKonwerter8000)KategorieCombo.SelectedItem

                    ).Jednostki;
                DoJednostkiComboBox.ItemsSource =
                    (
                        (IKonwerter8000)KategorieCombo.SelectedItem
                    ).Jednostki;
            }
        }

        private void PrzeliczButton_Click(object sender, RoutedEventArgs e)
        {
            if (ZJednostkiComboBox.SelectedIndex != -1)
            {
                IKonwerter8000 konwerter = (IKonwerter8000)KategorieCombo.SelectedItem;
                double wynik = konwerter.Konwertuj(
                    ZJednostkiComboBox.SelectedItem.ToString(),
                        DoJednostkiComboBox.SelectedItem.ToString(),
                            double.Parse(DoPrzeliczeniaTextBox.Text)
                    );
                WynikLabel.Content = wynik.ToString();
                LogDTO logDTO = new LogDTO()
                {
                    Id = 5,
                    Data = DateTime.Now,
                    DoJednostki = DoJednostkiComboBox.SelectedItem.ToString(),
                    ZJednostki = ZJednostkiComboBox.SelectedItem.ToString(),
                    WartoscDoPrzeliczen = double.Parse(DoPrzeliczeniaTextBox.Text),
                    WartoscPrzeliczona = wynik
                };
                l.DodajLog(logDTO);
                LogDataGrid.ItemsSource = l.PobierzLog();
            }
        }
    }
}
