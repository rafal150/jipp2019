using System.Windows;
using System.Windows.Controls;
using System.Net;
using Newtonsoft.Json;

namespace converter
{
    public partial class MainWindow : Window 
    {
        private static readonly string API_BASE_URL = "http://localhost:49358/api/converters";

        private ConverterObject[] converters;

        public double From { set; get; }
        public double To { set; get; }


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            LoadConverters();

            UnitsTypeComboBox.ItemsSource = this.converters;

            LoadTelemetry();
        }

        private void LoadConverters()
        {
            using (WebClient client = new WebClient())
            {
                var json = client.DownloadString(API_BASE_URL);
                converters = JsonConvert.DeserializeObject<ConverterObject[]>(json);
            }
        }

        private void LoadTelemetry()
        {
            using (WebClient client = new WebClient())
            {
                var json = client.DownloadString(API_BASE_URL + "/telemetry");
                TelemetryGrid.ItemsSource = JsonConvert.DeserializeObject<TelemetryDTO[]>(json);
            }
        }

        private void UnitsTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var unitList = ((ConverterObject)UnitsTypeComboBox.SelectedItem).Units;
            FromUnitComboBox.ItemsSource = unitList;
            ToUnitComboBox.ItemsSource = unitList;
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            using (WebClient client = new WebClient())
            {
                client.QueryString.Add("converterType", ((ConverterObject)UnitsTypeComboBox.SelectedItem).Name);
                client.QueryString.Add("unitFrom", FromUnitComboBox.SelectedItem.ToString());
                client.QueryString.Add("unitTo", ToUnitComboBox.SelectedItem.ToString());
                client.QueryString.Add("valueToConvert", From.ToString());
                Result.Text = client.DownloadString(API_BASE_URL + "/convert");
            }
            LoadTelemetry();
        }
    }
}

class ConverterObject
{
    public string Name { get; set; }
    public string[] Units { get; set; }
}