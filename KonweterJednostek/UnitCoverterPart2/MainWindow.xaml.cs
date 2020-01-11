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

namespace Konwerter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RepozytoriumStatystyk repository;

        public MainWindow(RepozytoriumStatystyk repo)
        {
            InitializeComponent();

            this.repository = repo;
            this.statisticsDataGrid.ItemsSource = repository.GetStatistics();

            List<Wybor> s = new List<Wybor>();
            s.Add(new Wybor(1, "TEMPERATURY"));
            s.Add(new Wybor(2, "DŁUGOŚĆ"));
            s.Add(new Wybor(3, "MASA"));
            WyborBox.ItemsSource = s;
            WyborBox.DisplayMemberPath = "typ";

            textBox.Visibility = System.Windows.Visibility.Hidden; 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Jednostki t = new Jednostki();

            Wybor tp = WyborBox.SelectedValue as Wybor;
            if (Convert.ToUInt64(tp.id_wyboru) == 1)
            {
                fromcombo1.ItemsSource = t.temp;
                tocombo2.ItemsSource = t.temp;
            }
            if (Convert.ToUInt64(tp.id_wyboru) == 2)
            {
                fromcombo1.ItemsSource = t.dlugosci;
                tocombo2.ItemsSource = t.dlugosci;
            }

            if (Convert.ToUInt64(tp.id_wyboru) == 3)
            {
                fromcombo1.ItemsSource = t.masa;
                tocombo2.ItemsSource = t.masa;
            }
        }

        private void conv_btn_Click_1(object sender, RoutedEventArgs e)
        {
            double i = double.Parse(amount_txt.Text);
            string x;
            string y;
            x = (fromcombo1.SelectedItem).ToString();
            y = (tocombo2.SelectedItem).ToString();
            Jednostki obliczarka = new Jednostki();
            result.Text = obliczarka.Oblicz(i, x, y) + " " + (tocombo2.SelectedItem).ToString();
            textBox.Text = "Jednostka konwersji : " + WyborBox.Text + " " + " Z jednostki : " + " " + fromcombo1.Text + " Na jednostke : " + " " + tocombo2.Text + " WARTOSC : " + " " + amount_txt.Text + " WYNIK : " + " " + result.Text;

            PolaDataGrid st = new PolaDataGrid()
            {
                     DateTime = DateTime.Now ,
                Type = textBox.Text 
            };

            this.repository.AddStatistic(st);
            this.statisticsDataGrid.ItemsSource = repository.GetStatistics();


        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            textBox.Text = "";
            amount_txt.Text = "";
            result.Text = "";
        }
    }
}
