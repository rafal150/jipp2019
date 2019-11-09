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

        
        public MainWindow(IStatisticsRepository repo)
        {
            
            InitializeComponent();
            
            for (int i = 0; i < AppData.types.Length; i++)
                TypeComboBox.Items.Add(AppData.types[i]);

            this.repository = repo;
            this.statisticsDataGrid.ItemsSource = repository.GetStatistics();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double inputValue, resultValue;

            double.TryParse(InputTextBox.Text, out inputValue);

            if (FromComboBox.Text == ToComboBox.Text)
                ResultTextBlock.Text = InputTextBox.Text;
            else
            {

                if (TypeComboBox.Text == "temperatura")
                {
                    ResultTextBlock.Text = ComputingMethods.ConvertTemperature(FromComboBox.Text.ToString(), ToComboBox.Text.ToString(), inputValue).ToString();
                }
                else if (TypeComboBox.Text == "długość")
                {
                    ResultTextBlock.Text = ComputingMethods.ConvertLength(FromComboBox.Text.ToString(), ToComboBox.Text.ToString(), inputValue).ToString();
                }
                else if (TypeComboBox.Text == "masa")
                {
                    ResultTextBlock.Text = ComputingMethods.ConvertWeight(FromComboBox.Text.ToString(), ToComboBox.Text.ToString(), inputValue).ToString();
                }

            }

            double.TryParse(ResultTextBlock.Text, out resultValue);


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


        private void TypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FromComboBox.Items.Clear();
            ToComboBox.Items.Clear();

            if (TypeComboBox.SelectedValue.ToString() == "temperatura")
            {
                for (int i = 0; i < AppData.tUnits.Length; i++)
                {
                    FromComboBox.Items.Add(AppData.tUnits[i]);
                    ToComboBox.Items.Add(AppData.tUnits[i]);
                }


            }
            else if (TypeComboBox.SelectedValue.ToString() == "długość")
            {
                for (int i = 0; i < AppData.lUnits.Length; i++)
                {
                    FromComboBox.Items.Add(AppData.lUnits[i]);
                    ToComboBox.Items.Add(AppData.lUnits[i]);
                }
            }
            else if (TypeComboBox.SelectedValue.ToString() == "masa")
            {
                for (int i = 0; i < AppData.wUnits.Length; i++)
                {
                    FromComboBox.Items.Add(AppData.wUnits[i]);
                    ToComboBox.Items.Add(AppData.wUnits[i]);
                }
            }

        }
    }
}