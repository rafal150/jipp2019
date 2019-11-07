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

namespace konwenter
{
   
    public partial class MainWindow : Window
    {
        Lista aa = new Lista();
        liczenie bb = new liczenie();
        LiczenieMetry cc = new LiczenieMetry();
        LIczenieAnglo dd = new LIczenieAnglo();
        LiczenieMorskie ee = new LiczenieMorskie();
        LiczenieMasy ff = new LiczenieMasy();
        LiczenieMAnglosaskie gg = new LiczenieMAnglosaskie();
        LiczenieInne hh = new LiczenieInne();
        public MainWindow()
        {
            InitializeComponent();
            this.ListaG.ItemsSource = aa.GetUnittypyjednostki();

            this.LoadStatistics();
        }
        private void LoadStatistics()
        {
            List<Statystyka> statistics;

            using (ConverterContext context = new ConverterContext())
            {
                statistics = context.Statystyka.ToList();
            }

            this.statystykaDataGrid.ItemsSource = statistics;
        }

        private void ComboBox_SelectionChanged()
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ListaG.SelectedIndex)
            {
                case 0:
                    this.Pole1.ItemsSource = aa.GetUnittemperatura();
                    this.Pole2.ItemsSource = aa.GetUnittemperatura();
                    break;
                case 1:
                    this.Pole1.ItemsSource = aa.GetUnitmetryczne();
                    this.Pole2.ItemsSource = aa.GetUnitmetryczne();
                    break;
                case 2:
                    this.Pole1.ItemsSource = aa.GetUnitanglo();
                    this.Pole2.ItemsSource = aa.GetUnitanglo();
                    break;
                case 3:
                    this.Pole1.ItemsSource = aa.GetUnitmorskie();
                    this.Pole2.ItemsSource = aa.GetUnitmorskie();
                    break;
                case 4:
                    this.Pole1.ItemsSource = aa.GetUnitmasy();
                    this.Pole2.ItemsSource = aa.GetUnitmasy();
                    break;
                case 5:
                    this.Pole1.ItemsSource = aa.GetUnitmanglosaskie();
                    this.Pole2.ItemsSource = aa.GetUnitmanglosaskie();
                    break;
                case 6:
                    this.Pole1.ItemsSource = aa.GetUnitinne();
                    this.Pole2.ItemsSource = aa.GetUnitinne();
                    break;

                    
            }


        }
       

        

        private void Button_Click(object sender, RoutedEventArgs e)           
        {        
           int val = int.Parse(this.Wartosc1.Text);
           this.Wartosc2.Text = bb.konwe(ListaG.SelectedIndex, Pole1.SelectedIndex, Pole2.SelectedIndex, val).ToString();
           
           this.Wartosc2.Text = cc.konwe(ListaG.SelectedIndex, Pole1.SelectedIndex, Pole2.SelectedIndex, val).ToString();

           this.Wartosc2.Text = dd.konwe(ListaG.SelectedIndex, Pole1.SelectedIndex, Pole2.SelectedIndex, val).ToString();

           this.Wartosc2.Text = ee.konwe(ListaG.SelectedIndex, Pole1.SelectedIndex, Pole2.SelectedIndex, val).ToString();

           this.Wartosc2.Text = ff.konwe(ListaG.SelectedIndex, Pole1.SelectedIndex, Pole2.SelectedIndex, val).ToString();

           this.Wartosc2.Text = gg.konwe(ListaG.SelectedIndex, Pole1.SelectedIndex, Pole2.SelectedIndex, val).ToString();

           this.Wartosc2.Text = hh.konwe(ListaG.SelectedIndex, Pole1.SelectedIndex, Pole2.SelectedIndex, val).ToString();

            using (ConverterContext context = new ConverterContext())
            {
                Statystyka st = new Statystyka()
                {
                    DateTime = DateTime.Now,
                    JednostkaWyjściowa = this.Pole1.SelectedItem.ToString(),
                    Rodzaj = "Temperatura"
                };

                context.Statystyka.Add(st);
                context.SaveChanges();
            }


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            konwenter.KonwenterDataSet konwenterDataSet = ((konwenter.KonwenterDataSet)(this.FindResource("konwenterDataSet")));
            // Załaduj dane do tabeli Kalkulator. Możesz modyfikować ten kod w razie potrzeby.
            konwenter.KonwenterDataSetTableAdapters.KalkulatorTableAdapter konwenterDataSetKalkulatorTableAdapter = new konwenter.KonwenterDataSetTableAdapters.KalkulatorTableAdapter();
            konwenterDataSetKalkulatorTableAdapter.Fill(konwenterDataSet.Kalkulator);
            System.Windows.Data.CollectionViewSource kalkulatorViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("kalkulatorViewSource")));
            kalkulatorViewSource.View.MoveCurrentToFirst();
        }

        private void statystykaDataGridChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
