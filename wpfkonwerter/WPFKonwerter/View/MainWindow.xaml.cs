using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
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
using WPFKonwerter.Model;
using WPFKonwerter.Model.DTO;

namespace WPFKonwerter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Categories categories;
        MassConverter mConv;
        Model.LengthConverter lConv;
        TemperatureConverter tConv;
        UnitsConverterEntities uce;
        //Statistic2SQL stats2SQL;
        //StatisticsAzure stats2Azure;
        Statistics statistics;

        IStatisticsRepo repo;

        public MainWindow(IStatisticsRepo statRepo)
        {
            InitializeComponent();
            repo = statRepo;
            categories = new Categories();
            mConv = new MassConverter(); ;
            lConv = new Model.LengthConverter();
            tConv = new TemperatureConverter();
            uce = new UnitsConverterEntities();
            //stats2SQL = new Statistic2SQL();
            //stats2Azure = new StatisticsAzure();
            
            cbCategory.SelectedIndex = 0;
            cbCategory.ItemsSource = categories.Category;
            //dgStatistics.ItemsSource = uce.Statistics_AC.ToList();
            dgStatistics.ItemsSource = statRepo.GetStats();

        }

        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbCategory.SelectedIndex==0)
            {
                //temp
                cbLeft.ItemsSource = cbRight.ItemsSource = tConv.Temperature;
                cbLeft.SelectedIndex = 0;
                cbRight.SelectedIndex = 1;       
            }
            else if (cbCategory.SelectedIndex == 1)
            {
                //dlugosc
                cbLeft.ItemsSource = cbRight.ItemsSource = lConv.Length;
                cbLeft.SelectedIndex = 0;
                cbRight.SelectedIndex = 1;
            }
            else if (cbCategory.SelectedIndex == 2)
            {
                //masa
                cbLeft.ItemsSource =cbRight.ItemsSource = mConv.Mass;
                cbLeft.SelectedIndex = 0;
                cbRight.SelectedIndex = 1;
            }
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            string result = "";
            double valueToConvert;
            if (tbLeft.Text == "") return;
      
            if (!Double.TryParse(tbLeft.Text, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out valueToConvert))
            {
                lblErr.Visibility = Visibility.Visible;
                return;
            }
            valueToConvert = Math.Round(valueToConvert, 2);

            if (cbCategory.SelectedIndex == 0)
            {
                result = tConv.Convert(cbLeft.SelectedIndex, cbRight.SelectedIndex, valueToConvert);
                tbRight.Text = result;
            }
            else if (cbCategory.SelectedIndex == 1)
            {
                result = lConv.Convert(cbLeft.SelectedIndex, cbRight.SelectedIndex, valueToConvert);
                tbRight.Text = result;
            }
            else if (cbCategory.SelectedIndex == 2)
            {
                result = mConv.Convert(cbLeft.SelectedIndex, cbRight.SelectedIndex, valueToConvert);
                tbRight.Text = result;
            }

            statistics = new Statistics()
            {
                CategoryType = cbCategory.SelectedValue.ToString(),
                ConversionDT = DateTime.Now,
                UnitFrom = cbLeft.SelectedValue.ToString(),
                ValueFrom = tbLeft.Text,
                UnitTo = cbRight.SelectedValue.ToString(),
                ValueTo = tbRight.Text
            };

            //zapis do bazki
            //if (Properties.Settings.Default.SaveToSQL)
            //    stats2SQL.SaveStats(statistics);
            //else
            //    stats2Azure.SaveStats(statistics);

            //nowy zapis
            repo.SaveStats(statistics);

            #region OLD save2sql -> przeniesione do oddzielnej klasy
            //uce.Statistics_AC.Add(new Statistics_AC()
            //{
            //    CategoryType = cbCategory.SelectedValue.ToString(),
            //    ConversionDT = DateTime.Now,
            //    UnitFrom = cbLeft.SelectedValue.ToString(),
            //    ValueFrom = tbLeft.Text,
            //    UnitTo = cbRight.SelectedValue.ToString(),
            //    ValueTo = tbRight.Text
            //}
            //);
            #endregion

            lblErr.Visibility = Visibility.Collapsed;
            
            dgStatistics.ItemsSource = null;
            dgStatistics.ItemsSource = repo.GetStats();
            //dgStatistics.ItemsSource=uce.Statistics_AC.ToList();

        }
    }
}
