//using Konwerter.Model;
//using Konwerter.Services;
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
using static Konwerter.ConvertersApiService;

namespace Konwerter
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ConvertersApiService converters;
        //private IStatystykiRepo repozytorium; 
                //TempConverter licz = new TempConverter();
                //DlugoscConverter licz2 = new DlugoscConverter();
                //MasaConverter licz3 = new MasaConverter();
        
        public MainWindow(ConvertersApiService converters)
        {
            InitializeComponent();
            this.converters = converters;


            //2020this.repozytorium = repo;
            //2020this.StatystykiDataGrid.ItemsSource = repozytorium.GetStatistics(); tutaj API pobieranie stats
            this.TypComboBox.ItemsSource = converters.GetConverters(); //nowe

        }
            //2020private void Load() //wyswietlenie statystyk z SQL
            //{
            //    List<Konwerter_stat> statystyki = null;
            //    using (KonwContext kontext1 = new KonwContext())
            //    {
            //        statystyki = kontext1.Konwerter_stat.ToList();
            //    }
            //    this.StatystykiDataGrid.ItemsSource = statystyki;
            //2020}
        //private void Dodaj_do_statystyk()   //poprzednie do dodawania do SQL
        //{
        //    using (KonwContext kontext2 = new KonwContext())
        //    {
        //        Konwerter_stat statystyki = new Konwerter_stat()
        //        {
        //            DateTime = DateTime.Now,
        //            UnitFrom = this.FromComboBox.SelectedItem.ToString(),
        //            UnitTo = this.ToComboBox.SelectedItem.ToString(),
        //            RawValue = decimal.Parse(this.WejscieTextBox.Text),
        //            ConvertedValue=decimal.Parse(this.WynikTextBlock.Text),
        //            Type = this.TypComboBox.SelectedItem.ToString(),
        //        };
        //        kontext2.Konwerter_stats.Add(statystyki);
        //        kontext2.SaveChanges();
        //    }
        //}
        private void Dodaj_do_statystyk()
        {
            //StatystykiObiekt sts = new StatystykiObiekt()
            //{
            //    DateTime = DateTime.Now,
            //    UnitFrom = this.FromComboBox.SelectedItem.ToString(),
            //    UnitTo = this.ToComboBox.SelectedItem.ToString(),
            //    RawValue = double.Parse(this.WejscieTextBox.Text),
            //    ConvertedValue = double.Parse(this.WynikTextBlock.Text),
            //    Type = ((IConverter)this.TypComboBox.SelectedItem).Name
            //};
            //this.repozytorium.Dodaj_do_bazy(sts);
            //this.StatystykiDataGrid.ItemsSource = repozytorium.GetStatistics(); //załadowanie statystyk
            
        }


        private void KonwertujButton_Click(object sender, RoutedEventArgs e)
        {
            string z_czego = FromComboBox.SelectedItem.ToString();
            string na_co = ToComboBox.SelectedItem.ToString();
            //string wartosc = int.Parse(this.WejscieTextBox.Text).ToString();
            double wartosc = double.Parse(this.WejscieTextBox.Text);
            //this.WynikTextBlock.Text =
            //  ((int.Parse(this.WejscieTextBox.Text)) * 2).ToString(); //przeliczanie
            if (this.TypComboBox.SelectedItem!=null)
            {
                Converter converter = (Converter)this.TypComboBox.SelectedItem;

                double wynik = this.converters.Liczenie(
                    this.FromComboBox.SelectedItem.ToString(),
                    this.ToComboBox.SelectedItem.ToString(), 
                    this.WejscieTextBox.Text,
                    converter.Name);
                WynikTextBlock.Text=wynik.ToString(); 
                
            }

            Dodaj_do_statystyk();
            MessageBox.Show("Dodano do bazy");
        }
        private void TypComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.TypComboBox.SelectedItem != null)
            {
                this.FromComboBox.ItemsSource = ((Converter)this.TypComboBox.SelectedItem).Units;

                this.ToComboBox.ItemsSource = ((Converter)this.TypComboBox.SelectedItem).Units;

            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //this.Load();  //wyciąganie danych z sql
        }

        private void WejscieTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.WejscieTextBox.Clear();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)   //wyswietlanie statystyk
        {
            //this.StatystykiDataGrid.ItemsSource = repozytorium.GetStatistics();

        }
    }
}
