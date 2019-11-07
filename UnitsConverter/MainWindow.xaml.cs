using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Validation;
using System.Diagnostics;
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
        private int value;
        private IStatisticsRepository repository;
       //public MainWindow() {  }


            public MainWindow(IStatisticsRepository repo)
            {
              
            InitializeComponent();
            this.converterMain.ItemsSource = Listy.TypeList;
            this.repository = repo;
                this.statisticsDataGrid.ItemsSource = repository.GetStatistics();
            }



            //InitializeComponent();
            //
            //this.LoadStatistics();
        

        //private void LoadStatistics()
        //{
        //    List<Statistic> Statistic;

        //    using (ConverterContext context = new ConverterContext())
        //    {
        //        Statistic = context.Statistic.ToList();
        //    }

            //this.statisticsDataGrid.ItemsSource = Statistic;
            //statisticsDataGrid.ItemsSource = 
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(InputTextBox.Text, out value))
            {
                //this.ResultTextblock.Text = (int.Parse(this.InputTextBox.Text) * 20).
                //  ToString();
                decimal inputValue, resultValue;

                decimal.TryParse(InputTextBox.Text, out inputValue);

                if (FromCombobox.Text == ToCombobox.Text)


                    this.InputTextBox.Text = ResultTextblock.Text;
                else
                {

                    if (converterMain.Text == "temperatura")
                    {
                        ResultTextblock.Text = Logic.CheckTempUnits(FromCombobox.Text.ToString(), ToCombobox.Text.ToString(), inputValue).ToString();
                    }
                    else if (converterMain.Text == "długość")
                    {
                        ResultTextblock.Text = Logic.CheckLengthUnits(FromCombobox.Text.ToString(), ToCombobox.Text.ToString(), inputValue).ToString();
                    }
                    else if (converterMain.Text == "masa")
                    {
                        ResultTextblock.Text = Logic.CheckWeightUnits(FromCombobox.Text.ToString(), ToCombobox.Text.ToString(), inputValue).ToString();
                    }
                }

               // using (ConverterContext context = new ConverterContext())
               // {
                    StatisticDTO st = new StatisticDTO()
                    {
                        DateTime = DateTime.Now,
                        FromUnit = this.FromCombobox.SelectedItem.ToString(),
                        Type = this.converterMain.SelectedItem.ToString(),
                        FromTo = this.FromCombobox.SelectedItem.ToString(),
                        ConvertedValue = this.ResultTextblock.Text
                    };

                    this.repository.AddStatistic(st);
                     this.statisticsDataGrid.ItemsSource = repository.GetStatistics();


                //context.SaveChanges();
                //this.statisticsDataGrid.Items.Refresh();
                // CollectionViewSource.GetDefaultView(statisticsDataGrid.ItemsSource).Refresh();
                // DataContext.Refresh(RefreshMode.OverwriteCurrentValues, ConverterContext.st);


                // }
            }
        }
        private void TypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FromCombobox.Items.Clear();
            ToCombobox.Items.Clear();

            if (converterMain.SelectedValue.ToString() == "temperatura")
            {
                //foreach (string unit in type)
                //    this.FromCombobox.Items.Add(unit);

                foreach (string unit in Listy.TempList)
                    this.ToCombobox.Items.Add(unit);
            }
            else if (converterMain.SelectedValue.ToString() == "długość")
            {
                foreach (string unit in Listy.Longlist)
                    this.FromCombobox.Items.Add(unit);

                foreach (string unit in Listy.Longlist)
                    this.ToCombobox.Items.Add(unit);
            }
            else if (ToCombobox.SelectedValue.ToString() == "masa")
            {
                foreach (string unit in Listy.WageList)
                    this.FromCombobox.Items.Add(unit);

                foreach (string unit in Listy.WageList)
                    this.ToCombobox.Items.Add(unit);
            }

        }



        public void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.converterMain.SelectedItem == "temperatura")
            {
                this.FromCombobox.ItemsSource = Listy.TempList;
                this.ToCombobox.ItemsSource = Listy.TempList;
            }
            else if (this.converterMain.SelectedItem == "długość")
            {
                this.FromCombobox.ItemsSource = Listy.Longlist;
                this.ToCombobox.ItemsSource = Listy.Longlist;
            }
            else if (this.converterMain.SelectedItem == "masa")
            {
                this.FromCombobox.ItemsSource = Listy.WageList;
                this.ToCombobox.ItemsSource = Listy.WageList;
            };
        }
    }
}

