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

namespace Konwerter
{
    public enum Kategoria { Temparatura, Długość, Masa }

    public partial class MainWindow : Window
    {
        private IStatisticRepository repository;
        Kategoria wybranaKategoria;
        ConverterManager converter = new ConverterManager();
        List<string> listaJednostek;

        public MainWindow(IStatisticRepository repository)
        {
            this.repository = repository;

            InitializeComponent();

            CategoryComboBox.ItemsSource = Enum.GetNames(typeof(Kategoria));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string from = FromComboBox.SelectedItem.ToString();
            string to = ToComboBox.SelectedItem.ToString();
            float amount = float.Parse(FromTextBox.Text);
            float result = converter.Convert(from, to, amount);
            string resultString = "Wynik: " + result.ToString();
            ResultTextBlock.Text = resultString;
            ResultTextBlock.UpdateLayout();

            StatisticDTO statystyki = new StatisticDTO
            {
                UnitFrom = from,
                UnitTo = to,
                DateTime = DateTime.Now,
                Type = wybranaKategoria.ToString(),
                ValueFrom = amount,
                ValueTo = result
            };
            repository.AddStatistic(statystyki);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            wybranaKategoria = (Kategoria)Enum.Parse(typeof(Kategoria), CategoryComboBox.SelectedItem.ToString());
            converter.kategoria = wybranaKategoria;
            listaJednostek = converter.listaJednostek;
            this.FromComboBox.ItemsSource = listaJednostek;
            this.ToComboBox.ItemsSource = listaJednostek;
        }

        private void StatystykiButton_Click(object sender, RoutedEventArgs e)
        {
            StatisticsWindow statystyki = new StatisticsWindow(repository);
            statystyki.Show();
        }
    }
}
