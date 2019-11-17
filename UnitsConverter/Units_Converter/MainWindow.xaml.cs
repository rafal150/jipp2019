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
using Units_Converter.Statistics;

namespace Units_Converter
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainComboBox.Items.Add("Temperatures");
            mainComboBox.Items.Add("Measures");
            mainComboBox.Items.Add("Weights");
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            List<Statistic> statistics;

            using (StatisticsModel context = new StatisticsModel())
            {
                statistics = context.Statistics.ToList();
            }

            this.statisticsDataGrid.ItemsSource = statistics;
            
        }

        private void mainComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(mainComboBox.SelectedItem.ToString())
            {
                case "Temperatures":
                    //pierwszy comboBoxFrom
                    comboBoxFrom.Items.Clear();
                    comboBoxFrom.Items.Add("Celsius");
                    comboBoxFrom.Items.Add("Fahrenheit");
                    comboBoxFrom.Items.Add("Kelvin");
                    comboBoxFrom.Items.Add("Rankine");
                    //drugi comboBoxTo
                    comboBoxTo.Items.Clear();
                    comboBoxTo.Items.Add("Celsius");
                    comboBoxTo.Items.Add("Fahrenheit");
                    comboBoxTo.Items.Add("Kelvin");
                    comboBoxTo.Items.Add("Rankine");
                    break;
                case "Measures":
                    //pierwszy comboBoxFrom
                    comboBoxFrom.Items.Clear();
                    comboBoxFrom.Items.Add("Kilometres");
                    comboBoxFrom.Items.Add("Metres");
                    comboBoxFrom.Items.Add("Decimetres");
                    comboBoxFrom.Items.Add("Centimetres");
                    comboBoxFrom.Items.Add("Milimetres");
                    comboBoxFrom.Items.Add("Miles");
                    comboBoxFrom.Items.Add("Yards");
                    comboBoxFrom.Items.Add("Feet");
                    comboBoxFrom.Items.Add("Inches");
                    comboBoxFrom.Items.Add("Nautical miles");
                    comboBoxFrom.Items.Add("Cables");
                    //drugi comboBoxTo
                    comboBoxTo.Items.Clear();
                    comboBoxTo.Items.Add("Kilometres");
                    comboBoxTo.Items.Add("Metres");
                    comboBoxTo.Items.Add("Decimetres");
                    comboBoxTo.Items.Add("Centimetres");
                    comboBoxTo.Items.Add("Milimetres");
                    comboBoxTo.Items.Add("Miles");
                    comboBoxTo.Items.Add("Yards");
                    comboBoxTo.Items.Add("Feet");
                    comboBoxTo.Items.Add("Inches");
                    comboBoxTo.Items.Add("Nautical miles");
                    comboBoxTo.Items.Add("Cables");
                    break;
                case "Weights":
                    //pierwszy comboBoxFrom
                    comboBoxFrom.Items.Clear();
                    comboBoxFrom.Items.Add("Tonnes");
                    comboBoxFrom.Items.Add("Kilograms");
                    comboBoxFrom.Items.Add("Decagrams");
                    comboBoxFrom.Items.Add("Grams");
                    comboBoxFrom.Items.Add("Milligrams");
                    comboBoxFrom.Items.Add("Pounds");
                    comboBoxFrom.Items.Add("Ounces");
                    //drugi comboBoxTo
                    comboBoxTo.Items.Clear();
                    comboBoxTo.Items.Add("Tonnes");
                    comboBoxTo.Items.Add("Kilograms");
                    comboBoxTo.Items.Add("Decagrams");
                    comboBoxTo.Items.Add("Grams");
                    comboBoxTo.Items.Add("Milligrams");
                    comboBoxTo.Items.Add("Pounds");
                    comboBoxTo.Items.Add("Ounces");
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Temperatures
            if (comboBoxFrom.Text == "Celsius")
            {
                double unitFrom = double.Parse(TextBoxFrom.Text);
                if (comboBoxTo.Text == "Celsius") textBlockConverted.Text = (unitFrom).ToString();
                else if (comboBoxTo.Text == "Fahrenheit") textBlockConverted.Text = ((9 * unitFrom / 5 + 32)).ToString();
                else if (comboBoxTo.Text == "Kelvin") textBlockConverted.Text = (unitFrom - 273.15).ToString();
                else if (comboBoxTo.Text == "Rankine") textBlockConverted.Text = (9 * (unitFrom + 273.15) / 5).ToString();
            }
            else if (comboBoxFrom.Text == "Fahrenheit")
            {
                double unitFrom = double.Parse(TextBoxFrom.Text);
                if (comboBoxTo.Text == "Celsjusz") textBlockConverted.Text = (5 * (unitFrom - 32) / 9).ToString();
                else if (comboBoxTo.Text == "Kelvin") textBlockConverted.Text = (5 * (unitFrom + 459.67) / 9).ToString();
                else if (comboBoxTo.Text == "Rankine") textBlockConverted.Text = (unitFrom + 459.67).ToString();
            }
            else if (comboBoxFrom.Text == "Kelvin")
            {
                double unitFrom = double.Parse(TextBoxFrom.Text);
                if (comboBoxTo.Text == "Celsjusz") textBlockConverted.Text = (unitFrom - 273.15).ToString();
                else if (comboBoxTo.Text == "Fahrenheit") textBlockConverted.Text = (9 * unitFrom / 5 - 459.67).ToString();
                else if (comboBoxTo.Text == "Rankine") textBlockConverted.Text = (unitFrom * 9 / 5).ToString();
            }
            else if (comboBoxFrom.Text == "Rankine")
            {
                double unitFrom = double.Parse(TextBoxFrom.Text);
                if (comboBoxTo.Text == "Celsjusz") textBlockConverted.Text = ((unitFrom - 491.67) * 5 / 9).ToString();
                else if (comboBoxTo.Text == "Fahrenheit") textBlockConverted.Text = (unitFrom - 459.67).ToString();
                else if (comboBoxTo.Text == "Kelvin") textBlockConverted.Text = (unitFrom * 5 / 9).ToString();
            }
            // Measures
            if (comboBoxFrom.Text == "Milimetres")
            {
                double unitFrom = double.Parse(TextBoxFrom.Text);
                if (comboBoxTo.Text == "Centimetres") textBlockConverted.Text = (unitFrom * 0.1).ToString();
                else if (comboBoxTo.Text == "Decimetres") textBlockConverted.Text = (unitFrom * 0.01).ToString();
                else if (comboBoxTo.Text == "Metres") textBlockConverted.Text = (unitFrom * 0.001).ToString();
                else if (comboBoxTo.Text == "Kilometres") textBlockConverted.Text = (unitFrom * 0.0001).ToString();
                else if (comboBoxTo.Text == "Miles") textBlockConverted.Text = (unitFrom / 1609344).ToString();
                else if (comboBoxTo.Text == "Yards") textBlockConverted.Text = (unitFrom * 0.00109361).ToString();
                else if (comboBoxTo.Text == "Feet") textBlockConverted.Text = (unitFrom * 0.00328084).ToString();
                else if (comboBoxTo.Text == "Inches") textBlockConverted.Text = (unitFrom * 0.03937).ToString();
                else if (comboBoxTo.Text == "Nautical miles") textBlockConverted.Text = (unitFrom / 1852000).ToString();
                else if (comboBoxTo.Text == "Cables") textBlockConverted.Text = (unitFrom * 0.000004556722).ToString();
                else if (comboBoxTo.Text == "Milimetres") textBlockConverted.Text = (unitFrom).ToString();
            }
            else if (comboBoxFrom.Text == "Centimetres")
            {
                double unitFrom = double.Parse(TextBoxFrom.Text);
                if (comboBoxTo.Text == "Milimetres") textBlockConverted.Text = (unitFrom * 10).ToString();
                else if (comboBoxTo.Text == "Decimetres") textBlockConverted.Text = (unitFrom * 0.1).ToString();
                else if (comboBoxTo.Text == "Metres") textBlockConverted.Text = (unitFrom * 0.01).ToString();
                else if (comboBoxTo.Text == "Kilometres") textBlockConverted.Text = (unitFrom * 0.001).ToString();
                else if (comboBoxTo.Text == "Miles") textBlockConverted.Text = (unitFrom * 0.0000062137).ToString();
                else if (comboBoxTo.Text == "Yards") textBlockConverted.Text = (unitFrom * 0.0109361).ToString();
                else if (comboBoxTo.Text == "Feet") textBlockConverted.Text = (unitFrom * 0.0328084).ToString();
                else if (comboBoxTo.Text == "Inches") textBlockConverted.Text = (unitFrom * 0.3937).ToString();
                else if (comboBoxTo.Text == "Nautical miles") textBlockConverted.Text = (unitFrom * 0.0000053996).ToString();
                else if (comboBoxTo.Text == "Cables") textBlockConverted.Text = (unitFrom * 0.00004556722).ToString();
                else if (comboBoxTo.Text == "Centimetres") textBlockConverted.Text = (unitFrom).ToString();
            }
            else if (comboBoxFrom.Text == "Decimetres")
            {
                double unitFrom = double.Parse(TextBoxFrom.Text);
                if (comboBoxTo.Text == "Milimetres") textBlockConverted.Text = (unitFrom * 100).ToString();
                else if (comboBoxTo.Text == "Centimetres") textBlockConverted.Text = (unitFrom * 10).ToString();
                else if (comboBoxTo.Text == "Metres") textBlockConverted.Text = (unitFrom * 0.1).ToString();
                else if (comboBoxTo.Text == "Kilometres") textBlockConverted.Text = (unitFrom * 0.01).ToString();
                else if (comboBoxTo.Text == "Miles") textBlockConverted.Text = (unitFrom * 0.000062137).ToString();
                else if (comboBoxTo.Text == "Yards") textBlockConverted.Text = (unitFrom * 0.109361).ToString();
                else if (comboBoxTo.Text == "Feet") textBlockConverted.Text = (unitFrom * 0.328084).ToString();
                else if (comboBoxTo.Text == "Inches") textBlockConverted.Text = (unitFrom * 3.937).ToString();
                else if (comboBoxTo.Text == "Nautical miles") textBlockConverted.Text = (unitFrom * 0.000053996).ToString();
                else if (comboBoxTo.Text == "Cables") textBlockConverted.Text = (unitFrom * 0.0004556722).ToString();
                else if (comboBoxTo.Text == "Decimetres") textBlockConverted.Text = (unitFrom).ToString();
            }
            else if (comboBoxFrom.Text == "Metres")
            {
                double unitFrom = double.Parse(TextBoxFrom.Text);
                if (comboBoxTo.Text == "Milimetres") textBlockConverted.Text = (unitFrom * 1000).ToString();
                else if (comboBoxTo.Text == "Centimetres") textBlockConverted.Text = (unitFrom * 100).ToString();
                else if (comboBoxTo.Text == "Decimetres") textBlockConverted.Text = (unitFrom * 10).ToString();
                else if (comboBoxTo.Text == "Kilometres") textBlockConverted.Text = (unitFrom * 0.001).ToString();
                else if (comboBoxTo.Text == "Miles") textBlockConverted.Text = (unitFrom * 0.00062137).ToString();
                else if (comboBoxTo.Text == "Yards") textBlockConverted.Text = (unitFrom * 1.09361).ToString();
                else if (comboBoxTo.Text == "Feet") textBlockConverted.Text = (unitFrom * 3.28084).ToString();
                else if (comboBoxTo.Text == "Inches") textBlockConverted.Text = (unitFrom * 39.37).ToString();
                else if (comboBoxTo.Text == "Nautical miles") textBlockConverted.Text = (unitFrom * 0.00053996).ToString();
                else if (comboBoxTo.Text == "Cables") textBlockConverted.Text = (unitFrom * 0.004556722).ToString();
                else if (comboBoxTo.Text == "Metres") textBlockConverted.Text = (unitFrom).ToString();
            }
            else if (comboBoxFrom.Text == "Kilometres")
            {
                double unitFrom = double.Parse(TextBoxFrom.Text);
                if (comboBoxTo.Text == "Milimetres") textBlockConverted.Text = (unitFrom * 1000000).ToString();
                else if (comboBoxTo.Text == "Centimetres") textBlockConverted.Text = (unitFrom * 100000).ToString();
                else if (comboBoxTo.Text == "Decimetres") textBlockConverted.Text = (unitFrom * 10000).ToString();
                else if (comboBoxTo.Text == "Metres") textBlockConverted.Text = (unitFrom * 1000).ToString();
                else if (comboBoxTo.Text == "Miles") textBlockConverted.Text = (unitFrom * 0.621371).ToString();
                else if (comboBoxTo.Text == "Yards") textBlockConverted.Text = (unitFrom * 1093.61).ToString();
                else if (comboBoxTo.Text == "Feet") textBlockConverted.Text = (unitFrom * 3280.84).ToString();
                else if (comboBoxTo.Text == "Inches") textBlockConverted.Text = (unitFrom * 39370).ToString();
                else if (comboBoxTo.Text == "Nautical miles") textBlockConverted.Text = (unitFrom * 0.53996).ToString();
                else if (comboBoxTo.Text == "Cables") textBlockConverted.Text = (unitFrom * 4.556722).ToString();
                else if (comboBoxTo.Text == "Kilometres") textBlockConverted.Text = (unitFrom).ToString();
            }
            else if (comboBoxFrom.Text == "Miles")
            {
                double unitFrom = double.Parse(TextBoxFrom.Text);
                if (comboBoxTo.Text == "Milimetres") textBlockConverted.Text = (unitFrom * 1609344).ToString();
                else if (comboBoxTo.Text == "Centimetres") textBlockConverted.Text = (unitFrom * 160934).ToString();
                else if (comboBoxTo.Text == "Decimetres") textBlockConverted.Text = (unitFrom * 16093.4).ToString();
                else if (comboBoxTo.Text == "Metres") textBlockConverted.Text = (unitFrom * 1609.34).ToString();
                else if (comboBoxTo.Text == "Kilometres") textBlockConverted.Text = (unitFrom * 1.60934).ToString();
                else if (comboBoxTo.Text == "Yards") textBlockConverted.Text = (unitFrom * 1760).ToString();
                else if (comboBoxTo.Text == "Feet") textBlockConverted.Text = (unitFrom * 5280).ToString();
                else if (comboBoxTo.Text == "Inches") textBlockConverted.Text = (unitFrom * 63360).ToString();
                else if (comboBoxTo.Text == "Nautical miles") textBlockConverted.Text = (unitFrom * 0.868976).ToString();
                else if (comboBoxTo.Text == "Cables") textBlockConverted.Text = (unitFrom * 8.68).ToString();
                else if (comboBoxTo.Text == "Miles") textBlockConverted.Text = (unitFrom).ToString();
            }
            else if (comboBoxFrom.Text == "Yards")
            {
                double unitFrom = double.Parse(TextBoxFrom.Text);
                if (comboBoxTo.Text == "Milimetres") textBlockConverted.Text = (unitFrom * 914.4).ToString();
                else if (comboBoxTo.Text == "Centimetres") textBlockConverted.Text = (unitFrom * 91.44).ToString();
                else if (comboBoxTo.Text == "Decimetres") textBlockConverted.Text = (unitFrom * 9.144).ToString();
                else if (comboBoxTo.Text == "Metres") textBlockConverted.Text = (unitFrom * 0.9144).ToString();
                else if (comboBoxTo.Text == "Kilometres") textBlockConverted.Text = (unitFrom * 0.0009144).ToString();
                else if (comboBoxTo.Text == "Miles") textBlockConverted.Text = (unitFrom / 1760).ToString();
                else if (comboBoxTo.Text == "Feet") textBlockConverted.Text = (unitFrom * 3).ToString();
                else if (comboBoxTo.Text == "Inches") textBlockConverted.Text = (unitFrom * 36).ToString();
                else if (comboBoxTo.Text == "Nautical miles") textBlockConverted.Text = (unitFrom * 0.000493737).ToString();
                else if (comboBoxTo.Text == "Cables") textBlockConverted.Text = (unitFrom * 0.0049342).ToString();
                else if (comboBoxTo.Text == "Yards") textBlockConverted.Text = (unitFrom).ToString();
            }
            else if (comboBoxFrom.Text == "Feet")
            {
                double unitFrom = double.Parse(TextBoxFrom.Text);
                if (comboBoxTo.Text == "Milimetres") textBlockConverted.Text = (unitFrom * 304.8).ToString();
                else if (comboBoxTo.Text == "Centimetres") textBlockConverted.Text = (unitFrom * 30.48).ToString();
                else if (comboBoxTo.Text == "Decimetres") textBlockConverted.Text = (unitFrom * 3.048).ToString();
                else if (comboBoxTo.Text == "Metres") textBlockConverted.Text = (unitFrom * 0.3048).ToString();
                else if (comboBoxTo.Text == "Kilometres") textBlockConverted.Text = (unitFrom * 0.0003048).ToString();
                else if (comboBoxTo.Text == "Miles") textBlockConverted.Text = (unitFrom / 5280).ToString();
                else if (comboBoxTo.Text == "Yards") textBlockConverted.Text = (unitFrom / 3).ToString();
                else if (comboBoxTo.Text == "Inches") textBlockConverted.Text = (unitFrom * 12).ToString();
                else if (comboBoxTo.Text == "Nautical miles") textBlockConverted.Text = (unitFrom * 0.000164579).ToString();
                else if (comboBoxTo.Text == "Cables") textBlockConverted.Text = (unitFrom * 0.00138889).ToString();
                else if (comboBoxTo.Text == "Feet") textBlockConverted.Text = (unitFrom).ToString();
            }
            else if (comboBoxFrom.Text == "Inches")
            {
                double unitFrom = double.Parse(TextBoxFrom.Text);
                if (comboBoxTo.Text == "Milimetres") textBlockConverted.Text = (unitFrom * 25.4).ToString();
                else if (comboBoxTo.Text == "Centimetres") textBlockConverted.Text = (unitFrom * 2.54).ToString();
                else if (comboBoxTo.Text == "Decimetres") textBlockConverted.Text = (unitFrom * 0.254).ToString();
                else if (comboBoxTo.Text == "Metres") textBlockConverted.Text = (unitFrom * 0.0254).ToString();
                else if (comboBoxTo.Text == "Kilometres") textBlockConverted.Text = (unitFrom * 0.0000254).ToString();
                else if (comboBoxTo.Text == "Miles") textBlockConverted.Text = (unitFrom / 63360).ToString();
                else if (comboBoxTo.Text == "Yards") textBlockConverted.Text = (unitFrom / 36).ToString();
                else if (comboBoxTo.Text == "Feet") textBlockConverted.Text = (unitFrom / 12).ToString();
                else if (comboBoxTo.Text == "Nautical miles") textBlockConverted.Text = ((unitFrom * 127) / 9260000).ToString();
                else if (comboBoxTo.Text == "Cables") textBlockConverted.Text = (unitFrom / 7200).ToString();
                else if (comboBoxTo.Text == "Inches") textBlockConverted.Text = (unitFrom).ToString();
            }
            else if (comboBoxFrom.Text == "Nautical miles")
            {
                double unitFrom = double.Parse(TextBoxFrom.Text);
                if (comboBoxTo.Text == "Milimetres") textBlockConverted.Text = (unitFrom * 1852000).ToString();
                else if (comboBoxTo.Text == "Centimetres") textBlockConverted.Text = (unitFrom * 185200).ToString();
                else if (comboBoxTo.Text == "Decimetres") textBlockConverted.Text = (unitFrom * 18520).ToString();
                else if (comboBoxTo.Text == "Metres") textBlockConverted.Text = (unitFrom * 1852).ToString();
                else if (comboBoxTo.Text == "Kilometres") textBlockConverted.Text = (unitFrom * 1.852).ToString();
                else if (comboBoxTo.Text == "Miles") textBlockConverted.Text = (unitFrom * 1.15078).ToString();
                else if (comboBoxTo.Text == "Yards") textBlockConverted.Text = (unitFrom * 2025.37).ToString();
                else if (comboBoxTo.Text == "Feet") textBlockConverted.Text = (unitFrom * 6076.12).ToString();
                else if (comboBoxTo.Text == "Inches") textBlockConverted.Text = (unitFrom * 72913.4).ToString();
                else if (comboBoxTo.Text == "Cables") textBlockConverted.Text = (unitFrom * 10).ToString();
                else if (comboBoxTo.Text == "Nautical miles") textBlockConverted.Text = (unitFrom).ToString();
            }
            else if (comboBoxFrom.Text == "Cables")
            {
                double unitFrom = double.Parse(TextBoxFrom.Text);
                if (comboBoxTo.Text == "Milimetres") textBlockConverted.Text = (unitFrom * 182880).ToString();
                else if (comboBoxTo.Text == "Centimetres") textBlockConverted.Text = (unitFrom * 18288).ToString();
                else if (comboBoxTo.Text == "Decimetres") textBlockConverted.Text = (unitFrom * 1828.8).ToString();
                else if (comboBoxTo.Text == "Metres") textBlockConverted.Text = (unitFrom * 182.88).ToString();
                else if (comboBoxTo.Text == "Kilometres") textBlockConverted.Text = (unitFrom * 0.18288).ToString();
                else if (comboBoxTo.Text == "Miles") textBlockConverted.Text = (unitFrom / 8.68).ToString();
                else if (comboBoxTo.Text == "Yards") textBlockConverted.Text = (unitFrom * 202.67).ToString();
                else if (comboBoxTo.Text == "Feet") textBlockConverted.Text = (unitFrom * 608).ToString();
                else if (comboBoxTo.Text == "Inches") textBlockConverted.Text = (unitFrom * 7291.34).ToString();
                else if (comboBoxTo.Text == "Nautical miles") textBlockConverted.Text = (unitFrom / 10).ToString();
                else if (comboBoxTo.Text == "Cables") textBlockConverted.Text = (unitFrom).ToString();
            }
            // Weights
            else if (comboBoxFrom.Text == "Milligrams")
            {
                double unitFrom = double.Parse(TextBoxFrom.Text);
                if (comboBoxTo.Text == "Grams") textBlockConverted.Text = (unitFrom * 0.001).ToString();
                else if (comboBoxTo.Text == "Decagrams") textBlockConverted.Text = (unitFrom * 0.0001).ToString();
                else if (comboBoxTo.Text == "Kilograms") textBlockConverted.Text = (unitFrom * 0.000001).ToString();
                else if (comboBoxTo.Text == "Tonnes") textBlockConverted.Text = (unitFrom * 0.000000001).ToString();
                else if (comboBoxTo.Text == "Pounds") textBlockConverted.Text = (unitFrom / 453592).ToString();
                else if (comboBoxTo.Text == "Ounces") textBlockConverted.Text = (unitFrom / 28349.5).ToString();

            }
            else if (comboBoxFrom.Text == "Grams")
            {
                double unitFrom = double.Parse(TextBoxFrom.Text);
                if (comboBoxTo.Text == "Milligrams") textBlockConverted.Text = (unitFrom * 1000).ToString();
                else if (comboBoxTo.Text == "Decagrams") textBlockConverted.Text = (unitFrom * 0.1).ToString();
                else if (comboBoxTo.Text == "Kilograms") textBlockConverted.Text = (unitFrom * 0.001).ToString();
                else if (comboBoxTo.Text == "Tonnes") textBlockConverted.Text = (unitFrom * 0.000001).ToString();
                else if (comboBoxTo.Text == "Pounds") textBlockConverted.Text = (unitFrom / 453.592).ToString();
                else if (comboBoxTo.Text == "Ounces") textBlockConverted.Text = (unitFrom / 28.3495).ToString();
            }
            else if (comboBoxFrom.Text == "Decagrams")
            {
                double unitFrom = double.Parse(TextBoxFrom.Text);
                if (comboBoxTo.Text == "Milligrams") textBlockConverted.Text = (unitFrom * 10000).ToString();
                else if (comboBoxTo.Text == "Grams") textBlockConverted.Text = (unitFrom * 10).ToString();
                else if (comboBoxTo.Text == "Kilograms") textBlockConverted.Text = (unitFrom * 0.01).ToString();
                else if (comboBoxTo.Text == "Tonnes") textBlockConverted.Text = (unitFrom * 0.00001).ToString();
                else if (comboBoxTo.Text == "Pounds") textBlockConverted.Text = (unitFrom / 45.3592).ToString();
                else if (comboBoxTo.Text == "Ounces") textBlockConverted.Text = (unitFrom / 2.83495).ToString();
            }
            else if (comboBoxFrom.Text == "Kilograms")
            {
                double unitFrom = double.Parse(TextBoxFrom.Text);
                if (comboBoxTo.Text == "Milligrams") textBlockConverted.Text = (unitFrom * 1000).ToString();
                else if (comboBoxTo.Text == "Grams") textBlockConverted.Text = (unitFrom * 1000).ToString();
                else if (comboBoxTo.Text == "Decagrams") textBlockConverted.Text = (unitFrom * 100).ToString();
                else if (comboBoxTo.Text == "Tonnes") textBlockConverted.Text = (unitFrom * 0.001).ToString();
                else if (comboBoxTo.Text == "Pounds") textBlockConverted.Text = (unitFrom * 2.20462).ToString();
                else if (comboBoxTo.Text == "Ounces") textBlockConverted.Text = (unitFrom * 35.274).ToString();
            }
            else if (comboBoxFrom.Text == "Tonnes")
            {
                double unitFrom = double.Parse(TextBoxFrom.Text);
                if (comboBoxTo.Text == "Milligrams") textBlockConverted.Text = (unitFrom * 1000000000).ToString();
                else if (comboBoxTo.Text == "Grams") textBlockConverted.Text = (unitFrom * 1000000).ToString();
                else if (comboBoxTo.Text == "Decagrams") textBlockConverted.Text = (unitFrom * 100000).ToString();
                else if (comboBoxTo.Text == "Kilograms") textBlockConverted.Text = (unitFrom * 1000).ToString();
                else if (comboBoxTo.Text == "Pounds") textBlockConverted.Text = (unitFrom * 2204.62).ToString();
                else if (comboBoxTo.Text == "Ounces") textBlockConverted.Text = (unitFrom * 35274).ToString();
            }
            else if (comboBoxFrom.Text == "Pounds")
            {
                double unitFrom = double.Parse(TextBoxFrom.Text);
                if (comboBoxTo.Text == "Milligrams") textBlockConverted.Text = (unitFrom * 453592).ToString();
                else if (comboBoxTo.Text == "Grams") textBlockConverted.Text = (unitFrom * 453.592).ToString();
                else if (comboBoxTo.Text == "Decagrams") textBlockConverted.Text = (unitFrom * 45.3592).ToString();
                else if (comboBoxTo.Text == "Kilograms") textBlockConverted.Text = (unitFrom * 0.453592).ToString();
                else if (comboBoxTo.Text == "Tonnes") textBlockConverted.Text = (unitFrom / 2204.62).ToString();
                else if (comboBoxTo.Text == "Ounces") textBlockConverted.Text = (unitFrom * 16).ToString();
            }
            else if (comboBoxFrom.Text == "Ounces")
            {
                double unitFrom = double.Parse(TextBoxFrom.Text);
                if (comboBoxTo.Text == "Milligrams") textBlockConverted.Text = (unitFrom * 28349.5).ToString();
                else if (comboBoxTo.Text == "Grams") textBlockConverted.Text = (unitFrom * 28.3495).ToString();
                else if (comboBoxTo.Text == "Decagrams") textBlockConverted.Text = (unitFrom * 2.83495).ToString();
                else if (comboBoxTo.Text == "Kilograms") textBlockConverted.Text = (unitFrom * 0.0283495).ToString();
                else if (comboBoxTo.Text == "Tonnes") textBlockConverted.Text = (unitFrom / 0.0000283495).ToString();
                else if (comboBoxTo.Text == "Pounds") textBlockConverted.Text = (unitFrom / 16).ToString();
            }
            using (StatisticsModel context = new StatisticsModel())
            {
                Statistic st = new Statistic()
                {
                    DateTime = DateTime.Now,
                    Type = "Units",
                    FromUnit = this.comboBoxFrom.SelectedItem.ToString(),
                    FromTo = this.comboBoxTo.SelectedItem.ToString(),
                    RawValue = Convert.ToDecimal(TextBoxFrom.Text),
                    ConvertedValue = Convert.ToDecimal(textBlockConverted.Text)
                };
                context.Statistics.Add(st);
                context.SaveChanges();
                LoadStatistics();
            }
        }
    }
}
