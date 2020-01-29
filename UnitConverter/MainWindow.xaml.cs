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
using UnitConverter.Converters;
using UnitConverter.DataBase;
using UnitConverter.Statistics;
//nowy
namespace UnitConverter
{
    public partial class MainWindow : Window
    {
        public String mUnit { get; set; }
        public String fUnit { get; set; }
        public String tUnit { get; set; }

        private double sval = 1;
        private double rval = 0;

        private IStatisticsRepository repo = new AzureStorageRepository();
        public static Manager m;

        public MainWindow()
        {    

            InitializeComponent();
            m = new Manager();

            ComboOption.ItemsSource = m.GetConverter().getMainUnits();
           

            this.DataContext = this;
        }


        public static Manager GetManager()
        {
            return m;
        }


        private void ComboOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboOption.SelectedItem != null)
            {
                ComboFrom.ItemsSource = m.GetConverter().GetConverter(mUnit).Units;
                ComboTo.ItemsSource = m.GetConverter().GetConverter(mUnit).Units;
            }
        }




        private void TextBoxFrom_TextChanged(object sender, TextChangedEventArgs e)
        {
            double.TryParse(TextBoxFrom.Text, out sval);
        }

        private void przelicz()
        {
      
            rval = m.GetConverter().GetConverter(ComboOption.SelectedItem.ToString()).Convert(fUnit, tUnit, sval);
            TextboxResult.Text = rval.ToString();
            StatisticDTO s = new StatisticDTO()
            {
                startValue = sval,
                finalValue = rval,
                fromUnit = fUnit,
                toUnit = tUnit,
                type = mUnit,
                date = DateTime.Now
            };

            //zapis do tabeli
            m.GetRepository().AddStatistic(s);
        }

        private void ButtonConvert_Click(object sender, RoutedEventArgs e)
        {
            przelicz();
        }

        private void ButtonLogs_Click(object sender, RoutedEventArgs e)
        {
            Logs l = new Logs();
            l.Show();
        }

    }

   
}
