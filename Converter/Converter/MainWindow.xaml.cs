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
using Converter.Dictionary;
using Converter.Model;
using Converter.Program;
using Converter.WindowHandler;


namespace Converter
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //DataBaseConnection.DataBaseConnection connection;
        public MainWindow()
        {
            InitializeComponent();            
            ComboBoxProperty.ItemsSource = WindowProperties.listOfProperty;
            
        }

        private void ButtonConvert_Click(object sender, RoutedEventArgs e)
        {
            MasterConnection masterConnection = new MasterConnection();
            //connection = new DataBaseConnection.DataBaseConnection();
            BaseConverter converter;
            if(ComboBoxProperty.Text.Equals(General.distance))
            {
                //DistanceConverter converter = new DistanceConverter(ComboBoxFromUnit.Text,ComboBoxToUnit.Text,WindowProperties.StringToDouble(TextBoxInput.Text));
                converter = new DistanceConverter(ComboBoxFromUnit.Text,ComboBoxToUnit.Text,WindowProperties.StringToDouble(TextBoxInput.Text),DateTime.Now,ComboBoxProperty.Text);
                converter.Convert();
                TextBoxOutput.Text = WindowProperties.DoubleToString(converter.Result);
                masterConnection.Add(converter);
                //connection.Converters.Add(converter);
            }
            if (ComboBoxProperty.Text.Equals(General.weight))
            {
                //WeightConverter converter = new WeightConverter(ComboBoxFromUnit.Text, ComboBoxToUnit.Text, WindowProperties.StringToDouble(TextBoxInput.Text));
                converter = new WeightConverter(ComboBoxFromUnit.Text, ComboBoxToUnit.Text, WindowProperties.StringToDouble(TextBoxInput.Text), DateTime.Now, ComboBoxProperty.Text);
                converter.Convert();
                TextBoxOutput.Text = WindowProperties.DoubleToString(converter.Result);
                masterConnection.Add(converter);
                //connection.Converters.Add(converter);
            }
            if (ComboBoxProperty.Text.Equals(General.temperature))
            {
                //TemperatureConverter converter = new TemperatureConverter(ComboBoxFromUnit.Text, ComboBoxToUnit.Text, WindowProperties.StringToDouble(TextBoxInput.Text));
                converter = new TemperatureConverter(ComboBoxFromUnit.Text, ComboBoxToUnit.Text, WindowProperties.StringToDouble(TextBoxInput.Text), DateTime.Now, ComboBoxProperty.Text);
                converter.Convert();
                TextBoxOutput.Text = WindowProperties.DoubleToString(converter.Result);
                masterConnection.Add(converter);
                //connection.Converters.Add(converter);
            }
            //connection.SaveChanges();
            
            //var allRows = masterConnection.GetLocal()// connection.Converters;
            if(ConfigurationManager.AppSettings["StatisticsRepository"].Equals("AzureStorage"))
            {
                DataBaseOutput.ItemsSource = masterConnection.GetAzure();
            }
            else
            {
                DataBaseOutput.ItemsSource = masterConnection.GetLocal().Converters.ToList<BaseConverter>();
            }
            




        }

        private void ComboBoxProperty_LayoutUpdated(object sender, EventArgs e)
        {
            if (ComboBoxProperty.Text.Equals(General.temperature))
            {
                ComboBoxFromUnit.ItemsSource = WindowProperties.listOfTemperatureUnits;
                ComboBoxToUnit.ItemsSource = WindowProperties.listOfTemperatureUnits;
            }
            if (ComboBoxProperty.Text.Equals(General.distance))
            {
                ComboBoxFromUnit.ItemsSource = WindowProperties.listOfDistanceUnits;
                ComboBoxToUnit.ItemsSource = WindowProperties.listOfDistanceUnits;
            }
            if (ComboBoxProperty.Text.Equals(General.weight))
            {
                ComboBoxFromUnit.ItemsSource = WindowProperties.listOfWeightUnits;
                ComboBoxToUnit.ItemsSource = WindowProperties.listOfWeightUnits;
            }
        }

        /*private void ComboBoxProperty_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (ComboBoxProperty.Text.Equals(General.temperature))
            {
                ComboBoxFromUnit.ItemsSource = WindowProperties.listOfTemperatureUnits;
                ComboBoxToUnit.ItemsSource = WindowProperties.listOfTemperatureUnits;
            }
            if (ComboBoxProperty.Text.Equals(General.distance))
            {
                ComboBoxFromUnit.ItemsSource = WindowProperties.listOfDistanceUnits;
                ComboBoxToUnit.ItemsSource = WindowProperties.listOfDistanceUnits;
            }
            if (ComboBoxProperty.Text.Equals(General.weight))
            {
                ComboBoxFromUnit.ItemsSource = WindowProperties.listOfWeightUnits;
                ComboBoxToUnit.ItemsSource = WindowProperties.listOfWeightUnits;
            }
        }*/

        /*private void ComboBoxProperty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }*/
    }
}
