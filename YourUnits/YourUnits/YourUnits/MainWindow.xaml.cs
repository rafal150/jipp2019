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

namespace YourUnits
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void YUMB1_Click(object sender, RoutedEventArgs e)
        {
            YourUnitsTemperature TemperatureWindow  = new YourUnitsTemperature();
            TemperatureWindow.Show();
            this.Close();
        }

        private void YUMB2_Click(object sender, RoutedEventArgs e)
        {
            YourUnitsLength LengthWindow = new YourUnitsLength();
            LengthWindow.Show();
            this.Close();
        }

        private void YUMB3_Click(object sender, RoutedEventArgs e)
        {
            YourUnitsMass MassWindow = new YourUnitsMass();
            MassWindow.Show();
            this.Close();
        }

     

    }
}
