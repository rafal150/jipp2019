using JIPP5.SDK;
using JIPP5_LAB.Bazy;
using System;
using System.Windows;
using System.Windows.Controls;

namespace JIPP5_LAB
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

            this.catergoriesCombobox.ItemsSource = converters.GetConverters();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.catergoriesCombobox.SelectedItem != null)
            {
                decimal.TryParse(this.inputTextBox.Text, out decimal decimalowe);

                Converter converter = (Converter)this.catergoriesCombobox.SelectedItem;
                decimal result = converters.Convert(
                    this.unitsFromCombobox.SelectedItem.ToString(),
                    this.unitsToCombobox.SelectedItem.ToString(),
                    decimalowe.ToString(),
                    converter.Nazwa);

                this.outputTextBlock.Text = result.ToString();
            }
        }

        private void catergoriesCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.catergoriesCombobox.SelectedItem != null)
            {
                this.unitsFromCombobox.ItemsSource = ((Converter)this.catergoriesCombobox.SelectedItem).JakieJednostki;
                this.unitsToCombobox.ItemsSource = ((Converter)this.catergoriesCombobox.SelectedItem).JakieJednostki;
            }
        }
    }
}