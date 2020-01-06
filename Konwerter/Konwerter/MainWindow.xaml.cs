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
using Konwerter.Services;
using Converter.SDK;

namespace Konwerter
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ConvertersApi converters;
        public MainWindow(ConvertersApi converters)
        {
            InitializeComponent();

            this.converters = converters;

            this.convenrsionTypeCombo.ItemsSource = converters.GetConverters();

            dbGrid.ItemsSource = converters.GetStatistics();
        }

        private void ConvenrsionTypeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.convenrsionTypeCombo.SelectedItem != null)
            {
                this.fromCombo.ItemsSource = ((Converter)this.convenrsionTypeCombo.SelectedItem).Units;
                this.toCombo.ItemsSource = ((Converter)this.convenrsionTypeCombo.SelectedItem).Units;
            }
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Converter converter = (Converter)this.convenrsionTypeCombo.SelectedItem;
                double result = converters.Convert(fromCombo.SelectedItem.ToString(), toCombo.SelectedItem.ToString(), this.valueToConvert.Text, converter.Name);

                this.convertedValue.Text = result.ToString();
            }
            catch
            {
                this.convertedValue.Text = "Invalid input value";
            }

            dbGrid.ItemsSource = converters.GetStatistics();
        }
    }
}
