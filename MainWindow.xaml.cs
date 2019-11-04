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

using Laborki.Classes;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Laborki
{

    public partial class MainWindow : Window
    {
        public static MainWindow AppWindow;
        public MainWindow()
        {
            InitializeComponent();
            AppWindow = this;

        }

        ConvertClass ConvertClass = new ConvertClass();
        DatabaseClass DatabaseClass = new DatabaseClass();
        AzureDatabaseClass AzureDatabaseClass = new AzureDatabaseClass();

        public string[] Units { get; set; }
        public string[] SubCategory { get; set; }

        public void comboBoxCategoryFix()
        {
            ComboBoxSubCategory.SelectedIndex = 0;
        }

        private void comboBoxCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ComboBoxItem typeItem = (ComboBoxItem)ComboBoxCategory.SelectedItem;
            string item = typeItem.Content.ToString();
            comboBoxCategoryFix();

            if (item == "Temperatura")
            {
                ComboBoxSubCategory.IsEnabled = false;
                Units = new string[] { "Celsjusz", "Farenheit", "Kelvin", "Rankine" };
                ComboBoxConvertFrom.ItemsSource = Units;
                ComboBoxConvertTo.ItemsSource = Units;
            }
            else if (item == "Miary dlugosci")
            {
                ComboBoxSubCategory.IsEnabled = true;
                SubCategory = new string[] { "Miary metryczne", "Miary anglosaskie", "Miary morskie" };
                ComboBoxSubCategory.ItemsSource = SubCategory;
            }
            else if (item == "Masa")
            {
                ComboBoxSubCategory.IsEnabled = true;
                SubCategory = new string[] { "System metryczny", "System anglosaski", "Inne" };
                ComboBoxSubCategory.ItemsSource = SubCategory;
            }



            //DataContext = this;
        }

        private void comboBoxSubCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ComboBoxItem typeItem = (ComboBoxItem)ComboBoxSubCategory.SelectedItem;
            //string item = typeItem.Content.ToString();

            string item = "";

            if (ComboBoxSubCategory.SelectedValue == null)
            {
                comboBoxCategoryFix();
            } else item = ComboBoxSubCategory.SelectedValue.ToString();

            if (item == "Miary metryczne")
            {
                Units = new string[] { "mm", "cm", "dcm", "m", "km" };
                ComboBoxConvertFrom.ItemsSource = Units;
                ComboBoxConvertTo.ItemsSource = Units;

            } else if (item == "Miary anglosaskie")
            {
                Units = new string[] { "cal", "stopa", "jard", "mila" };
                ComboBoxConvertFrom.ItemsSource = Units;
                ComboBoxConvertTo.ItemsSource = Units;
            } else if (item == "Miary morskie")
            {
                Units = new string[] { "kabel", "mila morska" };
                ComboBoxConvertFrom.ItemsSource = Units;
                ComboBoxConvertTo.ItemsSource = Units;
            } else if (item == "System metryczny")
            {
                Units = new string[] { "mg", "g", "dkg", "kg", "T" };
                ComboBoxConvertFrom.ItemsSource = Units;
                ComboBoxConvertTo.ItemsSource = Units;
            } else if (item == "System anglosaski")
            {
                Units = new string[] { "uncja", "funt" };
                ComboBoxConvertFrom.ItemsSource = Units;
                ComboBoxConvertTo.ItemsSource = Units;
            } else if (item == "Inne")
            {
                Units = new string[] { "karat", "kwintal" };
                ComboBoxConvertFrom.ItemsSource = Units;
                ComboBoxConvertTo.ItemsSource = Units;
            }
        }

        private void buttonConvert_Click(object sender, RoutedEventArgs e)
        {
            string from = ComboBoxConvertFrom.Text;
            string to = ComboBoxConvertTo.Text;
            double initial = Convert.ToDouble(TextBoxFrom.Text);
            double result = 0;

            ComboBoxItem typeItem = (ComboBoxItem)ComboBoxCategory.SelectedItem;
            string category = typeItem.Content.ToString();

            string subcategory = "";


            if (category == "Temperatura")
            {
                result = ConvertClass.convertTemperature(from, to);
            } else
            {
                switch (ComboBoxSubCategory.SelectedValue.ToString())
                {
                    case "Miary metryczne":
                        result = ConvertClass.convertMMetric(from, to);
                        break;

                    case "Miary anglosaskie":
                        result = ConvertClass.convertMEng(from, to);
                        break;

                    case "Miary morskie":
                        result = ConvertClass.convertMSea(from, to);
                        break;

                    case "System metryczny":
                        result = ConvertClass.convertSMetric(from, to);
                        break;

                    case "System anglosaski":
                        result = ConvertClass.convertSEng(from, to);
                        break;

                    case "Inne":
                        result = ConvertClass.convertSOther(from, to);
                        break;
                }

                subcategory = ComboBoxSubCategory.SelectedValue.ToString();
            }

            TextBoxResult.Text = result.ToString();
            
            if (ConfigurationManager.AppSettings["Database"] == "AzureStorage")
            {
                AzureDatabaseClass.saveToAzure(category, from, to, initial, result);               
            } else DatabaseClass.saveToDB(category, subcategory, from, to, initial, result);
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            
            ShowDB history = new ShowDB();
            history.Show();
        }

    }

}
