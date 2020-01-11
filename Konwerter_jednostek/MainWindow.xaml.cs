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
        private ILogic logicPart;
        private ConverterAPI converter;
        public MainWindow(IPolaczenie repo, ConvertersService converters, ILogic logic, ConverterAPI converter)
        {
            InitializeComponent();
            this.converter = converter;
            //InputType.ItemsSource = PolaczenieDb.PobierzListeMiar(null); //pobieranie z bazy nazwy miary
            logicPart = logic;
            logicPart.Inicjalizuj(repo, converters);
            InputType.ItemsSource = logicPart.PobierzListeInputowychMiar();
            InputType.DisplayMemberPath = "Nazwa_miary";
            Lista_statystyk.ItemsSource = converter.PobierzStatystyki();
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e) //przycisk konwersji
        {
            Output.Text = logicPart.Konwertuj(Input.Text, (Miara)InputType.SelectedItem, (Miara)OutputType.SelectedItem);
            Lista_statystyk.ItemsSource = converter.PobierzStatystyki();
        }

        private void OutputType_SelectionChanged(object sender, SelectionChangedEventArgs e) //zdarzenie na zmiane wybranej opcji miary z listy wyjsciowej
        {
            if (OutputType.SelectedIndex!=-1)
            {
                logicPart.UstawOutputTypID(((Miara)OutputType.SelectedItem).Miara_ID);
            }          
        }

        private void InputType_SelectionChanged(object sender, SelectionChangedEventArgs e) //na zmiane opcji z listy wejsciowej
        {
            OutputType.SelectedIndex = -1;
            OutputType.ItemsSource = logicPart.PobierzListeOutputowychMiar(((Miara)InputType.SelectedItem).Typ_ID);
            OutputType.DisplayMemberPath = "Nazwa_miary";
            logicPart.UstawInputTypID(((Miara)InputType.SelectedItem).Miara_ID);
        }   
    }
}
