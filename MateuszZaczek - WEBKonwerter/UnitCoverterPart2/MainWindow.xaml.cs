﻿using System;
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
using KonwerterZSQLiAZUREiPLUGIN.Services;

namespace KonwerterZSQLiAZUREiPLUGIN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ADDStat repository;

        public MainWindow(ADDStat repo, ConvertersService converters)
        {
            InitializeComponent();


            this.ComboOption.ItemsSource = new List<string>(new[]
       {
                "Temperatura", "Długość", "Masa" 
            });

            this.repository = repo;
            this.statisticsDataGrid.ItemsSource = repository.GetStatistics();

            this.ComboOption_Copy.ItemsSource = new List<string>(new[]
{
               "Moc plugin"
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBoxFrom.Text = "";
            TextboxResult.Text = "";
        }
        private void ComboOption_DropDownClosed(object sender, EventArgs e)
        {

            if (ComboOption_Copy.Text == "Moc plugin")
            {
                this.ComboFrom.ItemsSource = new List<string>(new[]
                {
                "HP", "kW", "KM"
                });

                this.ComboTo.ItemsSource = new List<string>(new[]
                {
                "HP", "kW", "KM"
                });
            }


            if (ComboOption.Text == "Temperatura")
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
                        if (ComboOption.Text == "Długość")
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
                        if (ComboOption.Text == "Masa")
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
            private void ButtonConvert_Click(object sender, RoutedEventArgs e)
        {
            if (ComboOption_Copy.Text == "Moc plugin")
            {
                if (ComboFrom.Text == "HP")
                {
                    double unitFrom = double.Parse(TextBoxFrom.Text);
                    if (ComboTo.Text == "KM") TextboxResult.Text = ((unitFrom * 1.01)).ToString();
                    if (ComboTo.Text == "kW") TextboxResult.Text = (unitFrom * 0.75).ToString();
                }

                if (ComboFrom.Text == "kW")
                {
                    double unitFrom = double.Parse(TextBoxFrom.Text);
                    if (ComboTo.Text == "HP") TextboxResult.Text = ((unitFrom * 1.34)).ToString();
                    if (ComboTo.Text == "KM") TextboxResult.Text = (unitFrom * 1.36).ToString();
                }

                if (ComboFrom.Text == "KM")
                {
                    double unitFrom = double.Parse(TextBoxFrom.Text);
                    if (ComboTo.Text == "HP") TextboxResult.Text = ((unitFrom * 0.99)).ToString();
                    if (ComboTo.Text == "kW") TextboxResult.Text = (unitFrom * 0.74).ToString();
                }
            }


            if (ComboOption.Text == "Temperatura")
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

            if (ComboOption.Text == "Długość")
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

            if (ComboOption.Text == "Masa")
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

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost:33555/");
        }
    }

}




