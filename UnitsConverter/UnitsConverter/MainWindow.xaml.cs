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

namespace UnitsConverter
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> typeList = new List<string>(new[] { "temperatura", "długość", "masa" });
        List<string> tempUnits = new List<string> { "°C", "°F", "K", "°Rank" };
        List<string> lengthUnits = new List<string> { "mm", "cm", "dcm", "m", "km", "cal", "stopa", "jard", "mila", "kabel", "mila morska" };
        List<string> weightUnits = new List<string> { "mg", "g", "dkg", "kg", "T", "uncja", "funt", "karat", "kwintal" };

        private IStatisticsRepository repository;
        public MainWindow(/*IStatisticsRepository repo*/)
        {
            InitializeComponent();

            
            this.TypeComboBox.ItemsSource = new List<string>(new[] { "temperatura", "długość", "masa" });
            this.LoadStatistics();
           
            /*
               this.repository = repo;
               this.statisticsDataGrid.ItemsSource = repository.GetStatistics();
               */
               
        }

        private void LoadStatistics()
        {

            List<Statistic> statistics = null;

            using (ConverterContext context = new ConverterContext())
            {

                statistics = context.Statistics.ToList();

            }

            this.statisticsDataGrid.ItemsSource = statistics;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //this.ResultTextBlock.Text =  ((int.Parse(this.InputTextBox.Text)) * 20).
            //  ToString();

            double inputValue, resultValue;
            double.TryParse(InputTextBox.Text, out inputValue);
            if (FromCombobox.Text == ToComboBox.Text)
                ResultTextBlock.Text = InputTextBox.Text;
            else
            {
                
                if (TypeComboBox.Text == "temperatura")
                {
                    ResultTextBlock.Text = Logic.CheckTempUnits(FromCombobox.Text.ToString(), ToComboBox.Text.ToString(), inputValue).ToString();
                }

                else if (TypeComboBox.Text == "długość")
                {
                    ResultTextBlock.Text = Logic.CheckLengthUnits(FromCombobox.Text.ToString(), ToComboBox.Text.ToString(), inputValue).ToString();
                }

                else if (TypeComboBox.Text == "masa")
                {
                    ResultTextBlock.Text = Logic.CheckWeightUnits(FromCombobox.Text.ToString(), ToComboBox.Text.ToString(), inputValue).ToString();
                }


            }

            double.TryParse(ResultTextBlock.Text, out resultValue);
            using (ConverterContext context = new ConverterContext())
            {
                Statistic st = new Statistic()
                {
                    DateTime = DateTime.Now,
                    UnitFrom = this.FromCombobox.SelectedItem.ToString(),
                    UnitTo = this.ToComboBox.SelectedItem.ToString(),
                    RawValue = (int)inputValue,
                    ConvertedValue = (int)resultValue,
                    Type = this.TypeComboBox.Text
                };

                context.Statistics.Add(st);
                context.SaveChanges();
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TypeComboBox.SelectedValue.ToString() == "temperatura")
            {
                foreach (string unit in tempUnits)
                    this.FromCombobox.Items.Add(unit);

                foreach (string unit in tempUnits)
                    this.ToComboBox.Items.Add(unit);
            }
            else if (TypeComboBox.SelectedValue.ToString() == "długość")
            {
                foreach (string unit in lengthUnits)
                    this.FromCombobox.Items.Add(unit);

                foreach (string unit in lengthUnits)
                    this.ToComboBox.Items.Add(unit);
            }
            else if (TypeComboBox.SelectedValue.ToString() == "masa")
            {
                foreach (string unit in weightUnits)
                    this.FromCombobox.Items.Add(unit);
            
                foreach (string unit in weightUnits)
                    this.ToComboBox.Items.Add(unit);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StatisticDTO st = new StatisticDTO()
            {
                DateTime = DateTime.Now,
                Type = "Masa"
            };

            this.repository.AddStatistic(st);
            this.statisticsDataGrid.ItemsSource = repository.GetStatistics();
        }
    }
}
