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

namespace Konwerter_jednostek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int inputTypID, outputTypID;
        private IPolaczenie connect;
        private IEnumerable<IKonwertuj> przelicznik;
        private List<Miara> listaMiar;
        private List<Przeliczanie_miar> listaPrzelicznikow;
        public MainWindow(IPolaczenie repo, ConvertersService converters)
        {
            InitializeComponent();
            //InputType.ItemsSource = PolaczenieDb.PobierzListeMiar(null); //pobieranie z bazy nazwy miary
            przelicznik = converters.GetConverters();

            listaPrzelicznikow = new List<Przeliczanie_miar>();
            listaMiar = new List<Miara>();
            foreach (var p in przelicznik)
            {
                listaMiar.AddRange(p.Lista_Miar);
                listaPrzelicznikow.AddRange(p.Lista_Przeliczanie_miar);
            }

            InputType.ItemsSource = listaMiar.Distinct();
            InputType.DisplayMemberPath = "Nazwa_miary";
            inputTypID = 0;
            outputTypID = 0;
            connect = repo;
            Lista_statystyk.ItemsSource = connect.PobierzStatystyki();
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e) //przycisk konwersji
        {
            Output.Text = Konwerter.Konwertuj(Convert.ToDouble(Input.Text), inputTypID, outputTypID, listaPrzelicznikow.Distinct()).ToString();
            //var nazwa_typu = PolaczenieDb.pobierz_nazwe_typu(((Miara)OutputType.SelectedItem).Typ_ID);
            var nazwa_typu = przelicznik.Select(x => x.Pobierz_nazwe_typu(((Miara)OutputType.SelectedItem).Typ_ID)).Where(x => x != "").First();
            //PolaczenieDb.Dodaj_statystyke(nazwa_typu, ((Miara)InputType.SelectedItem).Nazwa_miary, Convert.ToDouble(Input.Text), ((Miara)OutputType.SelectedItem).Nazwa_miary, Convert.ToDouble(Output.Text));
            connect.Dodaj_statystyke(new Statystyka(DateTime.Now, nazwa_typu, ((Miara)InputType.SelectedItem).Nazwa_miary, Convert.ToDouble(Input.Text), ((Miara)OutputType.SelectedItem).Nazwa_miary, Convert.ToDouble(Output.Text)));
            //Lista_statystyk.ItemsSource = PolaczenieDb.PobierzStatystyki();
            Lista_statystyk.ItemsSource = connect.PobierzStatystyki();
        }

        private void OutputType_SelectionChanged(object sender, SelectionChangedEventArgs e) //zdarzenie na zmiane wybranej opcji miary z listy wyjsciowej
        {
            if (OutputType.SelectedIndex!=-1)
            {
                outputTypID = ((Miara)OutputType.SelectedItem).Miara_ID;
            }
            
        }

        private void InputType_SelectionChanged(object sender, SelectionChangedEventArgs e) //na zmiane opcji z listy wejsciowej
        {
            OutputType.SelectedIndex = -1;
            //OutputType.ItemsSource = PolaczenieDb.PobierzListeMiar(((Miara)InputType.SelectedItem).Typ_ID);
            OutputType.ItemsSource = listaMiar.Where(x => x.Typ_ID == ((Miara)InputType.SelectedItem).Typ_ID).Distinct();
            OutputType.DisplayMemberPath = "Nazwa_miary";
            inputTypID = ((Miara)InputType.SelectedItem).Miara_ID;
        }

        
    }
}
