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
        int UnitCategory = 0;
        private InterfaceStatistic repository;


        public MainWindow(InterfaceStatistic repo)
        {
            InitializeComponent();

            this.repository = repo;
            this.statisticsDataGrid.ItemsSource = repository.GetStatistics();

            /*
            StatisticRecord loadRecord = new StatisticRecord();

            using (UnitConverterDB_Entities database = new UnitConverterDB_Entities())
            {
                foreach (Statistics record in database.Statistics.ToList())
                {
                    Listbox_Statistics.Items.Insert(0, record.Date.ToString() + "     z: " + record.ValueFrom.ToString() + record.UnitFrom.ToString() + "     na: " + record.ValueTo.ToString() + record.UnitTo.ToString());
                }
            }

            using (UnitConverterDB_Entities database = new UnitConverterDB_Entities())
            {
                foreach (Category record in database.Category.ToList())
                {
                    ComboBox_UnitCategory.Items.Add(record.name);
                }
            }
            */



        }

        

        private void ComboBox_UnitFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ComboBox_UnitFrom.SelectedItem != null && ComboBox_UnitTo.SelectedItem != null && double.TryParse(TextBox_ValueFrom.Text, out double test))
            {
                Button_Convert.Visibility = Visibility.Visible;
            }
        }

        private void ComboBox_UnitTo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox_UnitFrom.SelectedItem != null && ComboBox_UnitTo.SelectedItem != null && double.TryParse(TextBox_ValueFrom.Text, out double test))
            {
                Button_Convert.Visibility = Visibility.Visible;
            }
        }

        private void ComboBox_UnitCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UnitCategory = ComboBox_UnitCategory.SelectedIndex + 1;

            ComboBox_UnitFrom.Items.Clear();
            ComboBox_UnitTo.Items.Clear();
            Button_Convert.Visibility = Visibility.Hidden;

            using (UnitConverterDB_Entities database = new UnitConverterDB_Entities())
            {
                foreach (Units record in database.Units.Where(f => f.Category == ComboBox_UnitCategory.SelectedIndex + 1))
                {
                        ComboBox_UnitFrom.Items.Add(record.Name);
                        ComboBox_UnitTo.Items.Add(record.Name);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           



        }

        private void TextBox_ValueFrom_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ComboBox_UnitFrom.SelectedItem != null && ComboBox_UnitTo.SelectedItem != null && double.TryParse(TextBox_ValueFrom.Text, out double test))
            {
                Button_Convert.Visibility = Visibility.Visible;
            }
            else
            {
                Button_Convert.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Convert_Click(object sender, RoutedEventArgs e)
        {
            
            
            if (UnitCategory != 1 )
            {
                Unit ConvertedUnit = new Unit();

                using (UnitConverterDB_Entities database = new UnitConverterDB_Entities())
                {
                    foreach (Units record_from in database.Units.Where(f => f.Name == ComboBox_UnitFrom.SelectedItem))
                    {
                        ConvertedUnit.Set_Values(double.Parse(TextBox_ValueFrom.Text), record_from.BaseValue.Value);
                    }

                    ConvertedUnit.ConvertToBase();

                    foreach (Units record_to in database.Units.Where(f => f.Name == ComboBox_UnitTo.SelectedItem))
                    {
                        ConvertedUnit.Set_ValueBase(record_to.BaseValue.Value);
                    }

                    ConvertedUnit.ConvertToEnd();
                    Label_ValueTo.Content = ConvertedUnit.Get_ValueEnd();
                }

                using (UnitConverterDB_Entities database = new UnitConverterDB_Entities())
                {
                    Statistics new_record = new Statistics();

                    new_record.Date = DateTime.Now;
                    new_record.ValueFrom = double.Parse(TextBox_ValueFrom.Text);
                    new_record.UnitFrom = ComboBox_UnitFrom.SelectedItem.ToString();
                    new_record.ValueTo = double.Parse(Label_ValueTo.Content.ToString());
                    new_record.UnitTo = ComboBox_UnitTo.SelectedItem.ToString();

                    Listbox_Statistics.Items.Insert(0 ,new_record.Date.ToString() + "     z: " + new_record.ValueFrom.ToString() + new_record.UnitFrom.ToString() + "     na: " + new_record.ValueTo.ToString() + new_record.UnitTo.ToString());


                    database.Statistics.Add(new_record);
                    database.SaveChanges();
                }



            }
            else
            {
                TemperatureUnit ConvertedUnit = new TemperatureUnit();

                Label_ValueTo.Content = "Jestem upośledzony nie umiem w temperatury! :(";


                using (UnitConverterDB_Entities database = new UnitConverterDB_Entities())
                {
                    foreach (Units record_from in database.Units.Where(f => f.Name == ComboBox_UnitFrom.SelectedItem))
                    {
                        ConvertedUnit.Set_Values(double.Parse(TextBox_ValueFrom.Text), record_from.BaseValue.Value);
                    }

                    switch (ComboBox_UnitFrom.SelectedIndex)
                    {
                        case 0:
                            ConvertedUnit.CelToBase();
                            break;

                        case 1:
                            ConvertedUnit.FarToBase();
                            break;

                        case 2:
                            ConvertedUnit.KelToBase();
                            break;

                        case 3:
                            ConvertedUnit.RankToBase();
                            break;

                        default:
                            break;
                    }



                    
                    
                    foreach (Units record_to in database.Units.Where(f => f.Name == ComboBox_UnitTo.SelectedItem))
                    {  
                        ConvertedUnit.Set_ValueBase(record_to.BaseValue.Value);
                    }

                    switch (ComboBox_UnitTo.SelectedIndex)
                    {
                        case 0:
                            ConvertedUnit.BaselToCel();
                            break;

                        case 1:
                            ConvertedUnit.BaseToFar();
                            break;

                        case 2:
                            ConvertedUnit.BaseToKel();
                            break;

                        case 3:
                            ConvertedUnit.BaseToRank();
                            break;

                        default:
                            break;
                    }
                    
    
                    Label_ValueTo.Content = ConvertedUnit.Get_ValueEnd();
                }

                StatisticRecord newRecord = new StatisticRecord();

                newRecord.DateTime = DateTime.Now;
                newRecord.ValueFrom = double.Parse(TextBox_ValueFrom.Text);
                newRecord.UnitFrom = TextBox_ValueFrom.Text;
                newRecord.ValueTo = double.Parse(Label_ValueTo.Content.ToString());
                newRecord.UnitTo = ComboBox_UnitTo.SelectedItem.ToString();


                this.repository.AddStatistic(newRecord);
                this.statisticsDataGrid.ItemsSource = repository.GetStatistics();

                /*
                Listbox_Statistics.Items.Insert(0, newRecord.DateTime.ToString() + "     z: " + newRecord.ValueFrom.ToString() + newRecord.UnitFrom.ToString() + "     na: " + newRecord.ValueTo.ToString() + newRecord.UnitTo.ToString());
                */

            }
        }
    }
}
