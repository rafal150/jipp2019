using Converter.SDK;
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
using UnitConverteAZ.Services;

namespace UnitConverteAZ
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IStatisticRepository repository;    
    
        public MainWindow(IStatisticRepository repo, ConverterService converters)
        {
            InitializeComponent();
            LoadConverterStatistics();
            this.repository = repo;
            this.converterStatisticsDataGrid.ItemsSource = repository.GetStatistic();
            // this.MetricSystemCombobox.ItemsSource = new List<string>(new[] { "Miara", "Temperatura", "Waga" });

            this.MetricSystemCombobox.ItemsSource = converters.GetConverters();
            //this.FromUnitCombobox.ItemsSource = new List<string>(new[] { "MM", "CM", "DCM", "M"  });
        }

        private void FromUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.FromValueTextBox.Clear();
            this.ToUnitTextBlock.Text = "??????";
            this.FromValueTextBox.Focus();

        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.MetricSystemCombobox.SelectedItem != null)
            {
                IConverter converter = (IConverter)this.MetricSystemCombobox.SelectedItem;
                double result = converter.Convert(
                    this.FromUnitCombobox.SelectedItem.ToString(),
                    this.ToUnitCombobox.SelectedItem.ToString(),
                    double.Parse(this.FromValueTextBox.Text));

                this.ToUnitTextBlock.Text = result.ToString();


                StatisticDTO st = new StatisticDTO()
                {
                    Type = converter.Name,
                    Calculation_Time = DateTime.Now,
                    UnitFrom = this.FromUnitCombobox.SelectedItem.ToString(),
                    Unit_To = this.ToUnitCombobox.SelectedItem.ToString(),
                    Value_From = double.Parse(this.FromValueTextBox.Text),
                    Converted_Value = result
                };

                repository.AddStatistic(st);
                this.converterStatisticsDataGrid.ItemsSource = repository.GetStatistic();
            }


            //var a = FromUnitCombobox.SelectedValue.ToString();
            //var b = ToUnitCombobox.SelectedValue.ToString();
            //double c = (double.Parse(this.FromValueTextBox.Text));
            //double d = 0;
            //if (MetricSystemCombobox.SelectedValue.ToString() == "Temperatura")
            //{
            //    TempratureConventer temp = new TempratureConventer(a, b, c);
            //    d = temp.convertTemprature(a, b);
            //    this.ToUnitTextBlock.Text = d.ToString();

            //}
            //if (MetricSystemCombobox.SelectedValue.ToString() == "Miara")
            //{
            //    MetricConverter temp = new MetricConverter(a, b, c);
            //    d = temp.convert(a, b);
            //    this.ToUnitTextBlock.Text = d.ToString();

            //}
            //if (MetricSystemCombobox.SelectedValue.ToString() == "Waga")
            //{
            //    WeightConverter temp = new WeightConverter(a, b, c);
            //    d = temp.convert(a, b);
            //    this.ToUnitTextBlock.Text = d.ToString();
            //}


            //StatisticStorageAzureRepository rep = new StatisticStorageAzureRepository();
            //rep.AddStatistic(st);

            //StatisticSqlRepository rep = new StatisticSqlRepository();
            //rep.AddStatistic(st);

            //using ( Statistics context = new Statistics() )
            //{
            //UnitConverterAZ st = new UnitConverterAZ();

            //    st.Calculation_Time = DateTime.Now;
            //    st.UnitFrom = a;
            //    st.Value_From = c;
            //    st.Unit_To = b;
            //    st.Converted_Value = d;

            ////st.Unit_To = (double.Parse(d));


            //context.UnitConverterAZ.Add(st);
            //context.SaveChanges();


            //LoadConverterStatistics();


            //this.ToUnitTextBlock.Text = (double.Parse(this.FromValueTextBox.Text) * 2).ToString();

        }

        public void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(this.MetricSystemCombobox.SelectedItem != null)
            {
                this.FromUnitCombobox.ItemsSource = ((IConverter)this.MetricSystemCombobox.SelectedItem).Units;
                this.ToUnitCombobox.ItemsSource = ((IConverter)this.MetricSystemCombobox.SelectedItem).Units;
            }


            //if (MetricSystemCombobox.SelectedValue.ToString() == "Miara")
            //{
            //    //this.FromUnitCombobox.ItemsSource = new List<string>(new[] { "MM", "CM", "DCM", "M" });
            //    this.FromUnitCombobox.ItemsSource = MetricConverter.getUnitsNames();
            //    this.ToUnitCombobox.ItemsSource = MetricConverter.getUnitsNames();

            //}
            //if (MetricSystemCombobox.SelectedValue.ToString() == "Temperatura")
            //{
            //    this.FromUnitCombobox.ItemsSource = new List<string>(new[] { "Celcius", "Kalvin", "Fahrenheit", "Rankine" });
            //    this.ToUnitCombobox.ItemsSource = new List<string>(new[] { "Celcius", "Kalvin", "Fahrenheit", "Rankine" });
            //}
            //if (MetricSystemCombobox.SelectedValue.ToString() == "Waga")
            //{
            //    //var units = WeightConverter.getUnitsNames(); 
            //    //this.FromUnitCombobox.ItemsSource = new List<string>(new[] { "Celcius", "Kalvin", "Fahrenheit" });
            //    this.FromUnitCombobox.ItemsSource = WeightConverter.getUnitsNames();
            //    this.ToUnitCombobox.ItemsSource = WeightConverter.getUnitsNames();
            //}
        }



        private void LoadConverterStatistics()
        {
            //List<UnitConverterAZ> statistics;

            //using (Statistics context = new Statistics())
            //{

            //    UnitConverterAZ st = new UnitConverterAZ();
            //    {
            //        statistics = context.UnitConverterAZ.ToList();
            //    }

            //this.converterStatisticsDataGrid.ItemsSource = statistics;

            //this.converterStatisticsDataGrid.ItemsSource = new StatisticSqlRepository().GetStatistic();
           // this.converterStatisticsDataGrid.ItemsSource = new StatisticStorageAzureRepository().GetStatistic();
        }
        

        private void ConverterStatisticsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    }
