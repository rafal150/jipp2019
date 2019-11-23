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
    /// Logika interakcji dla klasy YourUnitsMass.xaml
    /// </summary>
    public partial class YourUnitsMass : Window
    {
        public YourUnitsMass()
        {
            InitializeComponent();
        }

        double TakeMiligram,    ShowMiligram;
        double TakeGram,        ShowGram;
        double TakeDecagram,    ShowDecagram;
        double TakeKilogram,    ShowKilogram;
        double TakeTonne,       ShowTonne;
        double TakeOunce,       ShowOunce;
        double TakePound,       ShowPound;
        double TakeCarat,       ShowCarat;
        double TakeQuintal,     ShowQuintal;

        private void YUMT2_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Bug - martwy kod //
        }

        

        private void YUMT1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TakeMiligram = Convert.ToDouble(YUMT1.Text);

                ShowGram = TakeMiligram / 1000;
                YUMT2.Text = ShowGram.ToString();

                ShowDecagram = TakeMiligram / 10000;
                YUMT3.Text = ShowDecagram.ToString();

                ShowKilogram = TakeMiligram / 1000000;
                YUMT4.Text = ShowKilogram.ToString();

                ShowTonne = TakeTonne / 1000000000;
                YUMT5.Text = ShowTonne.ToString();
            }
        }

        private void YUMT2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TakeGram = Convert.ToDouble(YUMT2.Text);

                ShowMiligram = TakeGram * 1000;
                YUMT1.Text = ShowMiligram.ToString();

                ShowDecagram = TakeGram / 10;
                YUMT3.Text = ShowDecagram.ToString();

                ShowKilogram = TakeGram / 1000;
                YUMT4.Text = ShowKilogram.ToString();

                ShowTonne = TakeGram / 1000000;
                YUMT5.Text = ShowTonne.ToString();
            }
        }

        private void YUMT3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TakeDecagram = Convert.ToDouble(YUMT3.Text);

                ShowMiligram = TakeDecagram * 10000;
                YUMT1.Text = ShowMiligram.ToString();

                ShowGram = TakeDecagram * 10;
                YUMT2.Text = ShowGram.ToString();

                ShowKilogram = TakeDecagram / 100;
                YUMT4.Text = ShowKilogram.ToString();

                ShowTonne = TakeDecagram / 100000;
                YUMT5.Text = ShowTonne.ToString();
            }
        }

        private void YUMT4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TakeKilogram = Convert.ToDouble(YUMT4.Text);

                ShowMiligram = TakeKilogram * 1000000;
                YUMT1.Text = ShowMiligram.ToString();

                ShowGram = TakeKilogram * 1000;
                YUMT2.Text = ShowGram.ToString();

                ShowDecagram = TakeKilogram * 100;
                YUMT3.Text = ShowDecagram.ToString();

                ShowTonne = TakeKilogram / 1000;
                YUMT5.Text = ShowTonne.ToString();
            }
        }

        private void YUMT5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TakeTonne = Convert.ToDouble(YUMT5.Text);

                ShowMiligram = TakeTonne * 1000000000;
                YUMT1.Text = ShowMiligram.ToString();

                ShowGram = TakeTonne * 1000000;
                YUMT2.Text = ShowGram.ToString();

                ShowDecagram = TakeTonne * 100000;
                YUMT3.Text = ShowDecagram.ToString();

                ShowKilogram = TakeTonne * 1000;
                YUMT4.Text = ShowKilogram.ToString();
            }
        }

        private void YUMT6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TakeOunce = Convert.ToDouble(YUMT6.Text);

                ShowPound = TakeOunce / 16;
                YUMT7.Text = ShowPound.ToString();

            }
        }

        private void YUMT7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TakePound = Convert.ToDouble(YUMT7.Text);

                ShowOunce = TakePound * 16;
                YUMT6.Text = ShowOunce.ToString();

            }
        }

        private void YUMT8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TakeCarat = Convert.ToDouble(YUMT8.Text);

                ShowGram = TakeCarat * 200;
                YUMT2.Text = ShowGram.ToString();

                ShowOunce = TakeCarat * 0.00705;
                YUMT6.Text = ShowOunce.ToString();

            }
        }

        private void YUMT9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TakeQuintal = Convert.ToDouble(YUMT9.Text);

                ShowKilogram = TakeQuintal * 100;
                YUMT4.Text = ShowKilogram.ToString();

                ShowPound = TakeQuintal * 100;
                YUMT7.Text = ShowPound.ToString();
            }
        }






















        private void YUMT6_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void YUMT7_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



    }
}
