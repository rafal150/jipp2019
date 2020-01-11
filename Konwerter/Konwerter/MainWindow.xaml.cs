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
using Konwerter.Serwisy;

namespace KonwerterNS
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string textBlockWybranyTyp;
        public IStatisticsRepository repo;
        public MainWindow(IStatisticsRepository repository, KonwerterSerwisy konwertery)
        {
            InitializeComponent();
            //List<string> ListTemperaturaJednostki = new List<string>(new[]{ "Celsjusz", "Farenheit", "Kelvin", "Rankin" });
            //List<string> ListDlugoscJednostki = new List<string>(new[] { "mm", "cm", "dcm", "m", "km", "cal", "stopa", "jard", "mila", "kabel", "mila morska" });
            //List<string> ListMasaJednostki = new List<string>(new[] { "mg", "g", "dkg", "kg", "T", "uncja", "funt", "karat", "kwintal" });  
            //ComboboxZTemp.DataContext = ListTemperaturaJednostki;
            //ComboboxNaTemp.DataContext = ListTemperaturaJednostki;
            //ComboboxZDlugosc.DataContext = ListDlugoscJednostki;
            //ComboboxNaDlugosc.DataContext = ListDlugoscJednostki;
            //ComboboxZMasa.DataContext = ListMasaJednostki;
            //ComboboxNaMasa.DataContext = ListMasaJednostki;

            this.repo = repository;
            this.dataGridStatistics.ItemsSource = repo.WczytajStaty();

            this.comboBoxTyp.ItemsSource = konwertery.WczytajKonwertery();
        }

        private void ButtonKonwertuj_Click(object sender, RoutedEventArgs e)
        {
            if (this.comboBoxTyp.SelectedItem != null)
            {
                IKonwerter converter = (IKonwerter)this.comboBoxTyp.SelectedItem;
                decimal result = converter.Konwertuj(comboBoxJednostkZ.SelectedIndex, comboBoxJednostkaNa.SelectedIndex, Convert.ToDouble(textBoxZ.Text));

                this.textBoxNa.Text = result.ToString();
                repo.ZapiszDoDB(textBlockWybranyTyp, comboBoxJednostkaNa.Text, comboBoxJednostkZ.Text, double.Parse(textBoxZ.Text), double.Parse(textBoxNa.Text));
                this.dataGridStatistics.ItemsSource = repo.WczytajStaty();
                //StatisticDTO st = new StatisticDTO()
                //{
                //    DateTime = DateTime.Now,
                //    Type = "Masa"
                //};

                //this.repository.AddStatistic(st);
                //this.statisticsDataGrid.ItemsSource = repository.GetStatistics();
            }
        }

        private void ComboBoxTyp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.comboBoxTyp.SelectedItem != null)
            {
                this.comboBoxJednostkZ.ItemsSource = ((IKonwerter)this.comboBoxTyp.SelectedItem).Jednostki;
                this.comboBoxJednostkaNa.ItemsSource = ((IKonwerter)this.comboBoxTyp.SelectedItem).Jednostki;
                this.textBoxNa.Text = null;
                this.textBoxZ.Text = null;
            }
        }

        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            textBlockWybranyTyp = (sender as TextBlock).Text;
        }

        //enum KownersjeDlugosc
        //{
        //    km = 1,
        //    cm= 100000,
        //    dcm = 10000,
        //    m = 1000,
        //    mm = 1000000
        //}

        //private void ButtonTemp_Click(object sender, RoutedEventArgs e)
        //{
        //    TextboxNaTemp.Text = TemperaturaKonwertuj(double.Parse(TextboxZTemp.Text), ComboboxZTemp.SelectedIndex, ComboboxNaTemp.SelectedIndex).ToString();
        //    repo.ZapiszDoDB("Temperatura", ComboboxZTemp.Text, ComboboxNaTemp.Text, double.Parse(TextboxZTemp.Text), double.Parse(TextboxNaTemp.Text));
        //    this.dataGridStatistics.ItemsSource = repo.WczytajStaty();

        //}

        //private double TemperaturaKonwertuj (double value, int unitFrom, int unitTo)
        //{
        //    if (unitFrom == 0)
        //    {
        //        switch (unitTo)
        //        {
        //            case 0:
        //                return value;
        //            case 1:
        //                return value * 9 / 5 + 32;
        //            case 2:
        //                return value + 273.15;
        //            case 3:
        //                return (value + 273.15) * 9 / 5;
        //        }
        //    }
        //    else if (unitFrom == 1)
        //    {
        //        switch (unitTo)
        //        {
        //            case 0:
        //                return (value - 32) * 5 / 9;
        //            case 1:
        //                return value;
        //            case 2:
        //                return (value + 459.67) * 5 / 9;
        //            case 3:
        //                return (value + 459.67);
        //        }
        //    }
        //    else if (unitFrom == 2)
        //    {
        //        switch (unitTo)
        //        {
        //            case 0:
        //                return value - 273.15;
        //            case 1:
        //                return (value * 9 / 5) - 459.67;
        //            case 2:
        //                return value;
        //            case 3:
        //                return value * 9 / 5;
        //        }
        //    }
        //    else if (unitFrom == 3)
        //    {
        //        switch (unitTo)
        //        {
        //            case 0:
        //                return (value - 491.67) * 5 / 9;
        //            case 1:
        //                return value - 459.67;
        //            case 2:
        //                return value * 5 / 9;
        //            case 3:
        //                return value;
        //        }
        //    }
        //    return 0;
        //}
        //public struct JednostkiDlugosci
        //{
        //    private const double mm = 1;
        //    private const double Cm = 0.1;
        //    private const double Dcm = 0.01;
        //    private const double M = 0.001;
        //    private const double Km = 0.000001;
        //    private const double Cal = 0.039370;
        //    private const double Stopa = 0.0032808;
        //    private const double Jard = 0.0010936100483;
        //    private const double Mila = 0.00000621371192237334;
        //    private const double Kabel = 0.0000053995680345572;
        //    private const double MilaMorska = 0.00000053995680345572;
        //    public static double PobierzJednostkeDlugosci(int index)
        //    {
        //        switch (index)
        //        {
        //            case 0:
        //                return mm;
        //            case 1:
        //                return Cm;
        //            case 2:
        //                return Dcm;
        //            case 3:
        //                return M;
        //            case 4:
        //                return Km;
        //            case 5:
        //                return Cal;
        //            case 6:
        //                return Stopa;
        //            case 7:
        //                return Jard;
        //            case 8:
        //                return Mila;
        //            case 9:
        //                return Kabel;
        //            case 10:
        //                return MilaMorska;
        //            default:
        //                return 0;
        //        }
        //    }
        //}
        //public struct JednostkiMasa
        //{
        //    private const double mg = 1;
        //    private const double g = 0.001;
        //    private const double dkg = 0.0001;
        //    private const double kg = 0.00001;
        //    private const double T = 0.00000001;
        //    private const double uncja = 0.000035274;
        //    private const double funt = 0.0000024419;
        //    private const double karat = 0.005;
        //    private const double kwintal = 10;

        //    public static double PobierzJednostkeMasy(int index)
        //    {

        //        switch (index)
        //        {
        //            case 0:
        //                return mg;
        //            case 1:
        //                return g;
        //            case 2:
        //                return dkg;
        //            case 3:
        //                return kg;
        //            case 4:
        //                return T;
        //            case 5:
        //                return uncja;
        //            case 6:
        //                return funt;
        //            case 7:
        //                return karat;
        //            case 8:
        //                return kwintal;
        //            default:
        //                return 0;
        //        }
        //    }
        //}
        //private void ButtonDlugosc_Click(object sender, RoutedEventArgs e)
        //{
        //    double NaDlugosci = 0;
        //    double ZDlugosci = double.Parse(TextboxZDlugosc.Text);
        //    double tmpZ = JednostkiDlugosci.PobierzJednostkeDlugosci(ComboboxZDlugosc.SelectedIndex);
        //    double tmpNa = JednostkiDlugosci.PobierzJednostkeDlugosci(ComboboxNaDlugosc.SelectedIndex);
        //    NaDlugosci = (ZDlugosci * tmpNa) / tmpZ;
        //    TextboxNaDlugosc.Text = NaDlugosci.ToString();
        //    repo.ZapiszDoDB("Dlugosc", ComboboxZDlugosc.Text, ComboboxNaDlugosc.Text, ZDlugosci, NaDlugosci);
        //    this.dataGridStatistics.ItemsSource = repo.WczytajStaty();


        //}

        //private void ButtonMasa_Click(object sender, RoutedEventArgs e)
        //{
        //    double NaMase = 0;
        //    double ZMasy = double.Parse(TextboxZMasa.Text);
        //    double tmpZ = JednostkiMasa.PobierzJednostkeMasy(ComboboxZMasa.SelectedIndex);
        //    double tmpNa = JednostkiMasa.PobierzJednostkeMasy(ComboboxNaMasa.SelectedIndex);
        //    NaMase = (ZMasy * tmpNa) / tmpZ;
        //    TextboxNaMasa.Text = NaMase.ToString();
        //    repo.ZapiszDoDB("Masa", ComboboxZMasa.Text, ComboboxNaMasa.Text, ZMasy, NaMase);
        //    this.dataGridStatistics.ItemsSource = repo.WczytajStaty();

        //}


        /*
        private double DlugoscKonwertuj(double z, int zjednostka, int najednostka)
        {
            if (zjednostka == 0)
            {
                switch (najednostka)
                {
                    case 0:
                        return z;
                    case 1:
                        return z * 10;
                    case 2:
                        return z * 100;
                    case 3:
                        return z * 1000;
                    case 4:
                        return z * 10000;
                    case 5:
                        return z * 25.4;
                    case 6:
                        return z * 304.8;
                    case 7:
                        return z * 914.4;
                    case 8:
                        return z * 1609344;
                    case 9:
                        return z * 185200;
                    case 10:
                        return z * 1852000;
                }
            }
            else if (zjednostka == 1)
            {
                switch (najednostka)
                {
                    case 0:
                        return z/10;
                    case 1:
                        return z;
                    case 2:
                        return z * 10;
                    case 3:
                        return z * 100;
                    case 4:
                        return z * 1000;
                    case 5:
                        return z * 2.54;
                    case 6:
                        return z * 30.48;
                    case 7:
                        return z * 91.44;
                    case 8:
                        return z * 160934.4;
                    case 9:
                        return z * 18520;
                    case 10:
                        return z * 185200;
                }
            }
            else if (zjednostka == 2)
            {
                switch (najednostka)
                {
                    case 0:
                        return z/100;
                    case 1:
                        return z/10;
                    case 2:
                        return z;
                    case 3:
                        return z*10;
                    case 4:
                        return z * 100;
                    case 5:
                        return z * 0.254;
                    case 6:
                        return z * 3.048;
                    case 7:
                        return z * 9.144;
                    case 8:
                        return z * 16093.44;
                    case 9:
                        return z * 1852;
                    case 10:
                        return z * 18520;
                }
            }
            else if (zjednostka == 3)
            {
                switch (najednostka)
                {
                    case 0:
                        return z/1000;
                    case 1:
                        return z/100;
                    case 2:
                        return z/10;
                    case 3:
                        return z;
                    case 4:
                        return z*10;
                    case 5:
                        return z * 0.0254;
                    case 6:
                        return z * 0.3048;
                    case 7:
                        return z * 0.9144;
                    case 8:
                        return z * 1609.344;
                    case 9:
                        return z * 185.2;
                    case 10:
                        return z * 1852;
                }
            }
            else if (zjednostka == 4)
            {
                switch (najednostka)
                {
                    case 0:
                        return z/10000;
                    case 1:
                        return z/1000;
                    case 2:
                        return z/100;
                    case 3:
                        return z/10;
                    case 4:
                        return z;
                    case 5:
                        return z * 0.00254;
                    case 6:
                        return z * 0.03048;
                    case 7:
                        return z * 0.09144;
                    case 8:
                        return z * 160.9344;
                    case 9:
                        return z * 18.52;
                    case 10:
                        return z * 185.2;
                }
            }
            else if (zjednostka == 5)
            {
                switch (najednostka)
                {
                    case 0:
                        return z * 0.0393700787;
                    case 1:
                        return z * 0.393700787;
                    case 2:
                        return z * 393700787;
                    case 3:
                        return z * 3.93700787;
                    case 4:
                        return z;
                    case 5:
                        return z;
                    case 6:
                        return z;
                    case 7:
                        return z;
                    case 8:
                        return z;
                    case 9:
                        return z;
                    case 10:
                        return z;
                }
            }
            else if (zjednostka == 6)
            {
                switch (najednostka)
                {
                    case 0:
                        return z;
                    case 1:
                        return z;
                    case 2:
                        return z;
                    case 3:
                        return z;
                    case 4:
                        return z;
                    case 5:
                        return z;
                    case 6:
                        return z;
                    case 7:
                        return z;
                    case 8:
                        return z;
                    case 9:
                        return z;
                    case 10:
                        return z;
                }
            }
            else if (zjednostka == 7)
            {
                switch (najednostka)
                {
                    case 0:
                        return z;
                    case 1:
                        return z;
                    case 2:
                        return z;
                    case 3:
                        return z;
                    case 4:
                        return z;
                    case 5:
                        return z;
                    case 6:
                        return z;
                    case 7:
                        return z;
                    case 8:
                        return z;
                    case 9:
                        return z;
                    case 10:
                        return z;
                }
            }
            else if (zjednostka == 8)
            {
                switch (najednostka)
                {
                    case 0:
                        return z;
                    case 1:
                        return z;
                    case 2:
                        return z;
                    case 3:
                        return z;
                    case 4:
                        return z;
                    case 5:
                        return z;
                    case 6:
                        return z;
                    case 7:
                        return z;
                    case 8:
                        return z;
                    case 9:
                        return z;
                    case 10:
                        return z;
                }
            }
            else if (zjednostka == 9)
            {
                switch (najednostka)
                {
                    case 0:
                        return z;
                    case 1:
                        return z;
                    case 2:
                        return z;
                    case 3:
                        return z;
                    case 4:
                        return z;
                    case 5:
                        return z;
                    case 6:
                        return z;
                    case 7:
                        return z;
                    case 8:
                        return z;
                    case 9:
                        return z;
                    case 10:
                        return z * 0.1;
                }
            }
            else if (zjednostka == 10)
            {
                switch (najednostka)
                {
                    case 0:
                        return z;
                    case 1:
                        return z;
                    case 2:
                        return z;
                    case 3:
                        return z;
                    case 4:
                        return z;
                    case 5:
                        return z;
                    case 6:
                        return z;
                    case 7:
                        return z;
                    case 8:
                        return z;
                    case 9:
                        return z/10;
                    case 10:
                        return z;
                }
            }
            return 0;
        }
        */

    }

 

    
}
