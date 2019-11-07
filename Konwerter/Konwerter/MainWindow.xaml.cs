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
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IStatystykiRepo repozytorium;
        obliczTemp licz = new obliczTemp();
        obliczDlugosc licz2 = new obliczDlugosc();
        obliczMase licz3 = new obliczMase();

        //public MainWindow()
        public MainWindow(IStatystykiRepo repo)
        {
            InitializeComponent();
            this.TypComboBox.ItemsSource = new List<string>(new[]
{
                "Temperatura", "Długość", "Masa"
            });

            this.repozytorium = repo;
            this.StatystykiDataGrid.ItemsSource = repozytorium.GetStatistics();

        }
        private void Load()
        {
            List<Konwerter_stat> statystyki = null;
            using (KonwContext kontext1 = new KonwContext())
            {
                statystyki = kontext1.Konwerter_stats.ToList();
            }
            this.StatystykiDataGrid.ItemsSource = statystyki;
        }
        private void Dodaj_do_statystyk()   //poprzednie do dodawania do SQL
        {
            using (KonwContext kontext2 = new KonwContext())
            {
                Konwerter_stat statystyki = new Konwerter_stat()
                {
                    DateTime = DateTime.Now,
                    UnitFrom = this.FromComboBox.SelectedItem.ToString(),
                    UnitTo = this.ToComboBox.SelectedItem.ToString(),
                    RawValue = decimal.Parse(this.WejscieTextBox.Text),
                    ConvertedValue=decimal.Parse(this.WynikTextBlock.Text),
                    Type = this.TypComboBox.SelectedItem.ToString(),
                };
                kontext2.Konwerter_stats.Add(statystyki);
                kontext2.SaveChanges();
            }
        }

        private void TypComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.TypComboBox.SelectedIndex == 0)
            {
                this.FromComboBox.ItemsSource = new List<string>(new[]  //z jednostki
                {
                "C", "F", "K","R"
                });
                
                this.ToComboBox.ItemsSource = new List<string>(new[]    //na jednostke
                {
                "C", "F", "K","R"
                });
                
            }
            else if (this.TypComboBox.SelectedIndex == 1)
            {
                this.FromComboBox.ItemsSource = new List<string>(new[]  //z jednostki
                {
                "mm", "cm", "dcm","m", "km","cal","stop","jard","mila","kabel","mila morska"
                });
                FromComboBox.SelectedItem = 0;

                this.ToComboBox.ItemsSource = new List<string>(new[]    //na jednostke
                {
                "mm", "cm", "dcm","m", "km","cal","stop","jard","mila","kabel","mila morska"
                });
            }
            else if (this.TypComboBox.SelectedIndex == 2)
            {
                this.FromComboBox.ItemsSource = new List<string>(new[]  //z jednostki
                {
                "mg", "g", "dkg","kg", "T","uncja","funt","karat","kwintal"
                });

                this.ToComboBox.ItemsSource = new List<string>(new[]    //na jednostke
                {
                "mg", "g", "dkg","kg", "T","uncja","funt","karat","kwintal"
                });
            }
            this.FromComboBox.SelectedIndex = 0;
            this.ToComboBox.SelectedIndex = 1;
        }
        private void KonwertujButton_Click(object sender, RoutedEventArgs e)
        {
            string z_czego = FromComboBox.SelectedItem.ToString();
            string na_co = ToComboBox.SelectedItem.ToString();
            //string wartosc = int.Parse(this.WejscieTextBox.Text).ToString();
            double wartosc = double.Parse(this.WejscieTextBox.Text);
            //this.WynikTextBlock.Text =
            //  ((int.Parse(this.WejscieTextBox.Text)) * 2).ToString(); //przeliczanie
            if (this.TypComboBox.SelectedIndex==0)
            {
                licz.liczenieTemp(z_czego, na_co, wartosc); //przeliczanie
                WynikTextBlock.Text = licz.wynik();   //wpisywanie wyniku
            }
            else if (this.TypComboBox.SelectedIndex == 1) //dlugosc
            {
                licz2.liczenieDlug(z_czego, na_co, wartosc);
                WynikTextBlock.Text = licz2.wynik();
            }
            else if(this.TypComboBox.SelectedIndex == 2) //masa
            {
                licz3.liczenieMasy(z_czego, na_co, wartosc);
                WynikTextBlock.Text = licz3.wynik();
            }
            else { }

            //Dodaj_do_statystyk();
            //MessageBox.Show("Dodano do bazy");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Load();  //wyciąganie danych z sql
        }

        private void WejscieTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.WejscieTextBox.Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StatystykiObiekt sts = new StatystykiObiekt()
            {
                DateTime = DateTime.Now,
                UnitFrom = this.FromComboBox.SelectedItem.ToString(),
                UnitTo = this.ToComboBox.SelectedItem.ToString(),
                RawValue = decimal.Parse(this.WejscieTextBox.Text),
                ConvertedValue = decimal.Parse(this.WynikTextBlock.Text),
                Type = this.TypComboBox.SelectedItem.ToString()
            };
            this.repozytorium.Dodaj_do_bazy(sts);
            this.StatystykiDataGrid.ItemsSource = repozytorium.GetStatistics();
            // 
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.StatystykiDataGrid.ItemsSource = repozytorium.GetStatistics();

        }
    }
}
