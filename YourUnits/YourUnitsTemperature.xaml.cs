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
using System.Windows.Shapes;

namespace YourUnits
{
    /// <summary>
    /// Logika interakcji dla klasy YourUnitsTemperature.xaml
    /// </summary>
    public partial class YourUnitsTemperature : Window
    {
        public YourUnitsTemperature()
        {
            InitializeComponent();
        }
            double ShowCelcius;
            double TakeCelcius;
            double TakeFarenheit;
            double ShowFarenheit;
            double TakeKelvin;
            double ShowKelvin;
            double ShowRankine;
            double TakeRankine;

        private void YUTT1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TakeCelcius = Convert.ToDouble(YUTT1.Text);

                ShowFarenheit = 2 * (TakeCelcius - 0.1 * TakeCelcius) + 32;
                YUTT2.Text = ShowFarenheit.ToString();

                ShowKelvin = TakeCelcius + 273.15;
                YUTT3.Text = ShowKelvin.ToString();

                ShowRankine = ShowKelvin *1.8;
                YUTT4.Text = ShowRankine.ToString();
            }
        }

        private void YUTT2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TakeFarenheit = Convert.ToDouble(YUTT2.Text);

                ShowCelcius = ((TakeFarenheit-32)/2) * 1.1;
                YUTT1.Text = ShowCelcius.ToString();

                ShowKelvin = ShowCelcius + 273.15;
                YUTT3.Text = ShowKelvin.ToString();

                ShowRankine = ShowKelvin * 1.8;
                YUTT4.Text = ShowRankine.ToString();
            }
        }

        private void YUTT3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TakeKelvin = Convert.ToDouble(YUTT3.Text);

                ShowCelcius = TakeKelvin - 273.15;
                YUTT1.Text = ShowCelcius.ToString();

                ShowFarenheit = 2 * (ShowCelcius - 0.1 * ShowCelcius) + 32;
                YUTT2.Text = ShowFarenheit.ToString();

                ShowRankine = TakeKelvin * 1.8;
                YUTT4.Text = ShowRankine.ToString();
            }
        }

        private void YUTT4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter )
            {
                TakeRankine = Convert.ToDouble(YUTT4.Text);

                ShowKelvin = TakeRankine / 1.8;
                YUTT3.Text = ShowKelvin.ToString();

                ShowCelcius = ShowKelvin - 273.15;
                YUTT1.Text = ShowCelcius.ToString();

                ShowFarenheit = 2 * (ShowCelcius - 0.1 * ShowCelcius) + 32;
                YUTT2.Text = ShowFarenheit.ToString();

            }
        }
    }
}
