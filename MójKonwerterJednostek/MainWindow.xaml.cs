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
using MójKonwerterJednostek.Dane;
using MójKonwerterJednostek.Jednostki;
using MójKonwerterJednostek.Konwertery;
using Autofac;
using System.Configuration;

namespace MójKonwerterJednostek
{
    
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IStatisticsRepository repository;
        public MainWindow()
        {   
            InitializeComponent();

            if (ConfigurationManager.AppSettings["StatisticsRepository"] == "AzureStorage")
            {
               repository = new StatisticsAzureStorageRepository();

            }
            else
            {
                repository = new StatisticsSqlRepository();
            }

            comboBoxChoice.ItemsSource = UnitsList.lsTypes;
            


        }

        private void TypeChange(object sender, SelectionChangedEventArgs e)
        {
            if ((string)comboBoxChoice.SelectedItem == "Weight")
                comboBox1.ItemsSource = comboBox4.ItemsSource = UnitsList.lsWeight;
            else if ((string)comboBoxChoice.SelectedItem == "Temperature")
                comboBox1.ItemsSource = comboBox4.ItemsSource = UnitsList.lsTemperature;
            else if ((string)comboBoxChoice.SelectedItem == "Length")
                comboBox1.ItemsSource = comboBox4.ItemsSource = UnitsList.lsLength;
            comboBox1.SelectedIndex = comboBox4.SelectedIndex = 0;
        }
        private void Calculate(object sender, RoutedEventArgs e)
        {   
            MyConverter Licz1 = new MyConverter((UnitTypes)comboBox1.SelectedItem, textbox1.Text, (UnitTypes)comboBox4.SelectedItem);
            textbox4.Text = Licz1.provideOutput();
            WriteRecord NewSave;

            if (Licz1.provideOutput()=="Złe Dane")
                MessageBox.Show(ErrorMessages.ErrorData, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            else
            {
                NewSave = new WriteRecord((int)Licz1.myInput, (int)Licz1.myOutput, (decimal)Licz1.myOutputValue, (decimal)Licz1.myInputValue, repository);
                if (NewSave.RecordSaved == false)
                    MessageBox.Show(ErrorMessages.ErrorInput, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                PressGeneral(sender, e);
            }

            

        }

        private void PressGeneral(object sender, RoutedEventArgs e)
        {
            try
            {
                dataGridStatistic.ItemsSource = repository.GetStatistics();
            }
            catch (System.Data.DataException)
            {
                MessageBox.Show(ErrorMessages.ErrorStatistic, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
          
        }

    }
}
