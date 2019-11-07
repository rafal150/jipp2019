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

namespace UnitCoverterPart2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IStatisticsRepository repository;
        private Converter _converter = PrepareConverter();
        public MainWindow(IStatisticsRepository repo)
        {
            InitializeComponent();

            this.repository = repo;
            this.statisticsDataGrid.ItemsSource = repository.GetStatistics();
            _converter.GetKeysFrom().ForEach(x => FromCombobox.Items.Add(x));
        }
        private static Converter PrepareConverter()
        {
            var converter = new Converter();
            //////////////////////
            //odleglosci
            /////////////////////////
            //metryczne
            converter.AddConvertion("Metr", "Kilometr", d => d * 0.001, d => d / 0.001);
            converter.AddConvertion("Metr", "Decymetr", d => d * 10, d => d / 10);
            converter.AddConvertion("Metr", "Centymetr", d => d * 100, d => d / 100);
            converter.AddConvertion("Metr", "Milimetr", d => d * 1000, d => d / 10);//
            converter.AddConvertion("Decymetr", "Kilometr", d => d * 0.0001, d => d / 0.0001);
            converter.AddConvertion("Decymetr", "Centymetr", d => d * 10, d => d / 10);
            converter.AddConvertion("Decymetr", "Milimetr", d => d * 100, d => d / 100);//
            converter.AddConvertion("Centymetr", "Kilometr", d => d * 0.00001, d => d / 0.00001);
            converter.AddConvertion("Centymetr", "Milimetr", d => d * 10, d => d / 10);//
            converter.AddConvertion("Milimetr", "Kilometr", d => d * 0.000001, d => d / 0.000001);
            //anglosaskie
            converter.AddConvertion("Cal", "Stopa", d => d * 0.083333, d => d / 0.083333);
            converter.AddConvertion("Cal", "Jard", d => d * 0.027778, d => d / 0.027778);
            converter.AddConvertion("Cal", "Mila", d => d * 0.000015783, d => d / 0.000015783);
            converter.AddConvertion("Stopa", "Jard", d => d * 0.333333, d => d / 0.333333);
            converter.AddConvertion("Stopa", "Mila", d => d * 0.000189393939, d => d / 0.000189393939);
            converter.AddConvertion("Mila", "Jard", d => d * 1.760, d => d / 1.760);
            //morskie
            converter.AddConvertion("MilaMorska", "Kabel", d => d * 10, d => d / 10);
            //mieszane metryczne
            converter.AddConvertion("Kilometr", "Cal", d => d * 39370.0787, d => d / 39370.0787);
            converter.AddConvertion("Kilometr", "Stopa", d => d * 3280.8399, d => d / 3280.8399);
            converter.AddConvertion("Kilometr", "Jard", d => d * 1093.6133, d => d / 1093.6133);
            converter.AddConvertion("Kilometr", "Mila", d => d * 0.621371192, d => d / 0.621371192);
            converter.AddConvertion("Kilometr", "MilaMorska", d => d * 0.539956803, d => d / 0.539956803);
            converter.AddConvertion("Kilometr", "Kabel", d => d * 4.55672208, d => d / 0.219456);

            converter.AddConvertion("Metr", "Cal", d => d * 39370.0787 * 0.001, d => d * 0.0254);
            converter.AddConvertion("Metr", "Stopa", d => d * 3280.8399 * 0.001, d => d * 0.3048);
            converter.AddConvertion("Metr", "Jard", d => d * 1093.6133 * 0.001, d => d * 0.9144);
            converter.AddConvertion("Metr", "Mila", d => d * 0.621371192 * 0.001, d => d * 1609.3472187);
            converter.AddConvertion("Metr", "MilaMorska", d => d * 0.539956803 * 0.001, d => d * 1852);
            converter.AddConvertion("Metr", "Kabel", d => d * 5.39956803 * 0.001, d => d * 219.456);

            converter.AddConvertion("Centymetr", "Cal", d => d * 39370.0787 * 0.001 * 0.01, d => d * 0.0254 * 100);
            converter.AddConvertion("Centymetr", "Stopa", d => d * 3280.8399 * 0.001 * 0.01, d => d * 0.3048 * 100);
            converter.AddConvertion("Centymetr", "Jard", d => d * 1093.6133 * 0.001 * 0.01, d => d * 0.9144 * 100);
            converter.AddConvertion("Centymetr", "Mila", d => d * 0.621371192 * 0.001 * 0.01, d => d * 1609.3472187 * 100);
            converter.AddConvertion("Centymetr", "MilaMorska", d => d * 0.539956803 * 0.001 * 0.01, d => d * 1852 * 100);
            converter.AddConvertion("Centymetr", "Kabel", d => d * 5.39956803 * 0.001 * 0.01, d => d * 219.456 * 100);

            converter.AddConvertion("Decymetr", "Cal", d => d * 39370.0787 * 0.001 * 0.1, d => d * 0.0254 * 10);
            converter.AddConvertion("Decymetr", "Stopa", d => d * 3280.8399 * 0.001 * 0.1, d => d * 0.3048 * 10);
            converter.AddConvertion("Decymetr", "Jard", d => d * 1093.6133 * 0.001 * 0.1, d => d * 0.9144 * 10);
            converter.AddConvertion("Decymetr", "Mila", d => d * 0.621371192 * 0.001 * 0.1, d => d * 1609.3472187 * 10);
            converter.AddConvertion("Decymetr", "MilaMorska", d => d * 0.539956803 * 0.001 * 0.1, d => d * 1852 * 10);
            converter.AddConvertion("Decymetr", "Kabel", d => d * 5.39956803 * 0.001 * 0.1, d => d * 219.456 * 10);

            converter.AddConvertion("Milimetr", "Cal", d => d * 39370.0787 * 0.001 * 0.001, d => d * 0.0254 * 1000);
            converter.AddConvertion("Milimetr", "Stopa", d => d * 3280.8399 * 0.001 * 0.001, d => d * 0.3048 * 1000);
            converter.AddConvertion("Milimetr", "Jard", d => d * 1093.6133 * 0.001 * 0.001, d => d * 0.9144 * 1000);
            converter.AddConvertion("Milimetr", "Mila", d => d * 0.621371192 * 0.001 * 0.001, d => d * 1609.3472187 * 1000);
            converter.AddConvertion("Milimetr", "MilaMorska", d => d * 0.539956803 * 0.001 * 0.001, d => d * 1852 * 1000);
            converter.AddConvertion("Milimetr", "Kabel", d => d * 5.39956803 * 0.001 * 0.001, d => d * 219.456 * 1000);
            //mieszane anglosaskie
            converter.AddConvertion("Cal", "MilaMorska", d => d * 0.0000137149, d => d / 0.0000137149);
            converter.AddConvertion("Cal", "Kabel", d => d * 0.000115740741, d => d / 0.000115740741);
            converter.AddConvertion("Stopa", "MilaMorska", d => d * 0.0001645788, d => d / 0.0001645788);
            converter.AddConvertion("Stopa", "Kabel", d => d * 0.00138888889, d => d / 0.00138888889);
            converter.AddConvertion("Jard", "MilaMorska", d => d * 0.0004937365, d => d / 0.0004937365);
            converter.AddConvertion("Jard", "Kabel", d => d * 0.00416666667, d => d / 0.00416666667);
            converter.AddConvertion("Mila", "MilaMorska", d => d * 0.8689762419, d => d / 0.8689762419);
            converter.AddConvertion("Mila", "Kabel", d => d * 7.33333333, d => d / 7.33333333);

            ///////////////////
            ///temperatury OK
            //////////////////
            converter.AddConvertion("Celcjusz", "Fahrenheit", d => (d * 1.8) + 32, d => (d - 32) / 1.8);
            converter.AddConvertion("Celcjusz", "Kelvin", d => d + 273.15, d => d - 273.15);
            converter.AddConvertion("Celcjusz", "Rankin", d => (d + 273.15) * 1.8, d => (d - 491.67) * 1.8);
            converter.AddConvertion("Fahrenheit", "Kelvin", d => (d + 459.67) * (5.0 / 9.0), d => (d * 1.8) - 459.67); //(T(°F) + 459.67) × 5/9 //T(K) × 9/5 - 459.67
            converter.AddConvertion("Fahrenheit", "Rankin", d => d + 459.67, d => d - 459.67);
            converter.AddConvertion("Rankin", "Kelvin", d => (d * (5.0 / 9.0)), d => d * 1.8);
            ///////////////////
            ///masy OK
            //////////////////
            converter.AddConvertion("mg", "g", d => d * 0.001, d => d / 0.001);
            converter.AddConvertion("mg", "dkg", d => d * 0.0001, d => d / 0.0001);
            converter.AddConvertion("mg", "kg", d => d * 0.000001, d => d / 0.000001);
            converter.AddConvertion("mg", "T", d => d / 1000000000, d => d * 1000000000);
            converter.AddConvertion("g", "dkg", d => d * 0.1, d => d / 0.1);
            converter.AddConvertion("g", "kg", d => d * 0.001, d => d / 0.001);
            converter.AddConvertion("g", "T", d => d * 0.000001, d => d / 0.000001);
            converter.AddConvertion("dkg", "kg", d => d * 0.01, d => d / 0.01);
            converter.AddConvertion("dkg", "T", d => d * 0.00001, d => d / 0.00001);
            converter.AddConvertion("kg", "T", d => d * 0.001, d => d / 0.001);
            converter.AddConvertion("uncja", "funt", d => d * 0.0625, d => d / 0.0625);
            converter.AddConvertion("karat", "kwintal", d => d * 0.000002, d => d / 0.000002);
            //mieszane
            converter.AddConvertion("uncja", "mg", d => d * 28349.523125, d => d / 28349.523125);
            converter.AddConvertion("uncja", "g", d => d * 28.349523125, d => d / 28.349523125);
            converter.AddConvertion("uncja", "dkg", d => d * 2.8349523125, d => d / 2.8349523125);
            converter.AddConvertion("uncja", "kg", d => d * 0.0283495231, d => d / 0.0283495231);
            converter.AddConvertion("uncja", "T", d => d * 0.0000283495, d => d / 0.0000283495);
            converter.AddConvertion("uncja", "karat", d => d * 141.74761563, d => d / 141.74761563);
            converter.AddConvertion("uncja", "kwintal", d => d * 0.0002834952, d => d / 0.0002834952);
            converter.AddConvertion("funt", "mg", d => d * 453592.37, d => d / 453592.37);
            converter.AddConvertion("funt", "g", d => d * 453.59237, d => d / 453.59237);
            converter.AddConvertion("funt", "dkg", d => d * 45.359237, d => d / 45.359237);
            converter.AddConvertion("funt", "kg", d => d * 0.45359237, d => d / 0.45359237);
            converter.AddConvertion("funt", "T", d => d * 0.0004535924, d => d / 0.0004535924);
            converter.AddConvertion("funt", "karat", d => d * 2267.96185, d => d / 2267.96185);
            converter.AddConvertion("funt", "kwintal", d => d * 0.0045359237, d => d / 0.0045359237);

            converter.AddConvertion("karat", "mg", d => d * 200, d => d / 200);
            converter.AddConvertion("karat", "g", d => d * 0.2, d => d / 0.2);
            converter.AddConvertion("karat", "dkg", d => d * 0.02, d => d / 0.02);
            converter.AddConvertion("karat", "kg", d => d * 0.0002, d => d / 0.0002);
            converter.AddConvertion("karat", "T", d => d * 0.00000022046, d => d / 0.00000022046);
            converter.AddConvertion("karat", "uncja", d => d / 5000000, d => d * 5000000);

            converter.AddConvertion("kwintal", "mg", d => d * 100000000, d => d / 100000000);
            converter.AddConvertion("kwintal", "g", d => d * 100000, d => d / 100000);
            converter.AddConvertion("kwintal", "dkg", d => d * 10000, d => d / 10000);
            converter.AddConvertion("kwintal", "kg", d => d * 100, d => d / 100);
            converter.AddConvertion("kwintal", "T", d => d * 0.1, d => d / 0.1);


            return converter;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (FromCombobox.SelectedItem == null || ToCombobox.SelectedItem == null || InputTextBox.Text == null)
            {
                throw new ArgumentException("Brakujące dane"); ;
            }
            using (ConverterContext context = new ConverterContext()) { 
                string result = _converter.Convert(FromCombobox.SelectedItem.ToString(), ToCombobox.SelectedItem.ToString(), int.Parse(InputTextBox.Text)).ToString();
                ResultTextblock.Text = result;

                StatisticDTO st = new StatisticDTO()
                {
                    DateTime = DateTime.Now,
                    UnitFrom = this.FromCombobox.SelectedItem.ToString(),
                    UnitTo = this.ToCombobox.SelectedItem.ToString(),
                    //Type = this.WhatCombobox.SelectedItem.ToString(),
                    RawValue = int.Parse(InputTextBox.Text),
                    ConvertedValue = float.Parse(result)
                };

                this.repository.AddStatistic(st);
                this.statisticsDataGrid.ItemsSource = repository.GetStatistics();
            }
        }
        private void ComboRefresh(string what)
        {
            switch (what)
            {
                case "temperatura":
                    this.ToCombobox.ItemsSource = new List<string>(new[] { "C", "K", "F", "R" });
                    this.FromCombobox.ItemsSource = new List<string>(new[] { "C", "K", "F", "R" });
                    break;
                case "dlugosc":
                    this.ToCombobox.ItemsSource = new List<string>(new[] { "mm", "cm", "dcm", "m", "km", "inch" });
                    this.FromCombobox.ItemsSource = new List<string>(new[] { "mm", "cm", "dcm", "m", "km", "inch" });
                    break;
                case "masa":
                    this.ToCombobox.ItemsSource = new List<string>(new[] { "g", "kg" });
                    this.FromCombobox.ItemsSource = new List<string>(new[] { "g", "kg" });
                    break;
                default:
                    this.ToCombobox.ItemsSource = new List<string>(new[] { "wybierz najpierw rodzaj" });
                    this.FromCombobox.ItemsSource = new List<string>(new[] { "wybierz najpierw rodzaj" });
                    break;

            }
        }
        private void FromCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                ToCombobox.Items.Clear();
                _converter.GetKeysTo(FromCombobox.SelectedItem.ToString()).ForEach(x => ToCombobox.Items.Add(x));

                // string what = this.WhatCombobox.SelectedItem.ToString();
                //  ComboRefresh(what);
                //this.ToCombobox.ItemsSource = new List<string>(new[] { "C", "K", "F", "D" });

            }
        }
    }
