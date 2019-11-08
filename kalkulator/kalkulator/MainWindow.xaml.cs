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

namespace kalkulator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        combobombo cb = new combobombo();
        liczydlo licz = new liczydlo();
        public MainWindow()
        {
           
            
            InitializeComponent();
            this.CalcType.ItemsSource = cb.GetUnittypes();
          this.Loadstatistick(); //ładuje baze do contextmenu
        }

        private void Loadstatistick()//pokazuje w contextmenu to co juz jest w bazie
        {
            List<statystyki> Statystyk;

            using (Prawidlowe_polaczenie context = new Prawidlowe_polaczenie())
            {
                Statystyk = context.statystyki.ToList();
            }
            this.Mygrid.ItemsSource = Statystyk;
        }
        private void CalcType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

                switch (CalcType.SelectedIndex)
                {
                    case 0:
                    this.StartType.ItemsSource = cb.GetUnittemp();
                    this.EndType.ItemsSource = cb.GetUnittemp();
                    break;
                    case 1:
                    this.StartType.ItemsSource = cb.GetUnitmet();
                    this.EndType.ItemsSource = cb.GetUnitmet();
                    break;
                    case 2:
                    this.StartType.ItemsSource = cb.GetUnitang();
                    this.EndType.ItemsSource = cb.GetUnitang();
                    break;
                    case 3:
                    this.StartType.ItemsSource = cb.GetUnitmor();
                    this.EndType.ItemsSource = cb.GetUnitmor();
                    break;
                     case 4:
                    this.StartType.ItemsSource = cb.GetUnitmmet();
                    this.EndType.ItemsSource = cb.GetUnitmmet();
                    break;
                    case 5:
                    this.StartType.ItemsSource = cb.GetUnitmang();
                    this.EndType.ItemsSource = cb.GetUnitmang();
                    break;
                    case 6:
                    this.StartType.ItemsSource = cb.GetUnitother();
                    this.EndType.ItemsSource = cb.GetUnitother();
                    break;

            }
            
            
                } 
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int val = int.Parse(this.StartValue.Text);
            this.EndValue.Text = licz.liczymy(CalcType.SelectedIndex, StartType.SelectedIndex, EndType.SelectedIndex,val).ToString();

             using (Prawidlowe_polaczenie contex = new Prawidlowe_polaczenie()) //wysylanie do bazy wyników
             {
                 statystyki st = new statystyki()
                 {
                     KATEGORIA = this.CalcType.Text,
                     WARTOSC_POCZATKOWA = int.Parse(this.StartValue.Text),
                     WARTOSC_KONCOWA = int.Parse(this.EndValue.Text),
                     DATA_GODZINA = DateTime.Now,
                     KTO = "null"
                 };
               contex.statystyki.Add(st);
                contex.SaveChanges();
                this.Loadstatistick();
            }
             


        }
    }
}
