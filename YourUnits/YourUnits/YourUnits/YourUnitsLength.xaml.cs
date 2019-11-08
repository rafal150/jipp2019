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
    /// Logika interakcji dla klasy YourUnitsLength.xaml
    /// </summary>
    public partial class YourUnitsLength : Window
    {
        public YourUnitsLength()
        {
            InitializeComponent();
        }

        double TakeMilimetre;
        double ShowMilimetre;
        double TakeCentimetre;
        double ShowCentimetre;
        double TakeDecimetre;
        double ShowDecimetre;
        double TakeMetre;
        double ShowMetre;
        double TakeKilometre;
        double ShowKilometre;

        double TakeInch;
        double ShowInch;
        double TakeFoot;
        double ShowFoot;
        double TakeYard;
        double ShowYard;
        double TakeMile;
        double ShowMile;

        double TakeCable;
        double ShowCable;
        double TakeMarinemile;
        double ShowMarinemile;


        private void YULT1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TakeMilimetre = Convert.ToDouble(YULT1.Text);

                ShowCentimetre = TakeMilimetre / 10;
                YULT2.Text = ShowCentimetre.ToString();

                ShowDecimetre = TakeMilimetre / 100;
                YULT3.Text = ShowDecimetre.ToString();

                ShowMetre = TakeMilimetre / 1000;
                YULT4.Text = ShowMetre.ToString();

                ShowKilometre = TakeMilimetre / 1000000;
                YULT5.Text = ShowKilometre.ToString();
            }
        }

        private void YULT1_TextChanged(object sender, TextChangedEventArgs e)
        {
            // BUG do naprawy //
        }

        private void YULT2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TakeCentimetre = Convert.ToDouble(YULT2.Text);

                ShowMilimetre = TakeCentimetre * 10;
                YULT1.Text = ShowMilimetre.ToString();

                ShowDecimetre = TakeCentimetre / 10;
                YULT3.Text = ShowDecimetre.ToString();

                ShowMetre = TakeCentimetre / 100;
                YULT4.Text = ShowMetre.ToString();

                ShowKilometre = TakeCentimetre / 100000;
                YULT5.Text = ShowKilometre.ToString();
            }
        }

        private void YULT3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TakeDecimetre = Convert.ToDouble(YULT3.Text);

                ShowMilimetre = TakeDecimetre * 100;
                YULT1.Text = ShowMilimetre.ToString();

                ShowCentimetre = TakeDecimetre * 10;
                YULT2.Text = ShowCentimetre.ToString();

                ShowMetre = TakeDecimetre / 10;
                YULT4.Text = ShowMetre.ToString();

                ShowKilometre = TakeDecimetre / 10000;
                YULT5.Text = ShowKilometre.ToString();
            }
        }

        private void YULT4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TakeMetre = Convert.ToDouble(YULT4.Text);

                ShowMilimetre = TakeMetre * 1000;
                YULT1.Text = ShowMilimetre.ToString();

                ShowCentimetre = TakeMetre * 100;
                YULT2.Text = ShowCentimetre.ToString();

                ShowDecimetre = TakeMetre * 10;
                YULT3.Text = ShowDecimetre.ToString();

                ShowKilometre = TakeMetre / 1000;
                YULT5.Text = ShowKilometre.ToString();
            }
        }

        private void YULT5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TakeKilometre = Convert.ToDouble(YULT5.Text);

                ShowMilimetre = TakeKilometre * 1000000;
                YULT1.Text = ShowMilimetre.ToString();

                ShowCentimetre = TakeKilometre * 100000;
                YULT2.Text = ShowCentimetre.ToString();

                ShowDecimetre = TakeKilometre * 10000;
                YULT3.Text = ShowDecimetre.ToString();

                ShowMetre = TakeKilometre * 1000;
                YULT4.Text = ShowMetre.ToString();
            }
        }




        private void YULT6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TakeInch = Convert.ToDouble(YULT6.Text);

                ShowFoot = TakeInch / 12;
                YULT7.Text = ShowFoot.ToString();

                ShowYard = TakeInch / 36;
                YULT8.Text = ShowYard.ToString();

                ShowMile = (TakeInch / 5280) / 12;
                YULT9.Text = ShowMile.ToString();
            }
        }

        private void YULT7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TakeFoot = Convert.ToDouble(YULT7.Text);

                ShowInch = TakeFoot * 12;
                YULT6.Text = ShowInch.ToString();

                ShowYard = TakeFoot / 3;
                YULT8.Text = ShowYard.ToString();

                ShowMile = TakeFoot / 5280;
                YULT9.Text = ShowMile.ToString();
            }
        }

        private void YULT8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TakeYard = Convert.ToDouble(YULT8.Text);

                ShowInch = TakeYard * 36;
                YULT6.Text = ShowInch.ToString();

                ShowFoot = TakeYard * 3 ;
                YULT7.Text = ShowFoot.ToString();

                ShowMile = TakeYard / 1760;
                YULT9.Text = ShowMile.ToString();
            }
        }

        private void YULT9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TakeMile = Convert.ToDouble(YULT9.Text);

                ShowInch = (TakeMile * 5280) * 12;
                YULT6.Text = ShowInch.ToString();

                ShowFoot = TakeMile * 5280;
                YULT7.Text = ShowFoot.ToString();

                ShowYard = TakeMile * 1760;
                YULT8.Text = ShowYard.ToString();
            }
        }

        private void YULT10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TakeCable = Convert.ToDouble(YULT10.Text);

                ShowMarinemile = TakeCable / 10;
                YULT11.Text = ShowMarinemile.ToString();
            }
        }

        private void YULT11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TakeMarinemile = Convert.ToDouble(YULT11.Text);

                ShowMarinemile = TakeMarinemile * 10;
                YULT10.Text = ShowMarinemile.ToString();
            }
        }

    }
}
