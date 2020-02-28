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
using ConverterLogic;

namespace Rafal_Ciupak_converter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Converter _converter;
        private IRepository<StatisticsEntryDto> _repository;

        private Converter PrepareConverter()
        {
            var converter = new Converter(_repository);

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
            if (ConfigurationManager.AppSettings["StatisticsRepository"] == "azure")
            {
                _repository = new AzureStatisticsRepository();
            }
            else
            {
                _repository = new SqlStatisticsRepository();
            }
            _converter = PrepareConverter();


            dataGridView1.Visibility = Visibility.Hidden;

            _converter.GetKeysFrom().ForEach(x => FromComboBox.Items.Add(x));

            //var km = _converter.Convert("Metr", "Kilometr", 123);
            //Console.Out.WriteLine(km);

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
        }

        private void HistoryButton_Click(object sender, RoutedEventArgs e)
        {
            dataGridView1.Visibility = Visibility.Visible;
            dataGridView1.ItemsSource = _repository.GetAll();
        }
    }
}
