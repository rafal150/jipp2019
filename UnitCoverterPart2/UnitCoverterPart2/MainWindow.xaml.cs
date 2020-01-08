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
using Newtonsoft.Json;
using RestSharp;
using Converters;

namespace UnitCoverterPart2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IStatisticsRepository repository;

        Logic logic;
        RestClient client = new RestClient("http://localhost:5000");

        public MainWindow(IStatisticsRepository repo)
        {
            InitializeComponent();

            //przez dll
            logic = Logic.GetInstance();
            this.TypeComboBox.ItemsSource = logic.getConverterTypes().types;

            //przez API
            client = new RestClient("http://localhost:5000");
            var request = new RestRequest("converters/ConverterTypes", Method.GET);
            request.RequestFormat = RestSharp.DataFormat.Json;
            var response = client.Execute(request);
            if (response.IsSuccessful)
                this.TypeComboBoxAPI.ItemsSource = (JsonConvert.DeserializeObject<Logic.ConverterTypes>(response.Content)).types;

            this.repository = repo;
            this.statisticsDataGrid.ItemsSource = repository.GetStatistics();
        }

        //obsługa przez dll
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double inputValue, resultValue;

            if (!double.TryParse(InputTextBox.Text, out inputValue))
                return;

            if (FromComboBox.Text == ToComboBox.Text)
                ResultTextBlock.Text = InputTextBox.Text;
            else
            {
                ResultTextBlock.Text = logic.CheckUnits(((Logic.ConverterType)TypeComboBox.SelectedValue).code, FromComboBox.Text.ToString(), ToComboBox.Text.ToString(), inputValue).ToString();              
            }

            if (!double.TryParse(ResultTextBlock.Text, out resultValue))
                return;

            try
            {
                StatisticDTO st = new StatisticDTO()
                {
                    DateTime = DateTime.Now,
                    UnitFrom = FromComboBox.SelectedItem.ToString(),
                    UnitTo = ToComboBox.SelectedItem.ToString(),
                    RawValue = (int)inputValue,
                    ConvertedValue = (int)resultValue,
                    Type = TypeComboBox.Text

                };

                this.repository.AddStatistic(st);
                this.statisticsDataGrid.ItemsSource = repository.GetStatistics();
            }
            catch { }
        }

        private void TypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FromComboBox.Items.Clear();
            ToComboBox.Items.Clear();

            if (TypeComboBox.SelectedValue != null)
            {
                foreach (string unit in logic.getUnits(((Logic.ConverterType)TypeComboBox.SelectedValue).code).units)
                {
                    this.FromComboBox.Items.Add(unit);
                    this.ToComboBox.Items.Add(unit);
                }
            }
        }

        private void InputTextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            InputTextBox.Text = "";
        }

        //obsługa przez API
        private void TypeComboBoxAPI_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FromComboBoxAPI.Items.Clear();
            ToComboBoxAPI.Items.Clear();

            if (TypeComboBoxAPI.SelectedValue != null)
            {
                var request = new RestRequest("converters/ConverterUnits", Method.GET);
                request.RequestFormat = RestSharp.DataFormat.Json;
                request.AddParameter("type", ((Logic.ConverterType)TypeComboBoxAPI.SelectedValue).code);
                var response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    foreach(string unit in (JsonConvert.DeserializeObject<Logic.Units>(response.Content)).units)
                    {
                        this.FromComboBoxAPI.Items.Add(unit);
                        this.ToComboBoxAPI.Items.Add(unit);
                    }
                }
                    
            }
        }

        private void InputTextBoxAPI_MouseEnter(object sender, MouseEventArgs e)
        {
            InputTextBoxAPI.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            double inputValue, resultValue;

            if (!double.TryParse(InputTextBoxAPI.Text, out inputValue))
                return;

            if (FromComboBoxAPI.Text == ToComboBoxAPI.Text)
                ResultTextBlockAPI.Text = InputTextBoxAPI.Text;
            else
            {
                var request = new RestRequest("converters/Converter", Method.GET);
                request.RequestFormat = RestSharp.DataFormat.Json;
                request.AddParameter("type", ((Logic.ConverterType)TypeComboBoxAPI.SelectedValue).code);
                request.AddParameter("from", FromComboBoxAPI.Text.ToString());
                request.AddParameter("to", ToComboBoxAPI.Text.ToString());
                request.AddParameter("value", inputValue);
                var response = client.Execute(request);
                if (response.IsSuccessful)
                    ResultTextBlockAPI.Text = response.Content.Replace(".",",");
            }

            if (!double.TryParse(ResultTextBlockAPI.Text, out resultValue))
                return;


            try
            {
                StatisticDTO st = new StatisticDTO()
                {
                    DateTime = DateTime.Now,
                    UnitFrom = FromComboBoxAPI.SelectedItem.ToString(),
                    UnitTo = ToComboBoxAPI.SelectedItem.ToString(),
                    RawValue = (int)inputValue,
                    ConvertedValue = (int)resultValue,
                    Type = TypeComboBoxAPI.Text

                };

                this.repository.AddStatistic(st);
                this.statisticsDataGrid.ItemsSource = repository.GetStatistics();
            }
            catch { }
        }
    }
}
