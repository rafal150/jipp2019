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

namespace KonwerterZSQLiAZURE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ADDStat repository;

        public MainWindow(ADDStat repo)
        {
            InitializeComponent();

            this.ComboOption.ItemsSource = new List<string>(new[]
{
                "TEMP", "LENGTH", "WEIGHT"
            });

            this.repository = repo;
            this.statisticsDataGrid.ItemsSource = repository.GetStatistics();
        }

        private void ComboOption_DropDownClosed(object sender, EventArgs e)
        {
            if (ComboOption.Text == "TEMP")
            {
                this.ComboFrom.ItemsSource = new List<string>(new[]
                {
                "Celsjusz", "Fahrenheit", "Kelvin", "Rankine"
                });

                this.ComboTo.ItemsSource = new List<string>(new[]
                {
                "Celsjusz", "Fahrenheit", "Kelvin", "Rankine"
                });
            }
            if (ComboOption.Text == "LENGTH")
            {
                this.ComboFrom.ItemsSource = new List<string>(new[]
                {
                "mm", "cm", "dm", "m", "km", "inch", "feet", "yard", "mile"
                });

                this.ComboTo.ItemsSource = new List<string>(new[]
                {
                "mm", "cm", "dm", "m", "km", "inch", "feet", "yard", "mile"
                });
            }
            if (ComboOption.Text == "WEIGHT")
            {
                this.ComboFrom.ItemsSource = new List<string>(new[]
                {
                "mg", "g", "dkg", "kg", "T"
                });

                this.ComboTo.ItemsSource = new List<string>(new[]
                {
                "mg", "g", "dkg", "kg", "T"
                });
            }
        }


        private void statisticsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonConvert_Click(object sender, RoutedEventArgs e)
        {
            if (ComboOption.Text == "TEMP")
            {
                if (ComboFrom.Text == "Celsjusz")
                {
                    double unitFrom = double.Parse(TextBoxFrom.Text);
                    if (ComboTo.Text == "Fahrenheit") TextboxResult.Text = ((9 * unitFrom / 5 + 32)).ToString();
                    if (ComboTo.Text == "Kelvin") TextboxResult.Text = (unitFrom - 273.15).ToString();
                    if (ComboTo.Text == "Rankine") TextboxResult.Text = (9 * (unitFrom + 273.15) / 5).ToString();
                }
                if (ComboFrom.Text == "Fahrenheit")
                {
                    double unitFrom = double.Parse(TextBoxFrom.Text);
                    if (ComboTo.Text == "Celsjusz") TextboxResult.Text = (5 * (unitFrom - 32) / 9).ToString();
                    if (ComboTo.Text == "Kelvin") TextboxResult.Text = (5 * (unitFrom + 459.67) / 9).ToString();
                    if (ComboTo.Text == "Rankine") TextboxResult.Text = (unitFrom + 459.67).ToString();
                }
                if (ComboFrom.Text == "Kelvin")
                {
                    double unitFrom = double.Parse(TextBoxFrom.Text);
                    if (ComboTo.Text == "Celsjusz") TextboxResult.Text = (unitFrom - 273.15).ToString();
                    if (ComboTo.Text == "Fahrenheit") TextboxResult.Text = (9 * unitFrom / 5 - 459.67).ToString();
                    if (ComboTo.Text == "Rankine") TextboxResult.Text = (unitFrom * 9 / 5).ToString();
                }
                if (ComboFrom.Text == "Rankine")
                {
                    double unitFrom = double.Parse(TextBoxFrom.Text);
                    if (ComboTo.Text == "Celsjusz") TextboxResult.Text = ((unitFrom - 491.67) * 5 / 9).ToString();
                    if (ComboTo.Text == "Fahrenheit") TextboxResult.Text = (unitFrom - 459.67).ToString();
                    if (ComboTo.Text == "Kelvin") TextboxResult.Text = (unitFrom * 5 / 9).ToString();
                }
            }

            if (ComboOption.Text == "LENGTH")
            {
                if (ComboFrom.Text == "mm")
                {
                    double unitFrom = double.Parse(TextBoxFrom.Text);
                    if (ComboTo.Text == "cm") TextboxResult.Text = (unitFrom * 0.1).ToString();
                    else if (ComboTo.Text == "dm") TextboxResult.Text = (unitFrom * 0.01).ToString();
                    else if (ComboTo.Text == "m") TextboxResult.Text = (unitFrom * 0.001).ToString();
                    else if (ComboTo.Text == "km") TextboxResult.Text = (unitFrom * 0.0001).ToString();
                }
                if (ComboFrom.Text == "cm")
                {
                    double unitFrom = double.Parse(TextBoxFrom.Text);
                    if (ComboTo.Text == "mm") TextboxResult.Text = (unitFrom * 10).ToString();
                    else if (ComboTo.Text == "dm") TextboxResult.Text = (unitFrom * 0.1).ToString();
                    else if (ComboTo.Text == "m") TextboxResult.Text = (unitFrom * 0.01).ToString();
                    else if (ComboTo.Text == "km") TextboxResult.Text = (unitFrom * 0.001).ToString();
                }
                if (ComboFrom.Text == "dm")
                {
                    double unitFrom = double.Parse(TextBoxFrom.Text);
                    if (ComboTo.Text == "mm") TextboxResult.Text = (unitFrom * 100).ToString();
                    else if (ComboTo.Text == "cm") TextboxResult.Text = (unitFrom * 10).ToString();
                    else if (ComboTo.Text == "m") TextboxResult.Text = (unitFrom * 0.1).ToString();
                    else if (ComboTo.Text == "km") TextboxResult.Text = (unitFrom * 0.01).ToString();
                }
                if (ComboFrom.Text == "m")
                {
                    double unitFrom = double.Parse(TextBoxFrom.Text);
                    if (ComboTo.Text == "mm") TextboxResult.Text = (unitFrom * 1000).ToString();
                    if (ComboTo.Text == "cm") TextboxResult.Text = (unitFrom * 100).ToString();
                    if (ComboTo.Text == "dm") TextboxResult.Text = (unitFrom * 10).ToString();
                    if (ComboTo.Text == "km") TextboxResult.Text = (unitFrom * 0.001).ToString();
                }
                if (ComboFrom.Text == "km")
                {
                    double unitFrom = double.Parse(TextBoxFrom.Text);
                    if (ComboTo.Text == "mm") TextboxResult.Text = (unitFrom * 1000000).ToString();
                    if (ComboTo.Text == "cm") TextboxResult.Text = (unitFrom * 100000).ToString();
                    if (ComboTo.Text == "dm") TextboxResult.Text = (unitFrom * 10000).ToString();
                    if (ComboTo.Text == "m") TextboxResult.Text = (unitFrom * 1000).ToString();
                }
            }

            if (ComboOption.Text == "WEIGHT")
            {
                if (ComboFrom.Text == "mg")
                {
                    double unitFrom = double.Parse(TextBoxFrom.Text);
                    if (ComboTo.Text == "g") TextboxResult.Text = (unitFrom * 0.001).ToString();
                    else if (ComboTo.Text == "dkg") TextboxResult.Text = (unitFrom * 0.0001).ToString();
                    else if (ComboTo.Text == "kg") TextboxResult.Text = (unitFrom * 0.000001).ToString();
                    else if (ComboTo.Text == "T") TextboxResult.Text = (unitFrom * 0.000000001).ToString();
                }
                if (ComboFrom.Text == "g")
                {
                    double unitFrom = double.Parse(TextBoxFrom.Text);
                    if (ComboTo.Text == "mg") TextboxResult.Text = (unitFrom * 1000).ToString();
                    else if (ComboTo.Text == "dkg") TextboxResult.Text = (unitFrom * 0.1).ToString();
                    else if (ComboTo.Text == "kg") TextboxResult.Text = (unitFrom * 0.001).ToString();
                    else if (ComboTo.Text == "T") TextboxResult.Text = (unitFrom * 0.000001).ToString();
                }
                if (ComboFrom.Text == "dkg")
                {
                    double unitFrom = double.Parse(TextBoxFrom.Text);
                    if (ComboTo.Text == "mg") TextboxResult.Text = (unitFrom * 10000).ToString();
                    else if (ComboTo.Text == "g") TextboxResult.Text = (unitFrom * 10).ToString();
                    else if (ComboTo.Text == "kg") TextboxResult.Text = (unitFrom * 0.01).ToString();
                    else if (ComboTo.Text == "T") TextboxResult.Text = (unitFrom * 0.00001).ToString();
                }
                if (ComboFrom.Text == "kg")
                {
                    double unitFrom = double.Parse(TextBoxFrom.Text);
                    if (ComboTo.Text == "mg") TextboxResult.Text = (unitFrom * 1000).ToString();
                    else if (ComboTo.Text == "g") TextboxResult.Text = (unitFrom * 1000).ToString();
                    else if (ComboTo.Text == "dkg") TextboxResult.Text = (unitFrom * 100).ToString();
                    else if (ComboTo.Text == "T") TextboxResult.Text = (unitFrom * 0.001).ToString();
                }
                if (ComboFrom.Text == "T")
                {
                    double unitFrom = double.Parse(TextBoxFrom.Text);
                    if (ComboTo.Text == "mg") TextboxResult.Text = (unitFrom * 1000000000).ToString();
                    if (ComboTo.Text == "g") TextboxResult.Text = (unitFrom * 1000000).ToString();
                    if (ComboTo.Text == "dkg") TextboxResult.Text = (unitFrom * 100000).ToString();
                    if (ComboTo.Text == "kg") TextboxResult.Text = (unitFrom * 1000).ToString();
                }
            }

            DBO st = new DBO()
            {
                DataGenerowania = DateTime.Now,
                LogKonwersji = "Konwersja Z: " + ComboFrom.SelectedValue + " "
                + "Konwersja NA: " + ComboTo.SelectedValue + " "
                + "Z wartosci: " + TextBoxFrom.Text + ComboFrom.SelectedValue + " "
                + "WYNIK: " + TextboxResult.Text + ComboTo.SelectedValue,

            };

            this.repository.AddStatistic(st);
            this.statisticsDataGrid.ItemsSource = repository.GetStatistics();
        }
      



        private void ButtonConvert_Copy_Click(object sender, RoutedEventArgs e)
        {
            TextBoxFrom.Text = "";
            TextboxResult.Text = "";
        }

        private void ButtonConvert_Copy1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            TextboxResult.Text = "";
            TextBoxFrom.Text = "";
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
    }

