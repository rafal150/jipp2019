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
using kalkulator.Services;


namespace kalkulator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow(ConvService converters)
        {
        
            
            InitializeComponent();
          this.Loadstatistick(); //ładuje baze do contextmenu
            this.CalcType.ItemsSource = converters.GetConverters();
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
            if (this.CalcType.SelectedItem != null)
            {
                this.StartType.ItemsSource = ((IConverter)this.CalcType.SelectedItem).Units;
                this.EndType.ItemsSource = ((IConverter)this.CalcType.SelectedItem).Units;
            }
           
        } 
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.CalcType.SelectedItem != null)
            {
                IConverter converter = (IConverter)this.CalcType.SelectedItem;
                double result = converter.Convert(
                    this.StartType.SelectedIndex,
                    this.EndType.SelectedIndex,
                    double.Parse(this.StartValue.Text));

                this.EndValue.Text = result.ToString();
            }
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
