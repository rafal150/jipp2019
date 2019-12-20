using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
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
using KonwerterSDK;
using WpfApp7;

namespace WpfAppJIPP
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Type typKlasy;
        private IStatisticsRepository repository;
        private List<InterfejsKonwerter> listaInterfejsow;
        private KonwerterService konwerterService;
        public MainWindow(IStatisticsRepository repo, KonwerterService konwerterService)
        {
            InitializeComponent();

            this.repository = repo;
            this.konwerterService = konwerterService;
            this.StatisticDataGrid.ItemsSource = repository.GetStatistics();
            listaInterfejsow = konwerterService.GetConverters();
            List<string> listaKlas = new List<string>();
            foreach (InterfejsKonwerter converterInterface in listaInterfejsow)
            {
                listaKlas.Add(converterInterface.GetType().Name);
            }
            Wybor_typuCombobox.ItemsSource = listaKlas;
        }


        private void TypCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string wybrany_typ = Wybor_typuCombobox.SelectedItem.ToString();

            typKlasy = Type.GetType("WpfAppJIPP.Jednostki." + wybrany_typ);
            if (typKlasy == null)

            {
                foreach (InterfejsKonwerter interfejsKonwerter in listaInterfejsow)
                {
                    if (interfejsKonwerter.GetType().Name == wybrany_typ)
                    {
                        typKlasy = interfejsKonwerter.GetType();
                        break;
                    }
                }
            }
            MethodInfo metoda = typKlasy.GetMethod("GetJednostki");
            List<string> listaJednostek = (List<string>)metoda.Invoke(null, null);
            ZCombobox.ItemsSource = listaJednostek;
            NACombobox.ItemsSource = listaJednostek;

        }

        private void CalcButton_click(object sender, RoutedEventArgs e)
        {
            Object instancjaKlasy = typKlasy.GetConstructor(new Type[] { }).Invoke(new object[] { });
            string z_wybor = ZCombobox.SelectedItem.ToString();
            string na_wybor = NACombobox.SelectedItem.ToString();
            double wartosc_z = Convert.ToDouble(this.ZTextBox.Text);
            PropertyInfo set = typKlasy.GetProperty(z_wybor);
            PropertyInfo get = typKlasy.GetProperty(na_wybor);
            set.SetValue(instancjaKlasy, wartosc_z);
            double wartosc_na = Double.Parse(get.GetValue(instancjaKlasy).ToString());
            this.NATextBox.Text = Convert.ToString(wartosc_na);
            using (Converter context = new Converter())
            {


                StatisticDTO st = new StatisticDTO()
                {
                    Id = repository.GetStatistics().Count() + 1,
                    Czas = DateTime.Now,
                    Typ = typKlasy.Name,
                    Konwersja_z = z_wybor,
                    Konwersja_na = na_wybor,
                    Wartosc_wprowadzona = Convert.ToDecimal(wartosc_z),
                    Wynik = Convert.ToDecimal(wartosc_na)
                };
                this.repository.AddStatistic(st);
                this.StatisticDataGrid.ItemsSource = repository.GetStatistics();
            }

        }


    }
}

