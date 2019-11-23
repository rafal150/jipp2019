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
using System.Configuration;

namespace Unitconverter
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Logika interakcji dla klasy MainWindow.xaml
        /// </summary>
        Temperatury temp = new Temperatury();
        Dlugosci dlug = new Dlugosci();
        Masy masy = new Masy();
        private IStatisticsRepository repository;
        //private StatisticsSQLRepo repository = new StatisticsSQLRepo();
        public MainWindow(IStatisticsRepository rep, Unitconverter.Services.ConvServices converters)
        {
            InitializeComponent();
            this.repository = rep;
            //this.ChoosecomboBox.ItemsSource = new string[3] { "Temperatury", "Długości", "Masy" }; ;
            //LoadBaza();
            this.ChoosecomboBox.ItemsSource = converters.GetConverters();
            this.ConverterdataGrid.ItemsSource = this.repository.GetStatistics();
            //this.RodzajBazylabel.Content = this.repository.ToString();
            this.RodzajBazylabel.Content = ConfigurationManager.AppSettings["StatRepo"];

        }
        /*
        private void LoadBaza()
        {
            List<UnitConverter> units = null;
            using (BazaUnitConverter baza = new BazaUnitConverter())
            {
                units = baza.UnitConverters.ToList();
            }
            this.ConverterdataGrid.ItemsSource = units;
        }
        */

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if(ChoosecomboBox.SelectedItem != null)
            {
                Unitconverter.Services.IConverter converter = ((Unitconverter.Services.IConverter)ChoosecomboBox.SelectedItem);
                this.OutputtextBlock.Text = converter.Convert(this.InputCombobox.SelectedItem.ToString(),this.OutputcomboBox.SelectedItem.ToString(),int.Parse(this.InputtextBox.Text)).ToString();
            }

            //oblicz();

            //koniec obliczanie
            //Zapamietanie danych
            StatDTO przech = new StatDTO()
            {
                DateTime = DateTime.Now,
                Type = this.ChoosecomboBox.SelectedItem.ToString(),
                FromUnit = this.InputCombobox.SelectedItem.ToString(),
                ToUnit = this.OutputcomboBox.SelectedItem.ToString(),
                RawValue = int.Parse(this.InputtextBox.Text),
                ConvertedValue = int.Parse(this.OutputtextBlock.Text)

            };
            //wprowadzenie do bazy
            this.repository.AddStatistic(przech);
            /*
            using (BazaUnitConverter baza = new BazaUnitConverter())
            {
                UnitConverter unit = new UnitConverter()
                {
                    DateTime = DateTime.Now,
                    Type = this.ChoosecomboBox.Text,
                    FromUnit = this.InputCombobox.Text,
                    ToUnit = this.OutputcomboBox.Text,
                    RawValue = int.Parse(this.InputtextBox.Text),
                    ConvertedValue = int.Parse(this.OutputtextBlock.Text)
                };
                baza.UnitConverters.Add(unit);
                baza.SaveChanges();

            }
            */
            //koniec wprowadzenie do bazy
            //wczytywanie bazy
            //LoadBaza();
            this.ConverterdataGrid.ItemsSource = this.repository.GetStatistics();
            //koniec wczytywanie bazy
        }

        private void oblicz()
        {
            if (InputCombobox.SelectedIndex != -1 && OutputcomboBox.SelectedIndex != -1 && InputtextBox.Text != "")
            {
                if (ChoosecomboBox.SelectedItem.ToString() == "Temperatury")
                {
                    this.OutputtextBlock.Text = Convert.ToString(temp.licztemp(this.InputCombobox.SelectedItem.ToString(), this.OutputcomboBox.SelectedItem.ToString(), Convert.ToDouble(this.InputtextBox.Text)));
                }
                if (ChoosecomboBox.SelectedItem.ToString() == "Długości")
                {
                    this.OutputtextBlock.Text = Convert.ToString(dlug.liczdlug(this.InputCombobox.SelectedItem.ToString(), this.OutputcomboBox.SelectedItem.ToString(), Convert.ToDouble(this.InputtextBox.Text)));
                }
                if (ChoosecomboBox.SelectedItem.ToString() == "Masy")
                {
                    this.OutputtextBlock.Text = Convert.ToString(masy.liczmasy(this.InputCombobox.SelectedItem.ToString(), this.OutputcomboBox.SelectedItem.ToString(), Convert.ToDouble(this.InputtextBox.Text)));
                }
            }
        }

        private void ChoosecomboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InputCombobox.Text = "";
            InputtextBox.Text = "";
            OutputcomboBox.Text = "";
            OutputtextBlock.Text = "";
            if(ChoosecomboBox.SelectedItem != null)
            {
                this.InputCombobox.ItemsSource = ((Unitconverter.Services.IConverter)ChoosecomboBox.SelectedItem).Units;
                this.OutputcomboBox.ItemsSource = ((Unitconverter.Services.IConverter)ChoosecomboBox.SelectedItem).Units;

            }
            /*
            if (ChoosecomboBox.SelectedItem.ToString() == "Temperatury")
            {
                this.InputCombobox.ItemsSource = temp.temp;
                this.OutputcomboBox.ItemsSource = temp.temp;
            }
            if (ChoosecomboBox.SelectedItem.ToString() == "Długości")
            {
                this.InputCombobox.ItemsSource = dlug.dlug;
                this.OutputcomboBox.ItemsSource = dlug.dlug;
            }
            if (ChoosecomboBox.SelectedItem.ToString() == "Masy")
            {
                this.InputCombobox.ItemsSource = masy.masy;
                this.OutputcomboBox.ItemsSource = masy.masy;
            }
            */
        }

        private void ChangeBaza_Click(object sender, RoutedEventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (ConfigurationManager.AppSettings["StatRepo"] == "SQL")
            {
                //ConfigurationManager.AppSettings.Set("StatRepo", "Azure");
                //ConfigurationManager.AppSettings["StatRepo"] = "Azure";
                config.AppSettings.Settings.Remove("StatRepo");
                config.AppSettings.Settings.Add("StatRepo", "Azure");
            }
            else
            {
                //ConfigurationManager.AppSettings.Set("StatRepo", "SQL");
                //ConfigurationManager.AppSettings["StatRepo"] = "SQL";
                //ConfigurationManager.(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\App.config")
                config.AppSettings.Settings.Remove("StatRepo");
                config.AppSettings.Settings.Add("StatRepo", "SQL");
            }

            config.Save();
            ConfigurationManager.RefreshSection("appSettings");

            //this.InputtextBox.Text = ConfigurationManager.AppSettings["StatRepo"];
            //this.ChangeBaza.Content = this.repository.ToString();
            if(MessageBox.Show("Po zmianie rodzaju bazy należy zrestartować program", "", MessageBoxButton.OK) == MessageBoxResult.OK) { this.Close(); }
        }

    }
}
