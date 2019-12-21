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
using System.Configuration;



namespace lab1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IStatisticsRepository repository;
        public MainWindow(IStatisticsRepository repo, Wybor_konwertera konwertery)
        {
            InitializeComponent();
            this.repository = repo;
            this.StatystykiDataGrid.ItemsSource = repository.GetStatistics();

            TypJednostki.ItemsSource = konwertery.GetConverters();    //new Wybor_konwertera().GetConverters();
            //LoadStatystyki();
        }

        private void LoadStatystyki()
        {
            List<Tabela1> units = null;
            using (Model1 baza = new Model1())
            {
                units = baza.Tabela1.ToList();
            }
            this.StatystykiDataGrid.ItemsSource = units;
        }

        public void TypJednostki_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.TypJednostki.SelectedItem != null)
            {
                this.JednostkaZ.ItemsSource = ((IKonwersja)this.TypJednostki.SelectedItem).Jednostki;
                this.JednostkaDo.ItemsSource = ((IKonwersja)this.TypJednostki.SelectedItem).Jednostki;
            }

        }

        private void Oblicz_Click(object sender, RoutedEventArgs e)
        {

            if (this.TypJednostki.SelectedItem != null)
            {
                IKonwersja konwerter = (IKonwersja)this.TypJednostki.SelectedItem;
                int result = konwerter.Konwertuj(
                    this.JednostkaZ.SelectedItem.ToString(),
                    this.JednostkaDo.SelectedItem.ToString(),
                    int.Parse(this.IloscPrzed.Text));

                this.IloscPo.Text = result.ToString();

                           }

            using (Model1 baza = new Model1())
            {

                /*Tabela1 unit = new Tabela1()
                {
                    Data = DateTime.Now,
                    TypJednostki = this.TypJednostki.Text,
                    JednostkaZ = this.JednostkaZ.Text,
                    JednostkaDo = this.JednostkaDo.Text,
                    IloscPrzed = int.Parse(this.IloscPrzed.Text),
                    IloscPo = int.Parse(this.IloscPo.Text)
                };
                baza.Tabela1.Add(unit);
                baza.SaveChanges();*/
            }
            StatisticDTO unit2 = new StatisticDTO()
            {
                Data = DateTime.Now,
                TypJednostki = this.TypJednostki.Text,
                JednostkaZ = this.JednostkaZ.Text,
                JednostkaDo = this.JednostkaDo.Text,
                IloscPrzed = int.Parse(this.IloscPrzed.Text),
                IloscPo = int.Parse(this.IloscPo.Text)
            };
            this.repository.AddStatistic(unit2);
            this.StatystykiDataGrid.ItemsSource = repository.GetStatistics();
            //LoadStatystyki();
        }
       
        private void RadioButton_Checked1(object sender, RoutedEventArgs e)
        {
            StatisticsAzureStorageRepository repo = new StatisticsAzureStorageRepository();
            this.repository = repo;
            this.StatystykiDataGrid.ItemsSource = this.repository.GetStatistics();
            StatystykiDataGrid.Items.Refresh();
        }

        private void RadioButton_Checked2(object sender, RoutedEventArgs e)
        {
            StatisticsSqlRepository repo = new StatisticsSqlRepository();
            this.repository = repo;
            this.StatystykiDataGrid.ItemsSource = this.repository.GetStatistics();
            StatystykiDataGrid.Items.Refresh();
        }
    }
             
}
                    


         
       
    

