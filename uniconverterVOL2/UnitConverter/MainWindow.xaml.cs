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

namespace UnitConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IRepository repository;
        Populate temperature = new Populate();
        Populate distance = new Populate();
        Populate mass = new Populate();

        public MainWindow(IRepository repo)
        {
            InitializeComponent();
            this.repository = repo;
            this.statisticsDataGrid.ItemsSource = repository.GetStatistics();
        }
        //public MainWindow()
        //{
        //    InitializeComponent();
        //}


        private void TypeComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            TypeComboBox.ItemsSource = new List<string>(new[]
            {
                "Temperatura", "Miary długości", "Miary masowe"
            });
        }


        private void TypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var choice = TypeComboBox.SelectedItem.ToString();
            switch (choice)
            {
                case "Temperatura":
                    FromComboBox.ItemsSource = temperature.populateTemperature();
                    ToComboBox.ItemsSource = temperature.populateTemperature();
                    break;
                case "Miary długości":
                    FromComboBox.ItemsSource = distance.populateDistance();
                    ToComboBox.ItemsSource = distance.populateDistance();
                    break;
                case "Miary masowe":
                    FromComboBox.ItemsSource = mass.populateMass();
                    ToComboBox.ItemsSource = mass.populateMass();
                    break;


            }
        }

        private void ToComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var conversionType = this.TypeComboBox.SelectedItem;
            var FromUnit = this.FromComboBox.SelectedItem.ToString();
            var ToUnit = this.ToComboBox.SelectedItem.ToString();
            var Input = float.Parse(InputTextBox.Text);


            switch (conversionType)
            {
                case "Temperatura":
                    Temperature temperatureConvert = new Temperature();
                    var baseValueTemp = temperatureConvert.toBaseUnit(FromUnit, Input);
                    ResultTextBlock.Text = (temperatureConvert.toUnit(ToUnit, baseValueTemp)).ToString();
                    break;
                case "Miary długości":
                    Distance distanceConvert = new Distance();
                    var baseValueDist = distanceConvert.toBaseUnit(FromUnit, Input);
                    ResultTextBlock.Text = (distanceConvert.toUnit(ToUnit, baseValueDist)).ToString();
                    break;
                case "Miary masowe":
                    Mass massConvert = new Mass();
                    var baseValueMass = massConvert.toBaseUnit(FromUnit, Input);
                    ResultTextBlock.Text = (massConvert.toUnit(ToUnit, baseValueMass)).ToString();
                    break;
            }
            StatisticJZDTO st = new StatisticJZDTO()
            {
                DateTime = DateTime.Now,
                UnitFrom = this.FromComboBox.SelectedItem.ToString(),
                UnitTo = this.ToComboBox.SelectedItem.ToString(),
                Type = this.TypeComboBox.SelectedItem.ToString(),
                RawValue = double.Parse(this.InputTextBox.Text),
                ConvertedValue = double.Parse(this.ResultTextBlock.Text)
            };
            this.repository.AddStatistic(st);
            this.statisticsDataGrid.ItemsSource = repository.GetStatistics();
            


        }
       

    }
} 

