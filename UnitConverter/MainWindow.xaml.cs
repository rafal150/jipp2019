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
using UnitConverter.Statistics;
using UnitConverter.DataBase;


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

            MainUnit.ItemsSource = m.GetConverter().getMainUnits();
           

            this.DataContext = this;
        }


        public static Manager GetManager()
        {
            return m;
        }


        private void MainUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           if(MainUnit.SelectedItem != null)
            {
                FromUnit.ItemsSource = m.GetConverter().GetConverter(mUnit).Units;
                ToUnit.ItemsSource = m.GetConverter().GetConverter(mUnit).Units;
            }
        }

       


        private void FromUnitValue_TextChanged(object sender, TextChangedEventArgs e)
        {

            double.TryParse(FromValue.Text, out sval);
            
        }

        private void update()
        {
      
            rval = m.GetConverter().GetConverter(MainUnit.SelectedItem.ToString()).Convert(fUnit, tUnit, sval);
            Result.Content = rval;
            StatisticDTO s = new StatisticDTO()
            {
                startValue = sval,
                finalValue = rval,
                fromUnit = fUnit,
                toUnit = tUnit,
                type = mUnit,
                date = DateTime.Now
            };

            //zapis

            m.GetRepository().AddStatistic(s);
        }

        private void Btt_Click(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show(m.GetConverter().RegisterPlugins());
            update();
        }

        private void Log_btt_Click(object sender, RoutedEventArgs e)
        {
            Logs l = new Logs();
            l.Show();
        }
    }

   
}
