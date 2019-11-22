using ConverterSDK;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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

namespace Rafal_Ciupak_converter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Converter _converter = PrepareConverter();
        private IRepository<StatisticsEntryDto> _repository;

        private static Converter PrepareConverter()
        {
            var converter = new Converter();

            converter.AddConvertion("Metr", "Kilometr", d => d / 1000);
            converter.AddConvertion("Metr", "Decymetr", d => d * 10);
            converter.AddConvertion("Metr", "Centymetr", d => d * 100);
            converter.AddConvertion("Metr", "Milimetr", d => d * 1000);

            converter.AddConvertion("Kilometr", "Metr", d => d * 1000);
            converter.AddConvertion("Kilometr", "Decymetr", d => d * 10000);
            converter.AddConvertion("Kilometr", "Centymetr", d => d * 100000);
            converter.AddConvertion("Kilometr", "Milimetr", d => d * 1000000);

            converter.AddConvertion("Decymetr", "Metr", d => d / 10);
            converter.AddConvertion("Decymetr", "Kilometr", d => d / 1000);
            converter.AddConvertion("Decymetr", "Centymetr", d => d * 10);
            converter.AddConvertion("Decymetr", "Milimetr", d => d * 100);

            converter.AddConvertion("Centymetr", "Metr", d => d / 100);
            converter.AddConvertion("Centymetr", "Kilometr", d => d / 10000);
            converter.AddConvertion("Centymetr", "Decymetr", d => d / 10);
            converter.AddConvertion("Centymetr", "Milimetr", d => d * 100);

            converter.AddConvertion("Milimetr", "Metr", d => d / 1000);
            converter.AddConvertion("Milimetr", "Kilometr", d => d / 100000);
            converter.AddConvertion("Milimetr", "Decymetr", d => d / 100);
            converter.AddConvertion("Milimetr", "Centymetr", d => d / 10);

            converter.AddConvertion("Cal", "Stopa", d => d * 0.0833);
            converter.AddConvertion("Cal", "Jard", d => d * 0.02778);
            converter.AddConvertion("Cal", "Mila", d => d * 0.00002);

            converter.AddConvertion("Stopa", "Cal", d => d * 12);
            converter.AddConvertion("Stopa", "Jard", d => d * 0.0333);
            converter.AddConvertion("Stopa", "Mila", d => d * 0.00019);

            converter.AddConvertion("Jard", "Cal", d => d * 36);
            converter.AddConvertion("Jard", "Stopa", d => d * 3);
            converter.AddConvertion("Jard", "Mila", d => d * 0.00057);

            converter.AddConvertion("Mila", "Cal", d => d * 63360);
            converter.AddConvertion("Mila", "Stopa", d => d * 5280);
            converter.AddConvertion("Mila", "Jard", d => d * 1760);

            converter.AddConvertion("Kabel", "Mila morska", d => d * 0.1);
            converter.AddConvertion("Mila morska", "Kabel", d => d * 10);

            converter.AddConvertion("Celsjusz", "Kelvin", d => d + 273.15);
            converter.AddConvertion("Celsjusz", "Fahrenheit", d => d * 1.8 + 32);
            converter.AddConvertion("Celsjusz", "Rankine", d => d + 273.15 * 1.8);

            converter.AddConvertion("Fahrenheit", "Kelvin", d => d + 459.67 * 5/9);
            converter.AddConvertion("Fahrenheit", "Celsjusz", d => 5/9*(d-32));
            converter.AddConvertion("Fahrenheit", "Rankine", d => d + 460.67);

            converter.AddConvertion("Kelvin", "Fahrenheit", d => d - 457.87);
            converter.AddConvertion("Kelvin", "Celsjusz", d => d - 273.15);
            converter.AddConvertion("Kelvin", "Rankine", d => d * 1.8);

            converter.AddConvertion("Rankine", "Fahrenheit", d => d - 458.67);
            converter.AddConvertion("Rankine", "Celsjusz", d => d - 272.59);
            converter.AddConvertion("Rankine", "Kelvin", d => d / 0.55);

            converter.AddConvertion("tona", "kilogram", d => d * 1000);
            converter.AddConvertion("tona", "dekagram", d => d * 100000);
            converter.AddConvertion("tona", "gram", d => d * 1000000);
            converter.AddConvertion("tona", "miligram", d => d * 1000000000);

            converter.AddConvertion("kilogram", "tona", d => d * 0.001);
            converter.AddConvertion("kilogram", "dekagram", d => d * 100);
            converter.AddConvertion("kilogram", "gram", d => d * 1000);
            converter.AddConvertion("kilogram", "miligram", d => d * 1000000);

            converter.AddConvertion("dekagram", "tona", d => d * 0.00001);
            converter.AddConvertion("dekagram", "kilogram", d => d * 0.01);
            converter.AddConvertion("dekagram", "gram", d => d * 10);
            converter.AddConvertion("dekagram", "miligram", d => d * 10000);

            converter.AddConvertion("gram", "tona", d => d * 0.000001);
            converter.AddConvertion("gram", "kilogram", d => d * 0.001);
            converter.AddConvertion("gram", "dekagram", d => d * 0.1);
            converter.AddConvertion("gram", "miligram", d => d * 1000);

            converter.AddConvertion("miligram", "tona", d => d * 0.00000000001);
            converter.AddConvertion("miligram", "kilogram", d => d * 0.000001);
            converter.AddConvertion("miligram", "dekagram", d => d * 0.0001);
            converter.AddConvertion("miligram", "gram", d => d * 0.001);

            converter.AddConvertion("uncja", "funt", d => d * 0.0625);
            converter.AddConvertion("funt", "uncja", d => d * 13.1657);

            converter.AddConvertion("karat", "kwintal", d => d * 0.000002);
            converter.AddConvertion("kwintal", "karat", d => d * 500000);

            List<IConverterPlug> plugins = ReadPlugins();
            plugins.ForEach(x => converter.AddConvertion(x.GetFrom(), x.GetTo(), x.GetConversionFunc()));

            return converter;
        }

        private static List<IConverterPlug> ReadPlugins()
        {
            string assemblyDirectory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pluginDirectory = System.IO.Path.Combine(assemblyDirectory, "plugins");

            var assemblies = Directory.GetFiles(pluginDirectory, "*Plugin.dll").Select(Assembly.LoadFrom).ToList();
            var plugs = assemblies.SelectMany(x => x.GetTypes())
                .Where(x => typeof(IConverterPlug).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => (IConverterPlug)Activator.CreateInstance(x))
                .ToList();
            return plugs;
        }

        public MainWindow()
        {
            InitializeComponent();
            dataGridView1.Visibility = Visibility.Hidden;

            _converter.GetKeysFrom().ForEach(x => FromComboBox.Items.Add(x));

            //var km = _converter.Convert("Metr", "Kilometr", 123);
            //Console.Out.WriteLine(km);

            if (ConfigurationManager.AppSettings["StatisticsRepository"] == "azure")
            {
                _repository = new AzureStatisticsRepository();
            }
            else
            {
                _repository = new SqlStatisticsRepository();
            }

            Console.In.Read();
        }

        private void From_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ToComboBox.Items.Clear();
            _converter.GetKeysTo(FromComboBox.SelectedItem.ToString()).ForEach(x => ToComboBox.Items.Add(x));
        }

        private void ToComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RunButton_Click(object sender, RoutedEventArgs e)
        {

            var sourceValue = FromTextBox.Text;
            double result;
            double.TryParse(sourceValue, out result);

            var value = _converter.Convert(FromComboBox.Text, ToComboBox.Text, result);
            ValueTextBox.Text = value.ToString();
            _repository.Save(new StatisticsEntryDto(DateTime.Now, FromComboBox.Text, ToComboBox.Text, sourceValue, result));
        }

        private void HistoryButton_Click(object sender, RoutedEventArgs e)
        {
            dataGridView1.Visibility = Visibility.Visible;
            dataGridView1.ItemsSource = _repository.GetAll();
        }
    }
}
